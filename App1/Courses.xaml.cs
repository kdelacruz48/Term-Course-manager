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
        public Courses()
        {
            InitializeComponent();
        }

        private void ToolbarItem_Clicked(object sender, EventArgs e)
        {
            
        }

        private void addCourseButton_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new Summary());
        }

        private void updateCourseButton_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new Summary());
        }

        private void deleteCourseButton_Clicked(object sender, EventArgs e)
        {

        }

        private void assesmentsButton_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new Assesments());
        }
    }
}