
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
using Android.Graphics.Drawables;
using Android.Graphics;

namespace Xam.Droid.SimpleCrop.Demo
{
	public class ProgressDialogFragment : DialogFragment
	{
		public override void OnCreate(Bundle savedInstanceState)
		{
			base.OnCreate(savedInstanceState);
			this.Cancelable = false;
		}

		public override Dialog OnCreateDialog(Bundle savedInstanceState)
		{

			ProgressDialog dialog = new ProgressDialog(this.Activity);
			dialog.SetTitle("Please Wait");
			dialog.SetMessage("Cropping..");
			dialog.Indeterminate = true;
			dialog.SetProgressStyle(ProgressDialogStyle.Spinner);

			return dialog;
			                        
		}

		public static ProgressDialogFragment getInstance()
		{
			ProgressDialogFragment fragment = new ProgressDialogFragment();
			Bundle args = new Bundle();
			fragment.Arguments = args;
			return fragment;
		}
	}


}
