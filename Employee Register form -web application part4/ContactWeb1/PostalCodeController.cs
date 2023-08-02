using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ContactWeb1
{
    public class PostalCodeController : ApiController
    {
        IList<ZipCode> zipCode = new List<ZipCode>()
        {
            new ZipCode(){zipCode = 625513, City = "Bodinayakanur", District = "Theni", State = "Tamilnadu", Country="India"},
            new ZipCode(){zipCode = 625531, City = "Theni", District = "Theni", State = "Tamilnadu", Country="India"},
            new ZipCode(){zipCode = 625001 , City = "Madurai South", District = "Madurai ", State = "Tamilnadu", Country="India"},

        };
        public IEnumerable<ZipCode> GetAllStudents()
        {
             return zipCode;
        }
        public ZipCode GetZipcodeDetails(int id)
        {
            var Code = zipCode.FirstOrDefault(e => e.zipCode == id);
            if (Code == null)
            {
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound));
            }
            return Code;
        }
    }
}
