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
    [RoutePrefix("api/consigner")]
    public class ConsignerController : ApiControllerBase
    {
        private IConsignerService _consignerService;

        public ConsignerController(IErrorService errorService, IConsignerService consignerService)
            : base(errorService)
        {
            this._consignerService = consignerService;
        }

        [Route("getall")]
        public HttpResponseMessage GetAll(HttpRequestMessage request)
        {
            return CreateHttpResponse(request, () =>
            {
                var model = _consignerService.GetAll();

                var responseData = Mapper.Map<IEnumerable<Consigner>, IEnumerable<ConsignerViewModel>>(model);
                var response = request.CreateResponse(HttpStatusCode.OK, responseData);

                return response;
            });
        }

        //[Route("getall")]
        //public HttpResponseMessage GetAll(HttpRequestMessage request, string keyword, int page, int pageSize = 20)
        //{
        //    return CreateHttpResponse(request, () =>
        //    {
        //        int totalRow = 0;
        //        var model = _consignerService.GetAll(keyword);

        //        totalRow = model.Count();
        //        var query = model.OrderByDescending(x => x.ID).Skip(page * pageSize).Take(pageSize);

        //        var responseData = Mapper.Map<IEnumerable<Consigner>, IEnumerable<ConsignerViewModel>>(query);

        //        var paginationSet = new PaginationSet<ConsignerViewModel>()
        //        {
        //            Items = responseData,
        //            Page = page,
        //            TotalCount = totalRow,
        //            TotalPages = (int)Math.Ceiling((decimal)totalRow / pageSize)
        //        };
        //        var response = request.CreateResponse(HttpStatusCode.OK, paginationSet);
        //        return response;
        //    });
        //}

        [Route("getbyid/{id:int}")]
        [HttpGet]
        public HttpResponseMessage GetById(HttpRequestMessage request, int id)
        {
            return CreateHttpResponse(request, () =>
            {
                var model = _consignerService.GetById(id);

                var responseData = Mapper.Map<Consigner, ConsignerViewModel>(model);

                var response = request.CreateResponse(HttpStatusCode.OK, responseData);

                return response;
            });
        }

        [Route("create")]
        public HttpResponseMessage Post(HttpRequestMessage request, ConsignerViewModel consignerVm)
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
                    Consigner newConsigner = new Consigner();
                    newConsigner.UpdateConsigner(consignerVm);
                    var consignerReturn = _consignerService.Add(newConsigner);
                    _consignerService.SaveChanges();
                    response = request.CreateResponse(HttpStatusCode.Created, consignerReturn);
                }
                return response;
            });
        }

        [Route("update")]
        public HttpResponseMessage Put(HttpRequestMessage request, ConsignerViewModel consignerVm)
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
                    var postConsignerDb = _consignerService.GetById(consignerVm.ID);
                    postConsignerDb.UpdateConsigner(consignerVm);
                    _consignerService.Update(postConsignerDb);
                    _consignerService.SaveChanges();

                    var responseData = Mapper.Map<Consigner, ConsignerViewModel>(postConsignerDb);
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
                    _consignerService.Delete(id);
                    _consignerService.SaveChanges();
                    response = request.CreateResponse(HttpStatusCode.OK);
                }
                return response;
            });
        }
    }
}
