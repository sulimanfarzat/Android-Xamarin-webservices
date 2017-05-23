using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Plugin.RestClient;
using XamTest.Models;

namespace XamTest.Services
{
	public class EmployeesServices
	{

		public async Task<List<Employee>> GetEmployeesAsync()
		{

			RestClient<Employee> restClient = new RestClient<Employee>();

			var employeesList = await restClient.GetAsync();

			return employeesList;
		}
		//	var list = new List<Employee>
		//	{
		//		new Employee
		//		{
		//			Name = "Suliman",
		//			Department = "PM"
		//		},
		//		new Employee
		//		{
		//			Name = "Daniel",
		//			Department = "PM"
		//		},
		//		new Employee
		//		{
		//			Name = "Jochen",
		//			Department = "PM"
		//		},
		//	};

		//	return list;


		//post
		public async Task PostEmployeesAsync(Employee employee)
		{

			RestClient<Employee> restClient = new RestClient<Employee>();

			var employeesList = await restClient.PostAsync(employee);

		}

		//put
		public async Task PutEmployeesAsync(int id, Employee employee)
		{

			RestClient<Employee> restClient = new RestClient<Employee>();

			var employeesList = await restClient.PutAsync(id, employee);

		}
		//delete
		public async Task DeleteEmployeesAsync(int id)
		{

			RestClient<Employee> restClient = new RestClient<Employee>();

			var employeesList = await restClient.DeleteAsync(id);

		}

		//search
		public async Task<List<Employee>> GetEmployeesByKeywordAsync(string keyword)
		{

			RestClient<Employee> restClient = new RestClient<Employee>();

			var employeesList = await restClient.GetByKeywordAsync(keyword);

			return employeesList;
		}

		internal Task GetEmployeesByKeywordAsync(int id, Employee selectedEmployee)
		{
			throw new NotImplementedException();
		}
	}
}
