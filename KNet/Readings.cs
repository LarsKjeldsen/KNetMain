using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;

namespace KNet
{
    class Reading
    {
        public String ReadingName;
        public int Unit;
    }

    class Readings : List<Reading>
    {
        DateTime SavedFromDate;

        public DataTable AllDataReadings = new DataTable("AllReadings");

        /* Constructor for Radings */
        public Readings(DateTime FromDate)
        {
            DateTime FromDateRound = new DateTime(FromDate.Year, FromDate.Month, FromDate.Day, FromDate.Hour, FromDate.Minute, 0);
            SavedFromDate = FromDateRound;

            AllDataReadings.Columns.Add("Time", typeof(DateTime));
            AllDataReadings.PrimaryKey = new DataColumn[] { AllDataReadings.Columns["Time"] };

            for (DateTime dt = FromDateRound; dt < DateTime.Now; dt = dt.AddMinutes(1))
                AllDataReadings.Rows.Add(dt);
        }


        /* Unfolds the data so each reading is in its own Row */
        public void AddReading(KNetDataSet.UnitsRow Unit, KNetDataSet AllKNetData)
        {
            if (Unit.idUnits == 0)
                return;  // Base station

            Reading rb = new Reading();
            rb.ReadingName = "Batteri niveau unit " + Unit.idUnits + " " + Unit.Name;
            rb.Unit = Unit.idUnits;
            this.Add(rb);

            AllDataReadings.BeginLoadData();

            AllDataReadings.Columns.Add(rb.ReadingName, typeof(Single));
            int ColIndex = AllDataReadings.Columns.IndexOf(rb.ReadingName);

            foreach (KNetDataSet.FactRow r in AllKNetData.Fact.Rows)
            {
                if (r.Units_idUnits == Unit.idUnits)
                {
                    DateTime dt = r.Time.AddSeconds(-r.Time.Second);
                    DataRow dr = AllDataReadings.Rows.Find(dt);
                    if (dr != null)
                        dr[ColIndex] = r.BatteryLevel;
                }
            }

            for (int i = 1; i <= Unit.NumReadings; i++)
            {
                string R = "Reading" + i.ToString();
                Reading r = new Reading();
                r.ReadingName = (string)Unit[R + "_Name"];
                r.Unit = Unit.idUnits;
                this.Add(r);

                AllDataReadings.Columns.Add(r.ReadingName, typeof(Single));
                ColIndex = AllDataReadings.Columns.IndexOf(r.ReadingName);

                foreach (KNetDataSet.FactRow r1 in AllKNetData.Fact.Select(String.Format(CultureInfo.InvariantCulture.DateTimeFormat, "Time > #{0}#", SavedFromDate)))
                {
                    if (r1.Units_idUnits == Unit.idUnits)
                    {
                        //   String s = String.Format("Time = {0}", r1.Time);
                        DateTime dt = r1.Time.AddSeconds(-r1.Time.Second);
                        DataRow dr = AllDataReadings.Rows.Find(dt);
                        if (dr != null)
                            dr[ColIndex] = r1[R];
                    }
                }
            }
            AllDataReadings.EndLoadData();
        }
    }
}
