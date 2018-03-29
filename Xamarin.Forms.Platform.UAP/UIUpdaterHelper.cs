using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.ApplicationModel.Core;

namespace Xamarin.Forms.Platform.UAP
{
	public static class UIUpdaterHelper
	{
		public static void RunOnUIThread(VisualElement view, Action action)
		{
			System.Diagnostics.Debug.WriteLine("VisualElementTracker.UpdateVisibility " + view.IdWindow);
			string currentWindowId = GetCurrentWindowId();
			if (currentWindowId != String.Empty)
			{
				System.Diagnostics.Debug.WriteLine("VisualElementTracker.UpdateVisibility CoreWindow.CustomProperties idWindow could be found");
				if (!view.IdWindow.Equals(currentWindowId, StringComparison.InvariantCultureIgnoreCase))
				{
					System.Diagnostics.Debug.WriteLine("VisualElementTracker.UpdateVisibility idWindows dont match");
					Device.BeginInvokeOnMainThread(
						() =>
						{
							System.Diagnostics.Debug.WriteLine("VisualElementTracker.UpdateVisibility BeginInvokeOnMainThread on element context started");
							action();//frameworkElement.Visibility = view.IsVisible ? Visibility.Visible : Visibility.Collapsed;
						},
						view.IdWindow);
				}
				else
				{
					action();
				}
			}
		}

		public static string GetCurrentWindowId()
		{
			CoreApplication.GetCurrentView().CoreWindow.CustomProperties.TryGetValue("idWindow", out object currentCoreWindowId);
			return currentCoreWindowId != null ? currentCoreWindowId.ToString() : String.Empty;
		}
	}
}
