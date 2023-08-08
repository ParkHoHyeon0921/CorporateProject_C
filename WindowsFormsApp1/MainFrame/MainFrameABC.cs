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
using WindowsFormsApp1.MainPage;
using WindowsFormsApp1.Sales_Status;
using WindowsFormsApp1.T_indicators_of_change;

namespace MainFrame
{
    
    public partial class MainFrameABC : Form
    {
        public MainFrameABC()
        {
            InitializeComponent();
            Home();
        }
        /// <summary>
        /// HomePage Move Setting
        /// </summary>
        public void Home()
        {
            panel1.Controls.Clear();
            this.page_home = new MainPageABC();
            panel1.Controls.Add(this.page_home);
            this.page_home.Show();
            button1.Visible = false;
            this.page_home.ranking1.button1.Click += SubPageMove;
            this.page_home.ranking1.comboBox1.TextChanged += starttext; // 관악구 행정동별 현황 확인 콤보박스 텍스트값 변화시 발생하는 이벤트


            PageSwitch = 0;
        }
        MainPageABC page_home;
        int PageSwitch = 0;

        /// <summary>
        /// SubPage Move Setting
        /// </summary>
        //public void SubPage()
        //{
        //    panel1.Controls.Clear();
        //    this.page_sub_1 = new Sales_StatusABC();
        //    panel1.Controls.Add(this.page_sub_1);
        //    this.page_sub_1.Show();
        //    button1.Visible = true;
        //    PageSwitch = 1;
        //}
        Sales_StatusABC page_sub_1;
        public void LastPage()
        {
            panel1.Controls.Clear();
            this.page_last = new UserControl1();
            panel1.Controls.Add(this.page_sub_1);
            this.page_last.Show();
            button1.Visible = true;
            PageSwitch = 2;
        }
        UserControl1 page_last;



        /// <summary>
        /// MainPage "매물보기"btn click event => SubPageMove
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SubPageMove(object sender, EventArgs e)
        {
            SubPage();
        }
        /// <summary>
        /// PrevPageBtn Function
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            if (PageSwitch == 1 || PageSwitch == 2)
            {
                Home();
            }
            else if (PageSwitch == 0)
            {
                SubPage();
            }
        }
        /// <summary>
        /// 기능 : 관악구 행정동별 현황 확인 콤보박스 변화시 해당 텍스트에 맞춰서 해당 이미지를 가지고 오는기능
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void starttext(object sender, EventArgs e)
        {
            Process process = new Process();
            try
            {
                process.StartInfo.FileName = @"python";
                process.StartInfo.Arguments = @"C:\Users\kdt111\Desktop\FirstProject\Chashtest\mattest.py";
                process.StartInfo.RedirectStandardInput = true;
                process.StartInfo.RedirectStandardOutput = true;
                process.StartInfo.UseShellExecute = false;
                process.StartInfo.CreateNoWindow = true;
                process.Start();
                process.StandardInput.WriteLine(this.page_home.ranking1.comboBox1.Text);
                process.StandardInput.Flush();
                process.StandardInput.Close();
                string output = process.StandardOutput.ReadToEnd();
                Image img = Image.FromFile(output);
                this.page_home.pictureBox1.Image = img;
                //process.Kill();
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, "Error");
            }
        }

        // 이종혁========================================================================================================================
        private void DataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                DataGridViewCell clickedCell = this.page_sub_1.tableControl2.dataGridView1.Rows[e.RowIndex].Cells[0];
                MessageBox.Show("Cell Clicked: " + clickedCell.Value);
            }
        }


        public void SubPage() //두번째 페이지 
        {
            panel1.Controls.Clear();
            this.page_sub_1 = new Sales_StatusABC();
            panel1.Controls.Add(this.page_sub_1);
            this.page_sub_1.Show();
            button1.Visible = true;
            PageSwitch = 1;

            this.page_sub_1.tableControl2.dataGridView1.Dock = DockStyle.Fill;
            this.page_sub_1.tableControl2.dataGridView1.Rows.Add("ID 1", "제목 1번", "사용중", "2019/03/11", "2019/03/18");
            this.page_sub_1.tableControl2.dataGridView1.CellClick += DataGridView1_CellClick;
            this.page_home.ranking1.comboBox1.TextChanged += starttext;
        }

    }
}
