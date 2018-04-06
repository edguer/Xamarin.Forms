using System;
using System.ComponentModel;
using Windows.ApplicationModel;
using Windows.ApplicationModel.Core;

namespace Xamarin.Forms.Platform.UWP
{
	public abstract class WindowsBasePage : Windows.UI.Xaml.Controls.Page
	{

		public Application Application { get; private set; }

		public WindowsBasePage()
		{
			if (!Windows.ApplicationModel.DesignMode.DesignModeEnabled)
			{
				Windows.UI.Xaml.Application.Current.Suspending += OnApplicationSuspending;
				Windows.UI.Xaml.Application.Current.Resuming += OnApplicationResuming;
			}
		}

		protected Platform Platform { get; private set; }

		protected abstract Platform CreatePlatform();

		protected void LoadApplication(Application application)
		{
			if (application == null)
				throw new ArgumentNullException("application");

			SaveDispatcher(application);
			Application.SetCurrentApplication(application);
			this.Application = application;
			Platform = CreatePlatform();
			Platform.SetPage(application.MainPage, application);
			this.Application.PropertyChanged += OnApplicationPropertyChanged;

			

			this.Application.SendStart();
		}

		/// <summary>
		/// Used to set the current dispatcher to List of Dispatchers.
		/// </summary>
		void SaveDispatcher(Application application)
		{
			Forms.Dispatchers.AddOrUpdate(application.WindowId, this.Dispatcher, (key, oldValue) => this.Dispatcher);
		}

		void OnApplicationPropertyChanged(object sender, PropertyChangedEventArgs e)
		{
			if (e.PropertyName == "MainPage")
				Platform.SetPage(this.Application.MainPage, this.Application);
		}

		void OnApplicationResuming(object sender, object e)
		{
			this.Application.SendResume();
		}

		async void OnApplicationSuspending(object sender, SuspendingEventArgs e)
		{
			SuspendingDeferral deferral = e.SuspendingOperation.GetDeferral();
			try
			{
				await this.Application.SendSleepAsync();
			}
			finally
			{
				deferral.Complete();
			}
		}
	}
}