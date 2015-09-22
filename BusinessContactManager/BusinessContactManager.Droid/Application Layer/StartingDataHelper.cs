using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using BusinessContactManager.Business_Layer.Entities;
using BusinessContactManager.Business_Layer;
using BusinessContactManager.DataAccessLayer;

namespace BusinessContactManager.Droid.Application_Layer
{
    internal class StartingDataHelper
    {
        private static CompanyRepository companyRepo;
        private static ContactRepository contactRepo;
        private static EventRepository eventRepo;

        static StartingDataHelper()
        {
            var connMgr = ConnectionManager.GetConnection(new SqliteConfig_Android());
            companyRepo = new CompanyRepository(connMgr);
            contactRepo = new ContactRepository(connMgr);
            eventRepo = new EventRepository(connMgr);
        }

        public static void CreateData()
        {
            contactRepo.DeleteAllContacts();
            companyRepo.DeleteAllCompanies();
            eventRepo.DeleteAllEvents();

            Contact contact1 = new Contact();
            contact1.FirstName = "Jane";
            contact1.LastName = "Smith";
            contact1.JobTitle = "Mobile App Developer";
            contact1.Phone = "701-555-1212";
            contact1.Image = Resource.Drawable.Dog1; //TODO: Need to allow picture to be uploaded in the app, but hard-coded for now
            contact1.Email = "jsmith@hotmail.com";
            contact1.Notes = "Does android and iOS development.";
            contactRepo.SaveContact(contact1);

            Company company1 = new Company();
            company1.Name = "Microsoft";
            company1.Website = "www.microsoft.com";
            companyRepo.SaveCompany(company1);

            Event event1 = new Event();
            event1.Date = new DateTime(2015, 6, 1);
            event1.Name = "Ignite Conference";
            event1.City = "Chicago";
            event1.State = "Illinois";
            eventRepo.SaveEvent(event1);

            contact1.CompanyId = company1.Id;
            contact1.EventId = event1.Id;
            contactRepo.SaveContact(contact1);

            Contact contact2 = new Contact();
            contact2.FirstName = "John";
            contact2.LastName = "Doe";
            contact2.JobTitle = "Web Developer";
            contact2.Phone = "218-281-5555";
            contact2.Image = Resource.Drawable.Dog2; //TODO: Need to allow picture to be uploaded in the app, but hard-coded for now
            contact2.Email = "jdoe@gmail.com";
            contact2.Notes = "Loves ASP .Net.";
            contactRepo.SaveContact(contact2);

            Company company2 = new Company();
            company2.Name = "Great Plains";
            company2.Website = "www.greatplains.com";
            companyRepo.SaveCompany(company2);

            Event event2 = new Event();
            event2.Date = new DateTime(2015, 5, 2);
            event2.Name = "THAT Conference";
            event2.City = "Wisconsin Dells";
            event2.State = "Wisconsin";
            eventRepo.SaveEvent(event2);

            contact2.CompanyId = company2.Id;
            contact2.EventId = event2.Id;
            contactRepo.SaveContact(contact2);
        }
    }
}