
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

namespace RaysHotDogs
{
    [Activity(Label = "AboutActivity")]
    public class AboutActivity : Activity
    {
        private TextView PhoneNumber;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            SetContentView(Resource.Layout.AboutView);
            FindViews();
            HandleEvents();
        }

        private void FindViews()
        {
            PhoneNumber = FindViewById<TextView>(Resource.Id.PhoneNumberTextView);
        }

        private void HandleEvents()
        {
            PhoneNumber.Click += PhoneNumber_Click;
        }

        void PhoneNumber_Click(object sender, EventArgs e)
        {
            var intent = new Intent(Intent.ActionCall);
            intent.SetData(Android.Net.Uri.Parse($"tel:{PhoneNumber.Text}"));
            StartActivity(intent);
        }

    }


}
