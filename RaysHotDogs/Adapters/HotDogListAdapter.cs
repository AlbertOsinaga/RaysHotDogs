using Android.App;
using Android.Views;
using Android.Widget;
using Android.Graphics;

using System;
using System.Collections.Generic;

using RaysHotDogs.Core;
using RaysHotDogs.Utility;

namespace RaysHotDogs.Adapters
{
    public class HotDogListAdapter : BaseAdapter<HotDog>
    {
        List<HotDog> Items;
        Activity Context;

        public HotDogListAdapter(Activity context, List<HotDog> items)
        {
            this.Context = context;
            this.Items = items;
        }

        public override long GetItemId(int position) => position;

        public override HotDog this[int position]
        {
            get => Items[position];
        }

        public override int Count 
        {
            get => Items.Count; 
        }

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            var item = Items[position];
            var imageBitmap = ImageHelper.GetImageBitmapFromUrl($"http://gillcleerenpluralsight.blob.core.windows.net/files/{item.ImagePath}.jpg");
            if (convertView == null)
            {
                convertView = Context.LayoutInflater
                        .Inflate(Resource.Layout.HotDogRowView, null);
            }
            convertView.FindViewById<TextView>(Resource.Id.HotDogNameTextView).Text = item.Name;
            convertView.FindViewById<TextView>(Resource.Id.ShortDescriptionTextView).Text = item.ShortDescription;
            convertView.FindViewById<TextView>(Resource.Id.PriceTextView).Text = $"$ {item.Price}";
            convertView.FindViewById<ImageView>(Resource.Id.HotDogImageView).SetImageBitmap(imageBitmap);
            return convertView;
        }
    }
}
