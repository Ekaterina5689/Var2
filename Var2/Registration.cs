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
    public partial class Registration : Form
    {
        Model1 db = new Model1();
        public Registration()
        {
            InitializeComponent();
        }

        private void Registration_Load(object sender, EventArgs e)
        {
           
        }

        private void RegistBtn_Click(object sender, EventArgs e)
        {
            if (logTxt.Text == "" || PassTxt.Text == "" || NameTxt.Text == "" || RoleTxt.Text == "")
            {
                MessageBox.Show("Нужно задать все данные!");
            }
            if ((RoleTxt.Text != "Покупатель") && (RoleTxt.Text != "Продавец") && (RoleTxt.Text != "Менеджер"))
            {
                MessageBox.Show("Задана неверная роль!");
                return;
            }

            Пользователи usr = db.Пользователи.Find(logTxt.Text);
            if (usr != null)
            {
                MessageBox.Show("Пользователь с таким логином уже есть!");
                return;
            }

            usr = new Пользователи();
            usr.Логин = logTxt.Text;
            usr.Пароль = PassTxt.Text;
            usr.Роль = RoleTxt.Text;
            usr.Имя = NameTxt.Text;
            var date1 = new DateTime(2000, 2, 1);
            usr.ДатаРождения = date1;
            usr.Фамилия = "Минькин";
            usr.Отчество = "Алексеевич";
            usr.НомерТелефона = "+7999999999";
            usr.Фото = "нет";
            usr.ЭлектронныйАдрес = "mina@gmail.com";
            db.Пользователи.Add(usr);
            try
            {
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }
            MessageBox.Show("Пользовактель" + usr.Логин + " зарегистрирован!");
            Authorization authorization = new Authorization();
            authorization.Show();
            this.Close();
            return;
        }


        private void ExitBtn_Click(object sender, EventArgs e)
        {
            this.Hide();
            Authorization autorization = new Authorization();
            autorization.Show();
        }

        //private void пользователиDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        //{

        //}
    }
}
