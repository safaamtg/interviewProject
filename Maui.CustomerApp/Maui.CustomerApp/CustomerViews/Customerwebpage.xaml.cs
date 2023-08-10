namespace Maui.CustomerApp.CustomerViews;

public partial class Customerwebpage : ContentPage
{
   

    public Customerwebpage()
    {
        InitializeComponent();

    }



    private void btnMainPage_Clicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync(nameof(CustomerMainPage));
    }
}