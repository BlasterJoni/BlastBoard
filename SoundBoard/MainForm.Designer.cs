using System.Windows.Forms;

namespace BlastBoard
{
    partial class MainForm
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.OutputCheck = new System.Windows.Forms.CheckBox();
            this.LocalCheck = new System.Windows.Forms.CheckBox();
            this.OutputVolumeBar = new System.Windows.Forms.TrackBar();
            this.LocalVolumeBar = new System.Windows.Forms.TrackBar();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.LinkCheck = new System.Windows.Forms.CheckBox();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.FlowLayoutPanelContextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.addButtonToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ButtonContextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.addButtonToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.editButtonToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.removeButtonToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.LayoutSelectorComboBox = new System.Windows.Forms.ComboBox();
            this.LayoutComboBoxContextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.addLayoutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.editLayoutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.removeLayoutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.StopButton = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.settingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.testToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.OutputVolumeBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.LocalVolumeBar)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.FlowLayoutPanelContextMenu.SuspendLayout();
            this.ButtonContextMenu.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.LayoutComboBoxContextMenu.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // OutputCheck
            // 
            this.OutputCheck.AutoSize = true;
            this.OutputCheck.Checked = true;
            this.OutputCheck.CheckState = System.Windows.Forms.CheckState.Checked;
            this.OutputCheck.Dock = System.Windows.Forms.DockStyle.Fill;
            this.OutputCheck.Location = new System.Drawing.Point(312, 3);
            this.OutputCheck.Name = "OutputCheck";
            this.OutputCheck.Size = new System.Drawing.Size(64, 29);
            this.OutputCheck.TabIndex = 2;
            this.OutputCheck.Text = "Output";
            this.OutputCheck.UseVisualStyleBackColor = true;
            this.OutputCheck.CheckedChanged += new System.EventHandler(this.OutputCheck_CheckedChanged);
            // 
            // LocalCheck
            // 
            this.LocalCheck.AutoSize = true;
            this.LocalCheck.Checked = true;
            this.LocalCheck.CheckState = System.Windows.Forms.CheckState.Checked;
            this.LocalCheck.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LocalCheck.Location = new System.Drawing.Point(3, 3);
            this.LocalCheck.Name = "LocalCheck";
            this.LocalCheck.Size = new System.Drawing.Size(54, 29);
            this.LocalCheck.TabIndex = 1;
            this.LocalCheck.Text = "Local";
            this.LocalCheck.UseVisualStyleBackColor = true;
            this.LocalCheck.CheckedChanged += new System.EventHandler(this.LocalCheck_CheckedChanged);
            // 
            // OutputVolumeBar
            // 
            this.OutputVolumeBar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.OutputVolumeBar.Location = new System.Drawing.Point(382, 3);
            this.OutputVolumeBar.Maximum = 100;
            this.OutputVolumeBar.Name = "OutputVolumeBar";
            this.OutputVolumeBar.Size = new System.Drawing.Size(200, 29);
            this.OutputVolumeBar.TabIndex = 5;
            this.OutputVolumeBar.TickStyle = System.Windows.Forms.TickStyle.None;
            this.OutputVolumeBar.Value = 100;
            this.OutputVolumeBar.ValueChanged += new System.EventHandler(this.OutputVolumeBar_ValueChanged);
            // 
            // LocalVolumeBar
            // 
            this.LocalVolumeBar.BackColor = System.Drawing.SystemColors.Control;
            this.LocalVolumeBar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LocalVolumeBar.Location = new System.Drawing.Point(63, 3);
            this.LocalVolumeBar.Maximum = 100;
            this.LocalVolumeBar.Name = "LocalVolumeBar";
            this.LocalVolumeBar.Size = new System.Drawing.Size(203, 29);
            this.LocalVolumeBar.TabIndex = 6;
            this.LocalVolumeBar.TickStyle = System.Windows.Forms.TickStyle.None;
            this.LocalVolumeBar.Value = 100;
            this.LocalVolumeBar.ValueChanged += new System.EventHandler(this.LocalVolumeBar_ValueChanged);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.ColumnCount = 5;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 60F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.51546F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 70F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 49.48454F));
            this.tableLayoutPanel1.Controls.Add(this.LinkCheck, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.LocalCheck, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.OutputVolumeBar, 4, 0);
            this.tableLayoutPanel1.Controls.Add(this.LocalVolumeBar, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.OutputCheck, 3, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(12, 27);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(585, 35);
            this.tableLayoutPanel1.TabIndex = 7;
            // 
            // LinkCheck
            // 
            this.LinkCheck.Appearance = System.Windows.Forms.Appearance.Button;
            this.LinkCheck.AutoSize = true;
            this.LinkCheck.BackgroundImage = global::BlastBoard.Properties.Resources.chain;
            this.LinkCheck.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.LinkCheck.Checked = true;
            this.LinkCheck.CheckState = System.Windows.Forms.CheckState.Checked;
            this.LinkCheck.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LinkCheck.Location = new System.Drawing.Point(272, 3);
            this.LinkCheck.Name = "LinkCheck";
            this.LinkCheck.Size = new System.Drawing.Size(34, 29);
            this.LinkCheck.TabIndex = 3;
            this.LinkCheck.UseVisualStyleBackColor = true;
            this.LinkCheck.CheckedChanged += new System.EventHandler(this.LinkCheck_CheckedChanged);
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.flowLayoutPanel1.AutoScroll = true;
            this.flowLayoutPanel1.ContextMenuStrip = this.FlowLayoutPanelContextMenu;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(12, 109);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(585, 320);
            this.flowLayoutPanel1.TabIndex = 10;
            // 
            // FlowLayoutPanelContextMenu
            // 
            this.FlowLayoutPanelContextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addButtonToolStripMenuItem});
            this.FlowLayoutPanelContextMenu.Name = "FlowLayoutPanelContextMenu";
            this.FlowLayoutPanelContextMenu.Size = new System.Drawing.Size(136, 26);
            // 
            // addButtonToolStripMenuItem
            // 
            this.addButtonToolStripMenuItem.Image = global::BlastBoard.Properties.Resources.keyboard__plus;
            this.addButtonToolStripMenuItem.Name = "addButtonToolStripMenuItem";
            this.addButtonToolStripMenuItem.Size = new System.Drawing.Size(135, 22);
            this.addButtonToolStripMenuItem.Text = "Add Button";
            this.addButtonToolStripMenuItem.Click += new System.EventHandler(this.addButtonToolStripMenuItem_Click);
            // 
            // ButtonContextMenu
            // 
            this.ButtonContextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addButtonToolStripMenuItem1,
            this.toolStripSeparator1,
            this.editButtonToolStripMenuItem,
            this.removeButtonToolStripMenuItem});
            this.ButtonContextMenu.Name = "contextMenuStrip1";
            this.ButtonContextMenu.Size = new System.Drawing.Size(157, 76);
            // 
            // addButtonToolStripMenuItem1
            // 
            this.addButtonToolStripMenuItem1.Image = global::BlastBoard.Properties.Resources.keyboard__plus;
            this.addButtonToolStripMenuItem1.Name = "addButtonToolStripMenuItem1";
            this.addButtonToolStripMenuItem1.Size = new System.Drawing.Size(156, 22);
            this.addButtonToolStripMenuItem1.Text = "Add Button";
            this.addButtonToolStripMenuItem1.Click += new System.EventHandler(this.addButtonToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(153, 6);
            // 
            // editButtonToolStripMenuItem
            // 
            this.editButtonToolStripMenuItem.Image = global::BlastBoard.Properties.Resources.keyboard__pencil;
            this.editButtonToolStripMenuItem.Name = "editButtonToolStripMenuItem";
            this.editButtonToolStripMenuItem.Size = new System.Drawing.Size(156, 22);
            this.editButtonToolStripMenuItem.Text = "Edit Button";
            this.editButtonToolStripMenuItem.Click += new System.EventHandler(this.editButtonToolStripMenuItem_Click);
            // 
            // removeButtonToolStripMenuItem
            // 
            this.removeButtonToolStripMenuItem.Image = global::BlastBoard.Properties.Resources.keyboard__minus;
            this.removeButtonToolStripMenuItem.Name = "removeButtonToolStripMenuItem";
            this.removeButtonToolStripMenuItem.Size = new System.Drawing.Size(156, 22);
            this.removeButtonToolStripMenuItem.Text = "Remove Button";
            this.removeButtonToolStripMenuItem.Click += new System.EventHandler(this.removeButtonToolStripMenuItem_Click);
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 80F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.Controls.Add(this.LayoutSelectorComboBox, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.StopButton, 0, 0);
            this.tableLayoutPanel2.Location = new System.Drawing.Point(12, 68);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(585, 35);
            this.tableLayoutPanel2.TabIndex = 12;
            // 
            // LayoutSelectorComboBox
            // 
            this.LayoutSelectorComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.LayoutSelectorComboBox.ContextMenuStrip = this.LayoutComboBoxContextMenu;
            this.LayoutSelectorComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.LayoutSelectorComboBox.FormattingEnabled = true;
            this.LayoutSelectorComboBox.Location = new System.Drawing.Point(471, 7);
            this.LayoutSelectorComboBox.Name = "LayoutSelectorComboBox";
            this.LayoutSelectorComboBox.Size = new System.Drawing.Size(111, 21);
            this.LayoutSelectorComboBox.TabIndex = 1;
            this.LayoutSelectorComboBox.SelectionChangeCommitted += new System.EventHandler(this.LayoutSelectorComboBox_SelectionChangeCommitted);
            // 
            // LayoutComboBoxContextMenu
            // 
            this.LayoutComboBoxContextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addLayoutToolStripMenuItem,
            this.toolStripSeparator2,
            this.editLayoutToolStripMenuItem,
            this.removeLayoutToolStripMenuItem});
            this.LayoutComboBoxContextMenu.Name = "LayoutComboBoxContextMenu";
            this.LayoutComboBoxContextMenu.Size = new System.Drawing.Size(157, 76);
            // 
            // addLayoutToolStripMenuItem
            // 
            this.addLayoutToolStripMenuItem.Image = global::BlastBoard.Properties.Resources.document__plus;
            this.addLayoutToolStripMenuItem.Name = "addLayoutToolStripMenuItem";
            this.addLayoutToolStripMenuItem.Size = new System.Drawing.Size(156, 22);
            this.addLayoutToolStripMenuItem.Text = "Add Layout";
            this.addLayoutToolStripMenuItem.Click += new System.EventHandler(this.addLayoutToolStripMenuItem_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(153, 6);
            // 
            // editLayoutToolStripMenuItem
            // 
            this.editLayoutToolStripMenuItem.Image = global::BlastBoard.Properties.Resources.document__pencil;
            this.editLayoutToolStripMenuItem.Name = "editLayoutToolStripMenuItem";
            this.editLayoutToolStripMenuItem.Size = new System.Drawing.Size(156, 22);
            this.editLayoutToolStripMenuItem.Text = "Edit Layout";
            this.editLayoutToolStripMenuItem.Click += new System.EventHandler(this.editLayoutToolStripMenuItem_Click);
            // 
            // removeLayoutToolStripMenuItem
            // 
            this.removeLayoutToolStripMenuItem.Image = global::BlastBoard.Properties.Resources.document__minus;
            this.removeLayoutToolStripMenuItem.Name = "removeLayoutToolStripMenuItem";
            this.removeLayoutToolStripMenuItem.Size = new System.Drawing.Size(156, 22);
            this.removeLayoutToolStripMenuItem.Text = "Remove Layout";
            this.removeLayoutToolStripMenuItem.Click += new System.EventHandler(this.removeLayoutToolStripMenuItem_Click);
            // 
            // StopButton
            // 
            this.StopButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.StopButton.Location = new System.Drawing.Point(3, 3);
            this.StopButton.Name = "StopButton";
            this.StopButton.Size = new System.Drawing.Size(462, 29);
            this.StopButton.TabIndex = 0;
            this.StopButton.Text = "Stop";
            this.StopButton.UseVisualStyleBackColor = true;
            this.StopButton.Click += new System.EventHandler(this.StopButton_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.settingsToolStripMenuItem,
            this.aboutToolStripMenuItem,
            this.testToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(609, 24);
            this.menuStrip1.TabIndex = 13;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // settingsToolStripMenuItem
            // 
            this.settingsToolStripMenuItem.Image = global::BlastBoard.Properties.Resources.gear;
            this.settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
            this.settingsToolStripMenuItem.Size = new System.Drawing.Size(77, 20);
            this.settingsToolStripMenuItem.Text = "Settings";
            this.settingsToolStripMenuItem.Click += new System.EventHandler(this.settingsToolStripMenuItem_Click);
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Image = global::BlastBoard.Properties.Resources.information_frame;
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(68, 20);
            this.aboutToolStripMenuItem.Text = "About";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // testToolStripMenuItem
            // 
            this.testToolStripMenuItem.Name = "testToolStripMenuItem";
            this.testToolStripMenuItem.Size = new System.Drawing.Size(40, 20);
            this.testToolStripMenuItem.Text = "Test";
            this.testToolStripMenuItem.Click += new System.EventHandler(this.testToolStripMenuItem_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(609, 436);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.tableLayoutPanel2);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(465, 240);
            this.Name = "MainForm";
            this.Text = "BlastBoard";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.OutputVolumeBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.LocalVolumeBar)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.FlowLayoutPanelContextMenu.ResumeLayout(false);
            this.ButtonContextMenu.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.LayoutComboBoxContextMenu.ResumeLayout(false);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private CheckBox OutputCheck;
        private CheckBox LocalCheck;
        private TrackBar OutputVolumeBar;
        private CheckBox LinkCheck;
        private TableLayoutPanel tableLayoutPanel1;
        private FlowLayoutPanel flowLayoutPanel1;
        private ContextMenuStrip ButtonContextMenu;
        private ToolStripMenuItem editButtonToolStripMenuItem;
        private ToolStripMenuItem removeButtonToolStripMenuItem;
        private TableLayoutPanel tableLayoutPanel2;
        private Button StopButton;
        private TrackBar LocalVolumeBar;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem settingsToolStripMenuItem;
        private ToolStripMenuItem aboutToolStripMenuItem;
        private ComboBox LayoutSelectorComboBox;
        private ContextMenuStrip FlowLayoutPanelContextMenu;
        private ToolStripMenuItem addButtonToolStripMenuItem;
        private ContextMenuStrip LayoutComboBoxContextMenu;
        private ToolStripMenuItem addLayoutToolStripMenuItem;
        private ToolStripMenuItem editLayoutToolStripMenuItem;
        private ToolStripMenuItem removeLayoutToolStripMenuItem;
        private ToolStripMenuItem addButtonToolStripMenuItem1;
        private ToolStripSeparator toolStripSeparator1;
        private ToolStripSeparator toolStripSeparator2;
        private ToolStripMenuItem testToolStripMenuItem;
    }
}

