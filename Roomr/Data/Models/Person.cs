using SQLite;
using SQLiteNetExtensions.Attributes;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
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
        public double Latitude { get; set; } = 0;
        public double Longitude { get; set; } = 0;
        public string ProfilePicture { get; set; }

        public Person() { }

        public Person(string username, string password)
        {
            Name = null;
            Username = username;
            Password = password;
            ContactInfo = null;
            City = null;
            Region = null;
            Country = null;
            ProfilePicture = null;
        }

        public Person(string name, string contactInfo, string city, string region, string country, string profilePicture)
        {
            Name = name;
            ContactInfo = contactInfo;
            City = city;
            Region = region;
            Country = country;
            ProfilePicture = profilePicture;
        }

        public Person(string username, string password, string name, string contactInfo, string city, string region, string country, string profilePicture)
        {
            Name = name;
            Username = username;
            Password = password;
            Name = name;
            ContactInfo = contactInfo;
            City = city;
            Region = region;
            Country = country;
            ProfilePicture = profilePicture;
        }
    

        public void postSignUpSetup(string name, string contactInfo, string city, string region, string country, string profilePicture)
        {
            Name = name;
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