using System;
using TotalTech.Models;
using Xamarin.Forms;

namespace TotalTech.Views
{
    public partial class StatesPage : ContentPage
    {
        public StatesPage()
        {
            InitializeComponent();
        }
        private bool isRowEven;

        private void Cell_OnAppearing(object sender, EventArgs e)
        {
            var viewCell = (ViewCell)sender;
            State state = (State)viewCell.BindingContext;
            viewCell.View.BackgroundColor = state.id %2 ==0 ?  Color.Gray: viewCell.View.BackgroundColor;
        }

    }
}
