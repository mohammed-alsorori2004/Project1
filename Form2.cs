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
        public static Form4 form4 = new Form4();
        public Form2()
        {
            InitializeComponent();
        }

        DataTable dt = new DataTable();
        

        private void edit(object sender, EventArgs e)
        {
            dgv1.CurrentRow.Cells[1].Value = txtName.Text;
            dgv1.CurrentRow.Cells[2].Value = txtCategory.Text;
            dgv1.CurrentRow.Cells[3].Value = txtPrice.Text;
            dgv1.CurrentRow.Cells[4].Value = txtQuantity.Text;

            
        }

        private void Delete(object sender, EventArgs e)
        {
            int delet = dgv1.CurrentCell.RowIndex;
            dgv1.Rows.RemoveAt(delet);
            
        }

        private void add(object sender, EventArgs e)
        {
            ShardData.product.Rows.Add(autoId, txtName.Text , txtCategory.Text, txtPrice.Text, txtQuantity.Text);
            dgv1.DataSource = ShardData.product;
            autoId++;
           

            
            
            txtName.Clear();
            txtName.Focus();
            txtCategory.Clear();
            txtPrice.Clear();
            txtQuantity.Clear();
            
        }

        private void Exit(object sender, EventArgs e)
        {
            Application.OpenForms[1].Show();
            this.Close();
        }

        private void Survey(object sender, EventArgs e)
        {
            txtCategory.Text = "";
            txtName.Text = "";
            txtPrice.Text = "";
            txtQuantity.Text = "";
        }

        

        private void Form2_Load(object sender, EventArgs e)
        {

            ShardData.product.Columns.Add("المعرف");
            ShardData.product.Columns.Add("الاسم");
            ShardData.product.Columns.Add("الفئة");
            ShardData.product.Columns.Add("السعر" , typeof(int));
            ShardData.product.Columns.Add("الكمية", typeof(int));
            
            dgv1.DataSource = ShardData.product;


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

        private void dgv1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void txtName_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form4 start2 = new Form4();
            start2.ShowDialog();
        }
    }
}