using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsAppTime
{
    public partial class Form1 : Form
    {
        int count;//用于定时器计数
        int time;//存储设定的定时值
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            int i;
            for (i = 1; i < 100; i++)//计数范围
            {
                comboBox1.Items.Add(i.ToString() + " 秒");
            }
        }

        private void timer1_Tick(object sender, EventArgs e)//定时器事件
        {
            count++;//记下当前秒
            label3.Text = (time - count).ToString() + "秒";//显示剩余时间
            progressBar1.Value = count;//设置进度条进度
            if(count == time)
            {
                timer1.Stop();//时间到，停止计时
                System.Media.SystemSounds.Asterisk.Play();//提示音
                MessageBox.Show("时间到了", "提示");//弹出提示框
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string str = comboBox1.Text;//将下拉框内容添加到一个变量中
            string data = str.Substring(0, 2);
            time = Convert.ToInt16(data);//得到设定的定时器值
            progressBar1.Maximum = time;//进度条的最大值
            timer1.Start();
        }
    }
}
