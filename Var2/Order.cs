using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Var2.ModelEF;
namespace Var2
{
    public partial class Order : Form
    {
       
        public Order()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void Order_Load(object sender, EventArgs e)
        {
            заказыBindingSource.DataSource = Program.db.Заказы.ToList();
           

        }

        private void ExitBtn_Click(object sender, EventArgs e)
        {
            Authorization authorization = new Authorization();
            authorization.Show();
            this.Hide();
        }

        private void OrderBtn_Click(object sender, EventArgs e)
        {
            Books books = new Books();
            books.Show();
            this.Hide();
        }

        private void OrderBtn_Click_1(object sender, EventArgs e)
        {
            ordert ordert = new ordert();
            ordert.Show();
        }
    }
    
}
