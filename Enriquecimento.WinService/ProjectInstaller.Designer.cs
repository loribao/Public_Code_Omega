﻿namespace Enriquecimento.WinService
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
            this.EnriquecimentoProcessInstaller = new System.ServiceProcess.ServiceProcessInstaller();
            this.Enriquecimento = new System.ServiceProcess.ServiceInstaller();
            // 
            // EnriquecimentoProcessInstaller
            // 
            this.EnriquecimentoProcessInstaller.Account = System.ServiceProcess.ServiceAccount.LocalSystem;
            this.EnriquecimentoProcessInstaller.Password = null;
            this.EnriquecimentoProcessInstaller.Username = null;
            // 
            // Enriquecimento
            // 
            this.Enriquecimento.Description = "Enriquecimento";
            this.Enriquecimento.DisplayName = "Enriquecimento";
            this.Enriquecimento.ServiceName = "Enriquecimento";
            // 
            // ProjectInstaller
            // 
            this.Installers.AddRange(new System.Configuration.Install.Installer[] {
            this.EnriquecimentoProcessInstaller,
            this.Enriquecimento});

        }

        #endregion

        private System.ServiceProcess.ServiceProcessInstaller EnriquecimentoProcessInstaller;
        private System.ServiceProcess.ServiceInstaller Enriquecimento;
    }
}