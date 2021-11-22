using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Xamarin.Essentials;
using App1.Classes;

namespace App1
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Summary : ContentPage
    {
        public static CourseTable course = new CourseTable();
        public Summary()
        {
            InitializeComponent();
        }

        private void ToolbarItem_Clicked(object sender, EventArgs e)
        {
            course.termId = MainPage.termIndex;
            course.courseName = entryCourseName.Text;
            course.courseStart = datePickerCourseStart.Date.ToShortDateString();
            course.courseEnd = DatePickerCourseEnd.Date.ToShortDateString();
            course.status = statusPicker.SelectedItem.ToString();
            course.instructorName = entryInstructorName.Text;
            course.instructorEmail = entryInstructorEmail.Text;
            course.instructorPhone = entryInstructorPhone.Text;
            course.notes = entryNotes.Text;

            using (SQLite.SQLiteConnection con = new SQLite.SQLiteConnection(App.FilePath))
            {
                con.CreateTable<CourseTable>();

                if (Courses.updateCourse == false)
                {
                    con.Insert(course);
                }

                else
                {
                    var temp = Courses.indexC as CourseTable;

                    con.Update(new CourseTable
                    {
                       courseId = temp.courseId,
                       termId = MainPage.termIndex,
                       courseName = entryCourseName.Text,
                       courseStart = datePickerCourseStart.Date.ToShortDateString(),
                       courseEnd = DatePickerCourseEnd.Date.ToShortDateString(),
                       status = statusPicker.SelectedItem.ToString(),
                       instructorName = entryInstructorName.Text,
                       instructorEmail = entryInstructorEmail.Text,
                       instructorPhone = entryInstructorPhone.Text,
                       notes = entryNotes.Text



                });
                }
            }

            Navigation.PushAsync(new Courses());
        }

        private async void shareButton_Clicked(object sender, EventArgs e)
        {
            await Share.RequestAsync(new ShareTextRequest
            {
                Text = entryNotes.Text,
                Title = "Share"
            }) ;
        }

        protected override void OnAppearing()
        {
            if (Courses.updateCourse == true)
            {
                var temp = Courses.indexC as CourseTable;
                entryCourseName.Text = temp.courseName;

                DateTime start = DateTime.Parse(temp.courseStart);
                DateTime end = DateTime.Parse(temp.courseEnd);

                datePickerCourseStart.Date = start;
                DatePickerCourseEnd.Date = end;

                statusPicker.SelectedItem = temp.status;
                entryInstructorName.Text = temp.instructorName;
                entryInstructorPhone.Text = temp.instructorPhone;
                entryInstructorEmail.Text = temp.instructorEmail;
                entryNotes.Text = temp.notes;

                

            }
        }
    }
}