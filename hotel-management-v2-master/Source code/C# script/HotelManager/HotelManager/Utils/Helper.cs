using HotelManager.DAO;
using HotelManager.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManager.Utils
{
    internal static class Helper
    {
        static DataTable dataTable = CustomerDAO.Instance.LoadFullCustomer();
        static DataTable dataTable1 = CompanyDAO.Instance.LoadFullCompany();

        public static string GetCustomerName(int id, int customerType)
        {
            List<Customer> list = new List<Customer>();
            List<Company> companyList = new List<Company>();
            foreach(DataRow row in dataTable.Rows)
            {
                Customer customer = new Customer(row);
                list.Add(customer);
            }
            foreach (DataRow row in dataTable1.Rows)
            {
                Company company = new Company(row);
                companyList.Add(company);
            }
            if (customerType == 0)
            {
                return list.Find(p=>p.Id == id)?.Name;
            }
            else
            {
                return companyList.Find(p => p.Id == id).CompanyName;
            }
        }
    }
}
