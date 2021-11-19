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
        public string termStart { get; set; }              //you will probably have to change the types for the pickers
        public string termEnd { get; set; }
        public string courseName1 { get; set; }
        public string status1 { get; set; }
        public int courseStart1 { get; set; }
        public int courseEnd1 { get; set; }
        public string instructorName1 { get; set; }
        [MaxLength(10)]
        public string instructorPhone1 { get; set; }
        public string instructorEmail1 { get; set; }
        public string notes1 { get; set; }
        public string oA1 { get; set; }
        public string pA1 { get; set; }
        public string courseName2 { get; set; }
        public string status2 { get; set; }
        public int courseStart2 { get; set; }
        public int courseEnd2 { get; set; }
        public string instructorName2 { get; set; }
        [MaxLength(10)]
        public string instructorPhone2 { get; set; }
        public string instructorEmail2 { get; set; }
        public string notes2 { get; set; }
        public string oA2 { get; set; }
        public string pA2 { get; set; }
        public string courseName3 { get; set; }
        public string status3 { get; set; }
        public int courseStart3 { get; set; }
        public int courseEnd3 { get; set; }
        public string instructorName3 { get; set; }
        [MaxLength(10)]
        public string instructorPhone3 { get; set; }
        public string instructorEmail3 { get; set; }
        public string notes3 { get; set; }
        public string oA3 { get; set; }
        public string pA3 { get; set; }
        public string courseName4 { get; set; }
        public string status4 { get; set; }
        public int courseStart4 { get; set; }
        public int courseEnd4 { get; set; }
        public string instructorName4 { get; set; }
        [MaxLength(10)]
        public string instructorPhone4 { get; set; }
        public string instructorEmail4 { get; set; }
        public string notes4 { get; set; }
        public string oA4 { get; set; }
        public string pA4 { get; set; }
        public string courseName5 { get; set; }
        public string status5 { get; set; }
        public int courseStart5 { get; set; }
        public int courseEnd5 { get; set; }
        public string instructorName5 { get; set; }
        [MaxLength(10)]
        public string instructorPhone5 { get; set; }
        public string instructorEmail5 { get; set; }
        public string notes5 { get; set; }
        public string oA5 { get; set; }
        public string pA5 { get; set; }
        public string courseName6 { get; set; }
        public string status6 { get; set; }
        public int courseStart6 { get; set; }
        public int courseEnd6 { get; set; }
        public string instructorName6 { get; set; }
        [MaxLength(10)]
        public string instructorPhone6 { get; set; }
        public string instructorEmail6 { get; set; }
        public string notes6 { get; set; }
        public string oA6 { get; set; }
        public string pA6 { get; set; }

        public Table()
        {

        }

    }


    
}
