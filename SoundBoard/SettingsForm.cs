using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using NAudio;
using NAudio.Wave;

namespace SoundBoard
{
    public partial class SettingsForm : Form
    {
        public SettingsForm()
        {
            InitializeComponent();
        }

        private void SettingsForm_Load(object sender, EventArgs e)
        {
            for(int i = 0; i < WaveOut.DeviceCount; i++)
            {
                SpeakersComboBox.Items.Add(WaveOut.GetCapabilities(i).ProductName);
                VACinputComboBox.Items.Add(WaveOut.GetCapabilities(i).ProductName);
            }
            SpeakersComboBox.SelectedIndex = Properties.Settings.Default.Speakers;
            VACinputComboBox.SelectedIndex = Properties.Settings.Default.VACinput;
        }

        private void SpeakersComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.Speakers = SpeakersComboBox.SelectedIndex;
        }

        private void VACinputComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.VACinput = VACinputComboBox.SelectedIndex;
        }

        private void SettingsForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Properties.Settings.Default.Save();
        }
    }
}
