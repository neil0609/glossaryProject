using GlossaryProject.Domain;
using GlossaryProject.Models.Requests.AddRequest;
using GlossaryProject.Models.Requests.UpdateRequest;
using GlossaryProject.Models.Responses;
using GlossaryProject.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;

namespace GlossaryProject.Controllers.ApiControllers
{
    [AllowAnonymous]
    [RoutePrefix("api/glossary")]
    public class GlossaryApiController : ApiController
    {
        [Route, HttpPost]
        public HttpResponseMessage Add(AddGlossaryItem model)
        {
            if (!ModelState.IsValid)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }

            try
            {
                ItemResponse<int> response = new ItemResponse<int>();
                response.Item = GlossaryService.InsertGlossaryItem(model);
                return Request.CreateResponse(response);
            }
            catch (Exception ex)
            {
                ErrorResponse er = new ErrorResponse(ex.Message);
                return Request.CreateResponse(HttpStatusCode.BadRequest, er);
            }
        }

        [Route("{id:int}"), HttpPut]
        public HttpResponseMessage Update(UpdateGlossaryItem model, int id)
        {
            if (!ModelState.IsValid)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }

            try
            {
                SuccessResponse response = new SuccessResponse();
                GlossaryService.UpdateglossaryItem(model);
                return Request.CreateResponse(response);
            }
            catch (Exception ex)
            {
                ErrorResponse er = new ErrorResponse(ex.Message);
                return Request.CreateResponse(HttpStatusCode.BadRequest, er);
            }
        }

        [Route("{id:int}"), HttpGet]
        public HttpResponseMessage GetGlossaryItem(int id)
        {
            try
            {
                ItemResponse<GlossaryItem> response = new ItemResponse<GlossaryItem>();
                response.Item = GlossaryService.GetGlossaryItem(id);
                return Request.CreateResponse(response);
            }
            catch (Exception ex)
            {
                ErrorResponse er = new ErrorResponse(ex.Message);
                return Request.CreateResponse(HttpStatusCode.BadRequest, er);
            }
        }

        [Route, HttpGet]
        public HttpResponseMessage GetGlossaryList()
        {
            try
            {
                ItemsResponse<GlossaryItem> response = new ItemsResponse<GlossaryItem>();
                response.Items = GlossaryService.GetGlossaryItemList();
                return Request.CreateResponse(response);
            }
            catch (Exception ex)
            {
                ErrorResponse er = new ErrorResponse(ex.Message);
                return Request.CreateResponse(HttpStatusCode.BadRequest, er);
            }
        }

        [Route("{id:int}"), HttpDelete]
        public HttpResponseMessage Delete(int id)
        {
            try
            {
                SuccessResponse response = new SuccessResponse();
                GlossaryService.DeleteGlossaryItem(id);
                return Request.CreateResponse(response);
            }
            catch (Exception ex)
            {
                ErrorResponse er = new ErrorResponse(ex.Message);
                return Request.CreateResponse(HttpStatusCode.BadRequest, er);
            }
        }


    }
}