﻿using App1.Classes;
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
        public static object temp;
        public static object index;

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
            
            
            index = termListVeiw.SelectedItem;
            Navigation.PushAsync(new AUTerm());
            updateTerm = true;

            
  
            
        }

        private void deleteTermButton_Clicked(object sender, EventArgs e)
        {

        }

        private void coursesButton_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new Courses());
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            using(SQLiteConnection con = new SQLiteConnection(App.FilePath))
            {
                con.CreateTable<Table>();
                var table = con.Table<Table>().ToList();

                termListVeiw.ItemsSource = table;
                termListVeiw.SelectedItem = table[0];
                
            }

            
        }

        



    }
}
