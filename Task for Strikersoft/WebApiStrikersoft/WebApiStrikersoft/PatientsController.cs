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
    public class PatientsController : ApiController
    {
        IContext db = new Context(WebConfigurationManager.ConnectionStrings["Strikersoft"].ConnectionString);

        // GET api/<controller>
        public IEnumerable<Patient> Get()
        {
            return db.GetAllPatients();
        }

        // GET api/<controller>/5
        public Patient Get(string id)
        {
            return db.GetPatientByID(Guid.Parse(id));
        }

        // POST api/<controller>
        public void Post([FromBody]Patient patient)
        {
            db.AddPatient(patient);
        }

        // PUT api/<controller>/5
        public void Put(string id, [FromBody]Patient patient)
        {
            db.UpdatePatient(Guid.Parse(id), patient);
        }

        // DELETE api/<controller>/5
        public void Delete(string id)
        {
            db.DeletePatient(Guid.Parse(id));
        }
    }
}
