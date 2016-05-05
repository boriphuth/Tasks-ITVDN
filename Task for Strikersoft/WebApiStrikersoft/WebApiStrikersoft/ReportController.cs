using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Core;
using System.Web.Configuration;

namespace WebApiStrikersoft
{
    public class ReportController : ApiController
    {
        IContext db = new Context(WebConfigurationManager.ConnectionStrings["Strikersoft"].ConnectionString);

        // GET api/<controller>
        public IEnumerable<Report> Get()
        {
            return db.GetReport();
        }
    }
}
