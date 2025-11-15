using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace Project
{
    public partial class Form2 : Form
    {
        int autoId = 1;
        public Form2()
        {
            InitializeComponent();
        }

        DataTable dt = new DataTable();
        

        private void button1_Click(object sender, EventArgs e)
        {
            dgv1.CurrentRow.Cells[1].Value = txtName.Text;
            dgv1.CurrentRow.Cells[2].Value = txtCategory.Text;
            dgv1.CurrentRow.Cells[3].Value = txtPrice.Text;
            dgv1.CurrentRow.Cells[4].Value = txtQuantity.Text;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int delet = dgv1.CurrentCell.RowIndex;
            dgv1.Rows.RemoveAt(delet);
        }

        private void button3_Click(object sender, EventArgs e)
        { 
            dt.Rows.Add(autoId, txtName.Text , txtCategory.Text, txtPrice.Text, txtQuantity.Text);
            dgv1.DataSource = dt;
            autoId++;
            txtName.Clear();
            txtName.Focus();
            txtCategory.Clear();
            txtPrice.Clear();
            txtQuantity.Clear();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Application.OpenForms[1].Show();
            this.Close();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            txtCategory.Text = "";
            txtName.Text = "";
            txtPrice.Text = "";
            txtQuantity.Text = "";
        }

        

        private void Form2_Load(object sender, EventArgs e)
        {

            dt.Columns.Add("المعرف");
            dt.Columns.Add("الاسم");
            dt.Columns.Add("الفئة");
            dt.Columns.Add("السعر" , typeof(int));
            dt.Columns.Add("الكمية", typeof(int));
            
            dgv1.DataSource = dt;

        }

        private void txtQuantity_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtQuantity_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != (char)Keys.Back)
            {
                e.Handled = true;
            }
        }

        private void txtPrice_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != (char)Keys.Back)
            {
                e.Handled = true;
            }
        }

        private void dgv1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            dgv1_SelectionChanged(null , null );
        }

        private void dgv1_SelectionChanged(object sender, EventArgs e)
        {
            txtName.Text = dgv1.CurrentRow.Cells[1].Value.ToString();
            txtCategory.Text = dgv1.CurrentRow.Cells[2].Value.ToString();
            txtPrice.Text = dgv1.CurrentRow.Cells[3].Value.ToString();
            txtQuantity.Text = dgv1.CurrentRow.Cells[4].Value.ToString();
        }
    }
}