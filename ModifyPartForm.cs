using InventoryManagementSystem.model;
using System;
using System.Drawing;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace InventoryManagementSystem
{
    public partial class ModifyPartForm : Form
    {
        //Determines if part is Inhouse or Outsourced.
        public bool isInHouse = true;

        //Save button is enabled if all text boxes contain data.
        private bool SaveEnabled()
        {
            return (!string.IsNullOrWhiteSpace(textBoxName.Text)) && (!string.IsNullOrWhiteSpace(textBoxInventory.Text)) && (!string.IsNullOrWhiteSpace(textBoxPrice.Text)) &&
                (!string.IsNullOrWhiteSpace(textBoxMax.Text)) && (!string.IsNullOrWhiteSpace(textBoxMin.Text)) && (!string.IsNullOrWhiteSpace(textBoxRadio.Text));
        }

        public ModifyPartForm()
       {
            InitializeComponent();
        }

        public ModifyPartForm(InHouse inHouse)
        {
            InitializeComponent();

            textBoxID.Text = inHouse.PartID.ToString();
            textBoxName.Text = inHouse.Name.ToString();
            textBoxInventory.Text = inHouse.InStock.ToString();
            textBoxPrice.Text = inHouse.Price.ToString();
            textBoxMax.Text = inHouse.Max.ToString();
            textBoxMin.Text = inHouse.Min.ToString();
            textBoxRadio.Text = inHouse.MachineID.ToString();
        }
        public ModifyPartForm(OutSourced outSourced)
        {
            InitializeComponent();

            textBoxID.Text = outSourced.PartID.ToString();
            textBoxName.Text = outSourced.Name.ToString();
            textBoxInventory.Text = outSourced.InStock.ToString();
            textBoxPrice.Text = outSourced.Price.ToString();
            textBoxMax.Text = outSourced.Max.ToString();
            textBoxMin.Text = outSourced.Min.ToString();
            textBoxRadio.Text = outSourced.CompanyName.ToString();

            rbOutsourced.Checked = true;
        }

        //Activates when In-House radio button is checked.
        private void RbInHouse_CheckedChanged_1(object sender, EventArgs e)
        {
            labelChange.Text = "Machine ID";
            isInHouse = true;
        }

        //Activates when Outsourced radio button is checked.
        private void RbOutsourced_CheckedChanged_1(object sender, EventArgs e)
        {
            labelChange.Text = "Company Name";
            isInHouse = false;
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
            else if ((isInHouse) && !(Regex.IsMatch(textBoxRadio.Text, @"^[0-9]+$")))
            {
                MessageBox.Show("Machine ID must be a number");
            }
            else if (!(isInHouse) && !(Regex.IsMatch(textBoxRadio.Text, @"^[a-zA-z]+$")))
            {
                MessageBox.Show("Company name must only contain letters");
            }

            else
            {
                if (rbInHouse.Checked == true)
                {
                    Part inHouse = new InHouse
                    {
                        PartID = int.Parse(textBoxID.Text),
                        Name = textBoxName.Text,
                        InStock = int.Parse(textBoxInventory.Text),
                        Price = decimal.Parse(textBoxPrice.Text),
                        Max = int.Parse(textBoxMax.Text),
                        Min = int.Parse(textBoxMin.Text),
                        MachineID = int.Parse(textBoxRadio.Text)
                    };
                    Inventory.UpdatePart(Inventory.SelectedIndex, inHouse);
                }

                else
                {
                    Part outSourced = new OutSourced 
                    {
                        PartID = int.Parse(textBoxID.Text),
                        Name = textBoxName.Text,
                        InStock = int.Parse(textBoxInventory.Text),
                        Price = decimal.Parse(textBoxPrice.Text),
                        Max = int.Parse(textBoxMax.Text),
                        Min = int.Parse(textBoxMin.Text),
                        CompanyName = textBoxRadio.Text
                    };
                    Inventory.UpdatePart(Inventory.SelectedIndex, outSourced);
                }
                Close();
            }
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            Close();
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

        private void TextBoxRadio_TextChanged(object sender, EventArgs e)
        {
            //int integer;
            if (string.IsNullOrWhiteSpace(textBoxRadio.Text))
            {
                textBoxRadio.BackColor = Color.Pink;
            }
            else
            {
                textBoxRadio.BackColor = Color.White;
            }

            saveButton.Enabled = SaveEnabled();
        }

        private void TextBoxRadio_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (isInHouse == false)
            {
                if (!char.IsControl(e.KeyChar) && !char.IsLetter(e.KeyChar)) //company name allows only letters
                {
                    e.Handled = true;
                }

            }
            else
            {

                if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar)) //machine ID allows only numbers
                {
                    e.Handled = true;
                }
            }
        }
    }
}
