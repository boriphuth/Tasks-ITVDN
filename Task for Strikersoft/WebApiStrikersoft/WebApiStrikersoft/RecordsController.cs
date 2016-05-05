using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Data;
using Core;
using System.Web.Configuration;

namespace WebApiStrikersoft
{
    public class RecordsController : ApiController
    {
        IContext db = new Context(WebConfigurationManager.ConnectionStrings["Strikersoft"].ConnectionString);

        // GET api/<controller>
        public IEnumerable<Patient> Get()
        {
            return db.GetAllPatients();
        }

        // GET api/<controller>/5
        public RegistrCard Get(string id)
        {
            return db.GetCardByID(Guid.Parse(id));
        }

        // POST api/<controller>
        public void Post([FromBody]RegistrCard card)
        {
            db.AddRecordToCard(card);
        }

        // PUT api/<controller>/5
        public void Put(string id, [FromBody]RegistrCard card)
        {
            db.UpdateRecord(Guid.Parse(id), card);
        }

        // DELETE api/<controller>/5
        public void Delete(string id)
        {
            db.DeleteRecord(Guid.Parse(id));
        }
    }
}
