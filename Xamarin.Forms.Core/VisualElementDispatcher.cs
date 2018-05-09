using System;
using System.Collections.Generic;
using System.Text;

namespace Xamarin.Forms
{
    public class VisualElementDispatcher
    {

		Guid _windowId;

		internal VisualElementDispatcher(Guid windowId)
		{
			_windowId = windowId;
		}

		public void BeginInvokeOnMainThread(Action action)
		{
			Device.BeginInvokeOnMainThread(action, _windowId);
		}

	}
}
