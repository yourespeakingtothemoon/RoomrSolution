using SQLite;
using SQLiteNetExtensions.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Roomr.Data.Models
{
    [Table("people")]
    public class Person : INotifyPropertyChanged
    {
        public int id;
        public string name;
        public string username;
        public string password;
        public string contactInfo;
        public string city;
        public string region;
        public string country;
        public string profilePicture;
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; } //Primary key
        public string Name
        {
            get { return this.name;  }
            set { 
                this.name = value;
                RaisePropertyChanged("Name");
            }
        }
        public string Username
        {
            get { return this.username; }
            set
            {
                this.username = value;
                RaisePropertyChanged("Username");
            }
        }
        public string Password
        {
            get { return this.password; }
            set
            {
                this.password = value;
                RaisePropertyChanged("Password");
            }
        }
        public string ContactInfo
        {
            get { return this.contactInfo; }
            set
            {
                this.contactInfo = value;
                RaisePropertyChanged("Contact Info");
            }
        }
        public string City
        {
            get { return this.city; }
            set
            {
                this.city = value;
                RaisePropertyChanged("City");
            }
        }
        public string Region
        {
            get { return this.region; }
            set
            {
                this.region = value;
                RaisePropertyChanged("Region");
            }
        }
        public string Country
        {
            get { return this.country; }
            set
            {
                this.country = value;
                RaisePropertyChanged("Country");
            }
        }
        public string ProfilePicture
        {
            get { return this.profilePicture; }
            set
            {
                this.profilePicture = value;
                RaisePropertyChanged("Profile Picture");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void RaisePropertyChanged(string name)
        {
            if (PropertyChanged != null)
                this.PropertyChanged(this, new PropertyChangedEventArgs(name));
        }
    }
}
