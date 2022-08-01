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
        }

        private string MyKeyYear(int n)
        {
            if (n == 2019)
                return "Year2019";
            else if (n == 2020)
                return "Year2020";
            else
                return "Large";
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
    }
}
