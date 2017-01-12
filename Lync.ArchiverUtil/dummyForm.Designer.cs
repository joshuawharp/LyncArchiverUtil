using System;

namespace Lync.ArchiverUtil
{
    partial class DummyForm
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
                convArch.Dispose();
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DummyForm));
            this.LyncArchiveUtilNotifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.LyncArchiveUtilMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.Exit = new System.Windows.Forms.ToolStripMenuItem();
            this.OpenConversationArchiveFolder = new System.Windows.Forms.ToolStripMenuItem();
            this.LyncArchiveUtilMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // LyncArchiveUtilNotifyIcon
            // 
            this.LyncArchiveUtilNotifyIcon.BalloonTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.LyncArchiveUtilNotifyIcon.ContextMenuStrip = this.LyncArchiveUtilMenu;
            this.LyncArchiveUtilNotifyIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("LyncArchiveUtilNotifyIcon.Icon")));
            this.LyncArchiveUtilNotifyIcon.Text = "Lync Archiver Utility";
            this.LyncArchiveUtilNotifyIcon.Visible = true;
            // 
            // LyncArchiveUtilMenu
            // 
            this.LyncArchiveUtilMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Exit,
            this.OpenConversationArchiveFolder});
            this.LyncArchiveUtilMenu.Name = "contextMenuStrip1";
            this.LyncArchiveUtilMenu.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.LyncArchiveUtilMenu.ShowImageMargin = false;
            this.LyncArchiveUtilMenu.Size = new System.Drawing.Size(215, 48);
            // 
            // Exit
            // 
            this.Exit.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.Exit.Name = "Exit";
            this.Exit.Size = new System.Drawing.Size(214, 22);
            this.Exit.Text = "Exit";
            this.Exit.Click += new System.EventHandler(this.LyncArchiveUtilMenuItem_Exit_Click);
            // 
            // OpenConversationArchveFolder
            // 
            this.OpenConversationArchiveFolder.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.OpenConversationArchiveFolder.Name = "OpenConversationArchiveFolder";
            this.OpenConversationArchiveFolder.Size = new System.Drawing.Size(214, 22);
            this.OpenConversationArchiveFolder.Text = "Open Conversation Archive Folder";
            this.OpenConversationArchiveFolder.Click += new System.EventHandler(this.LyncArchiveUtilMenuItem_OpenConversationArchveFolder_Click);
            // 
            // DummyForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(104, 0);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "DummyForm";
            this.Opacity = 0D;
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "dummyForm";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.dummyForm_FormClosing);
            this.Load += new System.EventHandler(this.dummyForm_Load);
            this.LyncArchiveUtilMenu.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.NotifyIcon LyncArchiveUtilNotifyIcon;
        private System.Windows.Forms.ContextMenuStrip LyncArchiveUtilMenu;
        private System.Windows.Forms.ToolStripMenuItem Exit;
        private System.Windows.Forms.ToolStripMenuItem OpenConversationArchiveFolder;
    }
}

