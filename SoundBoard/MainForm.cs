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
using Fleck;

namespace BlastBoard
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private List<MusicButtonInfo> CurrentButtons;
        private string CurrentLayout;
        private string ButtonLayoutsPath = System.Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + @"\BlastBoard\ButtonLayouts\";

        private AudioPlaybackEngine AudioEngine;

        private WebSocketServer RemoteServer;
        private List<IWebSocketConnection> CurrentRemotes = new List<IWebSocketConnection>();

        private void SendMessageServer(IWebSocketConnection socket, string messageType)
        {
            int localVolumeToSend = 0;
            int outputVolumeToSend = 0;
            LocalVolumeBar.Invoke(new MethodInvoker(() =>
            {
                localVolumeToSend = LocalVolumeBar.Value;
                outputVolumeToSend = OutputVolumeBar.Value;
            }));
            RemoteMessageToSend messageToSend = new RemoteMessageToSend(
                messageType,
                LocalCheck.Checked,
                localVolumeToSend,
                LinkCheck.Checked,
                OutputCheck.Checked,
                outputVolumeToSend,
                LayoutSelectorComboBox.SelectedText,
                LayoutSelectorComboBox.Items,
                CurrentButtons
                );
            socket.Send(JsonConvert.SerializeObject(messageToSend));
        }

        private void CloseRemoteServer()
        {
            if (RemoteServer != null)
            {
                RemoteServer.Dispose();
                RemoteServer = null;
            }
            foreach (IWebSocketConnection socket in CurrentRemotes)
            {
                socket.Close();
            }
            CurrentRemotes.Clear();
        }

        private void CreateRemoteServer()
        {
            CloseRemoteServer();
            RemoteServer = new WebSocketServer("ws://0.0.0.0:42069");
            RemoteServer.Start(socket =>
            {
                socket.OnOpen = () => CurrentRemotes.Add(socket);
                socket.OnClose = () => CurrentRemotes.Remove(socket);
                socket.OnMessage = message =>
                {
                    RemoteMessageReceived messageReceived = JsonConvert.DeserializeObject<RemoteMessageReceived>(message);
                    if (int.TryParse(messageReceived.message, out int buttonID))
                    {
                        AudioEngine.PlaySound(CurrentButtons[buttonID].file);
                    }
                    if (messageReceived.message == "full")
                    {
                        SendMessageServer(socket, "full");
                    }
                    if (messageReceived.message == "audio")
                    {
                        LocalCheck.Invoke(new MethodInvoker(() =>
                        {
                            LocalCheck.Checked = messageReceived.data.audio.local;
                            LocalVolumeBar.Value = messageReceived.data.audio.localVolume;
                            LinkCheck.Checked = messageReceived.data.audio.link;
                            OutputCheck.Checked = messageReceived.data.audio.output;
                            OutputVolumeBar.Value = messageReceived.data.audio.outputVolume;
                        }));
                    }
                    if (messageReceived.message == "layout")
                    {
                        LayoutSelectorComboBox.Invoke(new MethodInvoker(() =>
                        {
                            for (int i=0; i< LayoutSelectorComboBox.Items.Count; i++)
                            {
                                if (LayoutSelectorComboBox.Items[i].ToString() == messageReceived.data.layout.currentLayout)
                                {
                                    LayoutSelectorComboBox.SelectedIndex = i;
                                    break;
                                }
                            }
                            SaveLayout();
                            CurrentLayout = LayoutSelectorComboBox.SelectedItem.ToString();
                            ChangeLayout();
                        }));
                        SendMessageServer(socket, "layout");
                    }
                };
            });
        }

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
            string text = File.ReadAllText(ButtonLayoutsPath + CurrentLayout + ".json");
            CurrentButtons = JsonConvert.DeserializeObject<List<MusicButtonInfo>>(text);
            // When file is corrupt just load a new layout.
            if (CurrentButtons == null)
            {
                CurrentButtons = new List<MusicButtonInfo>();
            }
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
                if (File.Exists(ButtonLayoutsPath + CurrentLayout + ".json"))
                {
                    LayoutSelectorComboBox.SelectedItem = CurrentLayout;
                }
                else
                {
                    LayoutSelectorComboBox.SelectedIndex = 0;
                    CurrentLayout = LayoutSelectorComboBox.SelectedItem.ToString();
                }
            }
            else
            {
                File.WriteAllText(ButtonLayoutsPath + "DefaultLayout.json", "[]");
                LayoutSelectorComboBox.Items.Add("DefaultLayout");
                LayoutSelectorComboBox.SelectedItem = "DefaultLayout";
                CurrentLayout = "DefaultLayout";
            }
            ChangeLayout();
        }

        private void SaveLayout()
        {
            string text = JsonConvert.SerializeObject(CurrentButtons);
            File.WriteAllText(ButtonLayoutsPath + CurrentLayout + ".json", text);
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            CreateAudioEngine();
            CurrentLayout = Properties.Settings.Default.Layout;
            LocalVolumeBar.Value = (int)Properties.Settings.Default.LocalVolume;
            OutputVolumeBar.Value = (int)Properties.Settings.Default.OutputVolume;
            LocalCheck.Checked = Properties.Settings.Default.LocalCheck;
            LinkCheck.Checked = Properties.Settings.Default.LinkCheck;
            OutputCheck.Checked = Properties.Settings.Default.OutputCheck;
            UpdateLayouts();
            if (Properties.Settings.Default.Remote)
            {
                CreateRemoteServer();
            }
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            SaveLayout();
            Properties.Settings.Default.Layout = CurrentLayout;
            Properties.Settings.Default.LocalVolume = (float)LocalVolumeBar.Value;
            Properties.Settings.Default.OutputVolume = (float)OutputVolumeBar.Value;
            Properties.Settings.Default.LocalCheck = LocalCheck.Checked;
            Properties.Settings.Default.LinkCheck = LinkCheck.Checked;
            Properties.Settings.Default.OutputCheck = OutputCheck.Checked;
            Properties.Settings.Default.Save();
            CloseAudioEngine();
            CloseRemoteServer();
        }

        private void StopButton_Click(object sender, EventArgs e)
        {
            AudioEngine.StopSound();
        }

        private void LayoutSelectorComboBox_SelectionChangeCommitted(object sender, EventArgs e)
        {
            SaveLayout();
            CurrentLayout = LayoutSelectorComboBox.SelectedItem.ToString();
            ChangeLayout();
            foreach (IWebSocketConnection socket in CurrentRemotes)
            {
                SendMessageServer(socket, "layout");
            }
        }


        private void settingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (SettingsForm settingsWindow = new SettingsForm())
            {
                DialogResult result = settingsWindow.ShowDialog();
            }
            CreateAudioEngine();
            if (Properties.Settings.Default.Remote)
            {
                CreateRemoteServer();
            }
            else
            {
                Console.WriteLine("sdf");
                CloseRemoteServer();
            }
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
                    CurrentLayout = layoutWindow.name;
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
                    CurrentLayout = layoutWindow.name;
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

        private void LocalVolumeBar_ValueChanged(object sender, EventArgs e)
        {
            if (LinkCheck.Checked)
            {
                OutputVolumeBar.Value = LocalVolumeBar.Value;
                if (OutputCheck.Checked)
                {
                    AudioEngine.OutputVolume = LocalVolumeBar.Value;
                }
            }
            if (LocalCheck.Checked)
            {
                AudioEngine.LocalVolume = LocalVolumeBar.Value;
            }
            foreach(IWebSocketConnection socket in CurrentRemotes)
            {
                SendMessageServer(socket, "audio");
            }
        }

        private void OutputVolumeBar_ValueChanged(object sender, EventArgs e)
        {
            if (LinkCheck.Checked)
            {
                LocalVolumeBar.Value = OutputVolumeBar.Value;
                if (LocalCheck.Checked)
                {
                    AudioEngine.LocalVolume = OutputVolumeBar.Value;
                }
            }
            if (OutputCheck.Checked)
            {
                AudioEngine.OutputVolume = OutputVolumeBar.Value;
            }
            foreach (IWebSocketConnection socket in CurrentRemotes)
            {
                SendMessageServer(socket, "audio");
            }
        }

        private void LocalCheck_CheckedChanged(object sender, EventArgs e)
        {
            if (!LocalCheck.Checked)
            {
                AudioEngine.LocalVolume = 0.0f;
            }
            else
            {
                AudioEngine.LocalVolume = LocalVolumeBar.Value;
            }
            foreach (IWebSocketConnection socket in CurrentRemotes)
            {
                SendMessageServer(socket, "audio");
            }
        }

        private void OutputCheck_CheckedChanged(object sender, EventArgs e)
        {
            if (!OutputCheck.Checked)
            {
                AudioEngine.OutputVolume = 0.0f;
            }
            else
            {
                AudioEngine.OutputVolume = OutputVolumeBar.Value;
            }
            foreach (IWebSocketConnection socket in CurrentRemotes)
            {
                SendMessageServer(socket, "audio");
            }
        }

        private void LinkCheck_CheckedChanged(object sender, EventArgs e)
        {
            foreach (IWebSocketConnection socket in CurrentRemotes)
            {
                SendMessageServer(socket, "audio");
            }
        }

        private void testToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

    }
}
