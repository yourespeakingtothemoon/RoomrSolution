using SQLite;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Roomr.Data.Models
{
    [Table("hobbies")]
    public class Hobby
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Name { get; set; }

        public string icon { get; set; }
        public Hobby() {
      
        }

        public Hobby(string name)
        {
            Name = name;
            icon = "Resources/Images/Icons/" + name + ".png";
        }

        public override string ToString()
        {
            return "[" + Id + ": " + Name + "]";
        }
    }


    
    
}
