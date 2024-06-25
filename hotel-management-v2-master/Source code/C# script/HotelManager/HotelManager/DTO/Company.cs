using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManager.DTO
{
    public class Company
    {
        private int id;
        private string companyName;
        private string address;
        private string phoneNumber;
        private string email;
        private string companyRepName;
        private string companyRepId;
        private string companyRepContactNumber;

        public Company()
        {

        }
        public Company(int id,string companyName, string address, string phoneNumber, string email, string companyRepName, string companyRepId, string companyRepContactNumber)
        {
            this.Id = id;
            this.companyName = companyName;
            this.Address = address;
            this.PhoneNumber = phoneNumber;
            this.companyRepId = companyRepId;
            this.companyRepContactNumber = companyRepContactNumber;
            this.email = email;
            this.companyRepName = companyRepName; 
        }
        public Company(DataRow row)
        {
            this.Id= (int)row["id"];
            this.companyName = row["name"].ToString();
            this.Address = row["address"].ToString();
            this.PhoneNumber = row["phone"].ToString();
            this.companyRepId = row["repId"].ToString();
            this.companyRepContactNumber = row["repContactNumber"].ToString();
            this.email = row["email"].ToString();
            this.companyRepName = row["repName"].ToString();
        }
        public override bool Equals(object obj)
        {
            return this.Equals(obj as Company);
        }
        public bool Equals(Company companyPre)
        {
            if (companyPre == null)
                return false;
            if (this.Id != companyPre.Id) return false;
            if (this.email != companyPre.email) return false;
            if (this.companyName != companyPre.companyName) return false;
            if (this.address != companyPre.address) return false;
            if (this.phoneNumber != companyPre.phoneNumber) return false;
            return true;
        }
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public string Address { get => address; set => address = value; }
        public string PhoneNumber { get => phoneNumber; set => phoneNumber = value; }
        public int Id { get => id; set => id = value; }
        public string Email { get => email; set => email = value; }
        public string CompanyName { get => companyName; set => companyName = value; }
        public string CompanyRepName { get => companyRepName; set => companyRepName = value; }
        public string CompanyRepId { get => companyRepId; set => companyRepId = value; }
        public string CompanyRepContactNumber { get => companyRepContactNumber; set => companyRepContactNumber = value; }
    }
}
