
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
    [Activity(Label = "MenuActivity", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MenuActivity : Activity
    {
        private Button AboutButton;
        private Button CartButton;
        private Button MapButton;
        private Button OrderButton;
        private Button TakePictureButton;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            SetContentView(Resource.Layout.MainMenu);
            ActionBar.SetLogo(Resource.Drawable.smallicon);

            FindViews();
            HandleEvents();
        }

        private void FindViews()
        {
            AboutButton = FindViewById<Button>(Resource.Id.AboutButton);
            CartButton = FindViewById<Button>(Resource.Id.CartButton);
            MapButton = FindViewById<Button>(Resource.Id.MapButton);
            OrderButton = FindViewById<Button>(Resource.Id.OrderButton);
            TakePictureButton = FindViewById<Button>(Resource.Id.TakePictureButton);
        }

        private void HandleEvents()
        {
            AboutButton.Click += AboutButton_Click;
            CartButton.Click += CartButton_Click;
            MapButton.Click += MapButton_Click;
            OrderButton.Click += OrderButton_Click;
            TakePictureButton.Click += TakePictureButton_Click;
        }

        void AboutButton_Click(object sender, EventArgs e)
        {
            var intent = new Intent(this, typeof(AboutActivity));
            StartActivity(intent);
        }

        void CartButton_Click(object sender, EventArgs e)
        {
            var intent = new Intent(this, typeof(CartActivity));
            StartActivity(intent);
        }

        void MapButton_Click(object sender, EventArgs e)
        {
            var intent = new Intent(this, typeof(MapActivity));
            StartActivity(intent);
        }

        private void OrderButton_Click(object sender, EventArgs e)
        {
            var intent = new Intent(this, typeof(HotDogMenuActivity));
            StartActivity(intent);
        }

        void TakePictureButton_Click(object sender, EventArgs e)
        {
            var intent = new Intent(this, typeof(TakePictureActivity));
            StartActivity(intent);
        }
    }
}
