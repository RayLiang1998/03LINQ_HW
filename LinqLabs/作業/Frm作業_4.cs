using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LinqLabs.作業
{
    public partial class Frm作業_4 : Form
    {
        public Frm作業_4()
        {
            InitializeComponent();
            dbContext.Database.Log = Console.WriteLine;
        }

        NorthwindEntities dbContext = new NorthwindEntities();
        private string MyKeyYear(int n)
        {
            if (n == 2019)
                return "Year2019";
            else if (n == 2020)
                return "Year2020";
            else
                return "2021 ";
        }
        private void button38_Click(object sender, EventArgs e)
        {
            System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(@"c:\windows");

            System.IO.FileInfo[] files = dir.GetFiles();
            var q = from f in files
                    orderby f.Length descending
                    select f;

            this.dataGridView1.DataSource = q.ToList();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(@"c:\windows");

            System.IO.FileInfo[] files = dir.GetFiles();
            var q = from f in files
                    orderby f.CreationTime.Year descending
                    select f;

            this.dataGridView1.DataSource = q.ToList();
        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void button8_Click(object sender, EventArgs e)
        {
            //NW Products 低中高 價產品 
        }

        private void button15_Click(object sender, EventArgs e)
        {
            // Orders -  Group by 年
        }

        private void button10_Click(object sender, EventArgs e)
        {
            // Orders -  Group by 年 / 月
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //總銷售金額
            //var q =from p in dbContext.Products
            //       group p by p.ProductName into g
            //       select new {g.Key, }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //銷售最好的top 5業務員
        }

        private void button9_Click(object sender, EventArgs e)
        {
            // NW 產品最高單價前 5 筆(包括類別名稱)
            var q = (from p in this.dbContext.Products
                     join c in this.dbContext.Categories
                     on p.CategoryID equals c.CategoryID
                     orderby p.UnitPrice descending
                     select new { p.ProductName, p.ProductID, p.CategoryID, c.CategoryName, p.UnitPrice}).Take(5);

            this.dataGridView1.DataSource = q.ToList();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //NW 產品有任何一筆單價大於300 ?
        }
    }
}
