using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using AutoMapper;
using SimOnline.Common;
using SimOnline.Model.Models;
using SimOnline.Service;
using SimOnline.Web.Infrastructure.Core;
using SimOnline.Web.Infrastructure.Extensions;
using SimOnline.Web.Models;

namespace SimOnline.Web.API
{
    [RoutePrefix("api/simStore")]
    [Authorize]
    public class SimStoreController : ApiControllerBase
    {
        private ISimStoreService _simStoreService;

        public SimStoreController(IErrorService errorService, ISimStoreService simStoreService)
            : base(errorService)
        {
            this._simStoreService = simStoreService;
        }

        [Route("getall")]
        public HttpResponseMessage GetAll(HttpRequestMessage request)
        {
            return CreateHttpResponse(request, () =>
            {
                var model = _simStoreService.GetAll();
                var responseData = Mapper.Map<IEnumerable<SimStore>, IEnumerable<SimStoreViewModel>>(model);
                var response = request.CreateResponse(HttpStatusCode.OK, responseData);
                return response;
            });
        }

        [Route("search")]
        [HttpGet]
        public HttpResponseMessage Search(HttpRequestMessage request, string keyword, int? agentId = null, int? networkId = null, decimal? minPrice = null, decimal? maxPrice = null, int page = 0, int pageSize = 20)
        {
            var parameSearch = PrecateBuilder.True<SimStore>();

            if (keyword != null && keyword.IndexOf("*") < 0)
            {
                parameSearch = parameSearch.And(x => x.SimID.Contains(keyword));
            }
            if (keyword != null && keyword.IndexOf("*") >= 0)
            {
                string firstNumber = keyword.Split('*')[0];
                string endNumber = keyword.Split('*')[1];
                parameSearch = parameSearch.And(x => x.SimID.StartsWith(firstNumber));
                parameSearch = parameSearch.And(x => x.SimID.EndsWith(endNumber));
            }
            if (networkId.HasValue)
            {
                parameSearch = parameSearch.And(x => x.NetWorkID == networkId);
            }
            if (agentId.HasValue)
            {
                parameSearch = parameSearch.And(x => x.AgentID == agentId.ToString());
            }
            if (minPrice.HasValue)
            {
                parameSearch = parameSearch.And(x => x.Price >= minPrice);
            }
            if (maxPrice.HasValue)
            {
                parameSearch = parameSearch.And(x => x.Price <= maxPrice);
            }

            return CreateHttpResponse(request, () =>
            {
                int totalRow = 0;

                var model = parameSearch != null ? _simStoreService.SearchSim(parameSearch) : _simStoreService.GetAll();

                totalRow = model.Count();
                var query = model.OrderByDescending(x => x.Price).Skip((page - 1) * pageSize).Take(pageSize);

                var responseData = Mapper.Map<IEnumerable<SimStore>, IEnumerable<SimStoreViewModel>>(query);

                var paginationSet = new PaginationSet<SimStoreViewModel>()
                {
                    Items = responseData,
                    Page = page,
                    TotalCount = totalRow,
                    TotalPages = (int)Math.Ceiling((decimal)totalRow / pageSize)
                };
                var response = request.CreateResponse(HttpStatusCode.OK, paginationSet);
                return response;
            });
        }

        [Route("checksim")]
        [HttpGet]
        public HttpResponseMessage CheckSim(HttpRequestMessage request, string simStore, string price, string agentId)
        {
            return CreateHttpResponse(request, () =>
            {
                int result = _simStoreService.SearchSim(simStore, price, agentId);
                var response = request.CreateResponse(HttpStatusCode.OK, result);
                return response;
            });
        }

        //[Route("getbynumber/{string:number}")]
        //[HttpGet]
        //public HttpResponseMessage GetById(HttpRequestMessage request, int id)
        //{
        //    return CreateHttpResponse(request, () =>
        //    {
        //        var model = _simStoreService.GetById(id);

        //        var responseData = Mapper.Map<SimStore, SimStoreViewModel>(model);

        //        var response = request.CreateResponse(HttpStatusCode.OK, responseData);

        //        return response;
        //    });
        //}

        [Route("create")]
        public HttpResponseMessage Post(HttpRequestMessage request, SimStoreViewModel simStoreVm)
        {
            return CreateHttpResponse(request, () =>
            {
                HttpResponseMessage response = null;
                if (!ModelState.IsValid)
                {
                    request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
                }
                else
                {
                    SimStore newSimStore = new SimStore();
                    newSimStore.UpdateSimStore(simStoreVm);
                    var simStoreReturn = _simStoreService.Add(newSimStore);
                    _simStoreService.SaveChanges();
                    response = request.CreateResponse(HttpStatusCode.Created, simStoreReturn);
                }
                return response;
            });
        }

        [Route("up-sim-store")]
        public HttpResponseMessage PostMultipe(HttpRequestMessage request, List<SimStoreAddViewModel> listSimAddNewVm)
        {
            return CreateHttpResponse(request, () =>
            {
                HttpResponseMessage response = null;
                if (!ModelState.IsValid)
                {
                    request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
                }
                else
                {
                    List<SimStoreAddViewModel> listErrorSim = new List<SimStoreAddViewModel>();
                    SimStore newSimStore;
                    SimStoreViewModel simStoreViewModel;

                    if (listSimAddNewVm.Count > 0)
                    {
                        foreach (SimStoreAddViewModel simItem in listSimAddNewVm)
                        {
                            string simName = simItem.SimName.Trim().Replace(",", ".").Replace("-", ".").Replace(" ", ".").Replace("...", ".").Replace("..", ".");
                            string simID = simName.Replace(".", "");
                            string price = simItem.Price.ToString().Trim().Replace("k", "000").Replace("K", "000").Replace(",", "").Replace("-", "").Replace(" ", "").Replace(".", "");
                            if (CheckSimValid(simID, price) == null) {
                                newSimStore = new SimStore();
                                simStoreViewModel = new SimStoreViewModel();

                                simStoreViewModel.SimName = simName;
                                simStoreViewModel.SimID = simID;
                                simStoreViewModel.NetWorkID = 2;
                                simStoreViewModel.AgentID = "1";
                                simStoreViewModel.CreateDate = DateTime.Now;
                                simStoreViewModel.Price = Decimal.Parse(price);
                                simStoreViewModel.Discount = 15;
                                simStoreViewModel.Status = true;

                                newSimStore.UpdateSimStore(simStoreViewModel);
                                _simStoreService.Add(newSimStore);
                            }
                            else
                            {
                                listErrorSim.Add(simItem);
                            }
                        }
                        _simStoreService.SaveChanges();
                    }

                    response = request.CreateResponse(HttpStatusCode.Created, listErrorSim);
                }
                return response;
            });
        }

        private List<SimStore> GetSimStoreFromJson(List<SimStoreAddViewModel> listSimAddNewVm)
        {
            List<SimStore> listNewSim = new List<SimStore>();
            SimStore newSimStore;
            SimStoreViewModel simStoreViewModel;
            foreach (SimStoreAddViewModel simItem in listSimAddNewVm)
            {
                newSimStore = new SimStore();
                simStoreViewModel = new SimStoreViewModel();

                simStoreViewModel.SimName = simItem.SimName.Replace("-", ".").Replace(" ", "");
                simStoreViewModel.SimID = simStoreViewModel.SimName.Replace(".", "");
                simStoreViewModel.NetWorkID = 2;
                simStoreViewModel.AgentID = "1";
                simStoreViewModel.CreateDate = DateTime.Now;
                simStoreViewModel.Price = Decimal.Parse(simItem.Price.ToString().Replace(",", "").Replace("-", "").Replace(" ", ""));
                simStoreViewModel.Discount = 15;
                simStoreViewModel.Status = true;

                newSimStore.UpdateSimStore(simStoreViewModel);
                listNewSim.Add(newSimStore);
            }
            return listNewSim;
        }

        private string CheckSimValid(string strSim, string strPrice) {
            decimal myDec;
            string errorMessage = null;
            if (!decimal.TryParse(strSim, out myDec) || (!(strSim.StartsWith("01") && strSim.Length == 11) && !(strSim.StartsWith("09") && strSim.Length == 10)))
            {
                errorMessage = "Số sim nhập vào không hợp lệ.";
            }
            if (!decimal.TryParse(strPrice, out myDec) || strPrice.StartsWith("0") || strPrice.Length < 5)
            {
                errorMessage = "Giá sim nhập vào không hợp lệ.";
            }
            //if(1==1)
            //{
            //    errorMessage = "Số sim đã tồn tại.";
            //}
            return errorMessage;
        }

        
        //[Route("update")]
        //public HttpResponseMessage Put(HttpRequestMessage request, SimStoreViewModel simStoreVm)
        //{
        //    return CreateHttpResponse(request, () =>
        //    {
        //        HttpResponseMessage response = null;
        //        if (!ModelState.IsValid)
        //        {
        //            request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
        //        }
        //        else
        //        {
        //            var postSimStoreDb = _simStoreService.GetById(simStoreVm.SimID);
        //            postSimStoreDb.UpdateSimStore(simStoreVm);
        //            _simStoreService.Update(postSimStoreDb);
        //            _simStoreService.SaveChanges();

        //            var responseData = Mapper.Map<SimStore, SimStoreViewModel>(postSimStoreDb);
        //            response = request.CreateResponse(HttpStatusCode.Created, responseData);
        //        }
        //        return response;
        //    });
        //}

        //[Route("delete")]
        //public HttpResponseMessage Delete(HttpRequestMessage request, int id)
        //{
        //    return CreateHttpResponse(request, () =>
        //    {
        //        HttpResponseMessage response = null;
        //        if (ModelState.IsValid)
        //        {
        //            request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
        //        }
        //        else
        //        {
        //            _simStoreService.Delete(id);
        //            _simStoreService.SaveChanges();
        //            response = request.CreateResponse(HttpStatusCode.OK);
        //        }
        //        return response;
        //    });
        //}
    }
}