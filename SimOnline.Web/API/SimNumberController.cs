using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using AutoMapper;
using SimOnline.Model.Models;
using SimOnline.Service;
using SimOnline.Web.Infrastructure.Core;
using SimOnline.Web.Infrastructure.Extensions;
using SimOnline.Web.Models;

namespace SimOnline.Web.API
{
    [RoutePrefix("api/simnumber")]
    public class SimNumberController : ApiControllerBase
    {
        private ISimNumberService _simNumberService;

        public SimNumberController(IErrorService errorService, ISimNumberService simNumberService)
            : base(errorService)
        {
            this._simNumberService = simNumberService;
        }

        [Route("getall")]
        public HttpResponseMessage GetAll(HttpRequestMessage request)
        {
            return CreateHttpResponse(request, () =>
            {
                var model = _simNumberService.GetAll();
                var responseData = Mapper.Map<IEnumerable<SimNumber>, IEnumerable<SimNumberViewModel>>(model);
                var response = request.CreateResponse(HttpStatusCode.OK, responseData);
                return response;
            });
        }

        [Route("search")]
        [HttpGet]
        public HttpResponseMessage Search(HttpRequestMessage request, string keyword, int consignerId, int networkId, decimal minPrice, decimal maxPrice, int page, int pageSize = 20)
        {
            return CreateHttpResponse(request, () =>
            {
                int totalRow = 0;
                var model = _simNumberService.Search(keyword, consignerId, networkId, minPrice, maxPrice);

                totalRow = model.Count();
                var query = model.OrderByDescending(x => x.Price).Skip((page - 1) * pageSize).Take(pageSize);

                var responseData = Mapper.Map<IEnumerable<SimNumber>, IEnumerable<SimNumberViewModel>>(query);

                var paginationSet = new PaginationSet<SimNumberViewModel>()
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

        //[Route("getbynumber/{string:number}")]
        //[HttpGet]
        //public HttpResponseMessage GetById(HttpRequestMessage request, int id)
        //{
        //    return CreateHttpResponse(request, () =>
        //    {
        //        var model = _simNumberService.GetById(id);

        //        var responseData = Mapper.Map<SimNumber, SimNumberViewModel>(model);

        //        var response = request.CreateResponse(HttpStatusCode.OK, responseData);

        //        return response;
        //    });
        //}

        [Route("create")]
        public HttpResponseMessage Post(HttpRequestMessage request, SimNumberViewModel simNumberVm)
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
                    SimNumber newSimNumber = new SimNumber();
                    newSimNumber.UpdateSimNumber(simNumberVm);
                    var simNumberReturn = _simNumberService.Add(newSimNumber);
                    _simNumberService.SaveChanges();
                    response = request.CreateResponse(HttpStatusCode.Created, simNumberReturn);
                }
                return response;
            });
        }

        //[Route("update")]
        //public HttpResponseMessage Put(HttpRequestMessage request, SimNumberViewModel simNumberVm)
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
        //            var postSimNumberDb = _simNumberService.GetById(simNumberVm.SimID);
        //            postSimNumberDb.UpdateSimNumber(simNumberVm);
        //            _simNumberService.Update(postSimNumberDb);
        //            _simNumberService.SaveChanges();

        //            var responseData = Mapper.Map<SimNumber, SimNumberViewModel>(postSimNumberDb);
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
        //            _simNumberService.Delete(id);
        //            _simNumberService.SaveChanges();
        //            response = request.CreateResponse(HttpStatusCode.OK);
        //        }
        //        return response;
        //    });
        //}
    }
}