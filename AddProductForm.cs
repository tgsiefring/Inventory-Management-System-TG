using InventoryManagementSystem.model;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace InventoryManagementSystem
{
    public partial class AddProductForm : Form
    {
        BindingList<Part> partsAddedToAssociated = new BindingList<Part>();

        //Save button is enabled if all text boxes contain data.
        private bool SaveEnabled()
        {
            return (!string.IsNullOrWhiteSpace(textBoxName.Text)) && (!string.IsNullOrWhiteSpace(textBoxInventory.Text)) && (!string.IsNullOrWhiteSpace(textBoxPrice.Text)) &&
                (!string.IsNullOrWhiteSpace(textBoxMax.Text)) && (!string.IsNullOrWhiteSpace(textBoxMin.Text));
        }

        public AddProductForm()
        {
            InitializeComponent();

            allParts.DataSource = Inventory.AllParts;

            allParts.Columns["Min"].Visible = false;
            allParts.Columns["Max"].Visible = false;
            allParts.Columns[2].HeaderCell.Value = "Inventory";

            var associated = new BindingSource();
            associated.DataSource = partsAddedToAssociated;
            associatedParts.DataSource = associated;            

            associatedParts.Columns["Min"].Visible = false;
            associatedParts.Columns["Max"].Visible = false;
            associatedParts.Columns[2].HeaderCell.Value = "Inventory";

            allParts.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            allParts.ReadOnly = true;

            allParts.MultiSelect = false;

            allParts.AllowUserToAddRows = false;

            associatedParts.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            associatedParts.ReadOnly = true;

            associatedParts.MultiSelect = false;

            associatedParts.AllowUserToAddRows = false;

            textBoxName.BackColor = Color.Pink;
            textBoxInventory.BackColor = Color.Pink;
            textBoxPrice.BackColor = Color.Pink;
            textBoxMax.BackColor = Color.Pink;
            textBoxMin.BackColor = Color.Pink;
        }

        private void AllPartsBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            allParts.ClearSelection();
        }

        private void AssociatedPartsBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            associatedParts.ClearSelection();
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            if (Convert.ToInt32(textBoxMax.Text) < Convert.ToInt32(textBoxMin.Text))
            {
                MessageBox.Show("Minimum amount must be lower than maximum amount");
                return;
            }

            else if (Convert.ToInt32(textBoxInventory.Text) < Convert.ToInt32(textBoxMin.Text))
            {
                MessageBox.Show("Inventory amount must be equal to or greater than minimum amount");
            }

            else if (Convert.ToInt32(textBoxInventory.Text) > Convert.ToInt32(textBoxMax.Text))
            {
                MessageBox.Show("Inventory amount must be equal to or less than maximum amount");
            }
            else
            {
                Product product = new Product
                {
                    ProductID = Inventory.GenerateProductID(),
                    Name = textBoxName.Text,
                    InStock = int.Parse(textBoxInventory.Text),
                    Price = decimal.Parse(textBoxPrice.Text),
                    Max = int.Parse(textBoxMax.Text),
                    Min = int.Parse(textBoxMin.Text),
                };

                Inventory.AddProduct(product);

                foreach (Part part in partsAddedToAssociated)
                {
                    product.AddAssociatedPart(part);
                }
                Close();
            }
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void AddPartButton_Click(object sender, EventArgs e)
        {
            if (allParts.CurrentRow.DataBoundItem.GetType() == typeof(InHouse))
            {
                InHouse inHouse = (InHouse)allParts.CurrentRow.DataBoundItem;
                partsAddedToAssociated.Add(inHouse);
            }

            else
            {
                OutSourced outSourced = (OutSourced)allParts.CurrentRow.DataBoundItem;
                partsAddedToAssociated.Add(outSourced);
            }
        }

        private void DeletePartButton_Click(object sender, EventArgs e)
        {
            if (associatedParts.CurrentRow == null || !associatedParts.CurrentRow.Selected)
            {
                MessageBox.Show("No part is selected", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (DialogResult.Yes == MessageBox.Show("Are you sure you wish to delete this part?", "Please confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Warning))
            {
                foreach (DataGridViewRow row in associatedParts.SelectedRows)
                {
                    associatedParts.Rows.RemoveAt(row.Index);
                }
                return;
            }            
        }

        private void SearchButton_Click(object sender, EventArgs e)
        {
            allParts.ClearSelection();
            allParts.DefaultCellStyle.SelectionBackColor = Color.Purple;
            bool searchResult = false;
            if (searchTextProduct.Text != "")
            {
                for (int i = 0; i < Inventory.AllParts.Count; i++)
                {
                    if (Inventory.AllParts[i].PartID.ToString().Contains(searchTextProduct.Text))
                    {
                        allParts.Rows[i].Selected = true;
                        searchResult = true;
                    }
                }
            }
            if (!searchResult)
            {
                MessageBox.Show("Nothing found.");
            }
        }


        //Text box validation
        //TextChanged methods turn text boxes pink and do not allow clicking save button if the text box is empty.
        //KeyPress methods ensure only proper characters are allowed in text boxes.
        private void TextBoxName_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBoxName.Text))
            {
                textBoxName.BackColor = Color.Pink;
            }
            else
            {
                textBoxName.BackColor = Color.White;
            }

            saveButton.Enabled = SaveEnabled();
        }

        private void TextBoxName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsLetter(e.KeyChar)) //name allows only letters
            {
                e.Handled = true;
            }
        }

        private void TextBoxInventory_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBoxInventory.Text))
            {
                textBoxInventory.BackColor = Color.Pink;
            }
            else
            {
                textBoxInventory.BackColor = Color.White;
            }

            saveButton.Enabled = SaveEnabled();
        }

        private void TextBoxInventory_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar)) //inventory allows only numbers
            {
                e.Handled = true;
            }
        }

        private void TextBoxPrice_TextChanged(object sender, EventArgs e)
        {
            double dub;
            if (string.IsNullOrWhiteSpace(textBoxPrice.Text) || !(double.TryParse(textBoxPrice.Text, out dub)))
            {
                textBoxPrice.BackColor = Color.Pink;
            }
            else
            {
                textBoxPrice.BackColor = Color.White;
            }

            saveButton.Enabled = SaveEnabled();
        }

        private void TextBoxPrice_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '.' && textBoxPrice.Text.Contains(".")) //price allows only one decimal
            {
                e.Handled = true;
            }
            else if (e.KeyChar == '.' && textBoxPrice.Text.Length == 0) //price must start with a number
            {
                e.Handled = true;
            }
            else if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.') // price only allows numbers and decimal
            {
                e.Handled = true;
            }
        }

        private void TextBoxMax_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBoxMax.Text))
            {
                textBoxMax.BackColor = Color.Pink;
            }
            else
            {
                textBoxMax.BackColor = Color.White;
            }

            saveButton.Enabled = SaveEnabled();
        }

        private void TextBoxMax_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar)) //max allows only numbers
            {
                e.Handled = true;
            }
        }

        private void TextBoxMin_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBoxMin.Text))
            {
                textBoxMin.BackColor = Color.Pink;
            }
            else
            {
                textBoxMin.BackColor = Color.White;
            }

            saveButton.Enabled = SaveEnabled();
        }

        private void TextBoxMin_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar)) //min allows only numbers
            {
                e.Handled = true;
            }
        }        
    }
}
