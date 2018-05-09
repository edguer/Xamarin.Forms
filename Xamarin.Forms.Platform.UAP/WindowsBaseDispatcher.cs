using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Core;
using Xamarin.Forms.Internals;

namespace Xamarin.Forms.Platform.UWP
{
	internal class WindowsBaseDispatcher : IDispatcher
	{
		readonly CoreDispatcher _dispatcher;

		protected WindowsBaseDispatcher(CoreDispatcher dispatcher)
		{
			if (dispatcher == null)
				throw new ArgumentNullException(nameof(dispatcher));

			_dispatcher = dispatcher;
		}

		public void BeginInvokeOnMainThread(Action action)
		{
			_dispatcher.RunAsync(CoreDispatcherPriority.Normal, () => action()).WatchForError();
		}

		public bool IsInvokeRequired => !_dispatcher.HasThreadAccess;

		public Ticker CreateTicker()
		{
			return new WindowsTicker(this);
		}
	}
}
