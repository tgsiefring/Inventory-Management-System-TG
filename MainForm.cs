using InventoryManagementSystem.model;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace InventoryManagementSystem
{
    public partial class MainForm : Form
    {

        public MainForm()
        {
            InitializeComponent();

            parts.DataSource = Inventory.AllParts;
            parts.Columns["Min"].Visible = false;
            parts.Columns["Max"].Visible = false;
            parts.Columns[2].HeaderCell.Value = "Inventory";

            parts.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            parts.ReadOnly = true;

            parts.MultiSelect = false;

            parts.AllowUserToAddRows = false;

            products.DataSource = Inventory.Products;
            products.Columns["Min"].Visible = false;
            products.Columns["Max"].Visible = false;
            products.Columns[2].HeaderCell.Value = "Inventory";

            products.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            products.ReadOnly = true;
            products.MultiSelect = false;
            products.AllowUserToAddRows = false;

            Inventory.TestObjects();

        }


        private void AllPartsBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            parts.ClearSelection();
        }

        private void ProductsBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            products.ClearSelection();
        }

        //Selects row that is clicked in parts list.
        private void Parts_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            Inventory.SelectedIndex = parts.CurrentCell.RowIndex;
            Inventory.SelectedPart = Inventory.AllParts[Inventory.SelectedIndex];
        }

        private void DeletePartButton_Click(object sender, EventArgs e)
        {

            if (parts.CurrentRow == null || !parts.CurrentRow.Selected)
            {
                MessageBox.Show("No part is selected", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (DialogResult.Yes == MessageBox.Show("Are you sure you wish to delete this part?", "Please confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Warning))
            {
                Part part = parts.CurrentRow.DataBoundItem as Part;
                Inventory.DeletePart(part);
            }
        }

        private void AddPartButton_Click(object sender, EventArgs e)
        {
            AddPartForm form = new AddPartForm();
            form.ShowDialog();
        }

        private void ExitButton_Click(object sender, EventArgs e)
        {
            if (DialogResult.Yes == MessageBox.Show("Are you sure you wish to exit?", "Please confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Warning))
            {
                if (Application.MessageLoop == true)
                {
                    Application.Exit();
                }
                else
                {
                    Environment.Exit(1);
                }
            }
        }

        private void ModifyPartButton_Click(object sender, EventArgs e)
        {
            if (parts.CurrentRow == null || !parts.CurrentRow.Selected)
            {
                MessageBox.Show("No part is selected", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (parts.CurrentRow.DataBoundItem.GetType() == typeof(InHouse))
            {
                InHouse inHouse = (InHouse)parts.CurrentRow.DataBoundItem;
                new ModifyPartForm(inHouse).ShowDialog();
            }
            else
            {
                OutSourced outSourced = (OutSourced)parts.CurrentRow.DataBoundItem;
                new ModifyPartForm(outSourced).ShowDialog();
            }
        }

        private void ModifyProductButton_Click(object sender, EventArgs e)
        {
            if (products.CurrentRow == null || !products.CurrentRow.Selected)
            {
                MessageBox.Show("No product is selected", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            Product product = (Product)products.CurrentRow.DataBoundItem;
            new ModifyProductForm(product).ShowDialog();

        }

        private void AddProductButton_Click(object sender, EventArgs e)
        {
            AddProductForm form = new AddProductForm();
            form.ShowDialog();
        }

        private void SearchPartButton_Click(object sender, EventArgs e)
        {
            parts.ClearSelection();
            parts.DefaultCellStyle.SelectionBackColor = Color.Purple;
            bool searchResult = false;
            if (searchText1.Text != "")
            {
                for (int i = 0; i < Inventory.AllParts.Count; i++)
                {
                    if (Inventory.AllParts[i].PartID.ToString().Contains(searchText1.Text))
                    {
                        parts.Rows[i].Selected = true;
                        searchResult = true;
                    }
                }
            }
            if (!searchResult)
            {
                MessageBox.Show("Nothing found.");
            }

        }

        private void SearchProductButton_Click(object sender, EventArgs e)
        {
            products.ClearSelection();
            products.DefaultCellStyle.SelectionBackColor = Color.Purple;
            bool searchResult = false;
            if (searchText2.Text != "")
            {
                for (int i = 0; i < Inventory.Products.Count; i++)
                {
                    if (Inventory.Products[i].ProductID.ToString().Contains(searchText2.Text))
                    {
                        products.Rows[i].Selected = true;
                        searchResult = true;
                    }
                }
            }
            if (!searchResult)
            {
                MessageBox.Show("Nothing found.");
            }

        }

        private void DeleteProductButton_Click(object sender, EventArgs e)
        {
            if (products.CurrentRow == null || !products.CurrentRow.Selected)
            {
                MessageBox.Show("No product is selected", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
           
            Product product = products.CurrentRow.DataBoundItem as Product;

            if (product.AssociatedParts.Count > 0)
            {
                MessageBox.Show("Cannot delete a product that has parts associated with it. Please remove the parts associated with this product.", "Error",  MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (DialogResult.Yes == MessageBox.Show("Are you sure you wish to delete this product?", "Please confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Warning))
            {
                Inventory.RemoveProduct(product.ProductID);
            }
        }

        //Selects row that is clicked in products list.
        private void Products_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            Inventory.SelectedIndex = products.CurrentCell.RowIndex;
            Inventory.SelectedProduct = Inventory.Products[Inventory.SelectedIndex];
        }
    }
}