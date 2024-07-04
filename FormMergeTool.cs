using System.Drawing;
using System.Drawing.Imaging;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;

namespace PhotoMarginTool
{
    public partial class FormPhotoMergeTool : Form
    {
        public FormPhotoMergeTool()
        {
            InitializeComponent();
        }

        private void buttonPath_Click(object sender, EventArgs e)
        {
            DialogResult result = folderBrowserDialog1.ShowDialog();
            if (result == DialogResult.OK)
            {
                textBoxPath.Text = folderBrowserDialog1.SelectedPath;
            }
        }

        private void textBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void buttonRun_Click(object sender, EventArgs e)
        {
            if (textBoxPath.Text.Length == 0)
            {
                labelResult.Text = "請先選取目錄";
                return;
            }
            else if (textBoxWidth.Text.Length == 0)
            {
                labelResult.Text = "請先輸入寬像素";
                return;
            }

            DirectoryInfo info = new DirectoryInfo(textBoxPath.Text);
            if (!info.Exists)
            {
                labelResult.Text = "目錄不存在";
                return;
            }
            else
            {
                labelResult.Text = "執行中";

                DirectoryInfo[] directories = info.GetDirectories();
                foreach (DirectoryInfo directory in directories)
                {
                    mergeImage(directory, int.Parse(textBoxWidth.Text), int.Parse(textBoxLeftBorder.Text));
                }
            }

            labelResult.Text = "完成";
        }

        const float ImageA4 = 210f / 297f;
        const float Imag169 = 9f / 16f;
        const float Image43 = 3f / 4f;

        private void mergeImage(DirectoryInfo directoryInfo, int width, int leftBorder)
        {
            int height = (int)(width * ImageA4);
            int imageW = (width - (leftBorder * 5)) / 4;
            int imageH = 0;

            int[] x = { leftBorder, leftBorder * 2 + imageW, leftBorder * 3 + imageW * 2, leftBorder * 4 + imageW * 3 };
            int[] y = { height / 4, height / 4 * 3 };

            Bitmap bitmap = new Bitmap(width, height);
            Graphics g = Graphics.FromImage(bitmap);
            g.Clear(Color.White);

            FileInfo[] files = directoryInfo.GetFiles();
            int i = 0;
            foreach (var file in files)
            {
                if (files[i].Extension.ToLower() != ".jpg" && files[i].Extension.ToLower() != ".png" && files[i].Extension.ToLower() != ".jpeg" && files[i].Extension.ToLower() != ".bmp")
                {
                    continue;
                }

                System.Drawing.Image image = System.Drawing.Image.FromFile(file.FullName);
                imageH = (int)((float)image.Height / image.Width * imageW);
                g.DrawImage(image, new Rectangle(x[i % 4], y[i / 4] - imageH / 2, imageW, imageH));
                ++i;
            }

            string filePath = directoryInfo.FullName + ".png";
            bitmap.Save(filePath, System.Drawing.Imaging.ImageFormat.Png);
        }
    }
}