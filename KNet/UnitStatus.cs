using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Windows.Forms;

namespace KNet
{

    public partial class UnitStatus : Form
    {
        private static System.Timers.Timer t;
        bool Firsttime = true;
        bool IsRunning = false;

        KNetDataSet UnitsDataSet = new KNetDataSet();
        MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand();
        MySql.Data.MySqlClient.MySqlDataReader reader;

        public UnitStatus()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            System.Windows.Forms.Control.CheckForIllegalCrossThreadCalls = false;

            KNetDataSet UnitsDataSet = new KNetDataSet();
            unitsTableAdapter.Fill(UnitsDataSet.Units);

            MySql.Data.MySqlClient.MySqlConnection sqlconnection = new MySql.Data.MySqlClient.MySqlConnection();
            KNetDataSetAllReadings AllReadingsDataSet = new KNetDataSetAllReadings();

            cmd.Connection = allReadingsTableAdapter.Connection;
            cmd.CommandType = CommandType.Text;

            fillUnits(null, null);
            t = new System.Timers.Timer(1000);
            t.Elapsed += fillUnits;
            t.Enabled = true;
            t.AutoReset = true;
            Firsttime = false;
        }

        private void fillUnits(Object source, ElapsedEventArgs e)
        {
            if (IsRunning)
                return;

            IsRunning = true;
            cmd.Connection.Open();

            string dt_sting = "";
            DateTime dt;
            int q = 0;
            int ret;

            unitsTableAdapter.Fill(UnitsDataSet.Units);

            foreach (KNetDataSet.UnitsRow u in UnitsDataSet.Units)
                if (u.idUnits != 0)  // Don't dislplay Base
                {
                    if (!Firsttime)
                    {
                        cmd.CommandText = "SELECT MAX(`Time`) FROM AllReadings WHERE `Time` > now() + INTERVAL - 7 DAY AND R" + u.Battery_Nr.ToString("00") + " is NOT NULL";
                        reader = cmd.ExecuteReader();
                        reader.Read();
                        if (reader.HasRows && !reader.IsDBNull(0))
                        {
                            dt = reader.GetDateTime(0);
                            dt_sting = dt.ToString();
                        }
                        else
                        {
                            dt = DateTime.Parse("01-01-1900 00:00");
                            dt_sting = "";
                        }

                        reader.Close();


                        cmd.CommandText = "SELECT COUNT(`Time`) FROM AllReadings WHERE `Time` > now() + INTERVAL - 100 MINUTE AND R" + u.Battery_Nr.ToString("00") + " is NOT NULL";
                        reader = cmd.ExecuteReader();
                        reader.Read();
                        if (reader.HasRows && !reader.IsDBNull(0))
                            q = reader.GetInt16(0);
                        else
                            q = 0;
                        reader.Close();

                        for (int RowNr = 0; RowNr < UnitList.Rows.Count; RowNr++)
                            if (UnitList.Rows[RowNr].Cells[0].Value.Equals(u.idUnits))
                            {
                                UnitList.Rows[RowNr].SetValues(u.idUnits, u.Name, Convert.ToString(u.MeshAddr, 8).PadLeft(3, '0'), dt_sting, q);

                                if (dt > DateTime.Now.AddMinutes(-2))
                                    UnitList.Rows[RowNr].Cells["LastUpdated"].Style.BackColor = Color.LightGreen;
                                else if ((dt > DateTime.Now.AddMinutes(-30)))
                                    UnitList.Rows[RowNr].Cells["LastUpdated"].Style.BackColor = Color.LightYellow;
                                else
                                    UnitList.Rows[RowNr].Cells["LastUpdated"].Style.BackColor = Color.LightPink;
                            }

                    }
                    else
                        ret = UnitList.Rows.Add(u.idUnits, u.Name, Convert.ToString(u.MeshAddr, 8).PadLeft(3, '0'), "", "");


                    if (!Firsttime)
                        UnitList.Update();

                }
            cmd.Connection.Close();

            UnitList.AutoResizeColumns();
            IsRunning = false;
        }

        private void UnitStatus_Closing(object sender, FormClosingEventArgs e)
        {
            t.Close();
        }
    }

}
