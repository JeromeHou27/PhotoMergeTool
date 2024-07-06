using iTextSharp.text;
using iTextSharp.text.pdf;
using Font = iTextSharp.text.Font;
using Image = iTextSharp.text.Image;

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
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != '\b')
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

                genPdf(textBoxPath.Text, info.GetDirectories(), int.Parse(textBoxWidth.Text), int.Parse(textBoxHeight.Text), int.Parse(textBoxLeftBorder.Text));
            }

            labelResult.Text = "完成";
        }

        const float ImageA4 = 210f / 297f;
        const float Imag169 = 9f / 16f;
        const float Image43 = 3f / 4f;

        int width = 0;
        int height = 0;
        int imageW = 0;
        int imageH = 0;
        int[] x;
        int[] y;


        private void drawText(Document doc, PdfContentByte cb, int position, string text)
        {
            ColumnText ct = new ColumnText(cb);

            Font font = new Font(iTextSharp.text.Font.FontFamily.HELVETICA, 12, iTextSharp.text.Font.BOLD);
            Phrase phrase = new Phrase(text, font);

            ct.SetSimpleColumn(new Phrase(text, font), x[position] - width / 8, height - 10, x[position] + width / 8, height - 20, 1.5f, Element.ALIGN_CENTER);
            ct.Go();
        }

        private void drawPage(Document doc, PdfContentByte cb, int position, DirectoryInfo directoryInfo)
        {
            FileInfo[] files = directoryInfo.GetFiles();
            int i = 0;
            foreach (var file in files)
            {
                if (file.Extension.ToLower() != ".jpg" && file.Extension.ToLower() != ".png" && file.Extension.ToLower() != ".jpeg" && file.Extension.ToLower() != ".bmp")
                    continue;

                Image image = Image.GetInstance(file.FullName);
                imageH = (int)((float)image.Height / image.Width * imageW);
                image.ScaleToFit(imageW, imageH);
                image.SetAbsolutePosition(x[position] - imageW / 2, y[i] - imageH / 2);
                cb.AddImage(image);

                if (++i == 2)
                    break;
            }
        }

        private void genPdf(string path, DirectoryInfo[] directoryInfos, int pdfWidth, int pdfHeight, int leftBorder)
        {
            width = pdfWidth;
            height = pdfHeight;
            imageW = (width - (leftBorder * 5)) / 4;
            x = new int[] { width / 8, width * 3 / 8, width * 5 / 8, width * 7 / 8 };
            y = new int[] { height / 4 * 3, height / 4 };

            using (FileStream fs = new FileStream(Path.Combine(path, Path.GetFileName(path) + ".pdf"), FileMode.Create, FileAccess.Write, FileShare.None))
            {
                Document doc = new iTextSharp.text.Document(new RectangleReadOnly(width, height));
                PdfWriter writer = PdfWriter.GetInstance(doc, fs);
                doc.Open();

                for (int i = 0; i < directoryInfos.Length; i++)
                {
                    if (i % 4 == 0)
                        doc.NewPage();

                    drawPage(doc, writer.DirectContent, i % 4, directoryInfos[i]);
                    drawText(doc, writer.DirectContent, i % 4, directoryInfos[i].Name);
                }

                doc.Close();
            }
        }

        //private void mergeImage(DirectoryInfo directoryInfo, int width, int leftBorder)
        //{
        //    int height = (int)(width * ImageA4);
        //    int imageW = (width - (leftBorder * 5)) / 4;
        //    int imageH = 0;

        //    int[] x = { leftBorder, leftBorder * 2 + imageW, leftBorder * 3 + imageW * 2, leftBorder * 4 + imageW * 3 };
        //    int[] y = { height / 4, height / 4 * 3 };

        //    Bitmap bitmap = new Bitmap(width, height);
        //    Graphics g = Graphics.FromImage(bitmap);
        //    g.Clear(Color.White);

        //    FileInfo[] files = directoryInfo.GetFiles();
        //    int i = 0;
        //    foreach (var file in files)
        //    {
        //        if (files[i].Extension.ToLower() != ".jpg" && files[i].Extension.ToLower() != ".png" && files[i].Extension.ToLower() != ".jpeg" && files[i].Extension.ToLower() != ".bmp")
        //        {
        //            continue;
        //        }

        //        System.Drawing.Image image = System.Drawing.Image.FromFile(file.FullName);
        //        imageH = (int)((float)image.Height / image.Width * imageW);
        //        g.DrawImage(image, new Rectangle(x[i % 4], y[i / 4] - imageH / 2, imageW, imageH));
        //        ++i;
        //    }

        //    string filePath = directoryInfo.FullName + ".png";
        //    bitmap.Save(filePath, System.Drawing.Imaging.ImageFormat.Png);
        //}
    }
}