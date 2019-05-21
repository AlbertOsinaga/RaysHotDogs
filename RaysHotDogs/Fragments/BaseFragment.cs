
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;

using RaysHotDogs.Core;

namespace RaysHotDogs
{
    public class BaseFragment : Fragment
    {
        protected ListView listView;
        protected HotDogDataService DataService;
        protected List<HotDog> hotDogs;

        public BaseFragment()
        {
            DataService = new HotDogDataService();
        }

        protected void FindViews()
        {
            listView = this.View.FindViewById<ListView>(Resource.Id.HotDogListView);
        }

        protected void HandleEvents()
        {
            listView.ItemClick += ListView_ItemClick;;
        }

        void ListView_ItemClick(object sender, AdapterView.ItemClickEventArgs e)
        {
            var hotDog = hotDogs[e.Position];

            var intent = new Intent(this.Activity, typeof(HotDogDetailActivity));
            intent.PutExtra("SelectedHotDogId", hotDog.HotDogId);
            StartActivityForResult(intent, 100);
        }

    }
}
