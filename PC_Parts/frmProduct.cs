using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Linq;

// Author: Daniel McCracken
// Date: 18/06/2020
namespace PC_Parts
{
    public partial class frmProduct : Form
    {
        private bool _FieldWasChanged = false;
        private static bool _Timer;

        protected clsProduct _Product;

        public delegate void LoadProductFormDelegate(clsProduct prProduct);
        // Dictionary of available delegates.
        public static Dictionary<char, Delegate> _ProductForm = new Dictionary<char, Delegate>
        {
            { 'N', new LoadProductFormDelegate(frmNewProduct.Run)},
            { 'U', new LoadProductFormDelegate(frmUsedProduct.Run)}
        };

        // Dynamically invokes the correct delagate form the dictionary using the products product type.
        public static void CreateProductForm(clsProduct prProduct)
        {
            _ProductForm[prProduct.ProductType].DynamicInvoke(prProduct);
        }

        public frmProduct()
        {
            InitializeComponent();
        }

        // Gets the object retrieved according to the product type and places it in a class instance declared up top.
        public void SetDetails(clsProduct prProduct)
        {
            _Product = prProduct;
            updateForm();
            valueChangedEventSubcribe();

            // Hides the product id components if it is a new product form and start the timer.
            if (string.IsNullOrEmpty(txtName.Text))
            {
                txtProductId.Visible = false;
                lblProductId.Visible = false;
                _Timer = true;
            }
            timeUpdater();
            _FieldWasChanged = false;
            ShowDialog();
        }

        // Start event handlers to check for any user input.
        protected virtual void valueChangedEventSubcribe()
        {
            txtName.TextChanged += new EventHandler(input_ValueChanged);
            txtDescription.TextChanged += new EventHandler(input_ValueChanged);
            txtImageUrl.TextChanged += new EventHandler(input_ValueChanged);
            Controls.OfType<NumericUpDown>().ToList().ForEach(i => i.ValueChanged += input_ValueChanged);
        }

        // Update form with any details retrived. 
        protected virtual void updateForm()
        {
            txtName.Text = _Product.ProductName;
            numPrice.Value = _Product.Price;
            numQuantity.Value = _Product.Quantity;
            txtDateModified.Text = Convert.ToString(_Product.DateModified);
            txtProductId.Text = Convert.ToString(_Product.ProductID);
            txtDescription.Text = _Product.ProductDescription;
            txtImageUrl.Text = _Product.ProductImageUrl;
            
            // Populate the text boxes for the user to see according to the product type.
            if (Convert.ToString(_Product.ProductType) == "N")
            {
                txtProductType.Text = "New";
            }
            else if (Convert.ToString(_Product.ProductType) == "U")
            {
                txtProductType.Text = "Used";
            }
            else
                MessageBox.Show("There has been an error and the product type does not exist.");
        }

        // Push user input to an object.
        protected virtual void pushData()
        {
            _Product.ProductName = txtName.Text;
            _Product.Price = numPrice.Value;
            _Product.Quantity = Convert.ToInt32(numQuantity.Value);
            _Product.DateModified = DateTime.Now;
            _Product.ProductDescription = txtDescription.Text;
            _Product.ProductType = Convert.ToChar(txtProductType.Text.ToUpper().Substring(0,1));
            _Product.ProductImageUrl = txtImageUrl.Text;
        }

        // Timer boolean which will be used for new product forms.
        private async void timeUpdater()
        {
            while (_Timer == true)
            {
                txtDateModified.Text = DateTime.Now.ToString();
                await Task.Delay(1000);
            }
        }

        // Custom method for the event handlers which trigger on user input..
        protected virtual void input_ValueChanged(object sender, EventArgs e)
        {
            _FieldWasChanged = true;
        }

        // Validates that the url entered by user is valid.
        private static bool checkUrlValid(string strUrl)
        {
            Uri uriResult;
            return Uri.TryCreate(strUrl, UriKind.Absolute, out uriResult) &&
                (uriResult.Scheme == Uri.UriSchemeHttp || uriResult.Scheme == Uri.UriSchemeHttps);
        }

        // On click validates that fields are not empty and calls the url validation.
        private async void btnOk_Click(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrWhiteSpace(txtName.Text) && numPrice.Value >= 1 && checkUrlValid(txtImageUrl.Text))
                {
                    if (_FieldWasChanged)
                    {
                        pushData();
                        if (txtProductId.Visible)
                        {
                            MessageBox.Show(await ServiceClient.UpdateProductAsync(_Product));
                        }
                        else
                        {
                            MessageBox.Show(await ServiceClient.InsertProductAsync(_Product));
                        }
                    }
                    onFormLeave();
                }
                else
                    MessageBox.Show("You have invalid input or empty fields.", "Empty fields or invalid input.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Sorry there was an issue with your data", ex.Message);
            }
        }

        // On button click whill check if any input was made. If so then will confirm that th user is happy to lose changes made.
        private void btnCancel_Click(object sender, EventArgs e)
        {
            if (_FieldWasChanged)
            {
                if (MessageBox.Show("Warning you will lose any changes made. Do you want to continue?", "Cancel Product Changes", 
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    onFormLeave();
                }
            }
            else
                onFormLeave();
        } 
        
        // Reset ui components and booleans to their desired default on form leave then closes the form
        private void onFormLeave()
        {
            txtProductId.Visible = true;
            lblProductId.Visible = true;
            _FieldWasChanged = false;
            _Timer = false;
            Close();
        }
    }
}
