using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace xmplay
{
    public partial class Form1 : Form
    {
        public string filename;//保存音乐文件路径
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //打开选择文件对话框
            openFileDialog1.ShowDialog();
        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {       
            //将用户选择的文件路径副职给播放器
            wmp1.URL = openFileDialog1.FileName;
            button2.Text = "暂停(&p)";//更改按钮标题。
            this.Text = "熊猫音乐播放器" + " - 正在播放："+wmp1.currentMedia.getItemInfo("title");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (wmp1.playState == WMPLib.WMPPlayState.wmppsPlaying)
            {
                wmp1.Ctlcontrols.pause();
                button2.Text = "播放(&p)";

            }
            else
            {
                wmp1.Ctlcontrols.play();
                button2.Text = "暂停(&p)";
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            wmp1.Ctlcontrols.stop();
            button2.Text = "播放(&p)";
        }

        private void button4_Click(object sender, EventArgs e)
        {
            wmp1.settings.volume = wmp1.settings.volume + 3;
        }

        private void button5_Click(object sender, EventArgs e)
        {
                if (wmp1.settings.volume>9)
            {
                wmp1.settings.volume = wmp1.settings.volume - 2;
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            wmp1.Ctlcontrols.currentPosition = wmp1.Ctlcontrols.currentPosition + 3;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            wmp1.Ctlcontrols.currentPosition = wmp1.Ctlcontrols.currentPosition -3;
        }
    }
}
