using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Core;

namespace Xamarin.Forms.Platform.UWP
{
	internal class WindowsDispatcher : WindowsBaseDispatcher
	{
		public WindowsDispatcher(CoreDispatcher dispatcher) : base(dispatcher)
		{
		}
	}
}
