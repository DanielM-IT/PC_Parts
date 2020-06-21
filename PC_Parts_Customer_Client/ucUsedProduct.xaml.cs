using Windows.UI.Xaml.Controls;

// Author: Daniel McCracken
// Date: 18/06/2020
namespace PC_Parts_Customer_Client
{
    public sealed partial class ucUsedProduct : UserControl, IProductControl
    {
        public ucUsedProduct()
        {
            InitializeComponent();
        }

        // Updates condition text field
        public void UpdateControl(clsProduct prProduct)
        {
            tbDisplayCondition.Text = prProduct.Condition;
        }
    }
}
