
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
        private HotDogDataService HotDogDataService;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            SetContentView(Resource.Layout.HotDogMenuView);

            ActionBar.NavigationMode = ActionBarNavigationMode.Tabs;
            HotDogDataService = new HotDogDataService();

            AddTab("Favorites", Resource.Drawable.FavoritesIcon, new FavoriteHotDogFragment());
            AddTab("Meat Lovers", Resource.Drawable.MeatLoversIcon, new MeatLoversFragment());
            AddTab("Veggie Lovers", Resource.Drawable.veggieloversicon, new VeggieLoversFragment());
        }

        private void AddTab(string tabText, int iconResourceId, Fragment view)
        {
            var tab = this.ActionBar.NewTab();
            tab.SetText(tabText);
            tab.SetIcon(iconResourceId);

            tab.TabSelected += delegate(object sender, Android.App.ActionBar.TabEventArgs e) 
            {
                var fragment = this.FragmentManager.FindFragmentById(Resource.Id.FragmentContainer);
                if (fragment != null)
                    e.FragmentTransaction.Remove(fragment);
                e.FragmentTransaction.Add(Resource.Id.FragmentContainer, view);
            };

            tab.TabUnselected += (sender, e) => e.FragmentTransaction.Remove(view);
            this.ActionBar.AddTab(tab);
        }

        protected override void OnActivityResult(int requestCode, Result resultCode, Intent data)
        {
            base.OnActivityResult(requestCode, resultCode, data);

            if (resultCode == Result.Ok && requestCode == 100)
            {
                var selectedHotDog = HotDogDataService.GetHotDogById(data.GetIntExtra("SelectedHotDogId", 0));
                var amount = data.GetIntExtra("Amount", 0);
                var dialog = new Android.App.AlertDialog.Builder(this);
                dialog.SetTitle("Confirmation");
                dialog.SetMessage($"You've added {amount} times the {selectedHotDog.Name}");
                dialog.Show();
            }
        }
    }
}
