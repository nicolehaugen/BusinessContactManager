using System;

using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using BusinessContactManager.Droid.Application_Layer;

namespace BusinessContactManager.Droid
{
	[Activity (Label = "BusinessContactManager.Droid", MainLauncher = true, Icon = "@drawable/icon")]
	public class MainActivity : Activity
	{
		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);

			// Set our view from the "main" layout resource
			SetContentView (Resource.Layout.ContactGrid);

            StartingDataHelper.CreateData();

            var gridView = FindViewById<GridView>(Resource.Id.contactsGrid);
            gridView.Adapter = new ContactListAdapter(this);
            gridView.ItemClick += GridView_ItemClick;

            var addContactBtn = FindViewById<Button>(Resource.Id.addContact);
            addContactBtn.Click += AddContactBtn_Click;
        }

        protected override void OnResume()
        {
            base.OnResume();

            var gridView = FindViewById<GridView>(Resource.Id.contactsGrid);
            gridView.Adapter = new ContactListAdapter(this);
            gridView.ItemClick += GridView_ItemClick;
        }

        private void AddContactBtn_Click(object sender, EventArgs e)
        {
            var intent = new Intent(this, typeof(ContactDetailsActivity));
            StartActivity(intent);
        }

        private void GridView_ItemClick(object sender, AdapterView.ItemClickEventArgs e)
        {
            Toast.MakeText(this, e.Position.ToString(), ToastLength.Short).Show();
        }
    }
}


