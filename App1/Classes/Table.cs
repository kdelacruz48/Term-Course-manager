using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace App1.Classes
{

    

    public class Table
    {
        [PrimaryKey,AutoIncrement]
        public int iD { get; set; }
        public string termName { get; set; }
        public string termStart { get; set; }           
        public string termEnd { get; set; }
        
        public Table()
        {

        }

    }


    
}
