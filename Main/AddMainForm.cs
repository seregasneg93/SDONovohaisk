using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SDONovohaisk
{
    public partial class AddMainForm : Form
    {
        SqlDataAdapter adapter;
        DataTable datTab;
        SqlCommand sqlcom;
        public AddMainForm()
        {
            InitializeComponent();
        }

        private void AddMainForm_Load(object sender, EventArgs e)
        {
           cmbStatusEvent.Text = cmbStatusEvent.Items[0].ToString();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Hide();
            MainForm m = new MainForm();
            m.Show();
        }

        //private void textBox5_TextChanged(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        if (Convert.ToInt32(textBox5.Text) > Convert.ToInt32(tbTickP.Text))
        //        {
        //            //textBox5.Enabled = false;
        //            textBox5.BackColor = Color.Salmon;
        //            textBox5.ForeColor = Color.Black;
        //            label13.Visible = true;
        //        }
        //    }
        //    catch (Exception)
        //    {
        //        MessageBox.Show("Поле не может быть пустым.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Information);
        //    }

        //    if (Convert.ToInt32(textBox5.Text) < Convert.ToInt32(tbTickP.Text))
        //    {
        //        // textBox5.Enabled = true;
        //         textBox5.BackColor = Color.White;
        //        label13.Visible = false;
        //    }

        //    if (Convert.ToInt32(textBox5.Text) == Convert.ToInt32(tbTickP.Text))
        //    {
        //       //textBox5.Enabled = true;
        //        textBox5.BackColor = Color.LawnGreen;
        //        label13.Visible = false;
        //    }

        //}

        public void ekeyTB(KeyPressEventArgs e)
        {
            if ((e.KeyChar <= 47 || e.KeyChar >= 58) && e.KeyChar != 8)
                e.Handled = true;
        }

        public void ClearTB()
        {

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Hide();
            MainForm m = new MainForm();
            m.Show();
        }


        public int vwIdEvent()
        {
            ConnectSDO sdo = new ConnectSDO();
            sdo.OpenConnection();
            sqlcom = new SqlCommand("SELECT MAXId FROM vwMaxIdEv", sdo.getConnectSDO());
            sqlcom.ExecuteNonQuery();
            SqlDataAdapter adap = new SqlDataAdapter(sqlcom);
            datTab = new DataTable();
            adap.Fill(datTab);

            int a = 0;

            foreach (DataRow DR in datTab.Rows)
            {
                a = Convert.ToInt32(DR["MAXId"].ToString());
            }
            sdo.CloseConnection();

            return a;
        }

        public int vwIdUnit()
        {
            ConnectSDO sdo = new ConnectSDO();
            sdo.OpenConnection();
            sqlcom = new SqlCommand("SELECT MAXId FROM vwMaxIdUn", sdo.getConnectSDO());
            sqlcom.ExecuteNonQuery();
            SqlDataAdapter adap = new SqlDataAdapter(sqlcom);
            datTab = new DataTable();
            adap.Fill(datTab);

            int a = 0;

            foreach (DataRow DR in datTab.Rows)
            {
                a = Convert.ToInt32(DR["MAXId"].ToString());
            }
            sdo.CloseConnection();

            return a;
        }

        private void tbEvP1_KeyPress(object sender, KeyPressEventArgs e)
        {
            ekeyTB(e);
        }

        private void tbEvP2_KeyPress(object sender, KeyPressEventArgs e)
        {
            ekeyTB(e);
        }

        private void tbEvP3_KeyPress(object sender, KeyPressEventArgs e)
        {
            ekeyTB(e);
        }

        private void tbEvP4_KeyPress(object sender, KeyPressEventArgs e)
        {
            ekeyTB(e);
        }

        private void tbEvP5_KeyPress(object sender, KeyPressEventArgs e)
        {
            ekeyTB(e);
        }
        public void sumTBEP1()
        {
            if (tbEvP1.Text.Length > 0 && tbEvP2.Text.Length > 0 && tbEvP3.Text.Length > 0 && tbEvP4.Text.Length > 0)
            {
                int a = Convert.ToInt32(tbEvP1.Text);
                int b = Convert.ToInt32(tbEvP2.Text);
                int c = Convert.ToInt32(tbEvP3.Text);
                int d = Convert.ToInt32(tbEvP4.Text);
                int s = a + b + c + d;
                tbEventAllP.Text = Convert.ToString(s);
                if (tbEventAllP.Text.Length > 0 && tbEventAllB.Text.Length > 0)
                {
                    int a1 = Convert.ToInt32(tbEventAllP.Text);
                    int b1 = Convert.ToInt32(tbEventAllB.Text);
                    int s1 = a1 + b1;
                    tbEventAll.Text = Convert.ToString(s1);
                }
            }
            else
                return;
            SUMEvent();
        }

        public void sumTBEB1()
        {
            if (tbEvB1.Text.Length > 0 && tbEvB2.Text.Length > 0 && tbEvB3.Text.Length > 0 && tbEvB4.Text.Length > 0)
            {
                int a = Convert.ToInt32(tbEvB1.Text);
                int b = Convert.ToInt32(tbEvB2.Text);
                int c = Convert.ToInt32(tbEvB3.Text);
                int d = Convert.ToInt32(tbEvB4.Text);
                int s = a + b + c + d;
                tbEventAllB.Text = Convert.ToString(s);
                if (tbEventAllP.Text.Length > 0 && tbEventAllB.Text.Length > 0)
                {
                    int a1 = Convert.ToInt32(tbEventAllP.Text);
                    int b1 = Convert.ToInt32(tbEventAllB.Text);
                    int s1 = a1 + b1;
                    tbEventAll.Text = Convert.ToString(s1);
                }
            }
            else
                return;
            SUMEvent();
        }

        private void tbEvP1_TextChanged(object sender, EventArgs e)
        {
            sumTBEP1();
        }

        private void tbEvP2_TextChanged(object sender, EventArgs e)
        {
            sumTBEP1();
        }

        private void tbEvP3_TextChanged(object sender, EventArgs e)
        {
            sumTBEP1();
        }

        private void tbEvP4_TextChanged(object sender, EventArgs e)
        {
            sumTBEP1();
        }

        private void tbEvP5_TextChanged(object sender, EventArgs e)
        {
            sumTBEP1();
        }

        private void tbEvB1_TextChanged(object sender, EventArgs e)
        {
            sumTBEB1();
        }

        private void tbEvB2_TextChanged(object sender, EventArgs e)
        {
            sumTBEB1();
        }

        private void tbEvB3_TextChanged(object sender, EventArgs e)
        {
            sumTBEB1();
        }

        private void tbEvB4_TextChanged(object sender, EventArgs e)
        {
            sumTBEB1();
        }

        private void tbEvB5_TextChanged(object sender, EventArgs e)
        {
            sumTBEB1();
        }

        private void tbEvB1_KeyPress(object sender, KeyPressEventArgs e)
        {
            ekeyTB(e);
        }

        private void tbEvB2_KeyPress(object sender, KeyPressEventArgs e)
        {
            ekeyTB(e);
        }

        private void tbEvB3_KeyPress(object sender, KeyPressEventArgs e)
        {
            ekeyTB(e);
        }

        private void tbEvB4_KeyPress(object sender, KeyPressEventArgs e)
        {
            ekeyTB(e);
        }

        private void tbEvB5_KeyPress(object sender, KeyPressEventArgs e)
        {
            ekeyTB(e);
        }

        public void sumTBPP1()
        {
            if (tbpgr1.Text.Length > 0 && tbpgr2.Text.Length > 0 && tbpgr3.Text.Length > 0 && tbpgr4.Text.Length > 0)
            {
                int a = Convert.ToInt32(tbpgr1.Text);
                int b = Convert.ToInt32(tbpgr2.Text);
                int c = Convert.ToInt32(tbpgr3.Text);
                int d = Convert.ToInt32(tbpgr4.Text);
                int s = a + b + c + d;
                tbUnitAllP.Text = Convert.ToString(s);
                if (tbUnitAllP.Text.Length > 0 && tbUnitAllB.Text.Length > 0)
                {
                    int a1 = Convert.ToInt32(tbUnitAllP.Text);
                    int b1 = Convert.ToInt32(tbUnitAllB.Text);
                    int s1 = a1 + b1;
                    tbUnitAll.Text = Convert.ToString(s1);
                }
            }
            else
                return;
            SUNUnit();
        }

        private void tbpgr1_TextChanged(object sender, EventArgs e)
        {
            sumTBPP1();
        }

        private void tbpgr2_TextChanged(object sender, EventArgs e)
        {
            sumTBPP1();
        }

        private void tbpgr3_TextChanged(object sender, EventArgs e)
        {
            sumTBPP1();
        }

        private void tbpgr4_TextChanged(object sender, EventArgs e)
        {
            sumTBPP1();
        }

        private void tbpgr5_TextChanged(object sender, EventArgs e)
        {
            sumTBPP1();
        }

        private void tbpgr1_KeyPress(object sender, KeyPressEventArgs e)
        {
            ekeyTB(e);
        }

        private void tbpgr2_KeyPress(object sender, KeyPressEventArgs e)
        {
            ekeyTB(e);
        }

        private void tbpgr3_KeyPress(object sender, KeyPressEventArgs e)
        {
            ekeyTB(e);
        }

        private void tbpgr4_KeyPress(object sender, KeyPressEventArgs e)
        {
            ekeyTB(e);
        }

        private void tbpgr5_KeyPress(object sender, KeyPressEventArgs e)
        {
            ekeyTB(e);
        }

        public void sumTBPB1()
        {
            if (tbPBgr1.Text.Length > 0 && tbPBgr2.Text.Length > 0 && tbPBgr3.Text.Length > 0 && tbPBgr4.Text.Length > 0)
            {
                int a = Convert.ToInt32(tbPBgr1.Text);
                int b = Convert.ToInt32(tbPBgr2.Text);
                int c = Convert.ToInt32(tbPBgr3.Text);
                int d = Convert.ToInt32(tbPBgr4.Text);
                int s = a + b + c + d;
                tbUnitAllB.Text = Convert.ToString(s);
                if (tbUnitAllP.Text.Length > 0 && tbUnitAllB.Text.Length > 0)
                {
                    int a1 = Convert.ToInt32(tbUnitAllP.Text);
                    int b1 = Convert.ToInt32(tbUnitAllB.Text);
                    int s1 = a1 + b1;
                    tbUnitAll.Text = Convert.ToString(s1);
                }
            }
            else
                return;
            SUNUnit();
        }

        private void tbPBgr1_TextChanged(object sender, EventArgs e)
        {
            sumTBPB1();
        }

        private void tbPBgr2_TextChanged(object sender, EventArgs e)
        {
            sumTBPB1();
        }

        private void tbPBgr3_TextChanged(object sender, EventArgs e)
        {
            sumTBPB1();
        }

        private void tbPBgr4_TextChanged(object sender, EventArgs e)
        {
            sumTBPB1();
        }

        private void tbPBgr5_TextChanged(object sender, EventArgs e)
        {
            sumTBPB1();
        }

        private void tbPBgr1_KeyPress(object sender, KeyPressEventArgs e)
        {
            ekeyTB(e);
        }

        private void tbPBgr2_KeyPress(object sender, KeyPressEventArgs e)
        {
            ekeyTB(e);
        }

        private void tbPBgr3_KeyPress(object sender, KeyPressEventArgs e)
        {
            ekeyTB(e);
        }

        private void tbPBgr4_KeyPress(object sender, KeyPressEventArgs e)
        {
            ekeyTB(e);
        }

        private void tbPBgr5_KeyPress(object sender, KeyPressEventArgs e)
        {
            ekeyTB(e);
        }
        private void tbgr1_KeyPress(object sender, KeyPressEventArgs e)
        {
            ekeyTB(e);
        }

        private void tbgr2_KeyPress(object sender, KeyPressEventArgs e)
        {
            ekeyTB(e);
        }

        private void tbgr3_KeyPress(object sender, KeyPressEventArgs e)
        {
            ekeyTB(e);
        }

        private void tbgr4_KeyPress(object sender, KeyPressEventArgs e)
        {
            ekeyTB(e);
        }

        private void tbgr5_KeyPress(object sender, KeyPressEventArgs e)
        {
            ekeyTB(e);
        }

        private void tbTickB1_KeyPress(object sender, KeyPressEventArgs e)
        {
            ekeyTB(e);
        }

        private void tbTickB2_KeyPress(object sender, KeyPressEventArgs e)
        {
            ekeyTB(e);
        }

        private void tbTickB13_KeyPress(object sender, KeyPressEventArgs e)
        {
            ekeyTB(e);
        }

        private void tbTickB4_KeyPress(object sender, KeyPressEventArgs e)
        {
            ekeyTB(e);
        }

        private void tbTickB5_KeyPress(object sender, KeyPressEventArgs e)
        {
            ekeyTB(e);
        }


        public void sumTBEP2()
        {
            if (tbEventP21.Text.Length > 0 && tbEventP22.Text.Length > 0 && tbEventP23.Text.Length > 0 && tbEventP24.Text.Length > 0)
            {
                int a = Convert.ToInt32(tbEventP21.Text);
                int b = Convert.ToInt32(tbEventP22.Text);
                int c = Convert.ToInt32(tbEventP23.Text);
                int d = Convert.ToInt32(tbEventP24.Text);
                int s = a + b + c + d;
                tbEventAllP2.Text = Convert.ToString(s);
                if (tbEventAllP2.Text.Length > 0 && tbEventAllB2.Text.Length > 0)
                {
                    int a1 = Convert.ToInt32(tbEventAllP2.Text);
                    int b1 = Convert.ToInt32(tbEventAllB2.Text);
                    int s1 = a1 + b1;
                    tbEventAll2.Text = Convert.ToString(s1);
                }
            }
            else
                return;
            SUMEvent();
        }

        private void tbEventP21_TextChanged(object sender, EventArgs e)
        {
            sumTBEP2();
        }

        private void tbEventP22_TextChanged(object sender, EventArgs e)
        {
            sumTBEP2();
        }

        private void tbEventP23_TextChanged(object sender, EventArgs e)
        {
            sumTBEP2();
        }

        private void tbEventP24_TextChanged(object sender, EventArgs e)
        {
            sumTBEP2();
        }

        private void tbEventP25_TextChanged(object sender, EventArgs e)
        {
            sumTBEP2();
        }

        private void tbEventP21_KeyPress(object sender, KeyPressEventArgs e)
        {
            ekeyTB(e);
        }

        private void tbEventP22_KeyPress(object sender, KeyPressEventArgs e)
        {
            ekeyTB(e);
        }

        private void tbEventP23_KeyPress(object sender, KeyPressEventArgs e)
        {
            ekeyTB(e);
        }

        private void tbEventP24_KeyPress(object sender, KeyPressEventArgs e)
        {
            ekeyTB(e);
        }

        private void tbEventP25_KeyPress(object sender, KeyPressEventArgs e)
        {
            ekeyTB(e);
        }


        public void sumTBEB2()
        {
            if (tbEventB21.Text.Length > 0 && tbEventB22.Text.Length > 0 && tbEventB23.Text.Length > 0 && tbEventB24.Text.Length > 0)
            {
                int a = Convert.ToInt32(tbEventB21.Text);
                int b = Convert.ToInt32(tbEventB22.Text);
                int c = Convert.ToInt32(tbEventB23.Text);
                int d = Convert.ToInt32(tbEventB24.Text);
                int s = a + b + c + d;
                tbEventAllB2.Text = Convert.ToString(s);
                if (tbEventAllP2.Text.Length > 0 && tbEventAllB2.Text.Length > 0)
                {
                    int a1 = Convert.ToInt32(tbEventAllP2.Text);
                    int b1 = Convert.ToInt32(tbEventAllB2.Text);
                    int s1 = a1 + b1;
                    tbEventAll2.Text = Convert.ToString(s1);
                }
            }
            else
                return;
            SUMEvent();
        }

        private void tbEventB21_TextChanged(object sender, EventArgs e)
        {
            sumTBEB2();
        }

        private void tbEventB22_TextChanged(object sender, EventArgs e)
        {
            sumTBEB2();
        }

        private void tbEventB23_TextChanged(object sender, EventArgs e)
        {
            sumTBEB2();
        }

        private void tbEventB24_TextChanged(object sender, EventArgs e)
        {
            sumTBEB2();
        }

        private void tbEventB25_TextChanged(object sender, EventArgs e)
        {
            sumTBEB2();
        }

        private void tbEventB21_KeyPress(object sender, KeyPressEventArgs e)
        {
            ekeyTB(e);
        }

        private void tbEventB22_KeyPress(object sender, KeyPressEventArgs e)
        {
            ekeyTB(e);
        }

        private void tbEventB23_KeyPress(object sender, KeyPressEventArgs e)
        {
            ekeyTB(e);
        }

        private void tbEventB24_KeyPress(object sender, KeyPressEventArgs e)
        {
            ekeyTB(e);
        }

        private void tbEventB25_KeyPress(object sender, KeyPressEventArgs e)
        {
            ekeyTB(e);
        }


        public void sumTBPP2()
        {
            if (tbPgr21.Text.Length > 0 && tbPgr22.Text.Length > 0 && tbPgr23.Text.Length > 0 && tbPgr24.Text.Length > 0)
            {
                int a = Convert.ToInt32(tbPgr21.Text);
                int b = Convert.ToInt32(tbPgr22.Text);
                int c = Convert.ToInt32(tbPgr23.Text);
                int d = Convert.ToInt32(tbPgr24.Text);
                int s = a + b + c + d ;
                tbUnitAllP2.Text = Convert.ToString(s);
                if (tbUnitAllP2.Text.Length > 0 && tbUnitAllB2.Text.Length > 0)
                {
                    int a1 = Convert.ToInt32(tbUnitAllP2.Text);
                    int b1 = Convert.ToInt32(tbUnitAllB2.Text);
                    int s1 = a1 + b1;
                    tbUnitAll2.Text = Convert.ToString(s1);
                }
            }
            else
                return;
            SUNUnit();
        }

        private void tbPgr21_TextChanged(object sender, EventArgs e)
        {
            sumTBPP2();
        }

        private void tbPgr22_TextChanged(object sender, EventArgs e)
        {
            sumTBPP2();
        }

        private void tbPgr23_TextChanged(object sender, EventArgs e)
        {
            sumTBPP2();
        }

        private void tbPgr24_TextChanged(object sender, EventArgs e)
        {
            sumTBPP2();
        }

        private void tbPgr25_TextChanged(object sender, EventArgs e)
        {
            sumTBPP2();
        }

        private void tbPgr21_KeyPress(object sender, KeyPressEventArgs e)
        {
            ekeyTB(e);
        }

        private void tbPgr22_KeyPress(object sender, KeyPressEventArgs e)
        {
            ekeyTB(e);
        }

        private void tbPgr23_KeyPress(object sender, KeyPressEventArgs e)
        {
            ekeyTB(e);
        }

        private void tbPgr24_KeyPress(object sender, KeyPressEventArgs e)
        {
            ekeyTB(e);
        }

        private void tbPgr25_KeyPress(object sender, KeyPressEventArgs e)
        {
            ekeyTB(e);
        }

        public void sumTBPB2()
        {
            if (tbPBgr21.Text.Length > 0 && tbPBgr22.Text.Length > 0 && tbPBgr23.Text.Length > 0 && tbPBgr24.Text.Length > 0)
            {
                int a = Convert.ToInt32(tbPBgr21.Text);
                int b = Convert.ToInt32(tbPBgr22.Text);
                int c = Convert.ToInt32(tbPBgr23.Text);
                int d = Convert.ToInt32(tbPBgr24.Text);
                int s = a + b + c + d;
                tbUnitAllB2.Text = Convert.ToString(s);
                if (tbUnitAllP2.Text.Length > 0 && tbUnitAllB2.Text.Length > 0)
                {
                    int a1 = Convert.ToInt32(tbUnitAllP2.Text);
                    int b1 = Convert.ToInt32(tbUnitAllB2.Text);
                    int s1 = a1 + b1;
                    tbUnitAll2.Text = Convert.ToString(s1);
                }
            }
            else
                return;
            SUNUnit();
        }


        private void tbPBgr21_TextChanged(object sender, EventArgs e)
        {
            sumTBPB2();
        }

        private void tbPBgr22_TextChanged(object sender, EventArgs e)
        {
            sumTBPB2();
        }

        private void tbPBgr23_TextChanged(object sender, EventArgs e)
        {
            sumTBPB2();
        }

        private void tbPBgr24_TextChanged(object sender, EventArgs e)
        {
            sumTBPB2();
        }

        private void tbPBgr25_TextChanged(object sender, EventArgs e)
        {
            sumTBPB2();
        }

        private void tbPBgr21_KeyPress(object sender, KeyPressEventArgs e)
        {
            ekeyTB(e);
        }

        private void tbPBgr22_KeyPress(object sender, KeyPressEventArgs e)
        {
            ekeyTB(e);
        }

        private void tbPBgr23_KeyPress(object sender, KeyPressEventArgs e)
        {
            ekeyTB(e);
        }

        private void tbPBgr24_KeyPress(object sender, KeyPressEventArgs e)
        {
            ekeyTB(e);
        }

        private void tbPBgr25_KeyPress(object sender, KeyPressEventArgs e)
        {
            ekeyTB(e);
        }

        private void tbgr21_KeyPress(object sender, KeyPressEventArgs e)
        {
            ekeyTB(e);
        }

        private void tbgr22_KeyPress(object sender, KeyPressEventArgs e)
        {
            ekeyTB(e);
        }

        private void tbgr23_KeyPress(object sender, KeyPressEventArgs e)
        {
            ekeyTB(e);
        }

        private void tbgr24_KeyPress(object sender, KeyPressEventArgs e)
        {
            ekeyTB(e);
        }

        private void tbgr25_KeyPress(object sender, KeyPressEventArgs e)
        {
            ekeyTB(e);
        }

        private void tbTickB21_KeyPress(object sender, KeyPressEventArgs e)
        {
            ekeyTB(e);
        }

        private void tbTickB22_KeyPress(object sender, KeyPressEventArgs e)
        {
            ekeyTB(e);
        }

        private void tbTickB23_KeyPress(object sender, KeyPressEventArgs e)
        {
            ekeyTB(e);
        }

        private void tbTickB24_KeyPress(object sender, KeyPressEventArgs e)
        {
            ekeyTB(e);
        }

        private void tbTickB25_KeyPress(object sender, KeyPressEventArgs e)
        {
            ekeyTB(e);
        }

        public void SUMEvent()
        {
            int EventP1 = Convert.ToInt32(tbEventAllP.Text);
            int EventP2 = Convert.ToInt32(tbEventAllP2.Text);

            int EventB1 = Convert.ToInt32(tbEventAllB.Text);
            int EventB2 = Convert.ToInt32(tbEventAllB2.Text);

            int resEventP = EventP1 + EventP2;
            tbEvSUMP.Text = Convert.ToString(resEventP);

            int resEventB = EventB1 + EventB2;
            tbEventSUMB.Text = Convert.ToString(resEventB);

            int resEventS = resEventP + resEventB;
            tbEventSUM.Text = Convert.ToString(resEventS);
        }

        public void SUNUnit()
        {
            int UnitP1 = Convert.ToInt32(tbUnitAllP.Text);
            int UnitP2 = Convert.ToInt32(tbUnitAllP2.Text);

            int UnitB1 = Convert.ToInt32(tbUnitAllB.Text);
            int UnitB2 = Convert.ToInt32(tbUnitAllB2.Text);

            int resUnitP = UnitP1 + UnitP2;
            tbUnitSUMP.Text = Convert.ToString(resUnitP);

            int resUnitB = UnitB1 + UnitB2;
            tbUnitSUMB.Text = Convert.ToString(resUnitB);

            int resUnitS = resUnitP + resUnitB;
            tbUnitSUM.Text = Convert.ToString(resUnitS);
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (Int32.Parse(tbEventSUM.Text) > 0 && Int32.Parse(tbUnitSUM.Text) > 0)
            {
                try
                {
                    if (tbEvent.Text.Length > 0 && cmbStatusEvent.Text.Length > 0)
                    {
                        ConnectSDO sdo = new ConnectSDO();
                        SqlCommand sqlcom2 = new SqlCommand("spAddYearPlan", sdo.getConnectSDO());
                        sqlcom2.CommandType = CommandType.StoredProcedure;
                        sqlcom2.Parameters.AddWithValue("@DataEnd", SqlDbType.DateTime).Value = mcEndEvent.SelectionRange.Start;
                        sqlcom2.Parameters.AddWithValue("@Name", SqlDbType.NVarChar).Value = tbEvent.Text.Trim();
                        sqlcom2.Parameters.AddWithValue("@Status", SqlDbType.NVarChar).Value = cmbStatusEvent.Text.Trim();
                        sqlcom2.Parameters.AddWithValue("@DataFirst", SqlDbType.DateTime).Value = mcDataEvent.SelectionRange.Start;
                        sdo.OpenConnection();
                        sqlcom2.ExecuteNonQuery();
                        sdo.CloseConnection();
                    }
                    else
                        MessageBox.Show("Не удалось добавить данные!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    int Event = vwIdEvent();
                    if (cmbStatusQtyEvent1.Text.Length > 0)
                    {
                        string CategU = cmbStatusQtyEvent1.Text;
                        int EventU = Event;
                        spUnit(Event, CategU);

                        int Iduu = vwIdUnit();

                        if (tbEventAllP.Text.Length >= 0)
                        {
                            int IdU = Iduu;
                            int QtyU = Int32.Parse(tbEventAllP.Text);
                            string NameU = lblEvent.Text;
                            string CategoryU = lblP.Text;

                            spQtyUnit(IdU, QtyU, NameU, CategoryU);

                            int Qty1 = Int32.Parse(tbEventAllB.Text);
                            string Name1 = lblEvent.Text;
                            string Category1 = lblB.Text;

                            spQtyUnit(IdU, Qty1, Name1, Category1);

                            int Qty2 = Int32.Parse(tbUnitAllP.Text);
                            string Name2 = lblPeople.Text;
                            string Category2 = lblP.Text;

                            spQtyUnit(IdU, Qty2, Name2, Category2);

                            int Qty3 = Int32.Parse(tbUnitAllB.Text);
                            string Name3 = lblPeople.Text;
                            string Category3 = lblB.Text;

                            spQtyUnit(IdU, Qty3, Name3, Category3);
                        }
                        else
                            MessageBox.Show("Не удалось добавить подразделение!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }

                    if (cmbgr1.Text.Length > 0)
                    {
                        string CategU = cmbgr1.Text;
                        int EventU = Event;
                        spUnit(Event, CategU);

                        int Iduu = vwIdUnit();

                        if (tbEvP1.Text.Length >= 0 && tbEvB1.Text.Length >= 0 && tbpgr1.Text.Length >= 0 && tbPBgr1.Text.Length >= 0)
                        {
                            int IdU = Iduu;
                            int QtyU = Int32.Parse(tbEvP1.Text);
                            string NameU = lblEvent.Text;
                            string CategoryU = lblP.Text;

                            spQtyUnit(IdU, QtyU, NameU, CategoryU);

                            int Qty1 = Int32.Parse(tbEvB1.Text);
                            string Name1 = lblEvent.Text;
                            string Category1 = lblB.Text;

                            spQtyUnit(IdU, Qty1, Name1, Category1);

                            int Qty2 = Int32.Parse(tbpgr1.Text);
                            string Name2 = lblPeople.Text;
                            string Category2 = lblP.Text;

                            spQtyUnit(IdU, Qty2, Name2, Category2);

                            int Qty3 = Int32.Parse(tbPBgr1.Text);
                            string Name3 = lblPeople.Text;
                            string Category3 = lblB.Text;

                            spQtyUnit(IdU, Qty3, Name3, Category3);
                        }
                        else
                            MessageBox.Show("Не удалось добавить подразделение!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }


                    if (cmbgr2.Text.Length > 0)
                    {
                        string CategU = cmbgr2.Text;
                        int EventU = Event;
                        spUnit(Event, CategU);

                        int Iduu = vwIdUnit();

                        if (tbEvP2.Text.Length >= 0 && tbEvB2.Text.Length >= 0 && tbpgr2.Text.Length >= 0 && tbPBgr2.Text.Length >= 0)
                        {
                            int IdU = Iduu;
                            int QtyU = Int32.Parse(tbEvP2.Text);
                            string NameU = lblEvent.Text;
                            string CategoryU = lblP.Text;

                            spQtyUnit(IdU, QtyU, NameU, CategoryU);

                            int Qty1 = Int32.Parse(tbEvB2.Text);
                            string Name1 = lblEvent.Text;
                            string Category1 = lblB.Text;

                            spQtyUnit(IdU, Qty1, Name1, Category1);

                            int Qty2 = Int32.Parse(tbpgr2.Text);
                            string Name2 = lblPeople.Text;
                            string Category2 = lblP.Text;

                            spQtyUnit(IdU, Qty2, Name2, Category2);

                            int Qty3 = Int32.Parse(tbPBgr2.Text);
                            string Name3 = lblPeople.Text;
                            string Category3 = lblB.Text;

                            spQtyUnit(IdU, Qty3, Name3, Category3);
                        }
                        else
                            MessageBox.Show("Не удалось добавить подразделение!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }

                    if (cmbgr3.Text.Length > 0)
                    {
                        string CategU = cmbgr3.Text;
                        int EventU = Event;
                        spUnit(Event, CategU);

                        int Iduu = vwIdUnit();

                        if (tbEvP3.Text.Length >= 0 && tbEvB3.Text.Length >= 0 && tbpgr3.Text.Length >= 0 && tbPBgr3.Text.Length >= 0)
                        {
                            int IdU = Iduu;
                            int QtyU = Int32.Parse(tbEvP3.Text);
                            string NameU = lblEvent.Text;
                            string CategoryU = lblP.Text;

                            spQtyUnit(IdU, QtyU, NameU, CategoryU);

                            int Qty1 = Int32.Parse(tbEvB3.Text);
                            string Name1 = lblEvent.Text;
                            string Category1 = lblB.Text;

                            spQtyUnit(IdU, Qty1, Name1, Category1);

                            int Qty2 = Int32.Parse(tbpgr3.Text);
                            string Name2 = lblPeople.Text;
                            string Category2 = lblP.Text;

                            spQtyUnit(IdU, Qty2, Name2, Category2);

                            int Qty3 = Int32.Parse(tbPBgr3.Text);
                            string Name3 = lblPeople.Text;
                            string Category3 = lblB.Text;

                            spQtyUnit(IdU, Qty3, Name3, Category3);
                        }
                        else
                            MessageBox.Show("Не удалось добавить подразделение!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }

                    if (cmbgr4.Text.Length > 0)
                    {
                        string CategU = cmbgr4.Text;
                        int EventU = Event;
                        spUnit(Event, CategU);

                        int Iduu = vwIdUnit();

                        if (tbEvP4.Text.Length >= 0 && tbEvB4.Text.Length >= 0 && tbpgr4.Text.Length >= 0 && tbPBgr4.Text.Length >= 0)
                        {
                            int IdU = Iduu;
                            int QtyU = Int32.Parse(tbEvP4.Text);
                            string NameU = lblEvent.Text;
                            string CategoryU = lblP.Text;

                            spQtyUnit(IdU, QtyU, NameU, CategoryU);

                            int Qty1 = Int32.Parse(tbEvB4.Text);
                            string Name1 = lblEvent.Text;
                            string Category1 = lblB.Text;

                            spQtyUnit(IdU, Qty1, Name1, Category1);

                            int Qty2 = Int32.Parse(tbpgr4.Text);
                            string Name2 = lblPeople.Text;
                            string Category2 = lblP.Text;

                            spQtyUnit(IdU, Qty2, Name2, Category2);

                            int Qty3 = Int32.Parse(tbPBgr4.Text);
                            string Name3 = lblPeople.Text;
                            string Category3 = lblB.Text;

                            spQtyUnit(IdU, Qty3, Name3, Category3);
                        }
                        else
                            MessageBox.Show("Не удалось добавить подразделение!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }


                    if (cmbStatusQtyEventt2.Text.Length > 0)
                    {
                        string CategU = cmbStatusQtyEventt2.Text;
                        int EventU = Event;
                        spUnit(Event, CategU);

                        int Iduu = vwIdUnit();

                        if (tbEventAllP2.Text.Length >= 0)
                        {
                            int IdU = Iduu;
                            int QtyU = Int32.Parse(tbEventAllP2.Text);
                            string NameU = lblEvent.Text;
                            string CategoryU = lblP.Text;

                            spQtyUnit(IdU, QtyU, NameU, CategoryU);

                            int Qty1 = Int32.Parse(tbEventAllB2.Text);
                            string Name1 = lblEvent.Text;
                            string Category1 = lblB.Text;

                            spQtyUnit(IdU, Qty1, Name1, Category1);

                            int Qty2 = Int32.Parse(tbUnitAllP2.Text);
                            string Name2 = lblPeople.Text;
                            string Category2 = lblP.Text;

                            spQtyUnit(IdU, Qty2, Name2, Category2);

                            int Qty3 = Int32.Parse(tbUnitAllB2.Text);
                            string Name3 = lblPeople.Text;
                            string Category3 = lblB.Text;

                            spQtyUnit(IdU, Qty3, Name3, Category3);
                        }
                        else
                            MessageBox.Show("Не удалось добавить подразделение!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }

                    if (cmbGR21.Text.Length > 0)
                    {
                        string CategU = cmbGR21.Text;
                        int EventU = Event;
                        spUnit(Event, CategU);

                        int Iduu = vwIdUnit();

                        if (tbEventP21.Text.Length >= 0 && tbEventB21.Text.Length >= 0 && tbPgr21.Text.Length >= 0 && tbPBgr21.Text.Length >= 0)
                        {
                            int IdU = Iduu;
                            int QtyU = Int32.Parse(tbEventP21.Text);
                            string NameU = lblEvent.Text;
                            string CategoryU = lblP.Text;

                            spQtyUnit(IdU, QtyU, NameU, CategoryU);

                            int Qty1 = Int32.Parse(tbEventB21.Text);
                            string Name1 = lblEvent.Text;
                            string Category1 = lblB.Text;

                            spQtyUnit(IdU, Qty1, Name1, Category1);

                            int Qty2 = Int32.Parse(tbPgr21.Text);
                            string Name2 = lblPeople.Text;
                            string Category2 = lblP.Text;

                            spQtyUnit(IdU, Qty2, Name2, Category2);

                            int Qty3 = Int32.Parse(tbPBgr21.Text);
                            string Name3 = lblPeople.Text;
                            string Category3 = lblB.Text;

                            spQtyUnit(IdU, Qty3, Name3, Category3);
                        }
                        else
                            MessageBox.Show("Не удалось добавить подразделение!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }


                    if (cmbGR22.Text.Length > 0)
                    {
                        string CategU = cmbGR22.Text;
                        int EventU = Event;
                        spUnit(Event, CategU);

                        int Iduu = vwIdUnit();

                        if (tbEventP22.Text.Length >= 0 && tbEventB22.Text.Length >= 0 && tbPgr22.Text.Length >= 0 && tbPBgr22.Text.Length >= 0 )
                        {
                            int IdU = Iduu;
                            int QtyU = Int32.Parse(tbEventP22.Text);
                            string NameU = lblEvent.Text;
                            string CategoryU = lblP.Text;

                            spQtyUnit(IdU, QtyU, NameU, CategoryU);

                            int Qty1 = Int32.Parse(tbEventB22.Text);
                            string Name1 = lblEvent.Text;
                            string Category1 = lblB.Text;

                            spQtyUnit(IdU, Qty1, Name1, Category1);

                            int Qty2 = Int32.Parse(tbPgr22.Text);
                            string Name2 = lblPeople.Text;
                            string Category2 = lblP.Text;

                            spQtyUnit(IdU, Qty2, Name2, Category2);

                            int Qty3 = Int32.Parse(tbPBgr22.Text);
                            string Name3 = lblPeople.Text;
                            string Category3 = lblB.Text;

                            spQtyUnit(IdU, Qty3, Name3, Category3);
                        }
                        else
                            MessageBox.Show("Не удалось добавить подразделение!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }


                    if (cmbGR23.Text.Length > 0)
                    {
                        string CategU = cmbGR23.Text;
                        int EventU = Event;
                        spUnit(Event, CategU);

                        int Iduu = vwIdUnit();

                        if (tbEventP23.Text.Length >= 0 && tbEventB23.Text.Length >= 0 && tbPgr23.Text.Length >= 0 && tbPBgr23.Text.Length >= 0)
                        {
                            int IdU = Iduu;
                            int QtyU = Int32.Parse(tbEventP23.Text);
                            string NameU = lblEvent.Text;
                            string CategoryU = lblP.Text;

                            spQtyUnit(IdU, QtyU, NameU, CategoryU);

                            int Qty1 = Int32.Parse(tbEventB23.Text);
                            string Name1 = lblEvent.Text;
                            string Category1 = lblB.Text;

                            spQtyUnit(IdU, Qty1, Name1, Category1);

                            int Qty2 = Int32.Parse(tbPgr23.Text);
                            string Name2 = lblPeople.Text;
                            string Category2 = lblP.Text;

                            spQtyUnit(IdU, Qty2, Name2, Category2);

                            int Qty3 = Int32.Parse(tbPBgr23.Text);
                            string Name3 = lblPeople.Text;
                            string Category3 = lblB.Text;

                            spQtyUnit(IdU, Qty3, Name3, Category3);
                        }
                        else
                            MessageBox.Show("Не удалось добавить подразделение!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }


                    if (cmbGR24.Text.Length > 0)
                    {
                        string CategU = cmbGR24.Text;
                        int EventU = Event;
                        spUnit(Event, CategU);

                        int Iduu = vwIdUnit();

                        if (tbEventP24.Text.Length >= 0 && tbEventB24.Text.Length >= 0 && tbPgr24.Text.Length >= 0 && tbPBgr24.Text.Length >= 0)
                        {
                            int IdU = Iduu;
                            int QtyU = Int32.Parse(tbEventP24.Text);
                            string NameU = lblEvent.Text;
                            string CategoryU = lblP.Text;

                            spQtyUnit(IdU, QtyU, NameU, CategoryU);

                            int Qty1 = Int32.Parse(tbEventB24.Text);
                            string Name1 = lblEvent.Text;
                            string Category1 = lblB.Text;

                            spQtyUnit(IdU, Qty1, Name1, Category1);

                            int Qty2 = Int32.Parse(tbPgr24.Text);
                            string Name2 = lblPeople.Text;
                            string Category2 = lblP.Text;

                            spQtyUnit(IdU, Qty2, Name2, Category2);

                            int Qty3 = Int32.Parse(tbPBgr24.Text);
                            string Name3 = lblPeople.Text;
                            string Category3 = lblB.Text;

                            spQtyUnit(IdU, Qty3, Name3, Category3);
                        }
                        else
                            MessageBox.Show("Не удалось добавить подразделение!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }

                    MessageBox.Show("Годовое мероприятие добавлено!");
                    this.Hide();
                    MainForm m = new MainForm();
                    m.Show();
                }
                catch (Exception)
                {
                    MessageBox.Show("Не удалось добавить мероприятие!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
                MessageBox.Show("Заполните все поля!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public void spUnit(int Id, string Categ)
        {
            ConnectSDO sdo = new ConnectSDO();
            SqlCommand sqlcom2 = new SqlCommand("spAddYearUnit", sdo.getConnectSDO());
            sqlcom2.CommandType = CommandType.StoredProcedure;
            sqlcom2.Parameters.AddWithValue("@CategoryU", SqlDbType.NVarChar).Value = Categ;
            sqlcom2.Parameters.AddWithValue("@IdE", SqlDbType.Int).Value = Id;
            sdo.OpenConnection();
            sqlcom2.ExecuteNonQuery();
            sdo.CloseConnection();
        }

        public void spQtyUnit(int Id,int Qty,string Name,string Categ)
        {
            ConnectSDO sdo = new ConnectSDO();
            SqlCommand sqlcom2 = new SqlCommand("spAddQtyUnitYear", sdo.getConnectSDO());
            sqlcom2.CommandType = CommandType.StoredProcedure;
            sqlcom2.Parameters.AddWithValue("@IdU", SqlDbType.Int).Value = Id;
            sqlcom2.Parameters.AddWithValue("@Name", SqlDbType.NVarChar).Value = Name;
            sqlcom2.Parameters.AddWithValue("@Qty", SqlDbType.Int).Value = Qty;
            sqlcom2.Parameters.AddWithValue("@Category", SqlDbType.NVarChar).Value = Categ;
            sdo.OpenConnection();
            sqlcom2.ExecuteNonQuery();
            sdo.CloseConnection();
        }

        private void btnCancel_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            MainForm m = new MainForm();
            m.Show();
        }

        private void AddMainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Hide();
            MainForm m = new MainForm();
            m.Show();
        }
    }
}
