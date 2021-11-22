using App1.Classes;
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
        public static object indexC;
        public static object indexD;


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
            updateCourse = false;
            Navigation.PushAsync(new Summary());
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
                        courseListVeiw.SelectedItem = table[0];
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
            Navigation.PushAsync(new Assesments());
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            courseListVeiw.SelectedItem = null;
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
                    courseListVeiw.SelectedItem = table[0];
                }
                else
                {
                    courseListVeiw.SelectedItem = null;
                }
            }


        }
    }
}