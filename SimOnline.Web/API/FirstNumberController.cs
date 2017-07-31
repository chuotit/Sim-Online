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
using SimOnline.Web.Models;

namespace SimOnline.Web.API
{
    [RoutePrefix("api/firstnumber")]
    public class FirstNumberController : ApiControllerBase
    {
        private IFirstNumberService _firstNumberService;

        public FirstNumberController(IErrorService errorService, IFirstNumberService firstNumberService)
            : base(errorService)
        {
            this._firstNumberService = firstNumberService;
        }

        [Route("getall")]
        public HttpResponseMessage GetAll(HttpRequestMessage request)
        {
            return CreateHttpResponse(request, () =>
            {
                int totalRow = 0;
                var model = _firstNumberService.GetAll();

                totalRow = model.Count();
                var query = model.OrderByDescending(x => x.DisplayOrder);

                var responseData = Mapper.Map<IEnumerable<FirstNumber>, IEnumerable<FirstNumberViewModel>>(query.AsEnumerable());

                var paginationSet = new PaginationSet<FirstNumberViewModel>()
                {
                    Items = responseData,
                    TotalCount = totalRow
                };
                var response = request.CreateResponse(HttpStatusCode.OK, paginationSet);
                return response;
            });
        }

        [Route("getfirstnumberbynetwork/{id:int}")]
        [HttpGet]
        public HttpResponseMessage GetFirstNumberByNetwork(HttpRequestMessage request, int id)
        {
            return CreateHttpResponse(request, () =>
            {
                int totalRow = 0;
                var model = _firstNumberService.GetByNetwork(id);

                totalRow = model.Count();
                var query = model.OrderByDescending(x => x.DisplayOrder);

                var responseData = Mapper.Map<IEnumerable<FirstNumber>, IEnumerable<FirstNumberViewModel>>(query.AsEnumerable());

                var paginationSet = new PaginationSet<FirstNumberViewModel>()
                {
                    Items = responseData,
                    TotalCount = totalRow
                };
                var response = request.CreateResponse(HttpStatusCode.OK, paginationSet);
                return response;
            });
        }
    }
}
