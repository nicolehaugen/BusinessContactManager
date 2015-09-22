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
using Java.Lang;
using BusinessContactManager.Business_Layer.Entities;
using BusinessContactManager.Business_Layer;
using BusinessContactManager.Droid.Application_Layer;

namespace BusinessContactManager.Droid
{
    public class ContactListAdapter : BaseAdapter<Contact>
    {
        private readonly Context context;
        private List<Contact> contacts;
        private ConnectionManager connMgr;

        public ContactListAdapter(Context ctx) : base()
        {
            context = ctx;
            this.connMgr = ConnectionManager.GetConnection(new SqliteConfig_Android());
            this.contacts = new ContactRepository(connMgr).GetContacts().ToList<Contact>() ;
        }

        public override int Count
        {
            get { return this.contacts.Count; }
        }

        public override Contact this[int position]
        {
            get { return this.contacts[position]; }
        }

        public override long GetItemId(int position)
        {
            return position;
        }

        public override View GetView(int position, View convertView, ViewGroup parent)
        {

            View grid;
            LayoutInflater inflater = context.GetSystemService(Context.LayoutInflaterService).JavaCast<LayoutInflater>();

            if (convertView == null)
            {
                grid = new View(this.context);
                grid = inflater.Inflate(Resource.Layout.ContactGridCell, null);
                TextView contactNameTextView = (TextView)grid.FindViewById(Resource.Id.contactName);
                TextView companyNameTextView = (TextView)grid.FindViewById(Resource.Id.contactCompany);
                ImageView imageView = (ImageView)grid.FindViewById(Resource.Id.contactImage);

                string fullName = this.contacts[position].FirstName + " " + this.contacts[position].LastName;
                contactNameTextView.SetText(fullName, TextView.BufferType.Normal);

                CompanyRepository companyRepo = new CompanyRepository(this.connMgr);
                Company company = companyRepo.GetCompany(this.contacts[position].CompanyId);
                companyNameTextView.SetText(company.Name, TextView.BufferType.Normal);

                //TODO: these lines cause exception...have expicitly set this in the .axml instead
                //imageView.LayoutParameters = new AbsListView.LayoutParams(85, 85);
                //imageView.SetAdjustViewBounds(true);
                imageView.SetScaleType(ImageView.ScaleType.CenterCrop);
                imageView.SetPadding(8, 8, 8, 8);
                imageView.SetImageResource(this.contacts[position].Image);
            }
            else
            {
                grid = (View)convertView;
            }

            return grid;

        }
    }
}