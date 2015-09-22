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
using BusinessContactManager.Droid.Application_Layer;

namespace BusinessContactManager.Droid
{
    [Activity(Label = "ContactDetailsActivity")]
    public class ContactDetailsActivity : Activity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.ContactDetails);

            var saveBtn = FindViewById<Button>(Resource.Id.save);
            saveBtn.Click += SaveBtn_Click;
        }

        private void SaveBtn_Click(object sender, EventArgs e)
        {
            ConnectionManager connMgr = ConnectionManager.GetConnection(new SqliteConfig_Android());
            ContactRepository contactRepo = new ContactRepository(connMgr);
            CompanyRepository companyRepo = new CompanyRepository(connMgr);

            Contact c = new Contact();
            c.FirstName = FindViewById<EditText>(Resource.Id.firstNameEditText).Text;
            c.LastName = FindViewById<EditText>(Resource.Id.firstNameEditText).Text;
            c.JobTitle = FindViewById<EditText>(Resource.Id.titleEditText).Text;
            c.Phone = FindViewById<EditText>(Resource.Id.phoneEditText).Text;
            c.Email = FindViewById<EditText>(Resource.Id.emailEditText).Text;
            c.Notes = FindViewById<EditText>(Resource.Id.notesEditText).Text;
            c.Image = Resource.Drawable.CameraShy;

            Company co = new Company();
            co.Name = FindViewById<EditText>(Resource.Id.companyEditText).Text;
            co.Website = co.Name + ".com";
            companyRepo.SaveCompany(co);

            c.CompanyId = co.Id;
            contactRepo.SaveContact(c);

            Finish();
        }
    }
}