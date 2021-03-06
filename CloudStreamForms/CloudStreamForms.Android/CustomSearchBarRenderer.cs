﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Content.Res;
using Android.Graphics;
using Android.OS;
using Android.Runtime;
using Android.Text;
using Android.Views;
using Android.Widget;
using CloudStreamForms.Droid;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using static Java.Util.ResourceBundle;
using G = Android.Graphics;


[assembly: ExportRenderer(typeof(SearchBar), typeof(CustomSearchBarRenderer))]
namespace CloudStreamForms.Droid
{
    public class CustomSearchBarRenderer : SearchBarRenderer
    {
        private Context context;
        public CustomSearchBarRenderer(Context context) : base(context)
        {
            this.context = context;
        }

        protected override void OnElementChanged(ElementChangedEventArgs<SearchBar> args)
        {
            base.OnElementChanged(args);
            // Get native control (background set in shared code, but can use SetBackgroundColor here)
            SearchView searchView = (base.Control as SearchView);
            searchView.SetInputType(InputTypes.ClassText | InputTypes.TextVariationNormal);

            // Access search textview within control
            int textViewId = searchView.Context.Resources.GetIdentifier("android:id/search_src_text", null, null);
            EditText textView = (searchView.FindViewById(textViewId) as EditText);

            // Set custom colors
            // textView.SetBackgroundColor(G.Color.Rgb(25, 25, 25));
            textView.SetBackgroundColor(Settings.BlackBg ? G.Color.Rgb(12, 12, 12) : G.Color.Rgb(25, 25, 25));

            textView.SetHintTextColor(G.Color.Rgb(64, 64, 64));
            textView.SetTextColor(G.Color.Rgb(200, 200, 200));
            /*
            textView.SetTextColor(G.Color.Rgb(32, 32, 32));
            textView.SetHintTextColor(G.Color.Rgb(128, 128, 128));*/


            // Customize frame color
            int frameId = searchView.Context.Resources.GetIdentifier("android:id/search_plate", null, null);
            Android.Views.View frameView = (searchView.FindViewById(frameId) as Android.Views.View);
              frameView.SetBackgroundColor(G.Color.ParseColor(CloudStreamForms.Settings.MainBackgroundColor));
            //frameView.SetBackgroundColor(G.Color.Rgb(96, 96, 96));

            /*
            // Get native control (background set in shared code, but can use SetBackgroundColor here)
            SearchView searchView = (base.Control as SearchView);
          //  searchView.SetBackgroundColor(new G.Color() { A = 1, R = 1, B = 255, G = 1 });
            searchView.SetInputType(InputTypes.ClassText | InputTypes.TextVariationNormal);

            // Access search textview within control
            int textViewId = searchView.Context.Resources.GetIdentifier("android:id/search_src_text", null, null);
            EditText textView = (searchView.FindViewById(textViewId) as EditText);

            // Set custom colors
            //textView.SetBackgroundColor(G.Color.Rgb(225, 225, 225));
            textView.SetHintTextColor(G.Color.Rgb(64, 64, 64));
            textView.SetTextColor(G.Color.Rgb(200, 200, 200));
            textView.SetBackgroundColor(new G.Color() { A = 1, R = 1, B = 255, G = 1 });


            // Customize frame color
            int frameId = searchView.Context.Resources.GetIdentifier("android:id/search_plate", null, null);
            Android.Views.View frameView = (searchView.FindViewById(frameId) as Android.Views.View);
             Main.print(CloudStreamForms.Settings.MainBackgroundColor);
           //  frameView.SetBackgroundColor(G.Color.ParseColor(CloudStreamForms.Settings.MainBackgroundColor));*/
        }
    }
}