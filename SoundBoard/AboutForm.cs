using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;
using System.Reflection;

namespace BlastBoard
{
    public partial class AboutForm : Form
    {
        public AboutForm()
        {
            InitializeComponent();
        }

        public string ExeFolder = Path.GetDirectoryName(System.Reflection.Assembly.GetEntryAssembly().Location);

        private void button2_Click(object sender, EventArgs e)
        {
            Process.Start(ExeFolder + @"\Resources\Licenses\BlastBoard_license.txt");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Console.WriteLine(ExeFolder);
            Process.Start(ExeFolder + @"\Resources\Licenses");
        }

        private void LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
           LinkLabel link = sender as LinkLabel;
           Process.Start(link.Text);
        }

        private void AboutForm_Load(object sender, EventArgs e)
        {
            label2.Text = "Version " + Assembly.GetExecutingAssembly().GetName().Version.ToString();
        }
    }
}
