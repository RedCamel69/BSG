using BSG.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MembersBSG.Controllers
{
    public class TestController : ApiController
    {
        //[HttpGet]
        //public string Greet()

        //{
        //    return "BJ ";
        //}

        //[HttpGet]
        //public string Greet2(bool showDate)
        //{
        //    return "BJ2 " + DateTime.Now.ToLongDateString();
        //}

        //public IHttpActionResult GetProduct(int id)
        //{
        //    if (id == 1)
        //    {
        //        return Ok("Product Found"); 
        //    }
        //    else
        //    {
        //        return NotFound();
        //    }
        //}

        public IHttpActionResult GetCoach(Coach c)
        {

            /*
             * Fiddler REquest
             * http://localhost:56372/api/test
             * 
             * User-Agent: Fiddler
                Host: localhost:56372
                Content-Length: 22
                Accept: application/json
                Content-Type: application/json

    Body
    {"FirstName" : "Bill"}

             */

            if (c.FirstName=="Bill")
            {
                return Ok(c);
            }
            else
            {
                return NotFound();
            }
        }


    }
}
