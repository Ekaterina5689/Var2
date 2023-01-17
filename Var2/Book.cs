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
    public partial class Book : Form
    {
        string Search = "";
        string Sorting = "Без сортировки";
        string Filter = "Все типы";
        static public List<int> lstSelectedData = new List<int>();
        public Book()
        {
            InitializeComponent();
        }

        private void Book_Load(object sender, EventArgs e)
        {
            книгиBindingSource.DataSource = Program.db.Книги.ToList();
            книгиBindingSource.DataSource = Program.db.Книги.ToList();
            книгиBindingSource.DataSource = Program.db.Жанр.ToList();
            SortingCmb.SelectedIndex = 0;
            List<string> lstFiltr = Program.db.Жанр.Select(a => a.НазваниеЖанра).OrderBy(s => s).ToList();
            lstFiltr.Insert(0, "Все типы");
            FilterCmb.DataSource = lstFiltr;
            FilterCmb.SelectedIndex = 0;
            Podgotovka();
        }
        List<Книги> lstFormatData = new List<Книги>();
        public void Podgotovka()
        {
            lstFormatData = Program.db.Книги.ToList();
            if (Filter != "Все типы")
            {
                lstFormatData = lstFormatData.Where(p => (p.Жанр.НазваниеЖанра == Filter)).ToList();
            }

            if (Sorting != "Без сортровки")
            {
                if (Sorting == "Наименование")
                {
                    if (!SortingCheck.Checked)
                    {
                        lstFormatData = lstFormatData.OrderBy(p => p.Наименование).ToList();
                    }
                    else
                    {
                        lstFormatData = lstFormatData.OrderByDescending(p => p.Наименование).ToList();
                    }
                }
                if (Sorting == "Цена")
                {
                    if (!SortingCheck.Checked)
                    {
                        lstFormatData = lstFormatData.OrderBy(p => p.Цена).ToList();
                    }
                    else
                    {
                        lstFormatData = lstFormatData.OrderByDescending(p => p.Цена).ToList();
                    }
                }
                if (Sorting == "Автор")
                {
                    if (!SortingCheck.Checked)
                    {
                        lstFormatData = lstFormatData.OrderBy(p => p.КоличествоСтраниц).ToList();
                    }
                    else
                    {
                        lstFormatData = lstFormatData.OrderByDescending(p => p.КоличествоСтраниц).ToList();
                    }
                }
            }
            if (Search != "")
            {
                lstFormatData = lstFormatData.Where(p => p.Наименование.Contains(Search)).ToList();
                if (lstFormatData.Count == 0)
                {
                    MessageBox.Show("Строка " + Search + " нигде не найдена!");
                }
            }

            книгиBindingSource.DataSource = lstFormatData;
        }

        private void SearchTxt_TextChanged(object sender, EventArgs e)
        {

            Search = SearchTxt.Text;
            Podgotovka();
        }

        private void SortingCmb_SelectedIndexChanged(object sender, EventArgs e)
        {
            Sorting = SortingCmb.Text;
            Podgotovka();
        }

        private void FilterCmb_SelectedIndexChanged(object sender, EventArgs e)
        {
            Filter = FilterCmb.Text;
            Podgotovka();
        }

        private void SortingCheck_CheckedChanged(object sender, EventArgs e)
        {
            Podgotovka();
        }

        private void ExitBtn_Click(object sender, EventArgs e)
        {
            Authorization authorization = new Authorization();
            authorization.Show();
            this.Hide();
        }

        private void OrderBtn_Click(object sender, EventArgs e)
        {

        }
    }
}
