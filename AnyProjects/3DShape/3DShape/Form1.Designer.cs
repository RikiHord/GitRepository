namespace _3DShape
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
            this.pb_forShape = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pb_forShape)).BeginInit();
            this.SuspendLayout();
            // 
            // pb_forShape
            // 
            this.pb_forShape.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.pb_forShape.Location = new System.Drawing.Point(12, 12);
            this.pb_forShape.Name = "pb_forShape";
            this.pb_forShape.Size = new System.Drawing.Size(616, 616);
            this.pb_forShape.TabIndex = 0;
            this.pb_forShape.TabStop = false;
            this.pb_forShape.Paint += new System.Windows.Forms.PaintEventHandler(this.pb_forShape_Paint);
            this.pb_forShape.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pb_forShape_MouseDown);
            this.pb_forShape.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pb_forShape_MouseMove);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(978, 644);
            this.Controls.Add(this.pb_forShape);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "Form1";
            this.Text = "3DShape";
            ((System.ComponentModel.ISupportInitialize)(this.pb_forShape)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pb_forShape;
    }
}

