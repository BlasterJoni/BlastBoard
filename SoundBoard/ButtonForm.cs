using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SoundBoard
{
    public partial class ButtonForm : Form
    {
        public ButtonForm(string textParam="", string fileParam = "", string imageParam = "", string backgroundParam = "")
        {
            InitializeComponent();
            TextTexbox.Text = textParam;
            FilePathTextBox.Text = fileParam;
            ImagePathTextBox.Text = imageParam;
            BackgroundPathTextBox.Text = backgroundParam;
        }

        public string text;
        public Color textColor;
        public string file;
        public string image;
        public string background;

        private void ButtonFormSaveButton_Click(object sender, EventArgs e)
        {
            text = TextTexbox.Text;
            textColor = OpenColorPickerButton.BackColor;
            file = FilePathTextBox.Text;
            image = ImagePathTextBox.Text;
            background = BackgroundPathTextBox.Text;
            DialogResult = DialogResult.OK;
            Close();
        }

        private void TextTexbox_TextChanged(object sender, EventArgs e)
        {
            PreviewButton.Text = TextTexbox.Text;
        }

        private void ImagePathTextBox_TextChanged(object sender, EventArgs e)
        {
            PreviewButton.Image = Image.FromFile(ImagePathTextBox.Text);
            PreviewButton.ImageAlign = ContentAlignment.MiddleLeft;
        }

        private void BackgroundPathTextBox_TextChanged(object sender, EventArgs e)
        {
            PreviewButton.BackgroundImage = Image.FromFile(BackgroundPathTextBox.Text);
            PreviewButton.BackgroundImageLayout = ImageLayout.Stretch;
        }

        private void OpenColorPickerButton_BackColorChanged(object sender, EventArgs e)
        {
            PreviewButton.ForeColor = OpenColorPickerButton.BackColor;
        }

        private void OpenFileBrowserButton_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog fileDialog = new OpenFileDialog())
            {
                fileDialog.Filter = "Sound Files|*.wav;*.wave;*.aiff;*.aif;*.aifc;*.wma;*.sf2;*.mp3";
                DialogResult result = fileDialog.ShowDialog();
                if (result == DialogResult.OK)
                {
                    FilePathTextBox.Text = fileDialog.FileName;
                }
            }
        }

        private void OpenImageBrowserButton_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog fileDialog = new OpenFileDialog())
            {
                fileDialog.Filter = "Image Files|*.bmp;*.dib;*.gif;*.jpg;*.jpeg;*.jpe;*.jif;*.jfif;*.jfi;*.png;*.tiff;*.tif";
                DialogResult result = fileDialog.ShowDialog();
                if (result == DialogResult.OK)
                {
                    ImagePathTextBox.Text = fileDialog.FileName;
                }
            }
        }

        private void OpenBackgroundBrowserButton_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog fileDialog = new OpenFileDialog())
            {
                fileDialog.Filter = "Image Files|*.bmp;*.dib;*.gif;*.jpg;*.jpeg;*.jpe;*.jif;*.jfif;*.jfi;*.png;*.tiff;*.tif";
                DialogResult result = fileDialog.ShowDialog();
                if (result == DialogResult.OK)
                {
                    BackgroundPathTextBox.Text = fileDialog.FileName;
                }
            }
        }

        private void OpenColorPickerButton_Click(object sender, EventArgs e)
        {
            using (ColorDialog colorDialog = new ColorDialog())
            {
                DialogResult result = colorDialog.ShowDialog();
                if (result == DialogResult.OK)
                {
                    OpenColorPickerButton.BackColor = colorDialog.Color;
                }
            }
        }
    }
}
