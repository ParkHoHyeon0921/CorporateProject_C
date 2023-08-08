namespace WindowsFormsApp1.Sales_Status
{
    partial class Sales_StatusABC
    {
        /// <summary> 
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 구성 요소 디자이너에서 생성한 코드

        /// <summary> 
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel2 = new System.Windows.Forms.Panel();
            this.tableControl2 = new WindowsFormsApp1.UserForm_list.TableControl();
            this.panel1 = new System.Windows.Forms.Panel();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.map3 = new WindowsFormsApp1.Map();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.White;
            this.panel2.Controls.Add(this.tableControl2);
            this.panel2.Location = new System.Drawing.Point(815, 0);
            this.panel2.Margin = new System.Windows.Forms.Padding(0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(420, 653);
            this.panel2.TabIndex = 2;
            // 
            // tableControl2
            // 
            this.tableControl2.Location = new System.Drawing.Point(5, 3);
            this.tableControl2.Name = "tableControl2";
            this.tableControl2.Size = new System.Drawing.Size(410, 647);
            this.tableControl2.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.checkBox1);
            this.panel1.Controls.Add(this.comboBox2);
            this.panel1.Controls.Add(this.comboBox1);
            this.panel1.Controls.Add(this.map3);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(794, 653);
            this.panel1.TabIndex = 1;
            // 
            // checkBox1
            // 
            this.checkBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(213)))), ((int)(((byte)(236)))), ((int)(((byte)(230)))));
            this.checkBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.checkBox1.Location = new System.Drawing.Point(271, 5);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(138, 37);
            this.checkBox1.TabIndex = 3;
            this.checkBox1.Text = "매물 안보기";
            this.checkBox1.UseVisualStyleBackColor = false;
            // 
            // comboBox2
            // 
            this.comboBox2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(213)))), ((int)(((byte)(236)))), ((int)(((byte)(230)))));
            this.comboBox2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.IntegralHeight = false;
            this.comboBox2.ItemHeight = 25;
            this.comboBox2.Items.AddRange(new object[] {
            "10평 이하",
            "10평 이상"});
            this.comboBox2.Location = new System.Drawing.Point(131, 5);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(121, 33);
            this.comboBox2.TabIndex = 2;
            // 
            // comboBox1
            // 
            this.comboBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(213)))), ((int)(((byte)(236)))), ((int)(((byte)(230)))));
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.IntegralHeight = false;
            this.comboBox1.ItemHeight = 25;
            this.comboBox1.Items.AddRange(new object[] {
            "보라매동",
            "청림동",
            "성현동",
            "행운동",
            "낙성대동",
            "청룡동",
            "은천동",
            "중앙동",
            "인헌동",
            "남현동",
            "서원동",
            "신원동",
            "서림동",
            "신사동",
            "신림동",
            "난향동",
            "조원동",
            "대학동",
            "삼성동",
            "미성동",
            "난곡동"});
            this.comboBox1.Location = new System.Drawing.Point(4, 4);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 33);
            this.comboBox1.TabIndex = 2;
            // 
            // map3
            // 
            this.map3.Location = new System.Drawing.Point(3, 48);
            this.map3.Name = "map3";
            this.map3.Size = new System.Drawing.Size(788, 602);
            this.map3.TabIndex = 1;
            // 
            // Sales_StatusABC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "Sales_StatusABC";
            this.Size = new System.Drawing.Size(1260, 662);
            this.panel2.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private Map map1;
        private System.Windows.Forms.Panel panel2;
        private UserForm_list.TableControl tableControl1;
        private Map map3;
        private System.Windows.Forms.Panel panel1;
        public System.Windows.Forms.ComboBox comboBox1;
        public System.Windows.Forms.ComboBox comboBox2;
        private System.Windows.Forms.CheckBox checkBox1;
        public UserForm_list.TableControl tableControl2;
    }
}
