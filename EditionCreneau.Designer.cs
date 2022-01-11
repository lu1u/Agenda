namespace Agenda
{
    partial class EditionCreneau
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
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.labelJour = new System.Windows.Forms.Label();
            this.labelHeure = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.comboBoxEtat = new System.Windows.Forms.ComboBox();
            this.buttonOK = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.textBoxLabel = new System.Windows.Forms.TextBox();
            this.flowLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.labelJour);
            this.flowLayoutPanel1.Controls.Add(this.labelHeure);
            this.flowLayoutPanel1.Controls.Add(this.textBoxLabel);
            this.flowLayoutPanel1.Controls.Add(this.label5);
            this.flowLayoutPanel1.Controls.Add(this.comboBoxEtat);
            this.flowLayoutPanel1.Controls.Add(this.buttonOK);
            this.flowLayoutPanel1.Controls.Add(this.buttonCancel);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(4, 4);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(435, 123);
            this.flowLayoutPanel1.TabIndex = 0;
            // 
            // labelJour
            // 
            this.labelJour.AutoSize = true;
            this.labelJour.Location = new System.Drawing.Point(3, 0);
            this.labelJour.Name = "labelJour";
            this.labelJour.Size = new System.Drawing.Size(30, 13);
            this.labelJour.TabIndex = 0;
            this.labelJour.Text = "Jour:";
            // 
            // labelHeure
            // 
            this.labelHeure.AutoSize = true;
            this.flowLayoutPanel1.SetFlowBreak(this.labelHeure, true);
            this.labelHeure.Location = new System.Drawing.Point(39, 0);
            this.labelHeure.Name = "labelHeure";
            this.labelHeure.Size = new System.Drawing.Size(39, 13);
            this.labelHeure.TabIndex = 3;
            this.labelHeure.Text = "Heure:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(3, 39);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(29, 13);
            this.label5.TabIndex = 4;
            this.label5.Text = "Etat:";
            // 
            // comboBoxEtat
            // 
            this.flowLayoutPanel1.SetFlowBreak(this.comboBoxEtat, true);
            this.comboBoxEtat.FormattingEnabled = true;
            this.comboBoxEtat.Location = new System.Drawing.Point(38, 42);
            this.comboBoxEtat.Name = "comboBoxEtat";
            this.comboBoxEtat.Size = new System.Drawing.Size(121, 21);
            this.comboBoxEtat.TabIndex = 5;
            // 
            // buttonOK
            // 
            this.buttonOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.buttonOK.Location = new System.Drawing.Point(3, 69);
            this.buttonOK.Name = "buttonOK";
            this.buttonOK.Size = new System.Drawing.Size(75, 23);
            this.buttonOK.TabIndex = 6;
            this.buttonOK.Text = "OK";
            this.buttonOK.UseVisualStyleBackColor = true;
            // 
            // buttonCancel
            // 
            this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonCancel.Location = new System.Drawing.Point(84, 69);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(75, 23);
            this.buttonCancel.TabIndex = 7;
            this.buttonCancel.Text = "Annuler";
            this.buttonCancel.UseVisualStyleBackColor = true;
            // 
            // textBoxLabel
            // 
            this.flowLayoutPanel1.SetFlowBreak(this.textBoxLabel, true);
            this.textBoxLabel.Location = new System.Drawing.Point(3, 16);
            this.textBoxLabel.Name = "textBoxLabel";
            this.textBoxLabel.Size = new System.Drawing.Size(229, 20);
            this.textBoxLabel.TabIndex = 8;
            // 
            // EditionCreneau
            // 
            this.AcceptButton = this.buttonOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.CancelButton = this.buttonCancel;
            this.ClientSize = new System.Drawing.Size(443, 131);
            this.ControlBox = false;
            this.Controls.Add(this.flowLayoutPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "EditionCreneau";
            this.Opacity = 0.9D;
            this.Padding = new System.Windows.Forms.Padding(4);
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Edition Creneau";
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button buttonOK;
        private System.Windows.Forms.Button buttonCancel;
        public System.Windows.Forms.Label labelJour;
        public System.Windows.Forms.Label labelHeure;
        public System.Windows.Forms.ComboBox comboBoxEtat;
        public System.Windows.Forms.TextBox textBoxLabel;
    }
}