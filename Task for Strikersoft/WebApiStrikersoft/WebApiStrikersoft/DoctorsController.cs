using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Core;
using Data;
using System.Web.Configuration;
using Ninject;

namespace WebApiStrikersoft
{
   
    public class DoctorsController : ApiController
    {
        IContext db = new Context(WebConfigurationManager.ConnectionStrings["Strikersoft"].ConnectionString);
        Ninject.IKernel kernal = new StandardKernel();

        // GET api/<controller>
        public IEnumerable<Doctor> Get()
        {
            //Uncoment following to test Ninject Depndency

           
            //kernal.Bind<IRepository>().To<NinjaContext>();
            //var instance = kernal.Get<Context>();
            //return instance.GetAllDoctors();

            return db.GetAllDoctors();
        }

        // GET api/<controller>/5
        public Doctor Get(string id)
        {
            return db.GetDoctorByID(Guid.Parse(id));
        }

        // POST api/<controller>
        public void Post([FromBody]Doctor doctor)
        {
            db.AddDoctor(doctor);
        }

        // PUT api/<controller>/5
        public void Put(string id, [FromBody]Doctor doctor)
        {
            db.UpdateDoctor(Guid.Parse(id),doctor);
        }

        // DELETE api/<controller>/5
        public void Delete(string id)
        {
            db.DeleteDoctor(Guid.Parse(id));
        }
    }
}