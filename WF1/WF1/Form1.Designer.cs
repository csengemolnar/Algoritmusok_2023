namespace WF1
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            button1 = new Button();
            listBox2 = new ListBox();
            richTextBox1 = new RichTextBox();
            SuspendLayout();
            // 
            // button1
            // 
            button1.Location = new Point(270, 185);
            button1.Name = "button1";
            button1.Size = new Size(108, 59);
            button1.TabIndex = 0;
            button1.Text = "Megoldás";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // listBox2
            // 
            listBox2.FormattingEnabled = true;
            listBox2.ItemHeight = 15;
            listBox2.Location = new Point(439, 185);
            listBox2.Name = "listBox2";
            listBox2.Size = new Size(120, 79);
            listBox2.TabIndex = 2;
            // 
            // richTextBox1
            // 
            richTextBox1.Location = new Point(53, 144);
            richTextBox1.Name = "richTextBox1";
            richTextBox1.Size = new Size(179, 189);
            richTextBox1.TabIndex = 3;
            richTextBox1.Text = "6 7\r\n1 2 5\r\n1 3 3\r\n2 4 2\r\n3 4 4\r\n2 5 3\r\n4 6 8\r\n5 6 1\r\n";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(richTextBox1);
            Controls.Add(listBox2);
            Controls.Add(button1);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
        }

        #endregion

        private Button button1;
        private ListBox listBox2;
        private RichTextBox richTextBox1;
    }
}