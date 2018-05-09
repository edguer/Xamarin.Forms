using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms.Internals;

namespace Xamarin.Forms
{
	public interface IDispatcher
	{
		bool IsInvokeRequired { get; }

		void BeginInvokeOnMainThread(Action action);

		Ticker CreateTicker();
	}
}
