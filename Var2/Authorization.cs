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
    public partial class Authorization : Form
    {
        public static Пользователи USER { get; set; }
        public Authorization()
        {
            InitializeComponent();
        }
        Model1 db = new Model1();
        private void Authorization_Load(object sender, EventArgs e)
        {

        }

        private void NextBtn_Click(object sender, EventArgs e)
        {
            if (LogTxt.Text == "" || PassTxt.Text == "")
            {
                MessageBox.Show("Нужно задать логин и пароль!");
                return;
            }

            Пользователи usr = db.Пользователи.Find(LogTxt.Text);
            if ((usr != null) && (usr.Пароль == PassTxt.Text))
            {

                USER = usr;
                Capcha.Visible = true;
                label4.Visible = true;
                cap.Visible = true;
                inputTxt.Visible = true;
                vhodBtn.Visible = true;
                Random random = new Random();
                cap.Text = random.Next(1, 101).ToString();
            }
            else
            {
                MessageBox.Show("Пользователя с таким логином и паролем нет!");
                return;
            }
          
           
        }

        private void vhodBtn_Click(object sender, EventArgs e)
        {


            if (inputTxt.Text == cap.Text)
            {
                Пользователи usr = db.Пользователи.Find(LogTxt.Text);

                if ((usr != null) && (usr.Пароль == PassTxt.Text))
                {

                    USER = usr;


                    if (usr.Роль == "Покупатель")
                    {

                        Book book = new Book();
                        book.Show();
                        this.Hide();
                    }
                    else if (usr.Роль == "Менеджер")
                    {
                        Books books = new Books();
                        books.Show();
                        this.Hide();
                    }
                    else if (usr.Роль == "Продавец")
                    {
                        Order order = new Order();
                        order.Show();
                        this.Hide();
                    }
                    else
                    {

                        MessageBox.Show($"Роли {usr.Роль} в системе нет!");
                        return;
                    }

                }
               
            }
            else
            {

                MessageBox.Show("Неверно введено число с картинки!");
                Random random = new Random();
                cap.Text = random.Next(1, 101).ToString();

            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                PassTxt.UseSystemPasswordChar = false;
            }
            else
            {
                PassTxt.UseSystemPasswordChar = (true);
            }
        }

        private void ExitBtn_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void RegistBtn_Click(object sender, EventArgs e)
        {
            this.Hide();
            Registration rg = new Registration();
            rg.Show();
        }
    }
}
