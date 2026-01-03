
namespace UDPChatWinForms
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tb_username = new System.Windows.Forms.TextBox();
            this.but_save = new System.Windows.Forms.Button();
            this.but_exit = new System.Windows.Forms.Button();
            this.tb_chat = new System.Windows.Forms.TextBox();
            this.tb_msg = new System.Windows.Forms.TextBox();
            this.but_send = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.but_exit);
            this.groupBox1.Controls.Add(this.but_save);
            this.groupBox1.Controls.Add(this.tb_username);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(460, 77);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Settings";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Введите имя";
            // 
            // tb_username
            // 
            this.tb_username.Location = new System.Drawing.Point(85, 17);
            this.tb_username.Name = "tb_username";
            this.tb_username.Size = new System.Drawing.Size(210, 20);
            this.tb_username.TabIndex = 1;
            // 
            // but_save
            // 
            this.but_save.Location = new System.Drawing.Point(301, 15);
            this.but_save.Name = "but_save";
            this.but_save.Size = new System.Drawing.Size(153, 23);
            this.but_save.TabIndex = 2;
            this.but_save.Text = "Сохранить";
            this.but_save.UseVisualStyleBackColor = true;
            this.but_save.Click += new System.EventHandler(this.but_save_Click);
            // 
            // but_exit
            // 
            this.but_exit.Location = new System.Drawing.Point(301, 44);
            this.but_exit.Name = "but_exit";
            this.but_exit.Size = new System.Drawing.Size(153, 23);
            this.but_exit.TabIndex = 3;
            this.but_exit.Text = "Выйти";
            this.but_exit.UseVisualStyleBackColor = true;
            this.but_exit.Click += new System.EventHandler(this.but_exit_Click);
            // 
            // tb_chat
            // 
            this.tb_chat.Location = new System.Drawing.Point(13, 96);
            this.tb_chat.Multiline = true;
            this.tb_chat.Name = "tb_chat";
            this.tb_chat.ReadOnly = true;
            this.tb_chat.Size = new System.Drawing.Size(459, 245);
            this.tb_chat.TabIndex = 1;
            // 
            // tb_msg
            // 
            this.tb_msg.Location = new System.Drawing.Point(12, 348);
            this.tb_msg.Multiline = true;
            this.tb_msg.Name = "tb_msg";
            this.tb_msg.Size = new System.Drawing.Size(353, 51);
            this.tb_msg.TabIndex = 2;
            // 
            // but_send
            // 
            this.but_send.Location = new System.Drawing.Point(372, 348);
            this.but_send.Name = "but_send";
            this.but_send.Size = new System.Drawing.Size(100, 51);
            this.but_send.TabIndex = 3;
            this.but_send.Text = "Отправить";
            this.but_send.UseVisualStyleBackColor = true;
            this.but_send.Click += new System.EventHandler(this.but_send_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(484, 411);
            this.Controls.Add(this.but_send);
            this.Controls.Add(this.tb_msg);
            this.Controls.Add(this.tb_chat);
            this.Controls.Add(this.groupBox1);
            this.Name = "Form1";
            this.Text = "UDP Chat";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button but_exit;
        private System.Windows.Forms.Button but_save;
        private System.Windows.Forms.TextBox tb_username;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tb_chat;
        private System.Windows.Forms.TextBox tb_msg;
        private System.Windows.Forms.Button but_send;
    }
}

