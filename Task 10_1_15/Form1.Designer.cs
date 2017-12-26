namespace Task_10_1_15
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.InputDGV = new System.Windows.Forms.DataGridView();
            this.X1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Y1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.X2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Y2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.X3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Y3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RandomizeBtn = new System.Windows.Forms.Button();
            this.SubmitBTN = new System.Windows.Forms.Button();
            this.ClearBTN = new System.Windows.Forms.Button();
            this.OpenBTN = new System.Windows.Forms.Button();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.OutLB = new System.Windows.Forms.ListBox();
            ((System.ComponentModel.ISupportInitialize)(this.InputDGV)).BeginInit();
            this.SuspendLayout();
            // 
            // InputDGV
            // 
            this.InputDGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.InputDGV.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.X1,
            this.Y1,
            this.X2,
            this.Y2,
            this.X3,
            this.Y3});
            this.InputDGV.Location = new System.Drawing.Point(9, 10);
            this.InputDGV.Margin = new System.Windows.Forms.Padding(2);
            this.InputDGV.Name = "InputDGV";
            this.InputDGV.RowTemplate.Height = 24;
            this.InputDGV.Size = new System.Drawing.Size(458, 439);
            this.InputDGV.TabIndex = 0;
            // 
            // X1
            // 
            this.X1.HeaderText = "X1";
            this.X1.Name = "X1";
            this.X1.Width = 64;
            // 
            // Y1
            // 
            this.Y1.HeaderText = "Y1";
            this.Y1.Name = "Y1";
            this.Y1.Width = 64;
            // 
            // X2
            // 
            this.X2.HeaderText = "X2";
            this.X2.Name = "X2";
            this.X2.Width = 64;
            // 
            // Y2
            // 
            this.Y2.HeaderText = "Y2";
            this.Y2.Name = "Y2";
            this.Y2.Width = 64;
            // 
            // X3
            // 
            this.X3.HeaderText = "X3";
            this.X3.Name = "X3";
            this.X3.Width = 64;
            // 
            // Y3
            // 
            this.Y3.HeaderText = "Y3";
            this.Y3.Name = "Y3";
            this.Y3.Width = 64;
            // 
            // RandomizeBtn
            // 
            this.RandomizeBtn.Location = new System.Drawing.Point(127, 456);
            this.RandomizeBtn.Margin = new System.Windows.Forms.Padding(2);
            this.RandomizeBtn.Name = "RandomizeBtn";
            this.RandomizeBtn.Size = new System.Drawing.Size(110, 28);
            this.RandomizeBtn.TabIndex = 1;
            this.RandomizeBtn.Text = "Randomize";
            this.RandomizeBtn.UseVisualStyleBackColor = true;
            this.RandomizeBtn.Click += new System.EventHandler(this.RandomizeBtn_Click);
            // 
            // SubmitBTN
            // 
            this.SubmitBTN.Location = new System.Drawing.Point(241, 456);
            this.SubmitBTN.Margin = new System.Windows.Forms.Padding(2);
            this.SubmitBTN.Name = "SubmitBTN";
            this.SubmitBTN.Size = new System.Drawing.Size(110, 28);
            this.SubmitBTN.TabIndex = 3;
            this.SubmitBTN.Text = "Submit";
            this.SubmitBTN.UseVisualStyleBackColor = true;
            this.SubmitBTN.Click += new System.EventHandler(this.SubmitBTN_Click);
            // 
            // ClearBTN
            // 
            this.ClearBTN.Location = new System.Drawing.Point(356, 455);
            this.ClearBTN.Margin = new System.Windows.Forms.Padding(2);
            this.ClearBTN.Name = "ClearBTN";
            this.ClearBTN.Size = new System.Drawing.Size(110, 28);
            this.ClearBTN.TabIndex = 4;
            this.ClearBTN.Text = "Clear";
            this.ClearBTN.UseVisualStyleBackColor = true;
            this.ClearBTN.Click += new System.EventHandler(this.ClearBTN_Click);
            // 
            // OpenBTN
            // 
            this.OpenBTN.Location = new System.Drawing.Point(12, 456);
            this.OpenBTN.Name = "OpenBTN";
            this.OpenBTN.Size = new System.Drawing.Size(110, 28);
            this.OpenBTN.TabIndex = 5;
            this.OpenBTN.Text = "Open";
            this.OpenBTN.UseVisualStyleBackColor = true;
            this.OpenBTN.Click += new System.EventHandler(this.OpenBTN_Click);
            // 
            // OutLB
            // 
            this.OutLB.FormattingEnabled = true;
            this.OutLB.Location = new System.Drawing.Point(472, 12);
            this.OutLB.Name = "OutLB";
            this.OutLB.Size = new System.Drawing.Size(190, 472);
            this.OutLB.TabIndex = 6;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(674, 493);
            this.Controls.Add(this.OutLB);
            this.Controls.Add(this.OpenBTN);
            this.Controls.Add(this.ClearBTN);
            this.Controls.Add(this.SubmitBTN);
            this.Controls.Add(this.RandomizeBtn);
            this.Controls.Add(this.InputDGV);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Form1";
            this.Text = "Task 10_1_15";
            ((System.ComponentModel.ISupportInitialize)(this.InputDGV)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView InputDGV;
        private System.Windows.Forms.Button RandomizeBtn;
        private System.Windows.Forms.DataGridViewTextBoxColumn X1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Y1;
        private System.Windows.Forms.DataGridViewTextBoxColumn X2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Y2;
        private System.Windows.Forms.DataGridViewTextBoxColumn X3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Y3;
        private System.Windows.Forms.Button SubmitBTN;
        private System.Windows.Forms.Button ClearBTN;
        private System.Windows.Forms.Button OpenBTN;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.ListBox OutLB;
    }
}

