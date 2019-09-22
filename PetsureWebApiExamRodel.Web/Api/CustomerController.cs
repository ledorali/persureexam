using PetsureWebApiExamRodel.Data.Models;
using PetsureWebApiExamRodel.Data.Services;
using PetsureWebApiExamRodel.Web.Filters;
using PetsureWebApiExamRodel.Web.Logger;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Mvc;
using HttpGetAttribute = System.Web.Http.HttpGetAttribute;
using HttpPostAttribute = System.Web.Http.HttpPostAttribute;
using HttpPutAttribute = System.Web.Http.HttpPutAttribute;
using RouteAttribute = System.Web.Mvc.RouteAttribute;

namespace PetsureWebApiExamRodel.Web.Api
{
    [Authentication]
    public class CustomerController : ApiController
    {
        private readonly IServices db;

        public CustomerController(IServices db)
        {
            this.db = db;
        }

        [HttpGet]
        [Route("GetCustomerList")]
        public async Task<IHttpActionResult> Get()
        {
            //var model = db.GetCustomerList();
            //return model;

            try
            {
                var customers = await db.GetCustomerList();
                if(customers == null)
                {
                    return NotFound();
                }
                return Ok(customers);

            }
            catch (Exception ex)
            {

                return BadRequest();
            }
        }
        [HttpGet]
        [Route("GetCustomer")]
        public async Task<IHttpActionResult> GetCustomer(int id)
        {

            ErrorLog error = new ErrorLog();

            if (id <= 0)
            {
                string message = "Bad request, no id to get the customer";
                error.WriteErrorLog(message);

                return BadRequest();
            }

            try
                {
                    var customer = await db.GetCustomer(id);
                    if(customer == null)
                    {
                        return NotFound();
                    }
                    return Ok(customer);
                }
                catch (Exception ex)
                {
                    error.WriteErrorLog(ex.Message);
                    return BadRequest(); ;
                }
            }
        [HttpPost]
        [Route("CreateCustomer")]
        public async Task<IHttpActionResult> CreateCustomer([FromBody]Customer customer)
        {


                      ErrorLog error = new ErrorLog();

                    if (customer.FullName == null)
                    {
                        string message = "no items to add in the database";
                        error.WriteErrorLog(message);
                        throw new HttpResponseException(Request.CreateErrorResponse(HttpStatusCode.NoContent, message));


                    }
            try
                {
                    var customerresult = await db.CreateCustomer(customer);
                    if(customerresult  != null)
                    {
                        return Ok(customerresult);
                    }
                    else
                    {
                        return NotFound();
                    }

                }
                catch (Exception ex)
                {

                     error.WriteErrorLog(ex.Message);
                    return BadRequest();
                }
           }

        [HttpPost]
        [Route("DeleteCustomer")]
        public async Task<IHttpActionResult> DeleteCustomer(int? id)
        {

            ErrorLog error = new ErrorLog();
            int result = 0;
            if(id <= 0)
            {
                string message = "Bad request, no id parameter  to delete customer";
                error.WriteErrorLog(message);

                return BadRequest();
            }
            try
            {
                result = await db.DeleteCustomer(id);
                if(result == 0)
                {
                    return NotFound();
                }
                return Ok();
            }
            catch (Exception ex)
            {
                error.WriteErrorLog(ex.Message);
                return BadRequest();
            }
        }
        [HttpPut]
        [Route("UpdateCustomer")]
        public async Task<IHttpActionResult> UpdateCustomer([FromBody]Customer customer)
        {
            ErrorLog oErrlorLog = new ErrorLog();


            if (customer.FullName == null)
            {
                string message = "no items to update";
                oErrlorLog.WriteErrorLog(message);
                throw new HttpResponseException(Request.CreateErrorResponse(HttpStatusCode.NotFound, message));


            }
            try
            {
                await db.UpdateCustomer(customer);
                return Ok();

            }
            catch (System.ArgumentException ex)
            {

                oErrlorLog.WriteErrorLog(ex.Message);

                if (ex.GetType().FullName == "Microsoft.EntityFrameworkCore.DbUpdateConcurrencyException")
                {
                    return NotFound();
                }
                return BadRequest();
            }
        }


    }



}

    

