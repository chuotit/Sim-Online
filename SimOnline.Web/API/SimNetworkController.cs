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
    [RoutePrefix("api/simnetwork")]
    public class SimNetworkController : ApiControllerBase
    {
        private ISimNetworkService _simNetworkService;

        public SimNetworkController(IErrorService errorService, ISimNetworkService simNetworkService)
            : base(errorService)
        {
            this._simNetworkService = simNetworkService;
        }

        [Route("getall")]
        [AllowAnonymous]
        public HttpResponseMessage GetAll(HttpRequestMessage request)
        {
            return CreateHttpResponse(request, () =>
            {
                var model = _simNetworkService.GetAll();
                
                var responseData = Mapper.Map<IEnumerable<SimNetwork>, IEnumerable<SimNetworkViewModel>>(model);
                var response = request.CreateResponse(HttpStatusCode.OK, responseData);

                return response;
            });
        }

        [Route("getbyid/{id:int}")]
        [HttpGet]
        public HttpResponseMessage GetById(HttpRequestMessage request, int id)
        {
            return CreateHttpResponse(request, () =>
            {
                var model = _simNetworkService.GetById(id);

                var responseData = Mapper.Map<SimNetwork, SimNetworkViewModel>(model);

                var response = request.CreateResponse(HttpStatusCode.OK, responseData);

                return response;
            });
        }

        [Route("create")]
        public HttpResponseMessage Post(HttpRequestMessage request, SimNetworkViewModel simNetworkVm)
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
                    SimNetwork newSimNetwork = new SimNetwork();
                    newSimNetwork.UpdateSimNetwork(simNetworkVm);
                    var simNetworkReturn = _simNetworkService.Add(newSimNetwork);
                    _simNetworkService.SaveChanges();
                    response = request.CreateResponse(HttpStatusCode.Created, simNetworkReturn);
                }
                return response;
            });
        }

        [Route("update")]
        public HttpResponseMessage Put(HttpRequestMessage request, SimNetworkViewModel simNetworkVm)
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
                    var postSimNetworkDb = _simNetworkService.GetById(simNetworkVm.ID);
                    postSimNetworkDb.UpdateSimNetwork(simNetworkVm);
                    _simNetworkService.Update(postSimNetworkDb);
                    _simNetworkService.SaveChanges();

                    var responseData = Mapper.Map<SimNetwork, SimNetworkViewModel>(postSimNetworkDb);
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
                    _simNetworkService.Delete(id);
                    _simNetworkService.SaveChanges();
                    response = request.CreateResponse(HttpStatusCode.OK);
                }
                return response;
            });
        }
    }
}