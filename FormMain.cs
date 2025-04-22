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
        private static string OriginalText;
        public FormMain()
        {
            InitializeComponent();
            OriginalText = textBox1.Text;
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
                    OriginalText = textBox1.Text;
                    lblTextChanged.Text = "";
                    break;

            }
        }

        private void 새로만들기ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            lblFileName.Text = "제목없음";
            textBox1.Text = "글자를 입력해 주세요~";
            OriginalText = textBox1.Text;
            lblTextChanged.Text = "";
        }

        private void 저장ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(lblFileName.Text == "제목없음")
            {
                SaveFileDialog saveFileDialog = new SaveFileDialog();
                saveFileDialog.Filter = "텍스트 문서(*.txt)|*.txt|csv 파일(*.csv)|*.csv|모든 파일(*.*)|*.*";
                DialogResult result = saveFileDialog.ShowDialog();

                switch (result)
                {
                    case DialogResult.Cancel:
                        return;
                        break;
                    case DialogResult.OK:
                        lblFileName.Text = saveFileDialog.FileName;
                        break;
                }
            }
            using (StreamWriter sw = new StreamWriter(lblFileName.Text))
            {
                sw.Write(textBox1.Text);
                lblTextChanged.Text = "";
                OriginalText = textBox1.Text;
                sw.Close();
            }
        }

        private void 다른이름으로저장ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "텍스트 문서(*.txt)|*.txt|csv 파일(*.csv)|*.csv|모든 파일(*.*)|*.*";
            saveFileDialog.FileName = lblFileName.Text;
            DialogResult result = saveFileDialog.ShowDialog();

            switch (result)
            {
                case DialogResult.Cancel:
                    return;
                    break;
                case DialogResult.OK:
                    lblFileName.Text = saveFileDialog.FileName;
                    break;
            }
            using (StreamWriter sw = new StreamWriter(lblFileName.Text))
            {
                sw.Write(textBox1.Text);
                OriginalText = textBox1.Text;
                lblTextChanged.Text = "";
                sw.Close();
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if(textBox1.Text != OriginalText)
            {
                lblTextChanged.Text = "✨";
            }
            else
            {
                lblTextChanged.Text = "";
            }

        }
    }
}
