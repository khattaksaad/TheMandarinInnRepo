using HotelManager.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManager.DAO
{
    public class CompanyDAO
    {
        private static CompanyDAO instance;
        public static CompanyDAO Instance
        {
            get { if (instance == null) instance = new CompanyDAO(); return instance; }
            private set => instance = value;
        }

        private CompanyDAO() { }
        #region Method
        public bool InsertCompany(string name, string phone, string address, string email ,string companyRepName, string companyRepId, string companyRepContact)
        {
            string query = "USP_InsertCompany  @name , @phone , @address , @email , @repName , @repId , @repContactNumber";
            return DataProvider.Instance.ExecuteNoneQuery(query,new object[] { name, phone, address, email, companyRepName, companyRepId, companyRepContact })>0;
        }
        public Customer GetInfoByIdCard(string idCard)
        {
            //string query = "USP_IsIdCardExists @idCard";
            //Customer customer =new Customer(DataProvider.Instance.ExecuteQuery(query, new object[] { idCard }).Rows[0]);
            //return customer;
            return null;
        }


        //internal bool InsertCompany(Company company)
        //{
        //    //return InsertCompany(company.CompanyName, company.PhoneNumber, company.Address, company.CompanyRepName,
        //    //    company.CompanyRepId, company.CompanyRepContactNumber);
        //}


        //internal bool UpdateCompany(Customer customerNow, Customer customerPre)
        //{
        //    string query = "USP_UpdateCustomer @id , @customerName , @idCustomerType ," +
        //                    " @idCardNow , @address , @dateOfBirth , " +
        //                    "@phoneNumber , @email , @city , @sex , @nationality , @idCardPre";
        //    object[] parameter = new object[] {customerNow.Id, customerNow.Name, customerNow.IdCustomerType, customerNow.IdCard,
        //                            customerNow.Address, customerNow.DateOfBirth, customerNow.PhoneNumber, customerNow.Email, customerNow.City,
        //                            customerNow.Sex, customerNow.Nationality, customerPre.IdCard};
        //    return DataProvider.Instance.ExecuteNoneQuery(query, parameter) > 0;
        //}
        //public bool UpdateCustomer(int id,string name,string idCard,int idCustomerType, string phoneNumber, string email, string city,DateTime dateOfBirth,string address,string sex,string nationality)
        //{
        //    string query = "USP_UpdateCustomer_ @id , @name , @idCard , @idCustomerType , @phoneNumber , @email , @city, @dateOfBirth , @address , @sex , @nationality";
        //    return DataProvider.Instance.ExecuteNoneQuery(query, new object[] { id,name,idCard,idCustomerType,phoneNumber, email, city,dateOfBirth,address,sex,nationality})>0;
        //}

        internal DataTable LoadFullCompany()
        {
            string query = "USP_LoadFullCompany";
            return DataProvider.Instance.ExecuteQuery(query);
        }
        public DataRow Search(string name)
        {
            string query = "USP_SearchCompany @string";
            DataRowCollection rows =  DataProvider.Instance.ExecuteQuery(query, new object[] { name }).Rows;
            return rows?.Count > 0 ? rows[0] : null;
        }
        //public int GetIDCustomerFromBookRoom(int idReceiveRoom)
        //{
        //    string query = "USP_GetIDCustomerFromBookRoom @idReceiveRoom";
        //    return (int)DataProvider.Instance.ExecuteScalar(query, new object[] { idReceiveRoom });
        //}
        #endregion

    }
}
