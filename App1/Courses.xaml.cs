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
    public partial class Courses : ContentPage
    {
        public static bool updateCourse;
        public static object indexA;
        public static object indexC;
        public static object indexD;
        public static object indexN;
        


        public Courses()
        {
            InitializeComponent();
        }

        private void ToolbarItem_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new MainPage());
        }

        private void addCourseButton_Clicked(object sender, EventArgs e)
        {
            using (SQLiteConnection con = new SQLiteConnection(App.FilePath))
            {
                con.CreateTable<CourseTable>();
                var table = con.Table<CourseTable>().ToList();
                List<CourseTable> tempList = new List<CourseTable>();
                foreach (var item in table)
                {
                    if (item.termId == MainPage.termIndex)
                    {
                        tempList.Add(item);
                    }
                }

                if (tempList.Count >= 6)
                {
                    DisplayAlert("Course", "Term already has 6 courses", "ok");
                }
                else
                {
                    updateCourse = false;
                    Navigation.PushAsync(new Summary());
                    
                }

            }
        }

        private void updateCourseButton_Clicked(object sender, EventArgs e)
        {
            if (courseListVeiw.SelectedItem == null)
            {
                DisplayAlert("Course", "Please add a course", "ok");
            }
            else
            {
                updateCourse = true;
                indexC = courseListVeiw.SelectedItem;
                indexD = indexC;
                courseListVeiw.SelectedItem = null;
                Navigation.PushAsync(new Summary());
            }
        }

        private void deleteCourseButton_Clicked(object sender, EventArgs e)
        {
            using (SQLite.SQLiteConnection con = new SQLite.SQLiteConnection(App.FilePath))
            {

                var temp = courseListVeiw.SelectedItem as CourseTable;
                if (courseListVeiw.SelectedItem == null)
                {
                    DisplayAlert("Course", "no courses to delete", "ok");
                }

                else
                {
                    var id = temp.courseId;



                    con.Delete<CourseTable>(temp.courseId);

                    con.CreateTable<CourseTable>();
                    var table = con.Table<CourseTable>().ToList();
                    List<CourseTable> tempList = new List<CourseTable>();
                    foreach (var item in table)
                    {
                        if (item.termId == MainPage.termIndex)
                        {
                            tempList.Add(item);
                        }
                    }

                    courseListVeiw.ItemsSource = tempList;

                    if (tempList.Count > 0)
                    {
                        courseListVeiw.SelectedItem = tempList[0];
                    }
                    else
                    {
                        courseListVeiw.SelectedItem = null;
                    }
                }
            }
        }
        private void assesmentsButton_Clicked(object sender, EventArgs e)
        {
            if (courseListVeiw.SelectedItem == null)
            {
                DisplayAlert("Course", "Please select a course to add or update an assesment", "ok");
            }

            else
            {
                indexA = courseListVeiw.SelectedItem;

                Navigation.PushAsync(new Assesments());
            }
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            
            using (SQLiteConnection con = new SQLiteConnection(App.FilePath))
            {
                con.CreateTable<CourseTable>();
                var table = con.Table<CourseTable>().ToList();
                List<CourseTable> tempList = new List<CourseTable>();
                foreach (var item in table)
                {
                    if(item.termId == MainPage.termIndex)
                    {
                        tempList.Add(item);
                    }
                }

                courseListVeiw.ItemsSource = tempList;

                if (tempList.Count > 0)
                {
                    courseListVeiw.SelectedItem = tempList[0];
                }
                else
                {
                    courseListVeiw.SelectedItem = null;
                }
            }


        }

        private void notificationButton_Clicked(object sender, EventArgs e)
        {

            indexN = courseListVeiw.SelectedItem;
            var indexN1 = indexN as CourseTable;

            if (indexN1 != null)
            {

                DateTime endDay = DateTime.Parse(indexN1.courseEnd);


                if (indexN1.courseEnd == "" || indexN1.courseEnd == null)
                {
                    DisplayAlert("Assesment", "Notification not set for course", "ok");
                }
                else
                {
                    DisplayAlert("Assesment", "Notification set for " + indexN1.courseName + " for " + indexN1.courseEnd, "ok");
                    CrossLocalNotifications.Current.Show("Notification", "PA due", 2, endDay);
                }
            }

            else 
            {
                DisplayAlert("notification", "No course available to set notifications for", "ok");
            }
        }
    }
}