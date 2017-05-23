using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XamTest.ViewModels;

namespace XamTest.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class NewEmployeePage : ContentPage
	{
		public NewEmployeePage()
		{
			InitializeComponent();
		}

		//ربط اضافة التعديل في صفحة نيو
		public NewEmployeePage(MainViewModel mainViewModel)
		{
			InitializeComponent();

			BindingContext = mainViewModel;
		}
	}
}