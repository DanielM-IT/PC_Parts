using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

// Author: Daniel McCracken
// Date: 18/06/2020
namespace PC_Parts_Customer_Client
{
    public sealed partial class pgOrderConfirmation : Page
    {
        public pgOrderConfirmation()
        {
            InitializeComponent();
        }

        // Navigates to the home page on user click.
        private void btnReturnHome_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(pgMain));
        }
    }
}
