
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
using RaysHotDogs.Adapters;

namespace RaysHotDogs
{
    [Activity(Label = "Hot Dog Menu", MainLauncher =false)]
    public class HotDogMenuActivity : Activity
    {
        private ListView HotDogListView;
        private List<HotDog> AllHotDogs;
        private HotDogDataService HotDogDataService;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            SetContentView(Resource.Layout.HotDogMenuView);
            HotDogListView = FindViewById<ListView>(Resource.Id.HotDogListView);
            HotDogDataService = new HotDogDataService();
            AllHotDogs = HotDogDataService.GetAllHotDogs();
            HotDogListView.Adapter = new HotDogListAdapter(this, AllHotDogs);
            HotDogListView.FastScrollEnabled = true;
            HotDogListView.ItemClick += HotDogListView_ItemClick;
        }

        void HotDogListView_ItemClick(object sender, AdapterView.ItemClickEventArgs e)
        {
            var hotDog = AllHotDogs[e.Position];
            var intent = new Intent();
            intent.SetClass(this, typeof(HotDogDetailActivity));
            intent.PutExtra("SelectedHotDogId", hotDog.HotDogId);
            StartActivityForResult(intent, 100);
        }

        protected override void OnActivityResult(int requestCode, Result resultCode, Intent data)
        {
            base.OnActivityResult(requestCode, resultCode, data);

            if (resultCode == Result.Ok && requestCode == 100)
            {
                var selectedHotDog = HotDogDataService.GetHotDogById(data.GetIntExtra("SelectedHotDogId", 0));
                var amount = data.GetIntExtra("Amount", 0);
                var dialog = new AlertDialog.Builder(this);
                dialog.SetTitle("Confirmation");
                dialog.SetMessage($"You've added {amount} times the {selectedHotDog.Name}");
                dialog.Show();
            }
        }
    }
}
