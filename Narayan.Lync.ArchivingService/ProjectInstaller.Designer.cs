namespace Lync.Archiver.Service
{
    partial class ProjectInstaller
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

        #region Component Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.LyncArchivingServiceProcessInstaller = new System.ServiceProcess.ServiceProcessInstaller();
            this.LyncArchivingServiceInstaller = new System.ServiceProcess.ServiceInstaller();
            // 
            // LyncArchivingServiceProcessInstaller
            // 
            this.LyncArchivingServiceProcessInstaller.Password = null;
            this.LyncArchivingServiceProcessInstaller.Username = null;
            // 
            // LyncArchivingServiceInstaller
            // 
            this.LyncArchivingServiceInstaller.Description = "Lync Archiving Service to intercept and archive IM text in file system or Outlook" +
    " Inbox or Google Documents";
            this.LyncArchivingServiceInstaller.DisplayName = "Lync Archiving Service";
            this.LyncArchivingServiceInstaller.ServiceName = "LyncArchivingService";
            this.LyncArchivingServiceInstaller.StartType = System.ServiceProcess.ServiceStartMode.Automatic;
            // 
            // ProjectInstaller
            // 
            this.Installers.AddRange(new System.Configuration.Install.Installer[] {
            this.LyncArchivingServiceProcessInstaller,
            this.LyncArchivingServiceInstaller});

        }

        #endregion

        private System.ServiceProcess.ServiceProcessInstaller LyncArchivingServiceProcessInstaller;
        private System.ServiceProcess.ServiceInstaller LyncArchivingServiceInstaller;
    }
}