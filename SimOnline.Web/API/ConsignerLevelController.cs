using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using AutoMapper;
using SimOnline.Model.Models;
using SimOnline.Service;
using SimOnline.Web.Infrastructure.Core;
using SimOnline.Web.Infrastructure.Extensions;
using SimOnline.Web.Models;

namespace SimOnline.Web.API
{
    [RoutePrefix("api/consignerLevel")]
    public class ConsignerLevelController : ApiControllerBase
    {
        private IConsignerLevelService _consignerLevelService;

        public ConsignerLevelController(IErrorService errorService, IConsignerLevelService consignerLevelService)
            : base(errorService)
        {
            this._consignerLevelService = consignerLevelService;
        }

        [Route("getall")]
        public HttpResponseMessage GetAll(HttpRequestMessage request, int page, int pageSize = 20)
        {
            return CreateHttpResponse(request, () =>
            {
                int totalRow = 0;
                var model = _consignerLevelService.GetAll();

                totalRow = model.Count();
                var query = model.OrderByDescending(x => x.ID).Skip(page * pageSize).Take(pageSize);

                var responseData = Mapper.Map<IEnumerable<ConsignerLevel>, IEnumerable<ConsignerLevelViewModel>>(query);

                var paginationSet = new PaginationSet<ConsignerLevelViewModel>()
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

        [Route("getbyid/{id:int}")]
        [HttpGet]
        public HttpResponseMessage GetById(HttpRequestMessage request, int id)
        {
            return CreateHttpResponse(request, () =>
            {
                var model = _consignerLevelService.GetById(id);

                var responseData = Mapper.Map<ConsignerLevel, ConsignerLevelViewModel>(model);

                var response = request.CreateResponse(HttpStatusCode.OK, responseData);

                return response;
            });
        }

        [Route("create")]
        public HttpResponseMessage Post(HttpRequestMessage request, ConsignerLevelViewModel consignerLevelVm)
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
                    ConsignerLevel newConsignerLevel = new ConsignerLevel();
                    newConsignerLevel.UpdateConsignerLevel(consignerLevelVm);
                    var consignerLevelReturn = _consignerLevelService.Add(newConsignerLevel);
                    _consignerLevelService.SaveChanges();
                    response = request.CreateResponse(HttpStatusCode.Created, consignerLevelReturn);
                }
                return response;
            });
        }

        [Route("update")]
        public HttpResponseMessage Put(HttpRequestMessage request, ConsignerLevelViewModel consignerLevelVm)
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
                    var postConsignerLevelDb = _consignerLevelService.GetById(consignerLevelVm.ID);
                    postConsignerLevelDb.UpdateConsignerLevel(consignerLevelVm);
                    _consignerLevelService.Update(postConsignerLevelDb);
                    _consignerLevelService.SaveChanges();

                    var responseData = Mapper.Map<ConsignerLevel, ConsignerLevelViewModel>(postConsignerLevelDb);
                    response = request.CreateResponse(HttpStatusCode.Created, responseData);
                }
                return response;
            });
        }

        [Route("delete")]
        public HttpResponseMessage Delete(HttpRequestMessage request, int id)
        {
            return CreateHttpResponse(request, () =>
            {
                HttpResponseMessage response = null;
                if (ModelState.IsValid)
                {
                    request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
                }
                else
                {
                    _consignerLevelService.Delete(id);
                    _consignerLevelService.SaveChanges();
                    response = request.CreateResponse(HttpStatusCode.OK);
                }
                return response;
            });
        }
    }
}
