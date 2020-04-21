using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _8_puzzleGUI
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            Control.CheckForIllegalCrossThreadCalls = false;
        }
        

        private void button2_Click(object sender, EventArgs e)
        {
            Thread thr = new Thread(new ThreadStart(Start));
            thr.Start();
        }

        void Start()
        {
            foreach (TextBox item in flowLayoutPanel3.Controls)
            {
                item.Text = "";
            }
            tbKQ.Text = "";
            int[] a = new int[9];
            int q = 0;
            bool check1 = true;
            foreach (TextBox item in flowLayoutPanel1.Controls)
            {
                try
                {
                    a[q] = int.Parse(item.Text);
                    q = q + 1;
                }
                catch (Exception)
                {
                    MessageBox.Show("Bạn đã nhập dữ liệu không phải số hoặc có ô chưa nhập ở puzzle bắt đầu", "Lưu ý");
                    check1 = false;
                    break;
                }
            }
            if (check1 == true) ThuatToan.S0 = ThuatToan.chuyen2(a);

            a = new int[9];
            q = 0;
            bool check2 = true;
            foreach (TextBox item in flowLayoutPanel2.Controls)
            {
                try
                {
                    a[q] = int.Parse(item.Text);
                    q = q + 1;
                }
                catch (Exception)
                {
                    MessageBox.Show("Bạn đã nhập dữ liệu không phải số hoặc có ô chưa nhập ở puzzle kết thúc", "Lưu ý");
                    check2 = false;
                    break;
                }
            }
            if (check2 == true) ThuatToan.G = ThuatToan.chuyen2(a);

            bool check3 = true;
            int time = 0;
            try
            {
                time = int.Parse(tbDelay.Text);
            }
            catch
            {
                MessageBox.Show("Ô Delay nhập phải là số hoặc đang bị bỏ trống");
                check3 = false;
            }
            if (check1 == true && check2 == true && check3 == true)
            {
                ThuatToan.xuly();
                for (int i = 0; i < ThuatToan.KQ.n; i++)
                {
                    string t;
                    if (ThuatToan.KQ.e[i].go == 1)
                        t = "UP->";
                    else if (ThuatToan.KQ.e[i].go == 2)
                        t = "DOWN->";
                    else if (ThuatToan.KQ.e[i].go == 3)
                        t = "LEFT->";
                    else if (ThuatToan.KQ.e[i].go == 4)
                        t = "RIGHT->";
                    else t = "END";
                    tbKQ.Text = tbKQ.Text + t;
                    a = new int[9];
                    q = 0;
                    a = ThuatToan.chuyen1(ThuatToan.KQ.e[i].S);
                    foreach (TextBox item in flowLayoutPanel3.Controls)
                    {
                        item.Text = a[q].ToString();
                        q = q + 1;
                    }

                    Thread.Sleep(time);
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form2 name = new Form2();
            name.Show();
        }
    }
}
