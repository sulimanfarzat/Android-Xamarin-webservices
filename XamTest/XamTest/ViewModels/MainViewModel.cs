using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using XamTest.Models;
using XamTest.Services;
using Xamarin.Forms;

namespace XamTest.ViewModels
{
	public class MainViewModel : INotifyPropertyChanged
	{
		//list
		private List<Employee> _employeesList;
		private Employee _selectedEmployee = new Employee();
		private List<Employee> _selectedEmployees;
		private string _keyword;


		//entry text search
		public string Keyword
		{
				get { return _keyword;
				}
				set
			{
					_keyword = value;
					OnPropertyChanged();
				}
		}

		public List<Employee> EmployeesList
		{
			get { return _employeesList; }
			set
			{
				_employeesList = value;
				OnPropertyChanged();
			}
		}

		//search
		public List<Employee> SearchedEmployees
		{
			get { return _selectedEmployees; }
			set
			{
				_selectedEmployees = value;
				OnPropertyChanged();
			}
		}

		//select
		public Employee SelectedEmployee
		{
			get { return _selectedEmployee; }
			set
			{
				_selectedEmployee = value;
				OnPropertyChanged();
			}
		}
		//command button post
		public Command PostCommand
		{
			get
			{
				return new Command(async () =>
				{
					var employeesServices = new EmployeesServices();
					await employeesServices.PostEmployeesAsync(_selectedEmployee);
				});
			}
		}

		//command button put
		public Command PutCommand
		{
			get
			{
				return new Command(async () =>
				{
					var employeesServices = new EmployeesServices();
					await employeesServices.PutEmployeesAsync(_selectedEmployee.Id, _selectedEmployee);
				});
			}
		}

		//command button delet
		public Command DeleteCommand
		{
			get
			{
				return new Command(async () =>
				{
					var employeesServices = new EmployeesServices();
					await employeesServices.DeleteEmployeesAsync(_selectedEmployee.Id);
				});
			}
		}

		//command button search
		public Command SearchCommand
		{
			get
			{
				return new Command(async () =>
				{
					var employeesServices = new EmployeesServices();
					SearchedEmployees = await employeesServices.GetEmployeesByKeywordAsync(_keyword);
				});
			}
		}


		//update muss geändert
		public MainViewModel()
		{
			InitializeDataAsync();
		}

		private async Task InitializeDataAsync()
		{
			var employeesServices = new EmployeesServices();

			EmployeesList = await employeesServices.GetEmployeesAsync();
		}

		//changed
		public event PropertyChangedEventHandler PropertyChanged;

		protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
		{
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
		}
	}
}
