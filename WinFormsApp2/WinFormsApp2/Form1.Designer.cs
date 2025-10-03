namespace WinFormsApp2
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.ListBox lstTargets = null!;
        private System.Windows.Forms.Label lblCurrentWeapon = null!;
        private System.Windows.Forms.Button btnAutoSelect = null!;
        private System.Windows.Forms.Button btnNextWeapon = null!;
        private System.Windows.Forms.Button btnFire = null!;
        private System.Windows.Forms.DataGridView dgvHistory = null!;
        private System.Windows.Forms.Button btnRefreshTargets = null!;
        private System.Windows.Forms.Label lblTargets = null!;
        private System.Windows.Forms.Label lblWeaponTitle = null!;
        private System.Windows.Forms.Label lblHistory = null!;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();

            this.lstTargets = new System.Windows.Forms.ListBox();
            this.lblCurrentWeapon = new System.Windows.Forms.Label();
            this.btnAutoSelect = new System.Windows.Forms.Button();
            this.btnNextWeapon = new System.Windows.Forms.Button();
            this.btnFire = new System.Windows.Forms.Button();
            this.dgvHistory = new System.Windows.Forms.DataGridView();
            this.btnRefreshTargets = new System.Windows.Forms.Button();
            this.lblTargets = new System.Windows.Forms.Label();
            this.lblWeaponTitle = new System.Windows.Forms.Label();
            this.lblHistory = new System.Windows.Forms.Label();

            ((System.ComponentModel.ISupportInitialize)(this.dgvHistory)).BeginInit();
            this.SuspendLayout();

            // lstTargets
            this.lstTargets.FormattingEnabled = true;
            this.lstTargets.ItemHeight = 15;
            this.lstTargets.Location = new System.Drawing.Point(12, 38);
            this.lstTargets.Name = "lstTargets";
            this.lstTargets.Size = new System.Drawing.Size(260, 139);
            this.lstTargets.TabIndex = 0;

            // lblTargets
            this.lblTargets.AutoSize = true;
            this.lblTargets.Location = new System.Drawing.Point(12, 18);
            this.lblTargets.Name = "lblTargets";
            this.lblTargets.Size = new System.Drawing.Size(70, 15);
            this.lblTargets.TabIndex = 6;
            this.lblTargets.Text = "Radar targets";

            // btnRefreshTargets
            this.btnRefreshTargets.Location = new System.Drawing.Point(178, 12);
            this.btnRefreshTargets.Name = "btnRefreshTargets";
            this.btnRefreshTargets.Size = new System.Drawing.Size(94, 23);
            this.btnRefreshTargets.TabIndex = 1;
            this.btnRefreshTargets.Text = "Refresh";
            this.btnRefreshTargets.UseVisualStyleBackColor = true;
            this.btnRefreshTargets.Click += new System.EventHandler(this.btnRefreshTargets_Click);

            // lblWeaponTitle
            this.lblWeaponTitle.AutoSize = true;
            this.lblWeaponTitle.Location = new System.Drawing.Point(12, 190);
            this.lblWeaponTitle.Name = "lblWeaponTitle";
            this.lblWeaponTitle.Size = new System.Drawing.Size(96, 15);
            this.lblWeaponTitle.TabIndex = 7;
            this.lblWeaponTitle.Text = "Current weapon:";

            // lblCurrentWeapon
            this.lblCurrentWeapon.AutoSize = true;
            this.lblCurrentWeapon.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblCurrentWeapon.Location = new System.Drawing.Point(114, 190);
            this.lblCurrentWeapon.Name = "lblCurrentWeapon";
            this.lblCurrentWeapon.Size = new System.Drawing.Size(41, 15);
            this.lblCurrentWeapon.TabIndex = 2;
            this.lblCurrentWeapon.Text = "(none)";

            // btnAutoSelect
            this.btnAutoSelect.Location = new System.Drawing.Point(12, 213);
            this.btnAutoSelect.Name = "btnAutoSelect";
            this.btnAutoSelect.Size = new System.Drawing.Size(124, 27);
            this.btnAutoSelect.TabIndex = 3;
            this.btnAutoSelect.Text = "Select by distance";
            this.btnAutoSelect.UseVisualStyleBackColor = true;
            this.btnAutoSelect.Click += new System.EventHandler(this.btnAutoSelect_Click);

            // btnNextWeapon
            this.btnNextWeapon.Location = new System.Drawing.Point(148, 213);
            this.btnNextWeapon.Name = "btnNextWeapon";
            this.btnNextWeapon.Size = new System.Drawing.Size(124, 27);
            this.btnNextWeapon.TabIndex = 4;
            this.btnNextWeapon.Text = "Change weapon";
            this.btnNextWeapon.UseVisualStyleBackColor = true;
            this.btnNextWeapon.Click += new System.EventHandler(this.btnNextWeapon_Click);

            // btnFire
            this.btnFire.Location = new System.Drawing.Point(12, 246);
            this.btnFire.Name = "btnFire";
            this.btnFire.Size = new System.Drawing.Size(260, 32);
            this.btnFire.TabIndex = 5;
            this.btnFire.Text = "FIRE";
            this.btnFire.UseVisualStyleBackColor = true;
            this.btnFire.Click += new System.EventHandler(this.btnFire_Click);

            // lblHistory
            this.lblHistory.AutoSize = true;
            this.lblHistory.Location = new System.Drawing.Point(290, 18);
            this.lblHistory.Name = "lblHistory";
            this.lblHistory.Size = new System.Drawing.Size(47, 15);
            this.lblHistory.TabIndex = 8;
            this.lblHistory.Text = "History";

            // dgvHistory
            this.dgvHistory.AllowUserToAddRows = false;
            this.dgvHistory.AllowUserToDeleteRows = false;
            this.dgvHistory.AllowUserToOrderColumns = true;
            this.dgvHistory.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top 
                                        | System.Windows.Forms.AnchorStyles.Bottom) 
                                        | System.Windows.Forms.AnchorStyles.Left) 
                                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvHistory.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvHistory.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvHistory.Location = new System.Drawing.Point(290, 38);
            this.dgvHistory.Name = "dgvHistory";
            this.dgvHistory.ReadOnly = true;
            this.dgvHistory.RowTemplate.Height = 25;
            this.dgvHistory.Size = new System.Drawing.Size(498, 240);
            this.dgvHistory.TabIndex = 9;

            // Form1
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 290);
            this.Controls.Add(this.lblTargets);
            this.Controls.Add(this.btnRefreshTargets);
            this.Controls.Add(this.lstTargets);
            this.Controls.Add(this.lblWeaponTitle);
            this.Controls.Add(this.lblCurrentWeapon);
            this.Controls.Add(this.btnAutoSelect);
            this.Controls.Add(this.btnNextWeapon);
            this.Controls.Add(this.btnFire);
            this.Controls.Add(this.lblHistory);
            this.Controls.Add(this.dgvHistory);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Saraza S.A. Fire Control";
            this.Load += new System.EventHandler(this.Form1_Load);

            ((System.ComponentModel.ISupportInitialize)(this.dgvHistory)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion
    }
}
