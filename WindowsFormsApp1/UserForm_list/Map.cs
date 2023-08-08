using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Map : UserControl
    {
        public Map()
        {
            InitializeComponent();
            //Process process = new Process();
            //process.StartInfo.FileName = @"python";
            //process.StartInfo.Arguments = @"C:\Users\kdt111\Desktop\FirstProject\API_QT\htmltest.py";
            //process.StartInfo.RedirectStandardOutput = true;
            //process.StartInfo.RedirectStandardError = true;
            //process.StartInfo.UseShellExecute = false;
            //process.Start();
            //string output = process.StandardOutput.ReadToEnd();
            ////Console.WriteLine(output);
            //string url = output;
            //webBrowser1.Navigate(url);
        }
        private void webBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            Console.WriteLine("로딩완료");
        }
    }
}
