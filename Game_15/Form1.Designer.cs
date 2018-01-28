namespace Game_15
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
            this.MainMenu = new System.Windows.Forms.MenuStrip();
            this.MainMenuGame = new System.Windows.Forms.ToolStripMenuItem();
            this.Level1 = new System.Windows.Forms.ToolStripMenuItem();
            this.Level2 = new System.Windows.Forms.ToolStripMenuItem();
            this.Level3 = new System.Windows.Forms.ToolStripMenuItem();
            this.Level4 = new System.Windows.Forms.ToolStripMenuItem();
            this.GameState = new System.Windows.Forms.Label();
            this.GameField = new System.Windows.Forms.DataGridView();
            this.MainMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GameField)).BeginInit();
            this.SuspendLayout();
            // 
            // MainMenu
            // 
            this.MainMenu.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.MainMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MainMenuGame});
            this.MainMenu.Location = new System.Drawing.Point(0, 0);
            this.MainMenu.Name = "MainMenu";
            this.MainMenu.Size = new System.Drawing.Size(740, 28);
            this.MainMenu.TabIndex = 0;
            this.MainMenu.Text = "menuStrip1";
            // 
            // MainMenuGame
            // 
            this.MainMenuGame.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Level1,
            this.Level2,
            this.Level3,
            this.Level4});
            this.MainMenuGame.Name = "MainMenuGame";
            this.MainMenuGame.Size = new System.Drawing.Size(60, 24);
            this.MainMenuGame.Text = "Game";
            // 
            // Level1
            // 
            this.Level1.Name = "Level1";
            this.Level1.Size = new System.Drawing.Size(141, 26);
            this.Level1.Text = "Level 1";
            this.Level1.Click += new System.EventHandler(this.MainMenuGameLevel1_Click);
            // 
            // Level2
            // 
            this.Level2.Name = "Level2";
            this.Level2.Size = new System.Drawing.Size(141, 26);
            this.Level2.Text = "Level 2";
            this.Level2.Click += new System.EventHandler(this.MainMenuGameLevel2_Click);
            // 
            // Level3
            // 
            this.Level3.Name = "Level3";
            this.Level3.Size = new System.Drawing.Size(141, 26);
            this.Level3.Text = "Level 3";
            this.Level3.Click += new System.EventHandler(this.MainMenuGameLevel3_Click);
            // 
            // Level4
            // 
            this.Level4.Name = "Level4";
            this.Level4.Size = new System.Drawing.Size(141, 26);
            this.Level4.Text = "Закрыть";
            this.Level4.Click += new System.EventHandler(this.MainMenuGameExit_Click);
            // 
            // GameState
            // 
            this.GameState.AutoSize = true;
            this.GameState.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.GameState.Location = new System.Drawing.Point(12, 37);
            this.GameState.Name = "GameState";
            this.GameState.Size = new System.Drawing.Size(420, 24);
            this.GameState.TabIndex = 1;
            this.GameState.Text = "The game hasn\'t started yet. Please open a level.";
            // 
            // GameField
            // 
            this.GameField.BackgroundColor = System.Drawing.SystemColors.ActiveCaption;
            this.GameField.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.GameField.Location = new System.Drawing.Point(16, 78);
            this.GameField.Name = "GameField";
            this.GameField.RowTemplate.Height = 24;
            this.GameField.Size = new System.Drawing.Size(701, 425);
            this.GameField.TabIndex = 2;
            this.GameField.CellPainting += new System.Windows.Forms.DataGridViewCellPaintingEventHandler(this.GameField_CellPainting);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(740, 517);
            this.Controls.Add(this.GameField);
            this.Controls.Add(this.GameState);
            this.Controls.Add(this.MainMenu);
            this.MainMenuStrip = this.MainMenu;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form1";
            this.Text = "Сubicon game";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.MainMenu.ResumeLayout(false);
            this.MainMenu.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GameField)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip MainMenu;
        private System.Windows.Forms.ToolStripMenuItem MainMenuGame;
        private System.Windows.Forms.ToolStripMenuItem Level1;
        private System.Windows.Forms.ToolStripMenuItem Level2;
        private System.Windows.Forms.ToolStripMenuItem Level3;
        private System.Windows.Forms.ToolStripMenuItem Level4;
        private System.Windows.Forms.Label GameState;
        private System.Windows.Forms.DataGridView GameField;
    }
}

