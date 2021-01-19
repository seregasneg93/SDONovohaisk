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
    public partial class AddEventForm : Form
    {
        SqlDataAdapter adapter;
        DataTable datTab;
        SqlCommand sqlcom;
        int Idyp;
        public AddEventForm(int IdYP)
        {
            InitializeComponent();
            Idyp = IdYP;
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void AddEventForm_Load(object sender, EventArgs e)
        {

        }
        private void btnAddEvent_Click(object sender, EventArgs e)
        {
            AddNameEventFrom aef = new AddNameEventFrom();
            aef.ShowDialog();
        }

        public void SUMTBEventP()
        {
            if (tbEvP1.Text != "")
            {
                int a = Convert.ToInt32(tbEvP1.Text);
                int s = a + 0;
                tbEventAllP.Text = Convert.ToString(s);
                if (tbEventAllP.Text.Length > 0 && tbEventAllB.Text.Length > 0)
                {
                    int a1 = Convert.ToInt32(tbEventAllP.Text);
                    int b1 = Convert.ToInt32(tbEventAllB.Text);
                    int s1 = a1 + b1;
                    tbEventAll.Text = Convert.ToString(s1);
                }
            }

            if (tbEvP1.Text != "" && tbEvP2.Text != "" && tbEvP3.Text != "" && tbEvP4.Text != "" && tbEvP5.Text != "")
            {
                int a = Convert.ToInt32(tbEvP1.Text);
                int b = Convert.ToInt32(tbEvP2.Text);
                int c = Convert.ToInt32(tbEvP3.Text);
                int d = Convert.ToInt32(tbEvP4.Text);
                int f = Convert.ToInt32(tbEvP5.Text);
                int s = a + b + c + d + f;
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
           // SUMEvent();
        }

        public void ekeyTB(KeyPressEventArgs e)
        {
            if ((e.KeyChar <= 47 || e.KeyChar >= 58) && e.KeyChar != 8)
                e.Handled = true;
        }

        private void tbEvP2_TextChanged(object sender, EventArgs e)
        {
            SUMTBEventP();
        }

        private void tbEvP3_TextChanged(object sender, EventArgs e)
        {
            SUMTBEventP();
        }

        private void tbEvP1_TextChanged(object sender, EventArgs e)
        {
            SUMTBEventP();
        }

        private void tbEvP4_TextChanged(object sender, EventArgs e)
        {
            SUMTBEventP();
        }

        private void tbEvP5_TextChanged(object sender, EventArgs e)
        {
            SUMTBEventP();
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
        public void sumTBEB1()
        {
            if (tbEvB1.Text != "")
            {
                int a = Convert.ToInt32(tbEvB1.Text);
                int s = a + 0;
                tbEventAllB.Text = Convert.ToString(s);
                if (tbEventAllP.Text.Length > 0 && tbEventAllB.Text.Length > 0)
                {
                    int a1 = Convert.ToInt32(tbEventAllP.Text);
                    int b1 = Convert.ToInt32(tbEventAllB.Text);
                    int s1 = a1 + b1;
                    tbEventAll.Text = Convert.ToString(s1);
                }
            }

            if (tbEvB1.Text.Length > 0 && tbEvB2.Text.Length > 0 && tbEvB3.Text.Length > 0 && tbEvB4.Text.Length > 0 && tbEvB5.Text.Length > 0)
            {
                int a = Convert.ToInt32(tbEvB1.Text);
                int b = Convert.ToInt32(tbEvB2.Text);
                int c = Convert.ToInt32(tbEvB3.Text);
                int d = Convert.ToInt32(tbEvB4.Text);
                int f = Convert.ToInt32(tbEvB5.Text);
                int s = a + b + c + d + f;
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
            //SUMEvent();
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
            if (tbpgr1.Text != "")
            {
                int a = Convert.ToInt32(tbpgr1.Text);
                int s = a + 0;
                tbUnitAllP.Text = Convert.ToString(s);
                if (tbUnitAllP.Text.Length > 0 && tbUnitAllB.Text.Length > 0)
                {
                    int a1 = Convert.ToInt32(tbUnitAllP.Text);
                    int b1 = Convert.ToInt32(tbUnitAllB.Text);
                    int s1 = a1 + b1;
                    tbUnitAll.Text = Convert.ToString(s1);
                }
            }

            if (tbpgr1.Text.Length > 0 && tbpgr2.Text.Length > 0 && tbpgr3.Text.Length > 0 && tbpgr4.Text.Length > 0 && tbpgr5.Text.Length > 0)
            {
                int a = Convert.ToInt32(tbpgr1.Text);
                int b = Convert.ToInt32(tbpgr2.Text);
                int c = Convert.ToInt32(tbpgr3.Text);
                int d = Convert.ToInt32(tbpgr4.Text);
                int f = Convert.ToInt32(tbpgr5.Text);
                int s = a + b + c + d + f;
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
            //SUNUnit();
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
            if (tbPBgr1.Text != "")
            {
                int a = Convert.ToInt32(tbPBgr1.Text);
                int s = a + 0;
                tbUnitAllB.Text = Convert.ToString(s);
                if (tbUnitAllP.Text.Length > 0 && tbUnitAllB.Text.Length > 0)
                {
                    int a1 = Convert.ToInt32(tbUnitAllP.Text);
                    int b1 = Convert.ToInt32(tbUnitAllB.Text);
                    int s1 = a1 + b1;
                    tbUnitAll.Text = Convert.ToString(s1);
                }
            }

            if (tbPBgr1.Text.Length > 0 && tbPBgr2.Text.Length > 0 && tbPBgr3.Text.Length > 0 && tbPBgr4.Text.Length > 0 && tbPBgr5.Text.Length > 0)
            {
                int a = Convert.ToInt32(tbPBgr1.Text);
                int b = Convert.ToInt32(tbPBgr2.Text);
                int c = Convert.ToInt32(tbPBgr3.Text);
                int d = Convert.ToInt32(tbPBgr4.Text);
                int f = Convert.ToInt32(tbPBgr5.Text);
                int s = a + b + c + d + f;
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
            //SUNUnit();
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


        private void btnSave_Click(object sender, EventArgs e)
        {
            if (tbNameEvent.Text.Length > 0 && cmbStatusEvent.Text !="")
            {
                try
                {
                    if (tbNameEvent.Text.Length > 0 && cmbStatusEvent.Text.Length > 0)
                    {
                        ConnectSDO sdo = new ConnectSDO();
                        SqlCommand sqlcom2 = new SqlCommand("spAddEventt", sdo.getConnectSDO());
                        sqlcom2.CommandType = CommandType.StoredProcedure;
                        sqlcom2.Parameters.AddWithValue("@Name", SqlDbType.NVarChar).Value = tbNameEvent.Text.Trim();
                        sqlcom2.Parameters.AddWithValue("@Status", SqlDbType.NVarChar).Value = cmbStatusEvent.Text.Trim();
                        sqlcom2.Parameters.AddWithValue("@DataFirst", SqlDbType.DateTime).Value = mcEvent.SelectionRange.Start;
                        sqlcom2.Parameters.AddWithValue("@IdYP", SqlDbType.Int).Value = Idyp;
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
                            string NameUnit = cmbStatusQtyEvent1.Text;
                            string NameU = lblEvent.Text;
                            string CategoryU = lblP.Text;

                            spQtyUnit(IdU, QtyU,NameUnit, NameU, CategoryU);

                            int Qty1 = Int32.Parse(tbEventAllB.Text);
                            string NameUnit1 = cmbStatusQtyEvent1.Text;
                            string Name1 = lblEvent.Text;
                            string Category1 = lblB.Text;

                            spQtyUnit(IdU, Qty1, NameUnit1, Name1, Category1);

                            int Qty2 = Int32.Parse(tbUnitAllP.Text);
                            string NameUnit2 = cmbStatusQtyEvent1.Text;
                            string Name2 = lblPeople.Text;
                            string Category2 = lblP.Text;

                            spQtyUnit(IdU, Qty2, NameUnit2, Name2, Category2);

                            int Qty3 = Int32.Parse(tbUnitAllB.Text);
                            string NameUnit3 = cmbStatusQtyEvent1.Text;
                            string Name3 = lblPeople.Text;
                            string Category3 = lblB.Text;

                            spQtyUnit(IdU, Qty3, NameUnit3, Name3, Category3);

                            int Qty6 = Int32.Parse(tbAllPlayer.Text);
                            string NameUnit6 = cmbStatusQtyEvent1.Text;
                            string Name6 = lblParticial.Text;
                            string Category6 = lblB.Text;

                            spQtyUnit(IdU, Qty6, NameUnit6, Name6, Category6);
                        }
                    }
                    if (cmbgr1.Text.Length > 0)
                    {
                        //string CategU = cmbgr1.Text;
                        int EventU = Event;
                        //spUnit(Event, CategU);

                        int Iduu = vwIdUnit();

                        if (tbEvP1.Text.Length >= 0 && tbEvB1.Text.Length >= 0 && tbpgr1.Text.Length >= 0 && tbPBgr1.Text.Length >= 0)
                        {
                            int IdU = Iduu;
                            int QtyU = Int32.Parse(tbEvP1.Text);
                            string NameUnit = cmbgr1.Text;
                            string NameU = lblEvent.Text;
                            string CategoryU = lblP.Text;

                            spQtyUnit(IdU, QtyU, NameUnit, NameU, CategoryU);

                            int Qty1 = Int32.Parse(tbEvB1.Text);
                            string NameUnit1 = cmbgr1.Text;
                            string Name1 = lblEvent.Text;
                            string Category1 = lblB.Text;

                            spQtyUnit(IdU, Qty1, NameUnit1, Name1, Category1);

                            int Qty2 = Int32.Parse(tbpgr1.Text);
                            string NameUnit2 = cmbgr1.Text;
                            string Name2 = lblPeople.Text;
                            string Category2 = lblP.Text;

                            spQtyUnit(IdU, Qty2, NameUnit2, Name2, Category2);

                            int Qty3 = Int32.Parse(tbPBgr1.Text);
                            string NameUnit3 = cmbgr1.Text;
                            string Name3 = lblPeople.Text;
                            string Category3 = lblB.Text;

                            spQtyUnit(IdU, Qty3, NameUnit3, Name3, Category3);

                            int Qty6 = Int32.Parse(tbPlayer1.Text);
                            string NameUnit4 = cmbgr1.Text;
                            string Name6 = lblParticial.Text;
                            string Category6 = lblB.Text;

                            spQtyUnit(IdU, Qty6, NameUnit4, Name6, Category6);
                        }
                        else
                            MessageBox.Show("Не удалось добавить подразделение!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }


                    if (cmbgr2.Text.Length > 0)
                    {
                        //string CategU = cmbgr2.Text;
                        int EventU = Event;
                        //spUnit(Event, CategU);

                        int Iduu = vwIdUnit();

                        if (tbEvP2.Text.Length >= 0 && tbEvB2.Text.Length >= 0 && tbpgr2.Text.Length >= 0 && tbPBgr2.Text.Length >= 0)
                        {
                            int IdU = Iduu;
                            int QtyU = Int32.Parse(tbEvP2.Text);
                            string NameUnit = cmbgr2.Text;
                            string NameU = lblEvent.Text;
                            string CategoryU = lblP.Text;

                            spQtyUnit(IdU, QtyU, NameUnit, NameU, CategoryU);

                            int Qty1 = Int32.Parse(tbEvB2.Text);
                            string NameUnit1 = cmbgr2.Text;
                            string Name1 = lblEvent.Text;
                            string Category1 = lblB.Text;

                            spQtyUnit(IdU, Qty1, NameUnit1, Name1, Category1);

                            int Qty2 = Int32.Parse(tbpgr2.Text);
                            string NameUnit2 = cmbgr2.Text;
                            string Name2 = lblPeople.Text;
                            string Category2 = lblP.Text;

                            spQtyUnit(IdU, Qty2, NameUnit2, Name2, Category2);

                            int Qty3 = Int32.Parse(tbPBgr2.Text);
                            string NameUnit3 = cmbgr2.Text;
                            string Name3 = lblPeople.Text;
                            string Category3 = lblB.Text;

                            spQtyUnit(IdU, Qty3, NameUnit3, Name3, Category3);

                            int Qty6 = Int32.Parse(tbPlayer2.Text);
                            string NameUnit4 = cmbgr2.Text;
                            string Name6 = lblParticial.Text;
                            string Category6 = lblB.Text;

                            spQtyUnit(IdU, Qty6, NameUnit4, Name6, Category6);
                        }
                        else
                            MessageBox.Show("Не удалось добавить подразделение!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }

                    if (cmbgr3.Text.Length > 0)
                    {
                        //string CategU = cmbgr3.Text;
                        int EventU = Event;
                        //spUnit(Event, CategU);

                        int Iduu = vwIdUnit();

                        if (tbEvP3.Text.Length >= 0 && tbEvB3.Text.Length >= 0 && tbpgr3.Text.Length >= 0 && tbPBgr3.Text.Length >= 0)
                        {
                            int IdU = Iduu;
                            int QtyU = Int32.Parse(tbEvP3.Text);
                            string NameUnit = cmbgr3.Text;
                            string NameU = lblEvent.Text;
                            string CategoryU = lblP.Text;

                            spQtyUnit(IdU, QtyU, NameUnit, NameU, CategoryU);

                            int Qty1 = Int32.Parse(tbEvB3.Text);
                            string NameUnit1 = cmbgr3.Text;
                            string Name1 = lblEvent.Text;
                            string Category1 = lblB.Text;

                            spQtyUnit(IdU, Qty1, NameUnit1, Name1, Category1);

                            int Qty2 = Int32.Parse(tbpgr3.Text);
                            string NameUnit2 = cmbgr3.Text;
                            string Name2 = lblPeople.Text;
                            string Category2 = lblP.Text;

                            spQtyUnit(IdU, Qty2, NameUnit2, Name2, Category2);

                            int Qty3 = Int32.Parse(tbPBgr3.Text);
                            string NameUnit3 = cmbgr3.Text;
                            string Name3 = lblPeople.Text;
                            string Category3 = lblB.Text;

                            spQtyUnit(IdU, Qty3, NameUnit3, Name3, Category3);

                            int Qty6 = Int32.Parse(tbPlayer3.Text);
                            string NameUnit4 = cmbgr3.Text;
                            string Name6 = lblParticial.Text;
                            string Category6 = lblB.Text;

                            spQtyUnit(IdU, Qty6, NameUnit4, Name6, Category6);
                        }
                        else
                            MessageBox.Show("Не удалось добавить подразделение!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }


                    if (cmbgr4.Text.Length > 0)
                    {
                        //string CategU = cmbgr4.Text;
                        int EventU = Event;
                        //spUnit(Event, CategU);

                        int Iduu = vwIdUnit();

                        if (tbEvP4.Text.Length >= 0 && tbEvB4.Text.Length >= 0 && tbpgr4.Text.Length >= 0 && tbPBgr4.Text.Length >= 0)
                        {
                            int IdU = Iduu;
                            int QtyU = Int32.Parse(tbEvP4.Text);
                            string NameUnit = cmbgr4.Text;
                            string NameU = lblEvent.Text;
                            string CategoryU = lblP.Text;

                            spQtyUnit(IdU, QtyU, NameUnit, NameU, CategoryU);

                            int Qty1 = Int32.Parse(tbEvB4.Text);
                            string NameUnit1 = cmbgr4.Text;
                            string Name1 = lblEvent.Text;
                            string Category1 = lblB.Text;

                            spQtyUnit(IdU, Qty1, NameUnit1, Name1, Category1);

                            int Qty2 = Int32.Parse(tbpgr4.Text);
                            string NameUnit2 = cmbgr4.Text;
                            string Name2 = lblPeople.Text;
                            string Category2 = lblP.Text;

                            spQtyUnit(IdU, Qty2, NameUnit2, Name2, Category2);

                            int Qty3 = Int32.Parse(tbPBgr4.Text);
                            string NameUnit3 = cmbgr4.Text;
                            string Name3 = lblPeople.Text;
                            string Category3 = lblB.Text;

                            spQtyUnit(IdU, Qty3, NameUnit3, Name3, Category3);

                            int Qty6 = Int32.Parse(tbPlayer4.Text);
                            string NameUnit4 = cmbgr4.Text;
                            string Name6 = lblParticial.Text;
                            string Category6 = lblB.Text;

                            spQtyUnit(IdU, Qty6, NameUnit4, Name6, Category6);
                        }
                        else
                            MessageBox.Show("Не удалось добавить подразделение!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }

                    if (cmbgr5.Text.Length > 0)
                    {
                        //string CategU = cmbgr5.Text;
                        int EventU = Event;
                        //spUnit(Event, CategU);

                        int Iduu = vwIdUnit();

                        if (tbEvP5.Text.Length >= 0 && tbEvB5.Text.Length >= 0 && tbpgr5.Text.Length >= 0 && tbPBgr5.Text.Length >= 0)
                        {
                            int IdU = Iduu;
                            int QtyU = Int32.Parse(tbEvP5.Text);
                            string NameUnit = cmbgr5.Text;
                            string NameU = lblEvent.Text;
                            string CategoryU = lblP.Text;

                            spQtyUnit(IdU, QtyU, NameUnit, NameU, CategoryU);

                            int Qty1 = Int32.Parse(tbEvB5.Text);
                            string NameUnit1 = cmbgr5.Text;
                            string Name1 = lblEvent.Text;
                            string Category1 = lblB.Text;

                            spQtyUnit(IdU, Qty1, NameUnit1, Name1, Category1);

                            int Qty2 = Int32.Parse(tbpgr5.Text);
                            string NameUnit2 = cmbgr5.Text;
                            string Name2 = lblPeople.Text;
                            string Category2 = lblP.Text;

                            spQtyUnit(IdU, Qty2, NameUnit2, Name2, Category2);

                            int Qty3 = Int32.Parse(tbPBgr5.Text);
                            string NameUnit3 = cmbgr5.Text;
                            string Name3 = lblPeople.Text;
                            string Category3 = lblB.Text;

                            spQtyUnit(IdU, Qty3, NameUnit3, Name3, Category3);

                            int Qty6 = Int32.Parse(tbPlayer5.Text);
                            string NameUnit4 = cmbgr5.Text;
                            string Name6 = lblParticial.Text;
                            string Category6 = lblB.Text;

                            spQtyUnit(IdU, Qty6, NameUnit4, Name6, Category6);
                        }
                        else
                            MessageBox.Show("Не удалось добавить подразделение!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    MessageBox.Show(" Mероприятие добавлено!");                   
                }
                catch (Exception)
                {
                    MessageBox.Show("Не удалось добавить мероприятие!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                ClearTB();
            }
            else
                MessageBox.Show("Заполните название мероприятия или выберите статус!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Information);

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

        public void spQtyUnit(int Id, int Qty,string NameUnit, string Name, string Categ)
        {
            ConnectSDO sdo = new ConnectSDO();
            SqlCommand sqlcom2 = new SqlCommand("spAddAssignQty", sdo.getConnectSDO());
            sqlcom2.CommandType = CommandType.StoredProcedure;
            sqlcom2.Parameters.AddWithValue("@IdU", SqlDbType.Int).Value = Id;
            sqlcom2.Parameters.AddWithValue("@Name", SqlDbType.NVarChar).Value = Name;
            sqlcom2.Parameters.AddWithValue("@NameUnit", SqlDbType.NVarChar).Value = NameUnit;
            sqlcom2.Parameters.AddWithValue("@Qty", SqlDbType.Int).Value = Qty;
            sqlcom2.Parameters.AddWithValue("@Category", SqlDbType.NVarChar).Value = Categ;
            sdo.OpenConnection();
            sqlcom2.ExecuteNonQuery();
            sdo.CloseConnection();
        }

        public void ClearTB()
        {
            tbNameEvent.Clear();
            cmbStatusEvent.Text = "";
            cmbStatusQtyEvent1.Text = "";
            cmbgr1.Text = "";
            cmbgr2.Text = "";
            cmbgr3.Text = "";
            cmbgr4.Text = "";
            cmbgr5.Text = "";
            tbEventAll.Text = "";
            tbUnitAll.Text = "";
            tbEventAllP.Text = "0";
            tbEventAllB.Text = "0";
            tbUnitAllP.Text = "0";
            tbUnitAllB.Text = "0";
            tbEvP1.Text = "";
            tbEvP2.Text = "";
            tbEvP3.Text = "";
            tbEvP4.Text = "";
            tbEvP5.Text = "";
            tbEvB1.Text = "";
            tbEvB2.Text = "";
            tbEvB3.Text = "";
            tbEvB4.Text = "";
            tbEvB5.Text = "";
            tbpgr1.Text = "";
            tbpgr2.Text = "";
            tbpgr3.Text = "";
            tbpgr4.Text = "";
            tbpgr5.Text = "";
            tbPBgr1.Text = "";
            tbPBgr2.Text = "";
            tbPBgr3.Text = "";
            tbPBgr4.Text = "";
            tbPBgr5.Text = "";
            tbPlayer1.Text = "";
            tbPlayer2.Text = "";
            tbPlayer3.Text = "";
            tbPlayer4.Text = "";
            tbPlayer5.Text = "";
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            ClearTB();
        }

        public void cmbInd()
        {
            if (cmbStatusQtyEvent1.Text == "Массовое")
            {
                cmbgr2.Text = null;
                cmbgr3.Text = null;
                cmbgr4.Text = null;
                cmbgr5.Text = null;
                cmbgr2.Enabled = false;
                cmbgr3.Enabled = false;
                cmbgr4.Enabled = false;
                cmbgr5.Enabled = false;

                tbEvP2.Enabled = false;
                tbEvP3.Enabled = false;
                tbEvP4.Enabled = false;
                tbEvP5.Enabled = false;

                tbEvB2.Enabled = false;
                tbEvB3.Enabled = false;
                tbEvB4.Enabled = false;
                tbEvB5.Enabled = false;

                tbpgr2.Enabled = false;
                tbpgr3.Enabled = false;
                tbpgr4.Enabled = false;
                tbpgr5.Enabled = false;

                tbPBgr2.Enabled = false;
                tbPBgr3.Enabled = false;
                tbPBgr4.Enabled = false;
                tbPBgr5.Enabled = false;

                tbPlayer2.Enabled = false;
                tbPlayer3.Enabled = false;
                tbPlayer4.Enabled = false;
                tbPlayer5.Enabled = false;

                cmbgr1.Text = "Масса";
            }
            else
                IndOn();
        }

        private void cmbStatusQtyEvent1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //cmbInd();
        }

        public void IndOn()
        {
            cmbgr2.Enabled = true;
            cmbgr3.Enabled = true;
            cmbgr4.Enabled = true;
            cmbgr5.Enabled = true;

            tbEvP2.Enabled = true;
            tbEvP3.Enabled = true;
            tbEvP4.Enabled = true;
            tbEvP5.Enabled = true;

            tbEvB2.Enabled = true;
            tbEvB3.Enabled = true;
            tbEvB4.Enabled = true;
            tbEvB5.Enabled = true;

            tbpgr2.Enabled = true;
            tbpgr3.Enabled = true;
            tbpgr4.Enabled = true;
            tbpgr5.Enabled = true;

            tbPBgr2.Enabled = true;
            tbPBgr3.Enabled = true;
            tbPBgr4.Enabled = true;
            tbPBgr5.Enabled = true;

            tbPlayer2.Enabled = true;
            tbPlayer3.Enabled = true;
            tbPlayer4.Enabled = true;
            tbPlayer5.Enabled = true;

            cmbgr1.Text = null;
        }

        public void sumTBPlP()
        {
            if (tbPlayer1.Text != "")
            {
                int a = Convert.ToInt32(tbPlayer1.Text);
                int s1 = a + 0;
                tbAllPlayer.Text = Convert.ToString(s1);
            }

            if (tbPlayer1.Text.Length > 0 && tbPlayer2.Text.Length > 0 && tbPlayer3.Text.Length > 0 && tbPlayer4.Text.Length > 0 && tbPlayer5.Text.Length > 0)
            {
                int a = Convert.ToInt32(tbPlayer1.Text);
                int b = Convert.ToInt32(tbPlayer2.Text);
                int c = Convert.ToInt32(tbPlayer3.Text);
                int d = Convert.ToInt32(tbPlayer4.Text);
                int f = Convert.ToInt32(tbPlayer5.Text);
                int s = a + b + c + d + f;
                tbAllPlayer.Text = Convert.ToString(s);
            }
            else
                return;
        }

        private void tbPlayer1_TextChanged(object sender, EventArgs e)
        {
            sumTBPlP();
        }

        private void tbPlayer2_TextChanged(object sender, EventArgs e)
        {
            sumTBPlP();
        }

        private void tbPlayer3_TextChanged(object sender, EventArgs e)
        {
            sumTBPlP();
        }

        private void tbPlayer4_TextChanged(object sender, EventArgs e)
        {
            sumTBPlP();
        }

        private void tbPlayer5_TextChanged(object sender, EventArgs e)
        {
            sumTBPlP();
        }

        private void tbPlayer1_KeyPress(object sender, KeyPressEventArgs e)
        {
            ekeyTB(e);
        }

        private void tbPlayer2_KeyPress(object sender, KeyPressEventArgs e)
        {
            ekeyTB(e);
        }

        private void tbPlayer3_KeyPress(object sender, KeyPressEventArgs e)
        {
            ekeyTB(e);
        }

        private void tbPlayer4_KeyPress(object sender, KeyPressEventArgs e)
        {
            ekeyTB(e);
        }

        private void tbPlayer5_KeyPress(object sender, KeyPressEventArgs e)
        {
            ekeyTB(e);
        }
    }
}
