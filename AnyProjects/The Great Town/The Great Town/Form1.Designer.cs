namespace The_Great_Town
{
    partial class MainForm
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
            this.tlp_GameField = new System.Windows.Forms.TableLayoutPanel();
            this.console = new System.Windows.Forms.RichTextBox();
            this.btn_del1 = new System.Windows.Forms.Button();
            this.btn_choiseHouse = new System.Windows.Forms.Button();
            this.btn_choisePark = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.l_points = new System.Windows.Forms.Label();
            this.l_pointsCount = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // tlp_GameField
            // 
            this.tlp_GameField.ColumnCount = 10;
            this.tlp_GameField.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tlp_GameField.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tlp_GameField.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tlp_GameField.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tlp_GameField.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tlp_GameField.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tlp_GameField.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tlp_GameField.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tlp_GameField.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tlp_GameField.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tlp_GameField.Location = new System.Drawing.Point(13, 13);
            this.tlp_GameField.Name = "tlp_GameField";
            this.tlp_GameField.RowCount = 10;
            this.tlp_GameField.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tlp_GameField.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tlp_GameField.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tlp_GameField.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tlp_GameField.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tlp_GameField.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tlp_GameField.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tlp_GameField.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tlp_GameField.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tlp_GameField.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tlp_GameField.Size = new System.Drawing.Size(400, 400);
            this.tlp_GameField.TabIndex = 0;
            // 
            // console
            // 
            this.console.Location = new System.Drawing.Point(460, 13);
            this.console.Name = "console";
            this.console.Size = new System.Drawing.Size(412, 234);
            this.console.TabIndex = 1;
            this.console.Text = "";
            // 
            // btn_del1
            // 
            this.btn_del1.Location = new System.Drawing.Point(460, 254);
            this.btn_del1.Name = "btn_del1";
            this.btn_del1.Size = new System.Drawing.Size(112, 23);
            this.btn_del1.TabIndex = 2;
            this.btn_del1.Text = "Перегенерировать";
            this.btn_del1.UseVisualStyleBackColor = true;
            this.btn_del1.Click += new System.EventHandler(this.btn_del1_Click);
            // 
            // btn_choiseHouse
            // 
            this.btn_choiseHouse.BackColor = System.Drawing.Color.Green;
            this.btn_choiseHouse.FlatAppearance.BorderSize = 0;
            this.btn_choiseHouse.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_choiseHouse.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btn_choiseHouse.ForeColor = System.Drawing.Color.White;
            this.btn_choiseHouse.Location = new System.Drawing.Point(460, 284);
            this.btn_choiseHouse.Name = "btn_choiseHouse";
            this.btn_choiseHouse.Size = new System.Drawing.Size(64, 64);
            this.btn_choiseHouse.TabIndex = 3;
            this.btn_choiseHouse.Text = "House";
            this.btn_choiseHouse.UseVisualStyleBackColor = false;
            this.btn_choiseHouse.Click += new System.EventHandler(this.btn_choiseHouse_Click);
            // 
            // btn_choisePark
            // 
            this.btn_choisePark.BackColor = System.Drawing.Color.Gold;
            this.btn_choisePark.FlatAppearance.BorderSize = 0;
            this.btn_choisePark.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_choisePark.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btn_choisePark.ForeColor = System.Drawing.Color.White;
            this.btn_choisePark.Location = new System.Drawing.Point(530, 284);
            this.btn_choisePark.Name = "btn_choisePark";
            this.btn_choisePark.Size = new System.Drawing.Size(64, 64);
            this.btn_choisePark.TabIndex = 4;
            this.btn_choisePark.Text = "Park";
            this.btn_choisePark.UseVisualStyleBackColor = false;
            this.btn_choisePark.Click += new System.EventHandler(this.btn_choisePark_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(578, 255);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(112, 23);
            this.button1.TabIndex = 5;
            this.button1.Text = "Вывести матрицу";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // l_points
            // 
            this.l_points.AutoSize = true;
            this.l_points.Location = new System.Drawing.Point(758, 263);
            this.l_points.Name = "l_points";
            this.l_points.Size = new System.Drawing.Size(39, 13);
            this.l_points.TabIndex = 6;
            this.l_points.Text = "Points:";
            // 
            // l_pointsCount
            // 
            this.l_pointsCount.AutoSize = true;
            this.l_pointsCount.Location = new System.Drawing.Point(803, 263);
            this.l_pointsCount.Name = "l_pointsCount";
            this.l_pointsCount.Size = new System.Drawing.Size(13, 13);
            this.l_pointsCount.TabIndex = 7;
            this.l_pointsCount.Text = "0";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(884, 461);
            this.Controls.Add(this.l_pointsCount);
            this.Controls.Add(this.l_points);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btn_choisePark);
            this.Controls.Add(this.btn_choiseHouse);
            this.Controls.Add(this.btn_del1);
            this.Controls.Add(this.console);
            this.Controls.Add(this.tlp_GameField);
            this.Name = "MainForm";
            this.Text = "The Great Town";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tlp_GameField;
        private System.Windows.Forms.RichTextBox console;
        private System.Windows.Forms.Button btn_del1;
        private System.Windows.Forms.Button btn_choiseHouse;
        private System.Windows.Forms.Button btn_choisePark;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label l_points;
        private System.Windows.Forms.Label l_pointsCount;
    }
}

