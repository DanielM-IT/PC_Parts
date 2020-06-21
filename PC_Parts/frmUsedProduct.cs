using System;

// Author: Daniel McCracken
// Date: 18/06/2020
namespace PC_Parts
{
    public sealed partial class frmUsedProduct : frmProduct
    {
        // Create the child class as a singleton.
        private static readonly frmUsedProduct Instance = new frmUsedProduct();

        private frmUsedProduct()
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
            txtCondition.TextChanged += new EventHandler(input_ValueChanged);
        }

        // Update child form components
        protected override void updateForm()
        {
            base.updateForm();
            txtCondition.Text = _Product.Condition;
        }

        // Push data entered in child form components.
        protected override void pushData()
        {
            base.pushData();
            _Product.Condition = txtCondition.Text;
        }

        protected override void input_ValueChanged(object sender, EventArgs e)
        {
            base.input_ValueChanged(sender, e);
        }
    }
}
