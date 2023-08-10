using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using WindowsFormsApp1.MainPage;
using WindowsFormsApp1.Sales_Status;
using WindowsFormsApp1.T_indicators_of_change;
using static System.Windows.Forms.AxHost;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

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
        public void LastPage(string[] parts, List<string> rowDataList)
        {

            panel1.Controls.Clear();
            this.page_last = new UserControl1();
            panel1.Controls.Add(this.page_last);
            this.page_last.Show();
            button1.Visible = true;
            PageSwitch = 2;
            string estate_info = rowDataList[0]; // 주소, 면적, 매매가 담고있는 리스트 
            string input = estate_info; // 
            string result = input.Trim(); // 공백 지우기
            string[] parts2 = result.Split('-');

            string esate_la = parts[0];
            string esate_lo = parts[1];
            string esate_sing = parts[2];
            string dong_name = parts[3];
            string dong_code = parts[4];
            //string dong_name = result2;

            string esate_addr = parts2[0];
            string esate_area = parts2[1];
            string esate_price = parts2[2];
            //string labelText = $"{dong_name}의 상권변화지표";
            string input2 = dong_name; // 
            string labelText = input2.Trim(); // 공백 지우기

            this.page_last.label1.Text = $"{labelText}의 상권변화지표";
            this.page_last.label2.Text = esate_sing;
            this.page_last.label7.Text = esate_area;
            this.page_last.label8.Text = esate_price;
            //MessageBox.Show($"{parts[0]}{addr}{area}{price}");
            MessageBox.Show($"{parts2[0]}{parts2[1]}{parts2[2]}");
            //MessageBox.Show(parts[0]+"-"+parts[1]+"-"+parts[2]+"-"+result);
        }
        UserControl1 page_last;

        // 
        private void LastPageMove(object sender, EventArgs e, string[] parts, List<string> rowDataList)
        {
            LastPage(parts, rowDataList);
        }


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
                process.StartInfo.Arguments = @"C:\Users\kdt114\Desktop\FirstProject\Chashtest\mattest.py";
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
            string[] parts;
            List<string> rowDataList = new List<string>();
            // 데이터그리드 클릭한 셀 구분해주는 if문
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0) // 행과 열이 모두 0이상일때 클릭 이벤트 발생
            {
                DataGridViewCell clickedCell = this.page_sub_1.tableControl2.dataGridView1.Rows[e.RowIndex].Cells[0]; // 클릭한 셀의 0번 열에 있는 정보를 clickedCell에 저장
                DataGridViewCell clickedCell2 = this.page_sub_1.tableControl2.dataGridView1.Rows[e.RowIndex].Cells[1]; // 클릭한 셀의 0번 열에 있는 정보를 clickedCell에 저장
                DataGridViewCell clickedCell3 = this.page_sub_1.tableControl2.dataGridView1.Rows[e.RowIndex].Cells[2]; // 클릭한 셀의 0번 열에 있는 정보를 clickedCell에 저장
                //MessageBox.Show("Cell Clicked: " + clickedCell.Value);
                string cellValue = clickedCell.Value.ToString();
                string cellValue2 = clickedCell2.Value.ToString();
                string cellValue3 = clickedCell3.Value.ToString();
                parts = ClickCellInfo(cellValue);
                rowDataList.Add(cellValue + " - " + cellValue2 + "-" + cellValue3);
                // 데이터들 받은뒤에 페이지 넘기기
                LastPageMove(sender, e, parts, rowDataList);
            }
        }

        // 셀 클릭시 .py에 데이터 요청 
        public string[] ClickCellInfo(string estate)
        {
            string c_input = this.page_sub_1.comboBox1.Text;
            string input = estate;
            string result = input.Trim();

            Process process = new Process();//프로세스 객체 생성
            process.StartInfo.FileName = @"python";
            process.StartInfo.Arguments = @"C:\Users\KDT114\Desktop\CorporateProject\c_connector.py";

            process.StartInfo.RedirectStandardOutput = true; // C#변수에 output을 리다이렉트
            process.StartInfo.RedirectStandardInput = true; //.py에 값을 input 할수있게해준다
            process.StartInfo.UseShellExecute = false; // 몰루; 이거해야 제대로 작동함;
            process.StartInfo.CreateNoWindow = true; // 몰루; 이거해야 제대로 작동함;

            process.Start(); // 프로세스를 실행
            char asciiChar = (char)1; // 헤더,데이터 구분자
            char asciiChar2 = (char)2; // 데이터들 구분자

            process.StandardInput.WriteLine($"page_two_estate_click{asciiChar}{result}^{c_input}"); // C#에서 input 값 입력
            process.StandardInput.Flush(); // 인풋 값을 일시적으로 버퍼에 저장 그 값을  .py에 확실하게 넘겨주는 역할
            process.StandardInput.Close(); // input작업을 마친다고 알려주는 코드
            string output = process.StandardOutput.ReadToEnd(); // redirect값을 변수에 담는다
            string[] parts = output.Split(asciiChar);

            return parts;
        }

        public void SubPage() //두번째 페이지 
        {
            panel1.Controls.Clear();
            this.page_sub_1 = new Sales_StatusABC();
            panel1.Controls.Add(this.page_sub_1);
            this.page_sub_1.Show();
            button1.Visible = true;
            PageSwitch = 1;
            this.page_sub_1.comboBox2.Items.Add("선택안함");
            this.page_sub_1.comboBox2.SelectedIndex = 2;
            // 매물 테이블 클릭 이벤트
            this.page_sub_1.tableControl2.dataGridView1.Dock = DockStyle.Fill;
            this.page_sub_1.tableControl2.dataGridView1.CellDoubleClick += DataGridView1_CellClick;

            // 동을바꿀때마다 .py 실행
            this.page_sub_1.comboBox1.TextChanged += subpage_combo_start_py;

            // 평수 콤보박스를 바꿀때마다 .py 실행
            this.page_sub_1.comboBox2.TextChanged += subpage_combo_start_py2;
        }

        // 0809
        // 콤보박스 체인지 이벤트시 매물정보 datagridview에 집어넣기  
        private void subpage_combo_start_py(object sender, EventArgs e)
        {
            Process process = new Process();//프로세스 객체 생성
            try
            {   
                //this.page_sub_1.comboBox2.SelectedIndex = 2;
                string c_input = this.page_sub_1.comboBox1.Text;
                process.StartInfo.FileName = @"python";
                process.StartInfo.Arguments = @"C:\Users\KDT114\Desktop\CorporateProject\c_connector.py";

                process.StartInfo.RedirectStandardOutput = true; // C#변수에 output을 리다이렉트
                process.StartInfo.RedirectStandardInput = true; //.py에 값을 input 할수있게해준다
                process.StartInfo.UseShellExecute = false; // 몰루; 이거해야 제대로 작동함;
                process.StartInfo.CreateNoWindow = true; // 몰루; 이거해야 제대로 작동함;

                process.Start(); // 프로세스를 실행
                char asciiChar = (char)1; // 헤더,데이터 구분자
                char asciiChar2 = (char)2; // 데이터들 나누는 구분자

                process.StandardInput.WriteLine($"page_two_combo1{asciiChar}{c_input}"); // C#에서 input 값 입력
                process.StandardInput.Flush(); // 인풋 값을 일시적으로 버퍼에 저장 그 값을  .py에 확실하게 넘겨주는 역할
                process.StandardInput.Close(); // input작업을 마친다고 알려주는 코드

                string output = process.StandardOutput.ReadToEnd(); // redirect값을 변수에 담는다

                string[] parts = output.Split(asciiChar); // 받아온 행정동별 데이터를 매물별 데이터로 구분해서 배열에 넣는다 예시) [[매물주소(구분자) 면적(구분자) 매매가(구분자)], [[매물주소(구분자) 면적(구분자) 매매가(구분자)]]

                if (this.page_sub_1.tableControl2.dataGridView1.RowCount > 0)
                {
                    this.page_sub_1.tableControl2.dataGridView1.Rows.Clear();
                    this.page_sub_1.tableControl2.dataGridView1.Refresh();
                }
                MessageBox.Show(parts[0]);
                foreach (string part in parts) // 반복문으로 매물정보를 하나씩 꺼내서 데이터그리드에 집어넣는다
                {
                    string[] result = part.Split(asciiChar2); //매물별 데이터를 구분자로 구분해서 배열에 넣는다 예시) [매물주소(구분자) 면적(구분자) 매매가(구분자)] -> [매물주소, 면적, 매매가]
                    this.page_sub_1.tableControl2.dataGridView1.Rows.Add(result[0], result[1], result[2], "확인좀 해보자"); // 배열에 담긴 매물의 정보들을 데이터그리드에 집어넣는다

                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(this, "Error");
            }
        }
       
        // 2번 콤보박스 체인지 이벤트시 매물정보 datagridview에 집어넣기  
        private void subpage_combo_start_py2(object sender, EventArgs e)
        {
            Process process = new Process();//프로세스 객체 생성
            try
            {
                string c_input = this.page_sub_1.comboBox1.Text;
                string c_input2 = this.page_sub_1.comboBox2.Text;
                process.StartInfo.FileName = @"python";
                process.StartInfo.Arguments = @"C:\Users\KDT114\Desktop\CorporateProject\c_connector.py";

                process.StartInfo.RedirectStandardOutput = true; // C#변수에 output을 리다이렉트
                process.StartInfo.RedirectStandardInput = true; //.py에 값을 input 할수있게해준다
                process.StartInfo.UseShellExecute = false; // 몰루; 이거해야 제대로 작동함;
                process.StartInfo.CreateNoWindow = true; // 몰루; 이거해야 제대로 작동함;

                process.Start(); // 프로세스를 실행
                char asciiChar = (char)1; // 헤더,데이터 구분자
                char asciiChar2 = (char)2; // 데이터들 나누는 구분자

                process.StandardInput.WriteLine($"page_two_combo2{asciiChar}{c_input}{asciiChar2}{c_input2}"); // C#에서 input 값 입력
                process.StandardInput.Flush(); // 인풋 값을 일시적으로 버퍼에 저장 그 값을  .py에 확실하게 넘겨주는 역할
                process.StandardInput.Close(); // input작업을 마친다고 알려주는 코드

                string output = process.StandardOutput.ReadToEnd(); // redirect값을 변수에 담는다

                string[] parts = output.Split(asciiChar); // 받아온 행정동별 데이터를 매물별 데이터로 구분해서 배열에 넣는다 예시) [[매물주소(구분자) 면적(구분자) 매매가(구분자)], [[매물주소(구분자) 면적(구분자) 매매가(구분자)]]

                if (this.page_sub_1.tableControl2.dataGridView1.RowCount > 0)
                {
                    this.page_sub_1.tableControl2.dataGridView1.Rows.Clear();
                    this.page_sub_1.tableControl2.dataGridView1.Refresh();
                }

                MessageBox.Show(parts[0]);
                foreach (string part in parts) // 반복문으로 매물정보를 하나씩 꺼내서 데이터그리드에 집어넣는다
                {
                    string[] result = part.Split(asciiChar2); //매물별 데이터를 구분자로 구분해서 배열에 넣는다 예시) [매물주소(구분자) 면적(구분자) 매매가(구분자)] -> [매물주소, 면적, 매매가]
                    this.page_sub_1.tableControl2.dataGridView1.Rows.Add(result[0], result[1], result[2], "확인좀 해보자"); // 배열에 담긴 매물의 정보들을 데이터그리드에 집어넣는다

                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(this, "Error");
            }
        }

    }
}
