
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

using RaysHotDogs.Core;
using RaysHotDogs.Utility;

namespace RaysHotDogs
{
    [Activity(Label = "Hot Dog Detail", MainLauncher = false)]
    public class HotDogDetailActivity : Activity
    {
        private ImageView HotDogImageView;
        private TextView HotDogNameTextView;
        private TextView ShortDescriptionTextView;
        private TextView DescriptionTextView;
        private TextView PriceTextView;
        private EditText AmountEditText;
        private Button CancelButton;
        private Button OrderButton;

        private HotDog SelectedHotDog;
        private HotDogDataService DataService;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here

            SetContentView(Resource.Layout.HotDogDetailView);

            DataService = new HotDogDataService();
            var selectedHotDogId = Intent.GetIntExtra("SelectedHotDogId", 0);
            SelectedHotDog = DataService.GetHotDogById(selectedHotDogId);

            FindViews();
            BindData();
            HandleEvents();
        }

        private void BindData()
        {
            HotDogNameTextView.Text = SelectedHotDog.Name;
            ShortDescriptionTextView.Text = SelectedHotDog.ShortDescription;
            DescriptionTextView.Text = SelectedHotDog.Description;
            PriceTextView.Text = $"Price: {SelectedHotDog.Price}";

            var imageBitmap = ImageHelper.GetImageBitmapFromUrl($"http://gillcleerenpluralsight.blob.core.windows.net/files/{SelectedHotDog.ImagePath}.jpg");
            HotDogImageView.SetImageBitmap(imageBitmap);
        }

        private void FindViews()
        {
            HotDogImageView = FindViewById<ImageView>(Resource.Id.HotDogImageView);
            HotDogNameTextView = FindViewById<TextView>(Resource.Id.HotDogNameTextView);
            ShortDescriptionTextView = FindViewById<TextView>(Resource.Id.ShortDescriptionTextView);
            DescriptionTextView = FindViewById<TextView>(Resource.Id.DescriptionTextView);
            PriceTextView = FindViewById<TextView>(Resource.Id.PriceTextView);
            AmountEditText = FindViewById<EditText>(Resource.Id.AmountEditText);
            CancelButton = FindViewById<Button>(Resource.Id.CancelButton);
            OrderButton = FindViewById<Button>(Resource.Id.OrderButton);
        }

        private void HandleEvents()
        {
            CancelButton.Click += (sender, e) => { };
            OrderButton.Click += OrderButton_Click;
        }

        void OrderButton_Click(object sender, EventArgs e)
        {
            var amount = int.Parse(AmountEditText.Text);
            var intent = new Intent();
            intent.PutExtra("SelectedHotDogId", SelectedHotDog.HotDogId);
            intent.PutExtra("Amount", amount);

            SetResult(Result.Ok, intent);

            this.Finish();
        }
    }
}
