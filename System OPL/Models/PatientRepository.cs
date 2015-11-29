﻿using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;

namespace System_OPL.Models
{
    public class PatientRepository
    {
        private OplContext context;

        public void ClientFakerInsert(int amountOfPatients)
        {
            for (int i = 0; i < amountOfPatients; i++)
            {
                context.Patients.AddOrUpdate(new Patient()
                {
                    Name = Faker.NameFaker.FirstName(),
                    Surname = Faker.NameFaker.LastName(),
                    DoctorId = DoctorFaker(),
                    ContactDataId = AddressFaker(),
                    HealthStatusId = HealthStatusFaker()
                });
            }
            context.SaveChanges();

        }

        private int HealthStatusFaker()
        {
           var healthStatus = new HealthStatus()
           {
               //Content = 
           };

            return healthStatus.Id;
        }

        private int DoctorFaker()
        {
            var doctor = new Doctor()
            {
                Name = Faker.NameFaker.FirstName(),
                Surname = Faker.NameFaker.LastName(),
                OfficeNumber = Faker.NumberFaker.Number(1,30),
                WorkHourId = 1,
            };
            doctor.UserName = doctor.Name[0] + doctor.Surname;

            context.Doctors.AddOrUpdate(doctor);
            context.SaveChanges();

            return doctor.Id;
        }

        public int AddressFaker()
        {
            var address = new ContactData()
            {
                City = Faker.LocationFaker.City(),
                FlatNumber = Faker.LocationFaker.StreetNumber(),
                HomeNumber = Faker.NumberFaker.Number(1, 150),
                Street = Faker.LocationFaker.Street()
            };

            context.ContactDatas.AddOrUpdate(address);
            context.SaveChanges();

            return address.Id;
        }
    }
}