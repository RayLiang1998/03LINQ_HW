using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LinqLabs;

namespace MyHomeWork
{
    public partial class Frm作業_1 : Form
    {
        public Frm作業_1()
        {
            InitializeComponent();
            //this.ordersTableAdapter1.Fill(this.nwDataSet1.Orders);
            //this.productsTableAdapter1.Fill(this.nwDataSet1.Products);
            dbContext.Database.Log = Console.WriteLine;

            students_scores = new List<Student>()
                                         {
                                            new Student{ Name = "aaa", Class = "CS_101", Chi = 80, Eng = 80, Math = 50, Gender = "Male" },
                                            new Student{ Name = "bbb", Class = "CS_102", Chi = 80, Eng = 80, Math = 100, Gender = "Male" },
                                            new Student{ Name = "ccc", Class = "CS_101", Chi = 60, Eng = 50, Math = 75, Gender = "Female" },
                                            new Student{ Name = "ddd", Class = "CS_102", Chi = 80, Eng = 70, Math = 85, Gender = "Female" },
                                            new Student{ Name = "eee", Class = "CS_101", Chi = 80, Eng = 80, Math = 50, Gender = "Female" },
                                            new Student{ Name = "fff", Class = "CS_102", Chi = 80, Eng = 80, Math = 80, Gender = "Female" },

                                          };
        }
        NorthwindEntities dbContext = new NorthwindEntities();
        List<Student> students_scores;

        public class Student
        {
            public string Name { get; set; }
            public string Class { get; set; }
            public int Chi { get; set; }
            public int Eng { get; internal set; }
            public int Math { get; set; }
            public string Gender { get; set; }
        }

        private void bindingSource1_CurrentChanged(object sender, EventArgs e)
        {

        }

        int i;
        int T;
        int B;
        private void button13_Click(object sender, EventArgs e)
        {
            
            B = T;
            i = Convert.ToInt32(textBox1.Text);
            if (T > this.dbContext.Products.Count() - i)
            {
                //return;
            }
            var q = this.dbContext.Products.AsEnumerable().Skip(B).Take(i);
            this.dataGridView1.DataSource = q.ToList();
            T = B + i;
        }
        private void button12_Click(object sender, EventArgs e)
        {
            i = Convert.ToInt32(textBox1.Text);
            B -= i;
            if (B <0)
            {
                return;
            }
            var q = this.dbContext.Products.AsEnumerable().Skip(B).Take(i);
            this.dataGridView1.DataSource = q.ToList();
            T = B + i;
        }

        private void button14_Click(object sender, EventArgs e)
        {
            System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(@"c:\windows");

            System.IO.FileInfo[] files =  dir.GetFiles();

            var q = from f in files
                    where f.Extension == ".log"
                    select f;

            this.dataGridView1.DataSource = q.ToList();
        }

        private void button36_Click(object sender, EventArgs e)
        {
            #region 搜尋 班級學生成績

            // 
            // 共幾個 學員成績 ?						

            // 找出 前面三個 的學員所有科目成績					
            // 找出 後面兩個 的學員所有科目成績					

            // 找出 Name 'aaa','bbb','ccc' 的學成績						

            // 找出學員 'bbb' 的成績	                          

            // 找出除了 'bbb' 學員的學員的所有成績 ('bbb' 退學)	


            // 數學不及格 ... 是誰 
            #endregion
            var q = from s in students_scores
                    where s.Class == "CS_101"
                    select s;
            this.dataGridView1.DataSource = q.ToList();
        }

        private void button37_Click(object sender, EventArgs e)
        {
            //new {.....  Min=33, Max=34.}
            // 找出 'aaa', 'bbb' 'ccc' 學員 國文數學兩科 科目成績  |		

            //個人 所有科的  sum, min, max, avg

            var q2 = from s in students_scores
                    select new { s.Name, s.Chi, s.Eng, s.Math, sum = s.Chi + s.Eng + s.Math, avg = (s.Chi + s.Eng + s.Math) / 3 };
            this.dataGridView1.DataSource = q2.ToList();

        }

        private void button6_Click(object sender, EventArgs e)
        {
            var q = from p in this.dbContext.Orders.AsEnumerable()
                    select p;

            this.dataGridView1.DataSource = q.ToList();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var q = from p in this.dbContext.Orders.AsEnumerable()
                    where p.OrderDate.Value.Year == Convert.ToInt32(comboBox1.Text) 
                    select p;

            this.dataGridView2.DataSource = q.ToList();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(@"c:\windows");

            System.IO.FileInfo[] files = dir.GetFiles();
            var q = from f in files
                    where f.CreationTime.Year == 2019
                    select f;

            this.dataGridView1.DataSource = q.ToList();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(@"c:\windows");

            System.IO.FileInfo[] files = dir.GetFiles();
            var q = from f in files
                    where f.Length > 100000
                    orderby f.Length descending
                    select f;

            this.dataGridView1.DataSource = q.ToList();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            var q = from s in students_scores
                    where s.Name == "aaa" || s.Name == "bbb" || s.Name == "ccc"
                    select new { s.Name, s.Chi, s.Math };
            this.dataGridView1.DataSource = q.ToList();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            var q = (from s in students_scores
                    select s).Take(3);
            this.dataGridView1.DataSource = q.ToList();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            var q = (from s in students_scores
                     select s).Skip(students_scores.Count() - 2);
            this.dataGridView1.DataSource = q.ToList();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            var q = from s in students_scores
                    where s.Math < 60
                     select s;
            this.dataGridView1.DataSource = q.ToList();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            var q = (from s in students_scores
                    select new { total_count = students_scores.Count()}).Take(1);
            this.dataGridView1.DataSource = q.ToList();

            MessageBox.Show("Total count: " + students_scores.Count().ToString());
        }

        private void button10_Click(object sender, EventArgs e)
        {
            var q = from s in students_scores
                    where s.Name == "bbb"
                    select s;
            this.dataGridView1.DataSource = q.ToList();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            var q = from s in students_scores
                    where s.Name != "bbb"
                    select s;
            this.dataGridView1.DataSource = q.ToList();
        }
    }
}
