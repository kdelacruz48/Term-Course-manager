using App1.Classes;
using SQLite;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App1
{
    public partial class App : Application
    {
        public static string FilePath;

        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new MainPage());
        }

        public App(string filePath)
        {
            InitializeComponent();

            MainPage = new NavigationPage(new MainPage());

            FilePath = filePath;
        }

        protected override void OnStart()
        {
            using (SQLiteConnection con = new SQLiteConnection(App.FilePath))
            {


                con.CreateTable<Table>();
                var table = con.Table<Table>().ToList();

                Table entry = new Table();
                entry.termName = "Term 1";
                entry.termStart = DateTime.Now.Date.ToShortDateString();
                entry.termEnd = DateTime.Now.AddDays(10).Date.ToShortDateString();

                if (table.Count == 0)
                {
                    con.Insert(entry);
                }

                con.CreateTable<CourseTable>();
                var table1 = con.Table<CourseTable>().ToList();

                CourseTable entry1 = new CourseTable();
                entry1.termId = 1;
                entry1.courseName = "course 1";
                entry1.status = "Active";
                entry1.courseStart = DateTime.Now.Date.ToShortDateString();
                entry1.courseEnd = DateTime.Now.Date.AddDays(10).ToShortDateString();
                entry1.instructorName = "Kyle Delacruz";
                entry1.instructorPhone = "253-732-7805";
                entry1.instructorEmail = "kdelac7@wgu.edu";
                entry1.notes = "Thank you for grading my Assessment!";
                entry1.oA = "OA";
                entry1.oAStart = DateTime.Now.Date.ToShortDateString();
                entry1.oAEnd = DateTime.Now.Date.AddDays(10).ToShortDateString();
                entry1.pA = "PA";
                entry1.paStart = DateTime.Now.Date.ToShortDateString();
                entry1.paEnd = DateTime.Now.Date.AddDays(10).ToShortDateString();

                if (table1.Count == 0)
                {
                    con.Insert(entry1);
                }
            }
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
