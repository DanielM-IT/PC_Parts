using System;

// Author: Daniel McCracken
// Date: 18/06/2020
namespace PC_Parts
{
    // Create the child class as a singleton.
    public sealed partial class frmNewProduct : frmProduct
    {
        private static readonly frmNewProduct Instance = new frmNewProduct();

        private frmNewProduct()
        {
            InitializeComponent();
        }

        // Set the form details 
        public static void Run(clsProduct prProduct)
        {
            Instance.SetDetails(prProduct);
        }

        // Handles subscribing of events for child form components.
        protected override void valueChangedEventSubcribe()
        {
            base.valueChangedEventSubcribe();
            txtManufacturer.TextChanged += new EventHandler(input_ValueChanged);
        }

        // Update child form components
        protected override void updateForm()
        {
            base.updateForm();
            txtManufacturer.Text = _Product.Manufacturer;
        }

        // Push data entered in child form components.
        protected override void pushData()
        {
            base.pushData();
            _Product.Manufacturer = txtManufacturer.Text;
        }

        protected override void input_ValueChanged(object sender, EventArgs e)
        {
            base.input_ValueChanged(sender, e);
        }
    }
}
