using Android.App;
using Android.Widget;
using Android.OS;
using Com.Isseiaoki.Simplecropview;
using Com.Isseiaoki.Simplecropview.Callback;
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
			this.FindViewById<ImageButton>(Resource.Id.buttonDone).Click += (sender, e) =>
			{
				this.ShowProgress();
				var uri = Android.Net.Uri.FromFile(new Java.IO.File(this.CacheDir, "cropped"));

				this._cropView.StartCrop(uri, new CropCallBack(), new SaveCallBack().AddSuccess((obj) =>
				{
					var intent = new Intent(this, typeof(DetailActivity));
					intent.PutExtra("image", obj.ToString());
					this.DismissProgress();
					this.StartActivity(intent);
				}));

			};
			this.FindViewById<Button>(Resource.Id.buttonFitImage).Click += (sender, e) => { this._cropView.SetCropMode(CropImageView.CropMode.FitImage); };
			this.FindViewById<Button>(Resource.Id.button3_4).Click += (sender, e) => { this._cropView.SetCropMode(CropImageView.CropMode.Ratio34); };
			this.FindViewById<Button>(Resource.Id.button1_1).Click += (sender, e) => { this._cropView.SetCropMode(CropImageView.CropMode.Square); };
			this.FindViewById<Button>(Resource.Id.button4_3).Click += (sender, e) => { this._cropView.SetCropMode(CropImageView.CropMode.Ratio43); };
			this.FindViewById<Button>(Resource.Id.button9_16).Click += (sender, e) => { this._cropView.SetCropMode(CropImageView.CropMode.Ratio916); };
			this.FindViewById<Button>(Resource.Id.button16_9).Click += (sender, e) => { this._cropView.SetCropMode(CropImageView.CropMode.Ratio169); };
			this.FindViewById<Button>(Resource.Id.buttonFree).Click += (sender, e) => { this._cropView.SetCropMode(CropImageView.CropMode.Free); };
			this.FindViewById<ImageButton>(Resource.Id.buttonRotateLeft).Click += (sender, e) => { this._cropView.RotateImage(CropImageView.RotateDegrees.RotateM90d); };
			this.FindViewById<ImageButton>(Resource.Id.buttonRotateRight).Click += (sender, e) => { this._cropView.RotateImage(CropImageView.RotateDegrees.Rotate90d); };
			this.FindViewById<Button>(Resource.Id.buttonCustom).Click += (sender, e) => { this._cropView.SetCustomRatio(7, 5); };
			this.FindViewById<Button>(Resource.Id.buttonCircle).Click += (sender, e) => { this._cropView.SetCropMode(CropImageView.CropMode.Circle); };
			this.FindViewById<Button>(Resource.Id.buttonShowCircleButCropAsSquare).Click += (sender, e) => { this._cropView.SetCropMode(CropImageView.CropMode.CircleSquare); };
		}


		public void ShowProgress()
		{
			ProgressDialogFragment f = ProgressDialogFragment.getInstance();
			this.FragmentManager.BeginTransaction().Add(f, "ProgressDialog").CommitAllowingStateLoss();
		}

		public void DismissProgress()
		{
			var progressFragment = this.FragmentManager.FindFragmentByTag("ProgressDialog");
			if (progressFragment == null) return;
			this.FragmentManager.BeginTransaction().Remove(progressFragment).CommitAllowingStateLoss();
		}

	}
}

