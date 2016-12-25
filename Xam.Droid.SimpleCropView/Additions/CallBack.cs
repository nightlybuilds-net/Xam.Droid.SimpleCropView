using System;
namespace Com.Isseiaoki.Simplecropview.Callback
{
	public class CallBack : Java.Lang.Object, ICallBack
	{
		Action _onError;
		Action _onSuccess;


		/// <summary>
		/// Adds the error.
		/// </summary>
		/// <returns>The error.</returns>
		/// <param name="error">Error.</param>
		public ICallBack AddError(Action error)
		{
			this._onError = error;
			return this;
		}

		/// <summary>
		/// Adds the success.
		/// </summary>
		/// <returns>The success.</returns>
		/// <param name="success">Success.</param>
		public ICallBack AddSuccess(Action success)
		{
			this._onSuccess = success;
			return this;
		}


		#region ICALLBACK
		public void OnError()
		{
			this._onError?.Invoke();
		}

		public void OnSuccess()
		{
			this._onSuccess?.Invoke();
		}
		#endregion
	}

	public partial interface ICallBack { }
}
