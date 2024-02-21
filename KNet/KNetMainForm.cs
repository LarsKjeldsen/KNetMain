using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace KNet
{
    public partial class KNetMainForm : Form
    {
        long RecCount;
        long ReadingsCount;

        struct Reading
        {
            public string R_Name;
            public int R_Number;
            public string R_ReadingName;
        }


        List<Reading> Readings = new List<Reading>();

        public KNetMainForm()
        {
            InitializeComponent();
        }

        private void KNetMainForm_Load(object sender, EventArgs e)
        {
            LoadUnits();
            ChartScalePressed(ChartScaleDay, null);

            for (int i = 0; i < Readings.Count(); i++)
                SelectReadings.Items.Add(Readings[i].R_Name, false);

            SelectReadings.Sorted = true;

            int idx = SelectReadings.FindString("Ude temp", 0);
            if (idx != -1)
                SelectReadings.SetItemChecked(idx, true);  // Start by showing Outdoortemp
            ChartScalePressed(ChartScaleDay, null);

            MainChart.DataSource = kNetDataSetAllReadings;
            MainChart.DataBind();
 //           RecCount = (long)allReadingsTableAdapter.GetRecCount();
            ReadingsCount = Readings.Count();
        }



        private void AddChartSerie(string Name, string ReadingNr)
        {
            System.Windows.Forms.DataVisualization.Charting.Series series = new System.Windows.Forms.DataVisualization.Charting.Series();

            series.ChartArea = "ChartArea1";
            series.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series.IsXValueIndexed = true;
            series.Name = Name;
            series.XValueMember = "Time";
            series.XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.DateTime;
            series.YValueMembers = ReadingNr;
            if (Name == "HeaterOutdoorTemp")
                series.YAxisType = System.Windows.Forms.DataVisualization.Charting.AxisType.Secondary;
            else
                series.YAxisType = System.Windows.Forms.DataVisualization.Charting.AxisType.Primary;
            series.IsXValueIndexed = false;

            MainChart.Series.Add(series);
        }


        private void SeriesCheckBoxitemChecked(object sender, ItemCheckEventArgs e)
        {
            string SerieName = SelectReadings.Items[e.Index].ToString();

            if (MainChart.Series.FindByName(SerieName) != null)  // Serie already added
                if (e.NewValue == System.Windows.Forms.CheckState.Checked)
                    MainChart.Series.FindByName(SerieName).Enabled = true;
                else
                    MainChart.Series.FindByName(SerieName).Enabled = false;
            else
            { // Series not added yet
                for (int i = 0; i < Readings.Count(); i++)
                    if (Readings[i].R_Name.Equals(SerieName))
                        if (e.NewValue == System.Windows.Forms.CheckState.Checked)
                            AddChartSerie(Readings[i].R_Name, Readings[i].R_ReadingName);
                        else
                            MainChart.Series.FindByName(SerieName).Enabled = false;
            }
            MainChart.Update();
            MainChart.DataBind();
            MainChart.Update();
        }


        private void ChartScalePressed(object sender, EventArgs e)
        {
            ChartScaleHour.BackColor = System.Windows.Forms.Button.DefaultBackColor;
            ChartScale4Hour.BackColor = System.Windows.Forms.Button.DefaultBackColor;
            ChartScaleDay.BackColor = System.Windows.Forms.Button.DefaultBackColor;
            ChartScale2Days.BackColor = System.Windows.Forms.Button.DefaultBackColor;
            ChartScaleWeek.BackColor = System.Windows.Forms.Button.DefaultBackColor;
            ChartScaleMonth.BackColor = System.Windows.Forms.Button.DefaultBackColor;
            ChartScaleAll.BackColor = System.Windows.Forms.Button.DefaultBackColor;


            ((System.Windows.Forms.Button)sender).BackColor = SystemColors.ActiveCaption;

            if (sender == ChartScaleHour)
            {
                allReadingsTableAdapter.FillBy(kNetDataSetAllReadings.AllReadings, DateTime.Now.AddHours(-1));
                MainChart.ChartAreas[0].RecalculateAxesScale();

                MainChart.ChartAreas[0].AxisX.MajorGrid.IntervalType = System.Windows.Forms.DataVisualization.Charting.DateTimeIntervalType.Minutes;
                MainChart.ChartAreas[0].AxisX.MajorGrid.Interval = 6;
                MainChart.ChartAreas[0].AxisX.LabelStyle.IntervalType = System.Windows.Forms.DataVisualization.Charting.DateTimeIntervalType.Minutes;
                MainChart.ChartAreas[0].AxisX.LabelStyle.Interval = 6;
                MainChart.ChartAreas[0].AxisX.MajorTickMark.Interval = 6;
                MainChart.ChartAreas[0].AxisX.MajorTickMark.IntervalType = System.Windows.Forms.DataVisualization.Charting.DateTimeIntervalType.Minutes;
                MainChart.ChartAreas[0].AxisX.LabelStyle.IntervalType = System.Windows.Forms.DataVisualization.Charting.DateTimeIntervalType.Minutes;
                MainChart.ChartAreas[0].AxisX.LabelStyle.Format = "HH:mm";
                MainChart.ChartAreas[0].AxisX.Minimum = DateTime.Now.AddHours(-1).ToOADate();
            }
            if (sender == ChartScale4Hour)
            {
                allReadingsTableAdapter.FillBy(kNetDataSetAllReadings.AllReadings, DateTime.Now.AddHours(-4));
                MainChart.ChartAreas[0].RecalculateAxesScale();

                MainChart.ChartAreas[0].AxisX.MajorGrid.IntervalType = System.Windows.Forms.DataVisualization.Charting.DateTimeIntervalType.Hours;
                MainChart.ChartAreas[0].AxisX.MinorGrid.IntervalType = System.Windows.Forms.DataVisualization.Charting.DateTimeIntervalType.Minutes;
                MainChart.ChartAreas[0].AxisX.MajorGrid.Interval = 1;
                MainChart.ChartAreas[0].AxisX.LabelStyle.IntervalType = System.Windows.Forms.DataVisualization.Charting.DateTimeIntervalType.Hours;
                MainChart.ChartAreas[0].AxisX.LabelStyle.Interval = 1;
                MainChart.ChartAreas[0].AxisX.MajorTickMark.Interval = 1;
                MainChart.ChartAreas[0].AxisX.MajorTickMark.IntervalType = System.Windows.Forms.DataVisualization.Charting.DateTimeIntervalType.Hours;
                MainChart.ChartAreas[0].AxisX.LabelStyle.IntervalType = System.Windows.Forms.DataVisualization.Charting.DateTimeIntervalType.Hours;
                MainChart.ChartAreas[0].AxisX.LabelStyle.Format = "HH:mm";
                MainChart.ChartAreas[0].AxisX.Minimum = DateTime.Now.AddHours(-4).ToOADate();
            }
            if (sender == ChartScaleDay)
            {
                allReadingsTableAdapter.FillBy(kNetDataSetAllReadings.AllReadings, DateTime.Now.AddDays(-1));

                MainChart.ChartAreas[0].AxisX.MajorGrid.IntervalType = System.Windows.Forms.DataVisualization.Charting.DateTimeIntervalType.Hours;
                MainChart.ChartAreas[0].AxisX.MinorGrid.IntervalType = System.Windows.Forms.DataVisualization.Charting.DateTimeIntervalType.Minutes;
                MainChart.ChartAreas[0].AxisX.MajorGrid.Interval = 1;
                MainChart.ChartAreas[0].AxisX.LabelStyle.IntervalType = System.Windows.Forms.DataVisualization.Charting.DateTimeIntervalType.Hours;
                MainChart.ChartAreas[0].AxisX.LabelStyle.Interval = 1;
                MainChart.ChartAreas[0].AxisX.MajorTickMark.Interval = 1;
                MainChart.ChartAreas[0].AxisX.MajorTickMark.IntervalType = System.Windows.Forms.DataVisualization.Charting.DateTimeIntervalType.Hours;
                MainChart.ChartAreas[0].AxisX.LabelStyle.IntervalType = System.Windows.Forms.DataVisualization.Charting.DateTimeIntervalType.Hours;
                MainChart.ChartAreas[0].AxisX.LabelStyle.Format = "HH:mm";
                MainChart.ChartAreas[0].AxisX.Minimum = DateTime.Now.AddHours(-24).ToOADate();
            }
            if (sender == ChartScale2Days)
            {
                allReadingsTableAdapter.FillBy(kNetDataSetAllReadings.AllReadings, DateTime.Now.AddDays(-2));

                MainChart.ChartAreas[0].AxisX.MajorGrid.IntervalType = System.Windows.Forms.DataVisualization.Charting.DateTimeIntervalType.Hours;
                MainChart.ChartAreas[0].AxisX.MinorGrid.IntervalType = System.Windows.Forms.DataVisualization.Charting.DateTimeIntervalType.Minutes;
                MainChart.ChartAreas[0].AxisX.MajorGrid.Interval = 1;
                MainChart.ChartAreas[0].AxisX.LabelStyle.IntervalType = System.Windows.Forms.DataVisualization.Charting.DateTimeIntervalType.Hours;
                MainChart.ChartAreas[0].AxisX.LabelStyle.Interval = 1;
                MainChart.ChartAreas[0].AxisX.MajorTickMark.Interval = 1;
                MainChart.ChartAreas[0].AxisX.MajorTickMark.IntervalType = System.Windows.Forms.DataVisualization.Charting.DateTimeIntervalType.Hours;
                MainChart.ChartAreas[0].AxisX.LabelStyle.IntervalType = System.Windows.Forms.DataVisualization.Charting.DateTimeIntervalType.Hours;
                MainChart.ChartAreas[0].AxisX.LabelStyle.Format = "HH:mm";
                MainChart.ChartAreas[0].AxisX.Minimum = DateTime.Now.AddHours(-48).ToOADate();
            }
            if (sender == ChartScaleWeek)
            {
                allReadingsTableAdapter.FillBy(kNetDataSetAllReadings.AllReadings, DateTime.Now.AddDays(-7));

                MainChart.ChartAreas[0].AxisX.MajorGrid.IntervalType = System.Windows.Forms.DataVisualization.Charting.DateTimeIntervalType.Hours;
                MainChart.ChartAreas[0].AxisX.MajorGrid.Interval = 6;
                MainChart.ChartAreas[0].AxisX.LabelStyle.IntervalType = System.Windows.Forms.DataVisualization.Charting.DateTimeIntervalType.Hours;
                MainChart.ChartAreas[0].AxisX.LabelStyle.Interval = 6;
                MainChart.ChartAreas[0].AxisX.MajorTickMark.IntervalType = System.Windows.Forms.DataVisualization.Charting.DateTimeIntervalType.Hours;
                MainChart.ChartAreas[0].AxisX.MajorTickMark.Interval = 6;
                MainChart.ChartAreas[0].AxisX.LabelStyle.IntervalType = System.Windows.Forms.DataVisualization.Charting.DateTimeIntervalType.Hours;
                MainChart.ChartAreas[0].AxisX.LabelStyle.Interval = 6;
                MainChart.ChartAreas[0].AxisX.LabelStyle.Format = "dd/MM HH:mm";
                MainChart.ChartAreas[0].AxisX.Minimum = DateTime.Now.AddDays(-7).ToOADate();
            }
            if (sender == ChartScaleMonth)
            {
                allReadingsTableAdapter.FillAvghourlyBy(kNetDataSetAllReadings.AllReadings, DateTime.Now.AddMonths(-1));

                MainChart.ChartAreas[0].AxisX.MajorGrid.IntervalType = System.Windows.Forms.DataVisualization.Charting.DateTimeIntervalType.Days;
                MainChart.ChartAreas[0].AxisX.MajorGrid.Interval = 1;
                MainChart.ChartAreas[0].AxisX.LabelStyle.IntervalType = System.Windows.Forms.DataVisualization.Charting.DateTimeIntervalType.Days;
                MainChart.ChartAreas[0].AxisX.LabelStyle.Interval = 1;
                MainChart.ChartAreas[0].AxisX.MajorTickMark.IntervalType = System.Windows.Forms.DataVisualization.Charting.DateTimeIntervalType.Days;
                MainChart.ChartAreas[0].AxisX.MajorTickMark.Interval = 1;
                MainChart.ChartAreas[0].AxisX.LabelStyle.IntervalType = System.Windows.Forms.DataVisualization.Charting.DateTimeIntervalType.Days;
                MainChart.ChartAreas[0].AxisX.LabelStyle.Interval = 1;
                MainChart.ChartAreas[0].AxisX.LabelStyle.Format = "dd/MM";
                MainChart.ChartAreas[0].AxisX.Minimum = DateTime.Now.AddMonths(-1).ToOADate();

            }
            if (sender == ChartScaleAll)
            {
                allReadingsTableAdapter.Adapter.SelectCommand.CommandTimeout = 99999;
                allReadingsTableAdapter.FillAvghourlyBy(kNetDataSetAllReadings.AllReadings, DateTime.Now.AddYears(-2));

                MainChart.ChartAreas[0].AxisX.MajorGrid.IntervalType = System.Windows.Forms.DataVisualization.Charting.DateTimeIntervalType.Weeks;
                MainChart.ChartAreas[0].AxisX.MajorGrid.Interval = 1;
                MainChart.ChartAreas[0].AxisX.LabelStyle.IntervalType = System.Windows.Forms.DataVisualization.Charting.DateTimeIntervalType.Weeks;
                MainChart.ChartAreas[0].AxisX.LabelStyle.Interval = 1;
                MainChart.ChartAreas[0].AxisX.MajorTickMark.IntervalType = System.Windows.Forms.DataVisualization.Charting.DateTimeIntervalType.Weeks;
                MainChart.ChartAreas[0].AxisX.MajorTickMark.Interval = 3;
                MainChart.ChartAreas[0].AxisX.LabelStyle.IntervalType = System.Windows.Forms.DataVisualization.Charting.DateTimeIntervalType.Weeks;
                MainChart.ChartAreas[0].AxisX.LabelStyle.Interval = 3;
                MainChart.ChartAreas[0].AxisX.LabelStyle.Format = "dd/MM";
                MainChart.ChartAreas[0].AxisX.Minimum = DateTime.Now.AddYears(-2).ToOADate();
            }
            MainChart.DataBind();
            MainChart.Update();
        }



        private void Update_click(object sender, EventArgs e)
        {
            MainChart.DataBind();
        }

        private void LoadUnits()
        {
            KNetDataSet UnitsDataSet = new KNetDataSet();
            unitsTableAdapter.Fill(UnitsDataSet.Units);

            Readings.Clear();
            foreach (KNetDataSet.UnitsRow u in UnitsDataSet.Units)
            {
                Reading r;
                if (u.idUnits == 0)
                    continue; // Base station
                r.R_Name = "Battery Unit " + u.idUnits + " - " + u.Name;
                r.R_Number = u.Battery_Nr;
                r.R_ReadingName = "R" + u.Battery_Nr.ToString("D02");
                Readings.Add(r);
                // Battery

                for (int i = 1; i <= u.NumReadings; i++)
                {
                    string r1 = "Reading" + i;
                    r.R_Name = u[r1 + "_Name"].ToString();
                    r.R_Number = (int)u[r1 + "_Nr"];
                    r.R_ReadingName = "R" + r.R_Number.ToString("D02");
                    Readings.Add(r);
                }
            }
        }

        private void UnitStatusClicked(object sender, EventArgs e)
        {
            Form form = new UnitStatus();

            form.Show();
        }
    }
}
