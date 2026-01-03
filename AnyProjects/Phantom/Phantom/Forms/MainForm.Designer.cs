
namespace Phantom
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
            this.p_title = new System.Windows.Forms.Panel();
            this.l_title = new System.Windows.Forms.Label();
            this.but_add = new System.Windows.Forms.Button();
            this.lB_list = new System.Windows.Forms.ListBox();
            this.l_listname = new System.Windows.Forms.Label();
            this.p_title.SuspendLayout();
            this.SuspendLayout();
            // 
            // p_title
            // 
            this.p_title.BackColor = System.Drawing.Color.Tomato;
            this.p_title.Controls.Add(this.l_title);
            this.p_title.Dock = System.Windows.Forms.DockStyle.Top;
            this.p_title.Location = new System.Drawing.Point(0, 0);
            this.p_title.Name = "p_title";
            this.p_title.Size = new System.Drawing.Size(350, 75);
            this.p_title.TabIndex = 0;
            // 
            // l_title
            // 
            this.l_title.AutoSize = true;
            this.l_title.Font = new System.Drawing.Font("Roboto Bk", 26F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.l_title.ForeColor = System.Drawing.Color.White;
            this.l_title.Location = new System.Drawing.Point(95, 16);
            this.l_title.Name = "l_title";
            this.l_title.Size = new System.Drawing.Size(161, 42);
            this.l_title.TabIndex = 0;
            this.l_title.Text = "Phantom";
            // 
            // but_add
            // 
            this.but_add.BackColor = System.Drawing.Color.White;
            this.but_add.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.but_add.FlatAppearance.BorderColor = System.Drawing.Color.Tomato;
            this.but_add.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.but_add.Font = new System.Drawing.Font("Roboto Bk", 26F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.but_add.ForeColor = System.Drawing.Color.Tomato;
            this.but_add.Location = new System.Drawing.Point(0, 500);
            this.but_add.Name = "but_add";
            this.but_add.Size = new System.Drawing.Size(350, 50);
            this.but_add.TabIndex = 1;
            this.but_add.Text = "Add";
            this.but_add.UseVisualStyleBackColor = false;
            // 
            // lB_list
            // 
            this.lB_list.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lB_list.Font = new System.Drawing.Font("Roboto Bk", 16F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lB_list.ForeColor = System.Drawing.Color.Tomato;
            this.lB_list.FormattingEnabled = true;
            this.lB_list.HorizontalScrollbar = true;
            this.lB_list.ItemHeight = 25;
            this.lB_list.Location = new System.Drawing.Point(12, 114);
            this.lB_list.Name = "lB_list";
            this.lB_list.Size = new System.Drawing.Size(326, 375);
            this.lB_list.TabIndex = 2;
            // 
            // l_listname
            // 
            this.l_listname.AutoSize = true;
            this.l_listname.Font = new System.Drawing.Font("Roboto Bk", 18F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.l_listname.ForeColor = System.Drawing.Color.Tomato;
            this.l_listname.Location = new System.Drawing.Point(149, 80);
            this.l_listname.Name = "l_listname";
            this.l_listname.Size = new System.Drawing.Size(53, 29);
            this.l_listname.TabIndex = 3;
            this.l_listname.Text = "List";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(350, 550);
            this.Controls.Add(this.l_listname);
            this.Controls.Add(this.lB_list);
            this.Controls.Add(this.but_add);
            this.Controls.Add(this.p_title);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Name = "MainForm";
            this.Text = "Form1";
            this.p_title.ResumeLayout(false);
            this.p_title.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel p_title;
        private System.Windows.Forms.Label l_title;
        private System.Windows.Forms.Button but_add;
        private System.Windows.Forms.ListBox lB_list;
        private System.Windows.Forms.Label l_listname;
    }
}

