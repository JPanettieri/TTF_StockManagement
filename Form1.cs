// Copyright Skillage I.T. 
// This file is Skillage I.T. software and is made available under license. 
// This software is developed by: Joshua Panettieri  
// Date: 06 October 2022   Time: 12.00
// File Name: TTF_StockManagement.cs  Version: 1-0 
namespace TTF_StockManagement
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            try
            {
                //show the entire list
                productDataGrid.DataSource = ReadFile.ReadCSV();
            }
            //If the load fails, pop up a message warning the user
            catch (IOException)
            {
                System.Windows.Forms.MessageBox.Show("Old Data Loaded, Please check your file and try again.", "TTF Stock Manager");
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            string productSearched = textBoxName.Text.ToLower();
            string productDescriptionSearched = textBoxDescription.Text.ToLower();
            string productStockSearched = textBoxStock.Text;
            string priceTextSearched = textBoxPrice.Text;
            string productSupplierSearched = textBoxSupplier.Text.ToLower();
            //Show the new product list
            EditFile.AddProduct(productSearched, productDescriptionSearched, productStockSearched, priceTextSearched, productSupplierSearched);
            productDataGrid.DataSource = ReadFile.ReadCSV();
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            DialogResult iRemove;
            iRemove = MessageBox.Show("Are you sure you want to remove this product(s)??", "TTF Stock Manager", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (iRemove == DialogResult.Yes)
            {
                foreach (DataGridViewRow item in productDataGrid.SelectedRows)
                {
                    productDataGrid.Rows.RemoveAt(item.Index);

                }
                new ExportCSV().Export(productDataGrid);
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            try
            {
                //show the entire list
                productDataGrid.DataSource = ReadFile.ReadCSV();
            }
            //If the load fails, pop up a message warning the user
            catch (IOException)
            {
                System.Windows.Forms.MessageBox.Show("Old Data Loaded, Please check your file and try again.");
            }

        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            foreach (var c in Controls)
            {
                if (c is System.Windows.Forms.TextBox)
                {
                    ((System.Windows.Forms.TextBox)c).Clear();
                }

            }

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            DialogResult iSave;
            iSave = MessageBox.Show("Are you sure you want to save the Changes??", "TTF Stock Manager", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (iSave == DialogResult.Yes)
            {
                new ExportCSV().Export(productDataGrid);
            }
               
        }

        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.MessageBox.Show(
                "TTF was formed in the same year that the colony of South Australia enacted legislation " +
                "giving women the vote in 1894. We started off from humble beginnings making the push on " +
                "style of clothes pegs. We did this successfully for many decades with our products finding " +
                "penetration into overseas markets. These humble beginnings soon lifted us to great heights.\r\n\r\n" +
                "Since humble beginnings in 1894, TTF have grown and continue to expand. The company was formed on a " +
                "belief that consumers had a right to use quality textile fasteners when completing one of the most " +
                "fundamental tasks of modern humans, washing and drying clothes. We have not been quick to jump into " +
                "fads like hinged fasteners or plastic substitutes. We have formed partnerships with our suppliers " +
                "and continue to develop these today. We will maintain and strengthen our relationship and shared R&D " +
                "with ‘Lines for ALL Purposes’ and pursue new markets with them in joint marketing exercises.\r\n\r\n\r\n\r\n" + 
                "This Application was created to assist TTF to manage their stock of products and track their suppliers. " +
                "New products can be added and existing products can be edited. More features are to come. ", "TTF Stock Manager");

        }

        private void toolStripMenuItem4_Click_1(object sender, EventArgs e)
        {
            DialogResult iQuit;
            iQuit = MessageBox.Show("Do you want to quit?", "TTF Stock Manager", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (iQuit == DialogResult.Yes)
            {
                System.Windows.Forms.Application.Exit();
            }
        }

        private void radioButtonInStock_CheckedChanged(object sender, EventArgs e)
        {
            bool allInStockSelcted = true;
            productDataGrid.DataSource = FilteredResults.AllInStock(allInStockSelcted);
        }

        private void radioButtonAllStock_CheckedChanged(object sender, EventArgs e)
        {
            productDataGrid.DataSource = ReadFile.ReadCSV();
        }

        private void radioButtonOutStock_CheckedChanged(object sender, EventArgs e)
        {
            bool allOutStockSelcted = true;
            productDataGrid.DataSource = FilteredResults.AllOutStock(allOutStockSelcted);
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string textSearched = textBoxSearch.Text.ToLower();

            if (comboBoxSearch.SelectedItem.ToString() == "Id")
            {
                productDataGrid.DataSource = FilteredResults.SearchId(textSearched);
            }
            else if (comboBoxSearch.SelectedItem.ToString() == "Name")
            {
                productDataGrid.DataSource = FilteredResults.SearchName(textSearched);
            }
            else if (comboBoxSearch.SelectedItem.ToString() == "Description")
            {
                productDataGrid.DataSource = FilteredResults.SearchDescription(textSearched);
            }
            else if (comboBoxSearch.SelectedItem.ToString() == "Stock")
            {
                productDataGrid.DataSource = FilteredResults.SearchStock(textSearched);
            }
            else if (comboBoxSearch.SelectedItem.ToString() == "Price")
            {
                productDataGrid.DataSource = FilteredResults.SearchPrice(textSearched);
            }
            else if (comboBoxSearch.SelectedItem.ToString() == "Supplier")
            {
                productDataGrid.DataSource = FilteredResults.SearchSupplier(textSearched);
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}