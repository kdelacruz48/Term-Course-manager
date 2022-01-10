using App1.Classes;
using Plugin.LocalNotifications;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App1
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Assesments : ContentPage
    {
        public static CourseTable course = new CourseTable();

        public Assesments()
        {
            InitializeComponent();
        }

        private void ToolbarItem_Clicked(object sender, EventArgs e)
        {

            if (datePickerOAStart.Date > DatePickerOAEnd.Date || datePickerPAStart.Date > DatePickerPAEnd.Date)
            {
                DisplayAlert("Assesment", "start date cannot occur after end date", "ok");
            }
            else
            {
                using (SQLite.SQLiteConnection con = new SQLite.SQLiteConnection(App.FilePath))
                {
                    con.CreateTable<CourseTable>();

                    var temp = Courses.indexA as CourseTable;

                    con.Update(new CourseTable
                    {
                        courseId = temp.courseId,

                        termId = temp.termId,
                        courseName = temp.courseName,
                        courseStart = temp.courseStart,
                        courseEnd = temp.courseEnd,
                        status = temp.status,
                        instructorName = temp.instructorName,
                        instructorEmail = temp.instructorName,
                        instructorPhone = temp.instructorName,
                        notes = temp.notes,



                        oA = entryOA.Text,
                        oAStart = datePickerOAStart.Date.ToShortDateString(),
                        oAEnd = DatePickerOAEnd.Date.ToShortDateString(),
                        pA = entryPA.Text,
                        paStart = datePickerPAStart.Date.ToShortDateString(),
                        paEnd = DatePickerPAEnd.Date.ToShortDateString()




                    });

                }

                Navigation.PushAsync(new Courses());
            }
        }


        protected override void OnAppearing()
        {
            
            var temp = Courses.indexA as CourseTable;

            if (temp.oAStart != null)
            {
                entryOA.Text = temp.oA;

                DateTime start = DateTime.Parse(temp.oAStart);
                DateTime end = DateTime.Parse(temp.oAEnd);

                datePickerOAStart.Date = start;
                DatePickerOAEnd.Date = end;

                entryPA.Text = temp.pA;

                DateTime start1 = DateTime.Parse(temp.paStart);
                DateTime end1 = DateTime.Parse(temp.paEnd);

                datePickerPAStart.Date = start1;
                DatePickerPAEnd.Date = end1;

            }
        }

        private void deleteAssesmentButton_Clicked(object sender, EventArgs e)
        {
            using (SQLite.SQLiteConnection con = new SQLite.SQLiteConnection(App.FilePath))
            {
                con.CreateTable<CourseTable>();

                var temp = Courses.indexA as CourseTable;

                con.Update(new CourseTable
                {
                    courseId = temp.courseId,

                    termId = temp.termId,
                    courseName = temp.courseName,
                    courseStart = temp.courseStart,
                    courseEnd = temp.courseEnd,
                    status = temp.status,
                    instructorName = temp.instructorName,
                    instructorEmail = temp.instructorName,
                    instructorPhone = temp.instructorName,
                    notes = temp.notes,


                    oA = null,
                    oAStart = null,
                    oAEnd = null,
                    pA = null,
                    paStart = null,
                    paEnd = null

                });

            }

            Navigation.PushAsync(new Courses());
        }

        private void Notifications_Clicked(object sender, EventArgs e)
        {

            if (datePickerOAStart.Date > DatePickerOAEnd.Date || datePickerPAStart.Date > DatePickerPAEnd.Date)
            {
                DisplayAlert("Assesment", "start date cannot occur after end date", "ok");
            }
            else
            {
                using (SQLite.SQLiteConnection con = new SQLite.SQLiteConnection(App.FilePath))
                {
                    con.CreateTable<CourseTable>();

                    var temp = Courses.indexA as CourseTable;

                    con.Update(new CourseTable
                    {
                        courseId = temp.courseId,

                        termId = temp.termId,
                        courseName = temp.courseName,
                        courseStart = temp.courseStart,
                        courseEnd = temp.courseEnd,
                        status = temp.status,
                        instructorName = temp.instructorName,
                        instructorEmail = temp.instructorName,
                        instructorPhone = temp.instructorName,
                        notes = temp.notes,



                        oA = entryOA.Text,
                        oAStart = datePickerOAStart.Date.ToShortDateString(),
                        oAEnd = DatePickerOAEnd.Date.ToShortDateString(),
                        pA = entryPA.Text,
                        paStart = datePickerPAStart.Date.ToShortDateString(),
                        paEnd = DatePickerPAEnd.Date.ToShortDateString()

                    });
                }
                var oATime = DatePickerOAEnd.Date.ToShortDateString();
                DateTime end = DateTime.Parse(oATime);
                var endD = end.ToShortDateString();
                var paTime = DatePickerPAEnd.Date.ToShortDateString();
                DateTime end1 = DateTime.Parse(oATime);
                var endD1 = end.ToShortDateString();

                if (entryOA.Text == "" && entryPA.Text == "" || entryOA.Text == null && entryPA.Text == null)
                {
                    DisplayAlert("Assesment", "No Assesment saved for OA or PA", "ok");
                }
                else if (entryOA.Text == "" && entryPA.Text != "" || entryOA.Text == null && entryPA.Text != null)
                {
                    DisplayAlert("Assesment", "PA notification set for " + endD1, "ok");
                    CrossLocalNotifications.Current.Show("Notification", "PA due", 2, end1);
                }
                else if (entryOA.Text != "" && entryPA.Text == "" || entryOA.Text != null && entryPA.Text == null)
                {
                    DisplayAlert("Assesment", "OA notification set for " + endD, "ok");
                    CrossLocalNotifications.Current.Show("Notification", "OA due", 1, end);
                }

                else
                {
                    DisplayAlert("Assesment", "OA notification set for " + endD + " PA notification set for " + endD1, "ok");
                    CrossLocalNotifications.Current.Show("Notification", "OA due", 1, end);
                    CrossLocalNotifications.Current.Show("Notification", "PA due", 2, end1);
                }
            }

            
         
        }
    }
    
}