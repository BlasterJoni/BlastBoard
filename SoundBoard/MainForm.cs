using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using NAudio;
using NAudio.Wave;
using Newtonsoft.Json;

namespace BlastBoard
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }    

        public class MusicButtonInfo
        {
            public string text;
            public Color textColor;
            public string file;
            public string image;
            public string background;

            public MusicButtonInfo(string text, Color textColor, string file, string image, string background )
            {
                this.text = text;
                this.textColor = textColor;
                this.file = file;
                this.image = image;
                this.background = background;
            }
        }
        public List<MusicButtonInfo> CurrentButtons;
        public string ButtonLayoutsPath = System.Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + @"\BlastBoard\ButtonLayouts\";

        private AudioPlaybackEngine AudioEngine;

        private void CloseAudioEngine()
        {
            if (AudioEngine != null)
            {
                AudioEngine.Dispose();
                AudioEngine = null;
            }
        }

        private void CreateAudioEngine()
        {
            CloseAudioEngine();
            AudioEngine = new AudioPlaybackEngine();
        }

        private void ReloadButtons()
        {
            while(flowLayoutPanel1.Controls.Count > 0)
            {
                flowLayoutPanel1.Controls[0].Dispose();
            }
            foreach (MusicButtonInfo i in CurrentButtons)
            {
                Button button = new Button()
                {
                    Text = i.text,
                    ForeColor = i.textColor,
                    MinimumSize = new Size(75, 75),
                    ContextMenuStrip = ButtonContextMenu,
                    Font = new Font("Microsoft Sans Serif", 8.25F, FontStyle.Bold),
                    ImageAlign = ContentAlignment.MiddleLeft,
                    BackgroundImageLayout = ImageLayout.Stretch,
                };
                button.Image = (File.Exists(i.image)) ? Image.FromFile(i.image) : null;
                button.BackgroundImage = (File.Exists(i.background)) ? Image.FromFile(i.background) : null;

                if (File.Exists(i.file))
                {
                    button.Click += new EventHandler((object sender, EventArgs e) =>
                    {
                        AudioEngine.PlaySound(i.file);
                    });
                }
                flowLayoutPanel1.Controls.Add(button);
            }
        }

        private void ChangeLayout()
        {
            string text = File.ReadAllText(ButtonLayoutsPath + Properties.Settings.Default.Layout + ".json");
            CurrentButtons = JsonConvert.DeserializeObject<List<MusicButtonInfo>>(text);
            ReloadButtons();
        }

        private void UpdateLayouts()
        {
            Directory.CreateDirectory(ButtonLayoutsPath);
            IEnumerable<string> Layouts = Directory.EnumerateFiles(ButtonLayoutsPath, "*.json");
            if (LayoutSelectorComboBox.Items.Count > 0)
            {
                LayoutSelectorComboBox.Items.Clear();
            }
            if (Layouts.Count() > 0)
            {
                foreach (string i in Layouts)
                {
                    string a = i.Replace(ButtonLayoutsPath, "").Replace(".json", "");
                    LayoutSelectorComboBox.Items.Add(a);
                }
                if (File.Exists(ButtonLayoutsPath + Properties.Settings.Default.Layout + ".json"))
                {
                    LayoutSelectorComboBox.SelectedItem = Properties.Settings.Default.Layout;
                }
                else
                {
                    LayoutSelectorComboBox.SelectedIndex = 0;
                    Properties.Settings.Default.Layout = LayoutSelectorComboBox.SelectedItem.ToString();
                }
            }
            else
            {
                File.WriteAllText(ButtonLayoutsPath + "DefaultLayout.json", "[]");
                LayoutSelectorComboBox.Items.Add("DefaultLayout");
                LayoutSelectorComboBox.SelectedItem = "DefaultLayout";
                Properties.Settings.Default.Layout = "DefaultLayout";
            }
            ChangeLayout();
        }

        private void SaveLayout()
        {
            string text = JsonConvert.SerializeObject(CurrentButtons);
            File.WriteAllText(ButtonLayoutsPath + Properties.Settings.Default.Layout + ".json", text);
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            CreateAudioEngine();
            UpdateLayouts();
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            SaveLayout();
            Properties.Settings.Default.Save();
        }

        private void StopButton_Click(object sender, EventArgs e)
        {
            AudioEngine.StopSound();
        }

        private void LayoutSelectorComboBox_SelectionChangeCommitted(object sender, EventArgs e)
        {
            SaveLayout();
            Properties.Settings.Default.Layout = LayoutSelectorComboBox.SelectedItem.ToString();
            ChangeLayout();
        }


        private void settingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (SettingsForm settingsWindow = new SettingsForm())
            {
                DialogResult result = settingsWindow.ShowDialog();
            }
            CreateAudioEngine();
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (AboutForm aboutWindow = new AboutForm())
            {
                DialogResult result = aboutWindow.ShowDialog();
            }
        }

        private void addButtonToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (ButtonForm buttonWindow = new ButtonForm())
            {
                DialogResult result = buttonWindow.ShowDialog();
                if (result == DialogResult.OK)
                {
                    MusicButtonInfo buttonToAdd = new MusicButtonInfo(buttonWindow.text, buttonWindow.textColor, buttonWindow.file, buttonWindow.image, buttonWindow.background);
                    CurrentButtons.Add(buttonToAdd);
                    ReloadButtons();
                }
            }
        }

        private void removeButtonToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Thanks StackOverflow
            // Try to cast the sender to a ToolStripItem
            ToolStripItem menuItem = sender as ToolStripItem;
            if (menuItem != null)
            {
                // Retrieve the ContextMenuStrip that owns this ToolStripItem
                ContextMenuStrip owner = menuItem.Owner as ContextMenuStrip;
                if (owner != null)
                {
                    // Get the control that is displaying this context menu
                    Control sourceControl = owner.SourceControl;

                    // My code
                    int index = flowLayoutPanel1.Controls.IndexOf(sourceControl);
                    CurrentButtons.RemoveAt(index);
                    ReloadButtons();
                }
            }
        }

        private void editButtonToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Thanks StackOverflow
            // Try to cast the sender to a ToolStripItem
            ToolStripItem menuItem = sender as ToolStripItem;
            if (menuItem != null)
            {
                // Retrieve the ContextMenuStrip that owns this ToolStripItem
                ContextMenuStrip owner = menuItem.Owner as ContextMenuStrip;
                if (owner != null)
                {
                    // Get the control that is displaying this context menu
                    Control sourceControl = owner.SourceControl;

                    // My code
                    int index = flowLayoutPanel1.Controls.IndexOf(sourceControl);
                    MusicButtonInfo ButtonToEdit = CurrentButtons[index];
                    using (ButtonForm buttonWindow = new ButtonForm(ButtonToEdit.text, ButtonToEdit.textColor.ToArgb(), ButtonToEdit.file, ButtonToEdit.image, ButtonToEdit.background))
                    {
                        DialogResult result = buttonWindow.ShowDialog();
                        if (result == DialogResult.OK)
                        {
                            ButtonToEdit.text = buttonWindow.text;
                            ButtonToEdit.textColor = buttonWindow.textColor;
                            ButtonToEdit.file = buttonWindow.file;
                            ButtonToEdit.image = buttonWindow.image;
                            ButtonToEdit.background = buttonWindow.background;
                            ReloadButtons();
                        }
                    }

                }
            }
        }

        private void addLayoutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (LayoutForm layoutWindow = new LayoutForm(LayoutSelectorComboBox.Items))
            {
                DialogResult result = layoutWindow.ShowDialog();
                if (result == DialogResult.OK)
                {
                    File.WriteAllText(ButtonLayoutsPath + layoutWindow.name + ".json", "[]");
                    //We save the current layout and set the default layout the new one so that
                    //when it loads the layout list it changes the layout to the new one.
                    SaveLayout();
                    Properties.Settings.Default.Layout = layoutWindow.name;
                    UpdateLayouts();
                }
            }
        }

        private void editLayoutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (LayoutForm layoutWindow = new LayoutForm(LayoutSelectorComboBox.Items, LayoutSelectorComboBox.SelectedItem.ToString()))
            {
                DialogResult result = layoutWindow.ShowDialog();
                if (result == DialogResult.OK)
                {
                    if (File.Exists(ButtonLayoutsPath + layoutWindow.name + ".json"))
                    {
                        File.Delete(ButtonLayoutsPath + layoutWindow.name + ".json");
                    }
                    File.Move(ButtonLayoutsPath + LayoutSelectorComboBox.SelectedItem.ToString() + ".json", ButtonLayoutsPath + layoutWindow.name + ".json");
                    /*
                    When we save the layout it saves to the default name layout(current layout), so we got change the default layout to the new name before saving. 
                    Otherwise we would endup with both the old layout name and the new one.
                    */
                    //Changes save location to the new one, by changin the default/current layout var.
                    Properties.Settings.Default.Layout = layoutWindow.name;
                    //Saves layout to new file.
                    SaveLayout();
                    //Reloads layout list, changes to the new name one, unloads buttons, reloads buttons.
                    UpdateLayouts();
                }
            }
        }

        private void removeLayoutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (File.Exists(ButtonLayoutsPath + LayoutSelectorComboBox.SelectedItem.ToString() + ".json"))
            {
                File.Delete(ButtonLayoutsPath + LayoutSelectorComboBox.SelectedItem.ToString() + ".json");
            }
            UpdateLayouts();
        }

        private void LocalVolumeBar_Scroll(object sender, EventArgs e)
        {
            float volumePercent = (float)LocalVolumeBar.Value;
            if (LinkCheck.Checked)
            {
                OutputVolumeBar.Value = LocalVolumeBar.Value;
                if (OutputCheck.Checked)
                {
                    AudioEngine.SetOutputVolume(volumePercent);
                }
            }
            if (LocalCheck.Checked)
            {
                AudioEngine.SetLocalVolume(volumePercent);
            }
        }

        private void OutputVolumeBar_Scroll(object sender, EventArgs e)
        {
            float volumePercent = (float)OutputVolumeBar.Value;
            if (LinkCheck.Checked)
            {
                LocalVolumeBar.Value = OutputVolumeBar.Value;
                if (LocalCheck.Checked)
                {
                    AudioEngine.SetLocalVolume(volumePercent);
                }
            }
            if (OutputCheck.Checked)
            {
                AudioEngine.SetOutputVolume(volumePercent);
            }
        }

        private void LocalCheck_CheckedChanged(object sender, EventArgs e)
        {
            if (!LocalCheck.Checked)
            {
                AudioEngine.SetLocalVolume(0.0f);
            }
            else
            {
                float volumePercent = (float)LocalVolumeBar.Value;
                AudioEngine.SetLocalVolume(volumePercent);
            }
        }

        private void OutputCheck_CheckedChanged(object sender, EventArgs e)
        {
            if (!OutputCheck.Checked)
            {
                AudioEngine.SetOutputVolume(0.0f);
            }
            else
            {
                float volumePercent = (float)OutputVolumeBar.Value;
                AudioEngine.SetOutputVolume(volumePercent);
            }
        }
    }
}
