using System;
using Android.Graphics;

namespace Com.Isseiaoki.Simplecropview.Callback
{
	/// <summary>
	/// Crop call back.
	/// </summary>
	public class CropCallBack : Java.Lang.Object, ICropCallback
	{
		Action _onError;
		Action<Bitmap> _onSuccess;


		/// <summary>
		/// Adds the error.
		/// </summary>
		/// <returns>The error.</returns>
		/// <param name="error">Error.</param>
		public ICropCallback AddError(Action error)
		{
			this._onError = error;
			return this;
		}

		/// <summary>
		/// Adds the success.
		/// </summary>
		/// <returns>The success.</returns>
		/// <param name="success">Success.</param>
		public ICropCallback AddSuccess(Action<Bitmap> success)
		{
			this._onSuccess = success;
			return this;
		}


		#region ICALLBACK
		public void OnError()
		{
			this._onError?.Invoke();
		}

		public void OnSuccess(Bitmap bitmap)
		{
			this._onSuccess?.Invoke(bitmap);
		}
		#endregion
	}

	

	

}
