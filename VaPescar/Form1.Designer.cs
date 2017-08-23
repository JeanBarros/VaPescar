namespace VaPescar
{
    partial class Form1
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
            this.listHand = new System.Windows.Forms.ListBox();
            this.textProgress = new System.Windows.Forms.TextBox();
            this.textBooks = new System.Windows.Forms.TextBox();
            this.btnAsk = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnStart = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // listHand
            // 
            this.listHand.FormattingEnabled = true;
            this.listHand.Location = new System.Drawing.Point(344, 36);
            this.listHand.Name = "listHand";
            this.listHand.Size = new System.Drawing.Size(162, 407);
            this.listHand.TabIndex = 0;
            // 
            // textProgress
            // 
            this.textProgress.Location = new System.Drawing.Point(13, 82);
            this.textProgress.Multiline = true;
            this.textProgress.Name = "textProgress";
            this.textProgress.ReadOnly = true;
            this.textProgress.Size = new System.Drawing.Size(308, 257);
            this.textProgress.TabIndex = 1;
            // 
            // textBooks
            // 
            this.textBooks.Location = new System.Drawing.Point(13, 369);
            this.textBooks.Multiline = true;
            this.textBooks.Name = "textBooks";
            this.textBooks.ReadOnly = true;
            this.textBooks.Size = new System.Drawing.Size(308, 107);
            this.textBooks.TabIndex = 2;
            // 
            // btnAsk
            // 
            this.btnAsk.Enabled = false;
            this.btnAsk.Location = new System.Drawing.Point(344, 453);
            this.btnAsk.Name = "btnAsk";
            this.btnAsk.Size = new System.Drawing.Size(162, 23);
            this.btnAsk.TabIndex = 3;
            this.btnAsk.Text = "Perguntar por uma carta";
            this.btnAsk.UseVisualStyleBackColor = true;
            this.btnAsk.Click += new System.EventHandler(this.btnAsk_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Seu nome";
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(13, 36);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(196, 20);
            this.txtName.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(10, 66);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(92, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Progresso do jogo";
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(227, 36);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(94, 23);
            this.btnStart.TabIndex = 7;
            this.btnStart.Text = "Começar o jogo";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(341, 20);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(49, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "Sua mão";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(13, 350);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(35, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "Livros";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(522, 489);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnAsk);
            this.Controls.Add(this.textBooks);
            this.Controls.Add(this.textProgress);
            this.Controls.Add(this.listHand);
            this.Name = "Form1";
            this.Text = "Vá pescar!";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox listHand;
        private System.Windows.Forms.TextBox textProgress;
        private System.Windows.Forms.TextBox textBooks;
        private System.Windows.Forms.Button btnAsk;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
    }
}

