using MongoDB.Bson;
using MongoDB.Driver;
using PatientData.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace PatientData.Controllers
{
    public class PatientController : ApiController
    {
        MongoCollection<Patient> _patients;

        public PatientController()
        {
            _patients = PatientDb.Open();
        }

        public IEnumerable<Patient> Get()
        {
            return _patients.FindAll();
        }

        public HttpResponseMessage Get(string id)
        {
            var patient = _patients.FindOneById(ObjectId.Parse(id));
            if (patient == null)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Patient not found");
            }
            return Request.CreateResponse(patient);
        }

        [Route("api/patient/{id}/medications")]
        public HttpResponseMessage GetMedications(string id)
        {
            var patient = _patients.FindOneById(ObjectId.Parse(id));
            if (patient == null)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Patient not found");
            }
            return Request.CreateResponse(patient.Medications);
        }
    }
}
