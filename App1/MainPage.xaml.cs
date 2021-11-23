using App1.Classes;
using SQLite;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;


namespace App1
{
    public partial class MainPage : ContentPage
    {
        public static bool updateTerm;
        public static bool deleteTerm;
        public static object temp;
        public static object index;
        public static object deleteIndex;
        public static int termIndex;
        public static object tempC;
      

        public MainPage()
        {
            InitializeComponent();
        }

        private void ToolbarItem_Clicked(object sender, EventArgs e)
        {
            
        }

        private void ToolbarItem_Clicked_1(object sender, EventArgs e)
        {
           
        }

        private void addTermButton_Clicked(object sender, EventArgs e)
        {
            updateTerm = false;
            Navigation.PushAsync(new AUTerm());
        }

        private void updateTermButton_Clicked(object sender, EventArgs e)
        {

            if (termListVeiw.SelectedItem != null)
            {
                index = termListVeiw.SelectedItem;
                Navigation.PushAsync(new AUTerm());
                updateTerm = true;
            }
            else
            {
                DisplayAlert("Term", "Please select term", "ok");
            }            
  
            
        }

        private void deleteTermButton_Clicked(object sender, EventArgs e)
        {
            using (SQLite.SQLiteConnection con = new SQLite.SQLiteConnection(App.FilePath))
            {
                
                var temp = termListVeiw.SelectedItem as Table;

                if (termListVeiw.SelectedItem == null)
                {
                    DisplayAlert("Term", "No terms available for delete", "ok");
                }

                else
                {
                    var id = temp.iD;



                    con.Delete<Table>(temp.iD);

                    con.CreateTable<Table>();
                    var table = con.Table<Table>().ToList();

                    termListVeiw.ItemsSource = table;
                    
                    if (table.Count > 0)
                    {
                        termListVeiw.SelectedItem = table[0];
                    }
                    else
                    {
                        termListVeiw.SelectedItem = null;
                    }
                }
            }
         
        }

        private void coursesButton_Clicked(object sender, EventArgs e)
        {
            
            Table temp = new Table();
            
            temp = termListVeiw.SelectedItem as Table;
            
            if (termListVeiw.SelectedItem == null)
            {
                DisplayAlert("Term", "Please select term", "fine, I guess I have no choice");
            }
            
            else
            {
                
                termIndex = temp.iD;
                
                Navigation.PushAsync(new Courses());
            }
            
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            using(SQLiteConnection con = new SQLiteConnection(App.FilePath))
            {
                con.CreateTable<Table>();
                var table = con.Table<Table>().ToList();

                termListVeiw.ItemsSource = table;

                if (table.Count > 0)
                {
                    termListVeiw.SelectedItem = table[0];
                }
            }

            
        }

        
        


    }
}
