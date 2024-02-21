namespace KNet
{
    partial class KNetMainForm
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            this.MainChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.ChartScaleHour = new System.Windows.Forms.Button();
            this.ChartScale4Hour = new System.Windows.Forms.Button();
            this.ChartScaleDay = new System.Windows.Forms.Button();
            this.ChartScale2Days = new System.Windows.Forms.Button();
            this.ChartScaleAll = new System.Windows.Forms.Button();
            this.ChartScaleMonth = new System.Windows.Forms.Button();
            this.ChartScaleWeek = new System.Windows.Forms.Button();
            this.SelectReadings = new System.Windows.Forms.CheckedListBox();
            this.kNetDataSetAllReadingsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.kNetDataSetAllReadings = new KNet.KNetDataSetAllReadings();
            this.allReadingsTableAdapter = new KNet.KNetDataSetAllReadingsTableAdapters.AllReadingsTableAdapter();
            this.unitsTableAdapter = new KNet.KNetDataSetTableAdapters.UnitsTableAdapter();
            this.UnitStatus = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.MainChart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kNetDataSetAllReadingsBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kNetDataSetAllReadings)).BeginInit();
            this.SuspendLayout();
            // 
            // MainChart
            // 
            chartArea1.AxisX.IntervalType = System.Windows.Forms.DataVisualization.Charting.DateTimeIntervalType.Hours;
            chartArea1.AxisX.IsLabelAutoFit = false;
            chartArea1.AxisX.IsStartedFromZero = false;
            chartArea1.AxisX.LabelStyle.Angle = 45;
            chartArea1.AxisX.LabelStyle.Format = "g";
            chartArea1.AxisX.LabelStyle.Interval = 0D;
            chartArea1.AxisX.LabelStyle.IntervalOffset = 0D;
            chartArea1.AxisX.LabelStyle.IntervalOffsetType = System.Windows.Forms.DataVisualization.Charting.DateTimeIntervalType.Auto;
            chartArea1.AxisX.LabelStyle.IntervalType = System.Windows.Forms.DataVisualization.Charting.DateTimeIntervalType.Auto;
            chartArea1.AxisX.MinorGrid.Enabled = true;
            chartArea1.AxisX.MinorTickMark.Enabled = true;
            chartArea1.AxisY.IsStartedFromZero = false;
            chartArea1.AxisY2.IsStartedFromZero = false;
            chartArea1.CursorX.IsUserEnabled = true;
            chartArea1.CursorX.IsUserSelectionEnabled = true;
            chartArea1.Name = "ChartArea1";
            this.MainChart.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.MainChart.Legends.Add(legend1);
            this.MainChart.Location = new System.Drawing.Point(12, 116);
            this.MainChart.Name = "MainChart";
            this.MainChart.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.Bright;
            this.MainChart.Size = new System.Drawing.Size(1203, 419);
            this.MainChart.TabIndex = 0;
            this.MainChart.Text = "chart1";
            // 
            // ChartScaleHour
            // 
            this.ChartScaleHour.Location = new System.Drawing.Point(564, 83);
            this.ChartScaleHour.Name = "ChartScaleHour";
            this.ChartScaleHour.Size = new System.Drawing.Size(75, 23);
            this.ChartScaleHour.TabIndex = 2;
            this.ChartScaleHour.Text = "1 time";
            this.ChartScaleHour.UseVisualStyleBackColor = true;
            this.ChartScaleHour.Click += new System.EventHandler(this.ChartScalePressed);
            // 
            // ChartScale4Hour
            // 
            this.ChartScale4Hour.Location = new System.Drawing.Point(472, 83);
            this.ChartScale4Hour.Name = "ChartScale4Hour";
            this.ChartScale4Hour.Size = new System.Drawing.Size(75, 23);
            this.ChartScale4Hour.TabIndex = 3;
            this.ChartScale4Hour.Text = "4 time";
            this.ChartScale4Hour.UseVisualStyleBackColor = true;
            this.ChartScale4Hour.Click += new System.EventHandler(this.ChartScalePressed);
            // 
            // ChartScaleDay
            // 
            this.ChartScaleDay.Location = new System.Drawing.Point(380, 83);
            this.ChartScaleDay.Name = "ChartScaleDay";
            this.ChartScaleDay.Size = new System.Drawing.Size(75, 23);
            this.ChartScaleDay.TabIndex = 4;
            this.ChartScaleDay.Text = "1 dag";
            this.ChartScaleDay.UseVisualStyleBackColor = true;
            this.ChartScaleDay.Click += new System.EventHandler(this.ChartScalePressed);
            // 
            // ChartScale2Days
            // 
            this.ChartScale2Days.Location = new System.Drawing.Point(288, 83);
            this.ChartScale2Days.Name = "ChartScale2Days";
            this.ChartScale2Days.Size = new System.Drawing.Size(75, 23);
            this.ChartScale2Days.TabIndex = 5;
            this.ChartScale2Days.Text = "2 dage";
            this.ChartScale2Days.UseVisualStyleBackColor = true;
            this.ChartScale2Days.Click += new System.EventHandler(this.ChartScalePressed);
            // 
            // ChartScaleAll
            // 
            this.ChartScaleAll.Location = new System.Drawing.Point(12, 83);
            this.ChartScaleAll.Name = "ChartScaleAll";
            this.ChartScaleAll.Size = new System.Drawing.Size(75, 23);
            this.ChartScaleAll.TabIndex = 6;
            this.ChartScaleAll.Text = "Alt";
            this.ChartScaleAll.UseVisualStyleBackColor = true;
            this.ChartScaleAll.Click += new System.EventHandler(this.ChartScalePressed);
            // 
            // ChartScaleMonth
            // 
            this.ChartScaleMonth.Location = new System.Drawing.Point(104, 83);
            this.ChartScaleMonth.Name = "ChartScaleMonth";
            this.ChartScaleMonth.Size = new System.Drawing.Size(75, 23);
            this.ChartScaleMonth.TabIndex = 7;
            this.ChartScaleMonth.Text = "1 måned";
            this.ChartScaleMonth.UseVisualStyleBackColor = true;
            this.ChartScaleMonth.Click += new System.EventHandler(this.ChartScalePressed);
            // 
            // ChartScaleWeek
            // 
            this.ChartScaleWeek.Location = new System.Drawing.Point(196, 83);
            this.ChartScaleWeek.Name = "ChartScaleWeek";
            this.ChartScaleWeek.Size = new System.Drawing.Size(75, 23);
            this.ChartScaleWeek.TabIndex = 8;
            this.ChartScaleWeek.Text = "1 uge";
            this.ChartScaleWeek.UseVisualStyleBackColor = true;
            this.ChartScaleWeek.Click += new System.EventHandler(this.ChartScalePressed);
            // 
            // SelectReadings
            // 
            this.SelectReadings.CheckOnClick = true;
            this.SelectReadings.FormattingEnabled = true;
            this.SelectReadings.Location = new System.Drawing.Point(968, 12);
            this.SelectReadings.Name = "SelectReadings";
            this.SelectReadings.Size = new System.Drawing.Size(247, 94);
            this.SelectReadings.TabIndex = 9;
            this.SelectReadings.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.SeriesCheckBoxitemChecked);
            // 
            // kNetDataSetAllReadingsBindingSource
            // 
            this.kNetDataSetAllReadingsBindingSource.DataSource = this.kNetDataSetAllReadings;
            this.kNetDataSetAllReadingsBindingSource.Position = 0;
            // 
            // kNetDataSetAllReadings
            // 
            this.kNetDataSetAllReadings.DataSetName = "KNetDataSetAllReadings";
            this.kNetDataSetAllReadings.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // allReadingsTableAdapter
            // 
            this.allReadingsTableAdapter.ClearBeforeFill = true;
            // 
            // unitsTableAdapter
            // 
            this.unitsTableAdapter.ClearBeforeFill = true;
            // 
            // UnitStatus
            // 
            this.UnitStatus.Location = new System.Drawing.Point(846, 83);
            this.UnitStatus.Name = "UnitStatus";
            this.UnitStatus.Size = new System.Drawing.Size(75, 23);
            this.UnitStatus.TabIndex = 11;
            this.UnitStatus.Text = "Unit Status";
            this.UnitStatus.UseVisualStyleBackColor = true;
            this.UnitStatus.Click += new System.EventHandler(this.UnitStatusClicked);
            // 
            // KNetMainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1246, 606);
            this.Controls.Add(this.UnitStatus);
            this.Controls.Add(this.SelectReadings);
            this.Controls.Add(this.ChartScaleWeek);
            this.Controls.Add(this.ChartScaleMonth);
            this.Controls.Add(this.ChartScaleAll);
            this.Controls.Add(this.ChartScale2Days);
            this.Controls.Add(this.ChartScaleDay);
            this.Controls.Add(this.ChartScale4Hour);
            this.Controls.Add(this.ChartScaleHour);
            this.Controls.Add(this.MainChart);
            this.Name = "KNetMainForm";
            this.Text = "KNet";
            this.Load += new System.EventHandler(this.KNetMainForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.MainChart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kNetDataSetAllReadingsBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kNetDataSetAllReadings)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart MainChart;
        private System.Windows.Forms.Button ChartScaleHour;
        private System.Windows.Forms.Button ChartScale4Hour;
        private System.Windows.Forms.Button ChartScaleDay;
        private System.Windows.Forms.Button ChartScale2Days;
        private System.Windows.Forms.Button ChartScaleAll;
        private System.Windows.Forms.Button ChartScaleMonth;
        private System.Windows.Forms.Button ChartScaleWeek;
        private System.Windows.Forms.CheckedListBox SelectReadings;
        private System.Windows.Forms.BindingSource kNetDataSetAllReadingsBindingSource;
        private KNetDataSetAllReadings kNetDataSetAllReadings;
        private KNetDataSetAllReadingsTableAdapters.AllReadingsTableAdapter allReadingsTableAdapter;
        private KNetDataSetTableAdapters.UnitsTableAdapter unitsTableAdapter;
        private System.Windows.Forms.Button UnitStatus;
    }
}

