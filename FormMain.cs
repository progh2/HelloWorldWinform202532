using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HelloWorldWinform
{
    public partial class FormMain: Form
    {
        public FormMain()
        {
            InitializeComponent();
        }

        private void btnPush_Click(object sender, EventArgs e)
        {
            lblTitle.Text = "쾅~~~";
        }

        private void 끝내기ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void 프로그램정보ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // 모달(Modal) 창            
            Form formAbout1 = new FormAbout();
            formAbout1.Text = "모달창";
            formAbout1.ShowDialog();

            // 모달리스(Modeless) 창 
            Form formAbout2 = new FormAbout();            
            formAbout2.Text = "모달리스창";
            formAbout2.Show();

        }

        private void 열기ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "텍스트 문서(*.txt)|*.txt|csv 파일(*.csv)|*.csv|모든 파일(*.*)|*.*";
            DialogResult result = openFileDialog.ShowDialog();

            switch (result)
            {
                case DialogResult.Cancel:
                    return;
                    break;
                case DialogResult.OK:
                    lblFileName.Text = openFileDialog.FileName;
                    using (StreamReader sr = new StreamReader(openFileDialog.FileName))
                    {
                        textBox1.Text = sr.ReadToEnd();
                        sr.Close();
                    }
                    break;

            }
        }
    }
}
