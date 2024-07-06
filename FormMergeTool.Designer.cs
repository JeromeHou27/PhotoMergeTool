namespace PhotoMarginTool
{
    partial class FormPhotoMergeTool
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
            folderBrowserDialog1 = new FolderBrowserDialog();
            buttonPath = new Button();
            textBoxPath = new TextBox();
            textBoxWidth = new TextBox();
            labelWidth = new Label();
            buttonRun = new Button();
            labelResult = new Label();
            labelLeftBorder = new Label();
            textBoxLeftBorder = new TextBox();
            textBoxHeight = new TextBox();
            labelHeight = new Label();
            SuspendLayout();
            // 
            // buttonPath
            // 
            buttonPath.Location = new Point(37, 27);
            buttonPath.Margin = new Padding(2);
            buttonPath.Name = "buttonPath";
            buttonPath.Size = new Size(73, 23);
            buttonPath.TabIndex = 0;
            buttonPath.Text = "目錄";
            buttonPath.UseVisualStyleBackColor = true;
            buttonPath.Click += buttonPath_Click;
            // 
            // textBoxPath
            // 
            textBoxPath.Location = new Point(131, 27);
            textBoxPath.Margin = new Padding(2);
            textBoxPath.Name = "textBoxPath";
            textBoxPath.ReadOnly = true;
            textBoxPath.Size = new Size(418, 23);
            textBoxPath.TabIndex = 1;
            textBoxPath.WordWrap = false;
            // 
            // textBoxWidth
            // 
            textBoxWidth.Location = new Point(95, 81);
            textBoxWidth.Margin = new Padding(2);
            textBoxWidth.MaxLength = 5;
            textBoxWidth.Name = "textBoxWidth";
            textBoxWidth.Size = new Size(98, 23);
            textBoxWidth.TabIndex = 2;
            textBoxWidth.Text = "842";
            textBoxWidth.KeyPress += textBox_KeyPress;
            // 
            // labelWidth
            // 
            labelWidth.AutoSize = true;
            labelWidth.Location = new Point(37, 84);
            labelWidth.Margin = new Padding(2, 0, 2, 0);
            labelWidth.Name = "labelWidth";
            labelWidth.Size = new Size(43, 15);
            labelWidth.TabIndex = 4;
            labelWidth.Text = "寬像素";
            // 
            // buttonRun
            // 
            buttonRun.Location = new Point(37, 177);
            buttonRun.Margin = new Padding(2);
            buttonRun.Name = "buttonRun";
            buttonRun.Size = new Size(73, 23);
            buttonRun.TabIndex = 5;
            buttonRun.Text = "執行";
            buttonRun.UseVisualStyleBackColor = true;
            buttonRun.Click += buttonRun_Click;
            // 
            // labelResult
            // 
            labelResult.AutoSize = true;
            labelResult.Location = new Point(152, 181);
            labelResult.Margin = new Padding(2, 0, 2, 0);
            labelResult.Name = "labelResult";
            labelResult.Size = new Size(0, 15);
            labelResult.TabIndex = 6;
            // 
            // labelLeftBorder
            // 
            labelLeftBorder.AutoSize = true;
            labelLeftBorder.Location = new Point(37, 138);
            labelLeftBorder.Margin = new Padding(2, 0, 2, 0);
            labelLeftBorder.Name = "labelLeftBorder";
            labelLeftBorder.Size = new Size(43, 15);
            labelLeftBorder.TabIndex = 8;
            labelLeftBorder.Text = "左邊界";
            // 
            // textBoxLeftBorder
            // 
            textBoxLeftBorder.Location = new Point(95, 135);
            textBoxLeftBorder.Margin = new Padding(2);
            textBoxLeftBorder.MaxLength = 5;
            textBoxLeftBorder.Name = "textBoxLeftBorder";
            textBoxLeftBorder.Size = new Size(98, 23);
            textBoxLeftBorder.TabIndex = 3;
            textBoxLeftBorder.Text = "8";
            // 
            // textBoxHeight
            // 
            textBoxHeight.Location = new Point(95, 108);
            textBoxHeight.Margin = new Padding(2);
            textBoxHeight.MaxLength = 5;
            textBoxHeight.Name = "textBoxHeight";
            textBoxHeight.Size = new Size(98, 23);
            textBoxHeight.TabIndex = 2;
            textBoxHeight.Text = "595";
            textBoxHeight.KeyPress += textBox_KeyPress;
            // 
            // labelHeight
            // 
            labelHeight.AutoSize = true;
            labelHeight.Location = new Point(37, 111);
            labelHeight.Margin = new Padding(2, 0, 2, 0);
            labelHeight.Name = "labelHeight";
            labelHeight.Size = new Size(43, 15);
            labelHeight.TabIndex = 4;
            labelHeight.Text = "高像素";
            // 
            // FormPhotoMergeTool
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(587, 258);
            Controls.Add(labelLeftBorder);
            Controls.Add(textBoxLeftBorder);
            Controls.Add(labelResult);
            Controls.Add(buttonRun);
            Controls.Add(labelHeight);
            Controls.Add(labelWidth);
            Controls.Add(textBoxHeight);
            Controls.Add(textBoxWidth);
            Controls.Add(textBoxPath);
            Controls.Add(buttonPath);
            Margin = new Padding(2);
            Name = "FormPhotoMergeTool";
            Text = "PhotoMergeTool";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private FolderBrowserDialog folderBrowserDialog1;
        private Button buttonPath;
        private TextBox textBoxPath;
        private TextBox textBoxWidth;
        private Label labelWidth;
        private Button buttonRun;
        private Label labelResult;
        private Label labelLeftBorder;
        private TextBox textBoxLeftBorder;
        private TextBox textBoxHeight;
        private Label labelHeight;
    }
}