﻿using App1.Classes;
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

        private void ToolbarItem_Clicked(object sender, EventArgs e)
        {
            Table table = new Table()
            {
                termName = entryTermName.Text,
                termStart = datePickerTermStart.Date.ToShortDateString(),
                termEnd = DatePickerTermEnd.Date.ToShortDateString()
            };

            using(SQLite.SQLiteConnection con = new SQLite.SQLiteConnection(App.FilePath))
            {
                con.CreateTable<Table>();
                int rows = con.Insert(table);

            }
        }
    }
}