using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Roomr.Data.Models
{
    [Table("quiethours")]
    public class QuietHours
    {
        [SQLiteNetExtensions.Attributes.ForeignKey(typeof(Person))]
        public int PersonId { get; set; } //Foreign key to Person
        public bool Zero { get; set; }
        public bool One { get; set; }
        public bool Two { get; set; }
        public bool Three { get; set; }
        public bool Four { get; set; }
        public bool Five { get; set; }
        public bool Six { get; set; }
        public bool Seven { get; set; }
        public bool Eight { get; set; }
        public bool Nine { get; set; }
        public bool Ten { get; set; }
        public bool Eleven { get; set; }
        public bool Twelve { get; set; }
        public bool Thirteen { get; set; }
        public bool Fourteen { get; set; }
        public bool Fifteen { get; set; }
        public bool Sixteen { get; set; }
        public bool Seventeen { get; set; }
        public bool Eighteen { get; set; }
        public bool Nineteen { get; set; }
        public bool Twenty { get; set; }
        public bool TwentyOne { get; set; }
        public bool TwentyTwo { get; set; }
        public bool TwentyThree { get; set; }

        public QuietHours() { }


        public override string ToString() 
        {
            string result = "";
        
                if (Zero) result += "12 AM, ";
                if (One) result += "1 AM, ";
                if (Two) result += "2 AM, ";
                if (Three) result += "3 AM, ";
                if (Four) result += "4 AM, ";
                if (Five) result += "5 AM, ";
                if (Six) result += "6 AM, ";
                if (Seven) result += "7 AM, ";
                if (Eight) result += "8 AM, ";
                if (Nine) result += "9 AM, ";
                if (Ten) result += "10 AM, ";
                if (Eleven) result += "11 AM, ";
                if (Twelve) result += "12 PM, ";
                if (Thirteen) result += "1 PM, ";
                if (Fourteen) result += "2 PM, ";
                if (Fifteen) result += "3 PM, ";
                if (Sixteen) result += "4 PM, ";
                if (Seventeen) result += "5 PM, ";
                if (Eighteen) result += "6 PM, ";
                if (Nineteen) result += "7 PM, ";
                if (Twenty) result += "8 PM, ";
                if (TwentyOne) result += "9 PM, ";
                if (TwentyTwo) result += "10 PM, ";
                if (TwentyThree) result += "11 PM, ";

                result = result.Substring(0, result.Length - 2);

            return result;

            }
        
    }
}
