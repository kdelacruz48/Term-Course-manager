using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace App1.Classes
{
    class CourseTable
    {
        [PrimaryKey, AutoIncrement]
        public int courseId { get; set; }
        public int termId { get; set; }
        public string courseName { get; set; }
        public string status { get; set; }
        public int courseStart { get; set; }
        public int courseEnd { get; set; }
        public string instructorName { get; set; }
        [MaxLength(10)]
        public string instructorPhone { get; set; }
        public string instructorEmail { get; set; }
        public string notes { get; set; }
        public string oA { get; set; }
        public string pA { get; set; }

        public CourseTable()
        {

        }
    }
}
