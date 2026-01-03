namespace Rofl
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.TSSetting = new System.Windows.Forms.ToolStripDropDownButton();
            this.TSSetting_theme = new System.Windows.Forms.ToolStripMenuItem();
            this.light_theme = new System.Windows.Forms.ToolStripMenuItem();
            this.dark_theme = new System.Windows.Forms.ToolStripMenuItem();
            this.TSSetting_complexity = new System.Windows.Forms.ToolStripMenuItem();
            this.gg = new System.Windows.Forms.ToolStripMenuItem();
            this.TSSetting_language = new System.Windows.Forms.ToolStripMenuItem();
            this.rusL = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.Exit = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.TSAboutTheProgram = new System.Windows.Forms.ToolStripDropDownButton();
            this.TSATG_about_the_game = new System.Windows.Forms.ToolStripMenuItem();
            this.TSATG_Innovation = new System.Windows.Forms.ToolStripMenuItem();
            this.button2 = new System.Windows.Forms.Button();
            this.engL = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.AutoSize = true;
            this.button1.Location = new System.Drawing.Point(360, 239);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(82, 23);
            this.button1.TabIndex = 0;
            this.button1.TabStop = false;
            this.button1.Text = "Нажми меня";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            this.button1.Enter += new System.EventHandler(this.button1_Enter);
            this.button1.MouseEnter += new System.EventHandler(this.button1_MouseEnter);
            this.button1.MouseHover += new System.EventHandler(this.button1_MouseHover);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Impact", 14F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label1.Location = new System.Drawing.Point(540, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(124, 23);
            this.label1.TabIndex = 1;
            this.label1.Text = "Your attempts:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Impact", 14F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(670, 25);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(20, 23);
            this.label2.TabIndex = 2;
            this.label2.Text = "0";
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.TSSetting,
            this.toolStripSeparator1,
            this.TSAboutTheProgram});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(784, 25);
            this.toolStrip1.TabIndex = 3;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // TSSetting
            // 
            this.TSSetting.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.TSSetting.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.TSSetting_theme,
            this.TSSetting_complexity,
            this.TSSetting_language,
            this.toolStripSeparator2,
            this.Exit});
            this.TSSetting.Image = ((System.Drawing.Image)(resources.GetObject("TSSetting.Image")));
            this.TSSetting.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.TSSetting.Name = "TSSetting";
            this.TSSetting.Size = new System.Drawing.Size(80, 22);
            this.TSSetting.Text = "Настройки";
            // 
            // TSSetting_theme
            // 
            this.TSSetting_theme.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.light_theme,
            this.dark_theme});
            this.TSSetting_theme.Name = "TSSetting_theme";
            this.TSSetting_theme.Size = new System.Drawing.Size(180, 22);
            this.TSSetting_theme.Text = "Фон";
            // 
            // light_theme
            // 
            this.light_theme.Checked = true;
            this.light_theme.CheckState = System.Windows.Forms.CheckState.Checked;
            this.light_theme.Name = "light_theme";
            this.light_theme.Size = new System.Drawing.Size(180, 22);
            this.light_theme.Text = "Светлий";
            this.light_theme.Click += new System.EventHandler(this.light_theme_Click);
            // 
            // dark_theme
            // 
            this.dark_theme.Name = "dark_theme";
            this.dark_theme.Size = new System.Drawing.Size(180, 22);
            this.dark_theme.Text = "Темний";
            this.dark_theme.Click += new System.EventHandler(this.dark_theme_Click);
            // 
            // TSSetting_complexity
            // 
            this.TSSetting_complexity.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.gg});
            this.TSSetting_complexity.Name = "TSSetting_complexity";
            this.TSSetting_complexity.Size = new System.Drawing.Size(180, 22);
            this.TSSetting_complexity.Text = "Сложность";
            // 
            // gg
            // 
            this.gg.Checked = true;
            this.gg.CheckState = System.Windows.Forms.CheckState.Checked;
            this.gg.Name = "gg";
            this.gg.Size = new System.Drawing.Size(180, 22);
            this.gg.Text = "В разработке";
            // 
            // TSSetting_language
            // 
            this.TSSetting_language.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.rusL,
            this.engL});
            this.TSSetting_language.Name = "TSSetting_language";
            this.TSSetting_language.Size = new System.Drawing.Size(180, 22);
            this.TSSetting_language.Text = "Язик";
            // 
            // rusL
            // 
            this.rusL.Name = "rusL";
            this.rusL.Size = new System.Drawing.Size(180, 22);
            this.rusL.Text = "Русcкий";
            this.rusL.Click += new System.EventHandler(this.rusL_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(177, 6);
            // 
            // Exit
            // 
            this.Exit.Name = "Exit";
            this.Exit.Size = new System.Drawing.Size(180, 22);
            this.Exit.Text = "Виход";
            this.Exit.Click += new System.EventHandler(this.Exit_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // TSAboutTheProgram
            // 
            this.TSAboutTheProgram.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.TSAboutTheProgram.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.TSATG_about_the_game,
            this.TSATG_Innovation});
            this.TSAboutTheProgram.Image = ((System.Drawing.Image)(resources.GetObject("TSAboutTheProgram.Image")));
            this.TSAboutTheProgram.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.TSAboutTheProgram.Name = "TSAboutTheProgram";
            this.TSAboutTheProgram.Size = new System.Drawing.Size(86, 22);
            this.TSAboutTheProgram.Text = "О програме";
            // 
            // TSATG_about_the_game
            // 
            this.TSATG_about_the_game.Name = "TSATG_about_the_game";
            this.TSATG_about_the_game.Size = new System.Drawing.Size(180, 22);
            this.TSATG_about_the_game.Text = "О игре";
            this.TSATG_about_the_game.Click += new System.EventHandler(this.about_the_game_Click);
            // 
            // TSATG_Innovation
            // 
            this.TSATG_Innovation.Name = "TSATG_Innovation";
            this.TSATG_Innovation.Size = new System.Drawing.Size(180, 22);
            this.TSATG_Innovation.Text = "Нововидения";
            this.TSATG_Innovation.Click += new System.EventHandler(this.Innovation_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(0, 0);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(1, 1);
            this.button2.TabIndex = 4;
            this.button2.UseVisualStyleBackColor = false;
            // 
            // engL
            // 
            this.engL.Checked = true;
            this.engL.CheckState = System.Windows.Forms.CheckState.Checked;
            this.engL.Name = "engL";
            this.engL.Size = new System.Drawing.Size(180, 22);
            this.engL.Text = "English";
            this.engL.Click += new System.EventHandler(this.engL_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 461);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "Form1";
            this.Text = "Rofl v4.5.3 Alpha";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripDropDownButton TSSetting;
        private System.Windows.Forms.ToolStripMenuItem TSSetting_theme;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem light_theme;
        private System.Windows.Forms.ToolStripMenuItem dark_theme;
        private System.Windows.Forms.ToolStripMenuItem TSSetting_complexity;
        private System.Windows.Forms.ToolStripMenuItem gg;
        private System.Windows.Forms.ToolStripMenuItem TSSetting_language;
        private System.Windows.Forms.ToolStripMenuItem rusL;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem Exit;
        private System.Windows.Forms.ToolStripDropDownButton TSAboutTheProgram;
        private System.Windows.Forms.ToolStripMenuItem TSATG_about_the_game;
        private System.Windows.Forms.ToolStripMenuItem TSATG_Innovation;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.ToolStripMenuItem engL;
    }
}

