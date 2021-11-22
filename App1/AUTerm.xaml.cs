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

        public static Table table = new Table();
        public AUTerm()
        {
            InitializeComponent();
        }

        private void ToolbarItem_Clicked(object sender, EventArgs e) // save
        {
            //Table table = new Table()
            // {
            table.termName = entryTermName.Text;
            table.termStart = datePickerTermStart.Date.ToShortDateString();
            table.termEnd = DatePickerTermEnd.Date.ToShortDateString();

            // };

            if (datePickerTermStart.Date > DatePickerTermEnd.Date)
            {
                DisplayAlert("Term", "Start date is after end date", "ok");
            }

            else
            {


                using (SQLite.SQLiteConnection con = new SQLite.SQLiteConnection(App.FilePath))
                {
                    con.CreateTable<Table>();

                    if (MainPage.updateTerm == false)
                    {
                        con.Insert(table);
                    }

                    else
                    {
                        var temp = MainPage.index as Table;

                        con.Update(new Table
                        {
                            iD = temp.iD,
                            termName = entryTermName.Text,
                            termStart = datePickerTermStart.Date.ToShortDateString(),
                            termEnd = DatePickerTermEnd.Date.ToShortDateString(),



                        });
                    }
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