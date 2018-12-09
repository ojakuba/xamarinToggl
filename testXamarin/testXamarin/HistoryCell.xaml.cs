using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using testXamarin.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace testXamarin
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class HistoryCell : ViewCell
	{
		public HistoryCell (HistoryRowPresentationData data)
		{
			InitializeComponent ();
            BindingContext = data;
		}
	}
}