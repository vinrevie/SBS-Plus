namespace SBS_Plus.Windows
{
    partial class MainWindow
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.NewDocBtn = new System.Windows.Forms.Button();
            this.CloseKSBtn = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.tableWork = new System.Windows.Forms.DataGridView();
            this.numberCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NameCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.volumeCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.mesuareCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.priceCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.costCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.orgSearch = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.dogText = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.yearNumber = new System.Windows.Forms.TextBox();
            this.addressView = new System.Windows.Forms.TextBox();
            this.dateTimePicker2 = new System.Windows.Forms.DateTimePicker();
            this.label5 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.tableWork)).BeginInit();
            this.SuspendLayout();
            // 
            // NewDocBtn
            // 
            this.NewDocBtn.Location = new System.Drawing.Point(195, 750);
            this.NewDocBtn.Name = "NewDocBtn";
            this.NewDocBtn.Size = new System.Drawing.Size(200, 69);
            this.NewDocBtn.TabIndex = 1;
            this.NewDocBtn.Text = "Создать / отредактировать договор Word";
            this.NewDocBtn.UseVisualStyleBackColor = true;
            this.NewDocBtn.Click += new System.EventHandler(this.newDocButton_Click);
            // 
            // CloseKSBtn
            // 
            this.CloseKSBtn.Location = new System.Drawing.Point(958, 762);
            this.CloseKSBtn.Name = "CloseKSBtn";
            this.CloseKSBtn.Size = new System.Drawing.Size(200, 69);
            this.CloseKSBtn.TabIndex = 2;
            this.CloseKSBtn.Text = "Закрыть документ КС";
            this.CloseKSBtn.UseVisualStyleBackColor = true;
            this.CloseKSBtn.Click += new System.EventHandler(this.CloseKSBtn_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(643, 299);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(39, 29);
            this.button3.TabIndex = 39;
            this.button3.Text = "+";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // tableWork
            // 
            this.tableWork.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.tableWork.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.tableWork.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tableWork.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.numberCol,
            this.NameCol,
            this.volumeCol,
            this.mesuareCol,
            this.priceCol,
            this.costCol});
            this.tableWork.Location = new System.Drawing.Point(195, 371);
            this.tableWork.Name = "tableWork";
            this.tableWork.RowHeadersWidth = 62;
            this.tableWork.RowTemplate.Height = 28;
            this.tableWork.Size = new System.Drawing.Size(963, 315);
            this.tableWork.TabIndex = 38;
            this.tableWork.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.tableWork_DataError);
            this.tableWork.RowsAdded += new System.Windows.Forms.DataGridViewRowsAddedEventHandler(this.tableWork_RowsAdded);
            // 
            // numberCol
            // 
            this.numberCol.HeaderText = "№";
            this.numberCol.MinimumWidth = 8;
            this.numberCol.Name = "numberCol";
            // 
            // NameCol
            // 
            this.NameCol.HeaderText = "Наименование работ";
            this.NameCol.MinimumWidth = 8;
            this.NameCol.Name = "NameCol";
            // 
            // volumeCol
            // 
            this.volumeCol.HeaderText = "Объем";
            this.volumeCol.MinimumWidth = 8;
            this.volumeCol.Name = "volumeCol";
            // 
            // mesuareCol
            // 
            this.mesuareCol.HeaderText = "Ед. измер.";
            this.mesuareCol.MinimumWidth = 8;
            this.mesuareCol.Name = "mesuareCol";
            // 
            // priceCol
            // 
            this.priceCol.HeaderText = "Цена за ед.";
            this.priceCol.MinimumWidth = 8;
            this.priceCol.Name = "priceCol";
            // 
            // costCol
            // 
            this.costCol.HeaderText = "Стоимость работ";
            this.costCol.MinimumWidth = 8;
            this.costCol.Name = "costCol";
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Location = new System.Drawing.Point(298, 156);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(200, 26);
            this.dateTimePicker1.TabIndex = 37;
            // 
            // orgSearch
            // 
            this.orgSearch.FormattingEnabled = true;
            this.orgSearch.Location = new System.Drawing.Point(307, 297);
            this.orgSearch.Name = "orgSearch";
            this.orgSearch.Size = new System.Drawing.Size(151, 28);
            this.orgSearch.TabIndex = 36;
            this.orgSearch.SelectionChangeCommitted += new System.EventHandler(this.orgSearch_SelectionChangeCommitted);
            this.orgSearch.TextChanged += new System.EventHandler(this.orgSearch_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(191, 300);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(108, 20);
            this.label3.TabIndex = 35;
            this.label3.Text = "Организация";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(200, 204);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(57, 20);
            this.label4.TabIndex = 33;
            this.label4.Text = "Адрес";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(200, 156);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(48, 20);
            this.label2.TabIndex = 32;
            this.label2.Text = "Дата";
            // 
            // dogText
            // 
            this.dogText.Location = new System.Drawing.Point(307, 105);
            this.dogText.Name = "dogText";
            this.dogText.Size = new System.Drawing.Size(152, 26);
            this.dogText.TabIndex = 31;
            this.dogText.TextChanged += new System.EventHandler(this.dogText_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(200, 111);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(92, 20);
            this.label1.TabIndex = 30;
            this.label1.Text = "Договор №";
            // 
            // yearNumber
            // 
            this.yearNumber.Location = new System.Drawing.Point(1038, 103);
            this.yearNumber.Name = "yearNumber";
            this.yearNumber.Size = new System.Drawing.Size(100, 26);
            this.yearNumber.TabIndex = 42;
            // 
            // addressView
            // 
            this.addressView.Location = new System.Drawing.Point(298, 204);
            this.addressView.Multiline = true;
            this.addressView.Name = "addressView";
            this.addressView.Size = new System.Drawing.Size(358, 64);
            this.addressView.TabIndex = 43;
            // 
            // dateTimePicker2
            // 
            this.dateTimePicker2.Location = new System.Drawing.Point(698, 106);
            this.dateTimePicker2.Name = "dateTimePicker2";
            this.dateTimePicker2.Size = new System.Drawing.Size(200, 26);
            this.dateTimePicker2.TabIndex = 45;
            this.dateTimePicker2.ValueChanged += new System.EventHandler(this.dateTimePicker2_ValueChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(552, 106);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(124, 20);
            this.label5.TabIndex = 44;
            this.label5.Text = "Дата закрыьтя";
            this.label5.Click += new System.EventHandler(this.label5_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(1176, 186);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(237, 64);
            this.textBox1.TabIndex = 46;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(1176, 256);
            this.textBox2.Multiline = true;
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(237, 64);
            this.textBox2.TabIndex = 47;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(1098, 223);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(55, 20);
            this.label6.TabIndex = 48;
            this.label6.Text = "Аванс";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(972, 300);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(181, 20);
            this.label7.TabIndex = 49;
            this.label7.Text = "Промежуточный аванс";
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1447, 877);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.dateTimePicker2);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.addressView);
            this.Controls.Add(this.yearNumber);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.tableWork);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.orgSearch);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dogText);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.CloseKSBtn);
            this.Controls.Add(this.NewDocBtn);
            this.Name = "MainWindow";
            this.Text = "MainWindow";
            ((System.ComponentModel.ISupportInitialize)(this.tableWork)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button NewDocBtn;
        private System.Windows.Forms.Button CloseKSBtn;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.DataGridView tableWork;
        private System.Windows.Forms.DataGridViewTextBoxColumn numberCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn NameCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn volumeCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn mesuareCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn priceCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn costCol;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.ComboBox orgSearch;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox dogText;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox yearNumber;
        private System.Windows.Forms.TextBox addressView;
        private System.Windows.Forms.DateTimePicker dateTimePicker2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
    }
}