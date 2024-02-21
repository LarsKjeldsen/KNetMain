namespace KNet
{
    partial class UnitStatus
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
            this.UnitList = new System.Windows.Forms.DataGridView();
            this.UnitId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UnitName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Address = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LastUpdated = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Q = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Last1 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.unitsTableAdapter = new KNet.KNetDataSetTableAdapters.UnitsTableAdapter();
            this.allReadingsTableAdapter = new KNet.KNetDataSetAllReadingsTableAdapters.AllReadingsTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.UnitList)).BeginInit();
            this.SuspendLayout();
            // 
            // UnitList
            // 
            this.UnitList.AllowUserToAddRows = false;
            this.UnitList.AllowUserToDeleteRows = false;
            this.UnitList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.UnitList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.UnitId,
            this.UnitName,
            this.Address,
            this.LastUpdated,
            this.Q,
            this.Last1});
            this.UnitList.Location = new System.Drawing.Point(12, 12);
            this.UnitList.MultiSelect = false;
            this.UnitList.Name = "UnitList";
            this.UnitList.ReadOnly = true;
            this.UnitList.ShowEditingIcon = false;
            this.UnitList.Size = new System.Drawing.Size(700, 342);
            this.UnitList.TabIndex = 0;
            // 
            // UnitId
            // 
            this.UnitId.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.UnitId.HeaderText = "Unit";
            this.UnitId.Name = "UnitId";
            this.UnitId.ReadOnly = true;
            this.UnitId.Width = 51;
            // 
            // UnitName
            // 
            this.UnitName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.UnitName.HeaderText = "Name";
            this.UnitName.Name = "UnitName";
            this.UnitName.ReadOnly = true;
            this.UnitName.Width = 60;
            // 
            // Address
            // 
            this.Address.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.Address.HeaderText = "Address";
            this.Address.Name = "Address";
            this.Address.ReadOnly = true;
            this.Address.Width = 70;
            // 
            // LastUpdated
            // 
            this.LastUpdated.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.LastUpdated.HeaderText = "Last Updated";
            this.LastUpdated.Name = "LastUpdated";
            this.LastUpdated.ReadOnly = true;
            this.LastUpdated.Width = 96;
            // 
            // Q
            // 
            this.Q.HeaderText = "Kvalitet";
            this.Q.Name = "Q";
            this.Q.ReadOnly = true;
            // 
            // Last1
            // 
            this.Last1.HeaderText = "Last1";
            this.Last1.Name = "Last1";
            this.Last1.ReadOnly = true;
            // 
            // unitsTableAdapter
            // 
            this.unitsTableAdapter.ClearBeforeFill = true;
            // 
            // allReadingsTableAdapter
            // 
            this.allReadingsTableAdapter.ClearBeforeFill = true;
            // 
            // UnitStatus
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(724, 430);
            this.Controls.Add(this.UnitList);
            this.Name = "UnitStatus";
            this.Text = "Unit status";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.UnitStatus_Closing);
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.UnitList)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView UnitList;
        private KNetDataSetTableAdapters.UnitsTableAdapter unitsTableAdapter;
        private KNetDataSetAllReadingsTableAdapters.AllReadingsTableAdapter allReadingsTableAdapter;
        private System.Windows.Forms.DataGridViewTextBoxColumn UnitId;
        private System.Windows.Forms.DataGridViewTextBoxColumn UnitName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Address;
        private System.Windows.Forms.DataGridViewTextBoxColumn LastUpdated;
        private System.Windows.Forms.DataGridViewTextBoxColumn Q;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Last1;
    }
}