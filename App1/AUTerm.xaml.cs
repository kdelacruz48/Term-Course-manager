using App1.Classes;
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
    public partial class AUTerm : ContentPage
    {
        public AUTerm()
        {
            InitializeComponent();
        }

        private void ToolbarItem_Clicked(object sender, EventArgs e) // save
        {

            if (MainPage.updateTerm == false)
            {
                Table table = new Table()
                {
                    termName = entryTermName.Text,
                    termStart = datePickerTermStart.Date.ToShortDateString(),
                    termEnd = DatePickerTermEnd.Date.ToShortDateString()

                };

                using (SQLite.SQLiteConnection con = new SQLite.SQLiteConnection(App.FilePath))
                {
                    con.CreateTable<Table>();
                    con.Update(table);

                }

                Navigation.PushAsync(new MainPage());

            }
            else
            {
                Table table = new Table()
                {
                    termName = entryTermName.Text,
                    termStart = datePickerTermStart.Date.ToShortDateString(),
                    termEnd = DatePickerTermEnd.Date.ToShortDateString()

                };

                Table update = new Table()
                {

                }

                using (SQLite.SQLiteConnection con = new SQLite.SQLiteConnection(App.FilePath))
                {
                    con.CreateTable<Table>();
                    con.Insert(table);

                }

                Navigation.PushAsync(new MainPage());


            }
        }
        protected override void OnAppearing()
        {
            if (MainPage.updateTerm == true)
            {
                var temp = MainPage.index as Table;
                entryTermName.Text = temp.termName;
                
                DateTime start = DateTime.Parse(temp.termStart);
                DateTime end = DateTime.Parse(temp.termEnd);

                datePickerTermStart.Date = start;
                DatePickerTermEnd.Date = end;

            }
        }
    }
}