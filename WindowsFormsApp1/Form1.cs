using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp1.ServiceReference1;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        ServiceReference1.WebService1SoapClient service = new ServiceReference1.WebService1SoapClient();
        List<Student> students = new List<Student>();
        public Form1()
        {
            InitializeComponent();
           
        }

       public void loadData()
        {
            students = service.getAll().ToList();
            listView1.Items.Clear();
            foreach(Student st in students)
            {
                listView1.Items.Add( st.ma + "-" + st.ten);
            }
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string text1 = textBox1.Text;
            string text2 = textBox2.Text;
            service.addStudent(text1, text2);
            loadData();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            textBox2.Clear();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if(listView1.SelectedIndex >= 0)
            {
                 string text1 = listView1.SelectedItem.ToString().Split('-')[0];
                 service.deleteStudent(text1);
                 loadData();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            students = service.getAll().ToList();
            Student student = students.Find((st) => st.ma == textBox1.Text  );
            textBox1.Text = student.ma;
            textBox2.Text = student.ten;
        }
    }
}
