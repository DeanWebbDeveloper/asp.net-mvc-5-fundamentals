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
    }
}