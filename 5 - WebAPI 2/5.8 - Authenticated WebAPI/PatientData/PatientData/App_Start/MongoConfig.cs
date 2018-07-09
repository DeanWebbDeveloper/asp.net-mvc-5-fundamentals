using MongoDB.Driver.Linq;
using PatientData.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PatientData
{
    public static class MongoConfig
    {
        public static void Seed()
        {
            var patients = PatientDb.Open();

            if (!patients.AsQueryable().Any(p => p.Name == "Chris"))
            {
                var data = new List<Patient>()
                {
                    new Patient {   Name = "Chris",
                                    Ailments = new List<Ailment>() { new Ailment { Name = "Piracy"} },
                                    Medications = new List<Medication>() {new Medication { Name = "Rum", Doses = 1 } }
                    },
                    new Patient {   Name = "Hailey",
                                    Ailments = new List<Ailment>() { new Ailment { Name = "Qwerty"} },
                                    Medications = new List<Medication>() {new Medication { Name = "Aspirin", Doses = 200 } }
                    },
                    new Patient {   Name = "Chris",
                                    Ailments = new List<Ailment>() { new Ailment { Name = "Boring"} },
                                    Medications = new List<Medication>() {new Medication { Name = "Cool", Doses = 3 } }
                    },
                };

                patients.InsertBatch(data);
            }
        }
    }
}