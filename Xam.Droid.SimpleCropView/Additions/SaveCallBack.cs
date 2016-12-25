using System;

namespace Com.Isseiaoki.Simplecropview.Callback
{
	/// <summary>
	/// Save call back.
	/// </summary>
	public class SaveCallBack : Java.Lang.Object, ISaveCallback
	{ 
		Action _onError;
		Action<Android.Net.Uri> _onSuccess;

		/// <summary>
		/// Adds the error.
		/// </summary>
		/// <returns>The error.</returns>
		/// <param name="error">Error.</param>
		public ISaveCallback AddError(Action error)
		{
			this._onError = error;
			return this;
		}

		/// <summary>
		/// Adds the success.
		/// </summary>
		/// <returns>The success.</returns>
		/// <param name="success">Success.</param>
		public ISaveCallback AddSuccess(Action<Android.Net.Uri> success)
		{
			this._onSuccess = success;
			return this;
		}

		#region ICALLBACK
		public void OnError()
		{
			this._onError?.Invoke();
		}

		public void OnSuccess(Android.Net.Uri uri)
		{
			this._onSuccess?.Invoke(uri);
		}
		#endregion
	}

	
	
	
}
