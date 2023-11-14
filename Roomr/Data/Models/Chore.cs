using SQLite;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Roomr.Data.Models
{
    [SQLite.Table("chores")]
    public class Chore
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; } //Primary key
        public string Name { get; set; }

        public Chore (string name)
        {
            this.Name = name;
        }
    }
}
