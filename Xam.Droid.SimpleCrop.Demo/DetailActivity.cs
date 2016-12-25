
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

namespace Xam.Droid.SimpleCrop.Demo
{
	[Activity(Label = "DetailActivity")]
	public class DetailActivity : Activity
	{
		protected override void OnCreate(Bundle savedInstanceState)
		{
			base.OnCreate(savedInstanceState);

			// Create your application here
			this.SetContentView(Resource.Layout.Result_Activity);

			var imageView = this.FindViewById<ImageView>(Resource.Id.result_image);

			var uriString = Android.Net.Uri.Parse(Intent.GetStringExtra("image"));

			imageView.SetImageURI(uriString);

		}
	}
}
