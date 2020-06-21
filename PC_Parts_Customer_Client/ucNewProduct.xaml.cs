using Windows.UI.Xaml.Controls;

// Author: Daniel McCracken
// Date: 18/06/2020
namespace PC_Parts_Customer_Client
{
    public sealed partial class ucNewProduct : UserControl, IProductControl
    {
        public ucNewProduct()
        {
            InitializeComponent();
        }

        // Updates manufacturer field
        public void UpdateControl(clsProduct prProduct)
        {
            tbDisplayManufacturer.Text = prProduct.Manufacturer;
        }
    }
}
