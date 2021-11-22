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

            if (entryCourseName.Text == "" || entryCourseName.Text == null)
            {
                DisplayAlert("Course", "Please enter a valid name", "ok");
            }
            else if (datePickerCourseStart.Date > DatePickerCourseEnd.Date)
            {
                DisplayAlert("Course", "Course start is after Course end", "ok");
            }
            else if (statusPicker.SelectedIndex == -1)
            {
                DisplayAlert("Course", "Please select course status", "ok");
            }
            else if (entryInstructorName.Text == "" || entryInstructorName.Text == null)
            {
                DisplayAlert("Course", "Please enter instructor name", "ok");
            }
            else if (entryInstructorPhone.Text == "" || entryInstructorPhone.Text == null) 
            {
                DisplayAlert("Course", "Please enter instructor phone", "ok");
            }
            else if (entryInstructorEmail.Text == "" || entryInstructorEmail.Text == null)
            {
                DisplayAlert("Course", "Please enter instructor email", "ok");
            }
            else if (entryNotes.Text == "" || entryNotes.Text == null)
            {
                DisplayAlert("Course", "Please enter notes, or type N/A", "ok");
            }
            else
            {


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
            statusPicker.SelectedIndex = 0;
            if (Courses.updateCourse == true)
            {
                var temp = Courses.indexD as CourseTable;
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



                Courses.indexD = null;

            }
        }
    }
}