using SQLite;
using SQLiteNetExtensions.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Roomr.Data.Models
{
    [Table("people")]
    public class Person
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; } //Primary key
        public string Name { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string ContactInfo { get; set; }
        public string City { get; set; }
        public string Region { get; set; }
        public string Country { get; set; }
        public string ProfilePicture { get; set; }

        public Person() { }

        public Person(string username, string password)
        {
            Username = username;
            Password = password;
        }

        public Person(string name, string username, string password, string contactInfo, string city, string region, string country, string profilePicture)
        {
            Name = name;
            Username = username;
            Password = password;
            ContactInfo = contactInfo;
            City = city;
            Region = region;
            Country = country;
            ProfilePicture = profilePicture;
        }

        public override string ToString()
        {
            return "Id: [" + Id + "] Name/Username: [" + Name + "/" + Username + "] Pass: [" + Password + "] Location: [" + City + ", " + Region + ", " + Country + "] Profile Picture URL: [" + ProfilePicture + "]";
        }
    }
}