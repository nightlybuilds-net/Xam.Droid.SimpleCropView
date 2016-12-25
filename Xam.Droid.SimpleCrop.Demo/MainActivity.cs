using Android.App;
using Android.Widget;
using Android.OS;
using Com.Isseiaoki.Simplecropview;
using System;
using Android.Views;
using Com.Isseiaoki.Simplecropview.Callback;
using Android.Graphics;
using Android.Net;
using Android.Content;

namespace Xam.Droid.SimpleCrop.Demo
{
	[Activity(Label = "Xam.Droid.SimpleCrop.Demo", MainLauncher = true, Icon = "@mipmap/icon")]
	public class MainActivity : Activity
	{
		CropImageView _cropView;

		public MainActivity()
		{
		}

		protected override void OnCreate(Bundle savedInstanceState)
		{
			base.OnCreate(savedInstanceState);

			// Set our view from the "main" layout resource
			SetContentView(Resource.Layout.Main);


			this._cropView = this.FindViewById<CropImageView>(Resource.Id.cropImageView);
			this._cropView.SetImageResource(Resource.Drawable.original);

			this.BindViews();
		}


		private void BindViews()
		{
			this.FindViewById<Button>(Resource.Id.buttonDone).Click += Handle_Click;
			this.FindViewById<Button>(Resource.Id.buttonFitImage).Click += Handle_Click;
			this.FindViewById<Button>(Resource.Id.button3_4).Click += Handle_Click;
			this.FindViewById<Button>(Resource.Id.button1_1).Click += Handle_Click;
			this.FindViewById<Button>(Resource.Id.button4_3).Click += Handle_Click;
			this.FindViewById<Button>(Resource.Id.button9_16).Click += Handle_Click;
			this.FindViewById<Button>(Resource.Id.button16_9).Click += Handle_Click;
			this.FindViewById<Button>(Resource.Id.buttonFree).Click += Handle_Click;
			//his.FindViewById<Button>(Resource.Id.buttonPickImage).Click += Handle_Click;
			this.FindViewById<Button>(Resource.Id.buttonRotateLeft).Click += Handle_Click;
			this.FindViewById<Button>(Resource.Id.buttonRotateRight).Click += Handle_Click;
			this.FindViewById<Button>(Resource.Id.buttonCustom).Click += Handle_Click;
			this.FindViewById<Button>(Resource.Id.buttonCircle).Click += Handle_Click;
			this.FindViewById<Button>(Resource.Id.buttonShowCircleButCropAsSquare).Click += Handle_Click;
		}

		void Handle_Click(object sender, EventArgs e)
		{
			var view = sender as View;

			switch (view.Id)
			{
				case Resource.Id.buttonDone:
					var uri = Android.Net.Uri.FromFile(new Java.IO.File(this.CacheDir,"cropped"));

					// using save callback
					this._cropView.StartCrop(uri, new CropCallBack(), new SaveCallBack().AddSuccess((obj) => 
					{
						var intent = new Intent(this,typeof(DetailActivity));
						intent.PutExtra("image",obj.ToString());
						this.StartActivity(intent);
					}));
					break;
				case Resource.Id.buttonFitImage:
					this._cropView.SetCropMode(CropImageView.CropMode.FitImage);
					break;
				case Resource.Id.button1_1:
					this._cropView.SetCropMode(CropImageView.CropMode.Square);
					break;
				case Resource.Id.button3_4:
					this._cropView.SetCropMode(CropImageView.CropMode.Ratio34);
					break;
				case Resource.Id.button4_3:
					this._cropView.SetCropMode(CropImageView.CropMode.Ratio43);
					break;
				case Resource.Id.button9_16:
					this._cropView.SetCropMode(CropImageView.CropMode.Ratio916);
					break;
				case Resource.Id.button16_9:
					this._cropView.SetCropMode(CropImageView.CropMode.Ratio169);
					break;
				case Resource.Id.buttonCustom:
					this._cropView.SetCustomRatio(7, 5);
					break;
				case Resource.Id.buttonFree:
					this._cropView.SetCropMode(CropImageView.CropMode.Free);
					break;
				case Resource.Id.buttonCircle:
					this._cropView.SetCropMode(CropImageView.CropMode.Circle);
					break;
				case Resource.Id.buttonShowCircleButCropAsSquare:
					this._cropView.SetCropMode(CropImageView.CropMode.CircleSquare);
					break;
				case Resource.Id.buttonRotateLeft:
					this._cropView.RotateImage(CropImageView.RotateDegrees.RotateM90d);
					break;
				case Resource.Id.buttonRotateRight:
					this._cropView.RotateImage(CropImageView.RotateDegrees.Rotate90d);
					break;
					//case Resource.Id.buttonPickImage:
					//	//MainFragmentPermissionsDispatcher.pickImageWithCheck(MainFragment.this);
					//	break;
			}
		}



	}
}

