using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using XamTest.Models;
using XamTest.ViewModels;
using XamTest.Views;

namespace XamTest
{
	public partial class MainPage : ContentPage
	{
		public MainPage()
		{
			InitializeComponent();
		}

		//زر اضافة بيانات
		private void Button_Clicked(object sender, EventArgs e)
		{
			Navigation.PushAsync(new NewEmployeePage());
		}

		//اضافة خاصية التعديل في القائمة
		private async void ListView_ItemTapped(object sender, ItemTappedEventArgs e)
		{
			var employee = EmployeesListView.SelectedItem as Employee;

			if (employee != null)
			{
				var mainViewModel = BindingContext as MainViewModel;

				if (mainViewModel != null)
				{
					mainViewModel.SelectedEmployee = employee;

					await Navigation.PushAsync(new NewEmployeePage(mainViewModel)); //ربط مع صفحة نيو
				}
			}
		}

		//اضافة زر بحث
		private async void Button_Clicked_1(object sender, EventArgs e)
		{

			var mainViewModel = BindingContext as MainViewModel;

			if (mainViewModel != null)
			{
				await Navigation.PushAsync(new SearchPage(mainViewModel));
			}
		}
	}
}
