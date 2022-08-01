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
    public partial class Frm作業_2 : Form
    {
        public Frm作業_2()
        {
            InitializeComponent();
            this.productPhotoTableAdapter1.Fill(this.awDataSet1.ProductPhoto);
        }

        private void button11_Click(object sender, EventArgs e)
        {
            this.dataGridView1.DataSource = awDataSet1.ProductPhoto;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            var q = from p in awDataSet1.ProductPhoto
                    where p.ModifiedDate >= this.dateTimePicker1.Value && p.ModifiedDate <= this.dateTimePicker2.Value
                    select p;
            this.dataGridView1.DataSource = q.ToList();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            var q = from p in awDataSet1.ProductPhoto
                    where p.ModifiedDate.Year == Convert.ToInt32(this.comboBox3.Text)
                    select p;
            this.dataGridView1.DataSource = q.ToList();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            if (comboBox2.Text == "第一季")
                season(1, 3);
            if (comboBox2.Text == "第二季")
                season(4, 6);
            if (comboBox2.Text == "第三季")
                season(7, 9);
            if (comboBox2.Text == "第四季")
                season(10, 12);
        }

        private void Frm作業_2_Load(object sender, EventArgs e)
        {
            var q = from p in awDataSet1.ProductPhoto
                    orderby p.ModifiedDate.Year
                    select p.ModifiedDate.Year;

            List<int> list = new List<int>();
            foreach (var item in q.Distinct())
                comboBox3.Items.Add(item);
        }

        private void season( int month1, int month2)
        {
            var q = from p in awDataSet1.ProductPhoto
                    where p.ModifiedDate.Year == Convert.ToInt32(this.comboBox3.Text)
                    && p.ModifiedDate.Month >= month1 && p.ModifiedDate.Month <= month2
                    select p;
            this.dataGridView1.DataSource = q.ToList();
            label1.Text = "有" + q.ToList().Count() + "筆 ";
        }
    }
}
