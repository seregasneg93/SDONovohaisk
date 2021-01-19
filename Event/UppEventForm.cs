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
    public partial class UppEventForm : Form
    {
        SqlDataAdapter adapter;
        DataTable datTab;
        SqlCommand sqlcom;
        int Ide;
        string Namee, Statuse, Namee2;
        DateTime datef;
        int[] Eventunit1, Eventqty1,Eventunitq2;
        int[] Eventunit2;
        string[] Namee3;
        public UppEventForm(int IdE,string NameE,string StatusE,DateTime DateF,string NameCateg, int[] EventIdUnit, int[] EventIdQty, int[] EventIdQty2, int[] EventQty2, string[] NameE3)
        {
            InitializeComponent();
            Ide = IdE;
            Namee = NameE;
            Statuse = StatusE;
            datef = DateF;
            Namee2 = NameCateg; 
           Eventunit1 = EventIdUnit;
            Eventqty1 = EventIdQty;
            Eventunit2 = EventIdQty2;
            Eventunitq2 = EventQty2;
            Namee3 = NameE3;
        }

        private void UppEventForm_Load(object sender, EventArgs e)
        {
            assignTB(Ide, Namee, Statuse, datef, Namee2, Eventunit1, Eventqty1, Eventunit2, Eventunitq2, Namee3);
        }

        public void assignTB(int IdE, string NameE, string StatusE, DateTime DateF, string NameCateg, int[] EventIdUnit, int[] EventIdQty, int[] EventIdQty2, int[] EventQty2, string[] NameE3)
        {
            tbIdE.Text = Convert.ToString(IdE);
            tbNameEvent.Text = NameE;
            cmbStatusEvent.Text = StatusE;
            mcEvent.SetDate(DateF);
            cmbStatusQtyEvent1.Text = NameCateg;

            if (NameE3.Length == 5)
            {
                cmbgr1.Text = NameE3[0];
                tbEvP1.Text = EventQty2[0].ToString();
                tbEvB1.Text = EventQty2[1].ToString();
                tbpgr1.Text = EventQty2[2].ToString();
                tbPBgr1.Text = EventQty2[3].ToString();
                tbPlayer1.Text = EventQty2[4].ToString();
            }

             if (NameE3.Length == 25)
            {
                cmbgr1.Text = NameE3[0];
                cmbgr2.Text = NameE3[7];
                cmbgr3.Text = NameE3[11];
                cmbgr4.Text = NameE3[17];
                cmbgr5.Text = NameE3[22];

                tbEvP1.Text = EventQty2[0].ToString();
                tbEvB1.Text = EventQty2[1].ToString();
                tbpgr1.Text = EventQty2[2].ToString();
                tbPBgr1.Text = EventQty2[3].ToString();
                tbPlayer1.Text = EventQty2[4].ToString();

                tbEvP2.Text = EventQty2[5].ToString();
                tbEvB2.Text = EventQty2[6].ToString();
                tbpgr2.Text = EventQty2[7].ToString();
                tbPBgr2.Text = EventQty2[8].ToString();
                tbPlayer2.Text = EventQty2[9].ToString();

                tbEvP3.Text = EventQty2[10].ToString();
                tbEvB3.Text = EventQty2[11].ToString();
                tbpgr3.Text = EventQty2[12].ToString();
                tbPBgr3.Text = EventQty2[13].ToString();
                tbPlayer3.Text = EventQty2[14].ToString();

                tbEvP4.Text = EventQty2[15].ToString();
                tbEvB4.Text = EventQty2[16].ToString();
                tbpgr4.Text = EventQty2[17].ToString();
                tbPBgr4.Text = EventQty2[18].ToString();
                tbPlayer4.Text = EventQty2[19].ToString();

                tbEvP5.Text = EventQty2[20].ToString();
                tbEvB5.Text = EventQty2[21].ToString();
                tbpgr5.Text = EventQty2[22].ToString();
                tbPBgr5.Text = EventQty2[23].ToString();
                tbPlayer5.Text = EventQty2[24].ToString();
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Hide();
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
        private void tbEvP1_TextChanged(object sender, EventArgs e)
        {
            SUMTBEventP();
        }

        private void tbEvP2_TextChanged(object sender, EventArgs e)
        {
            SUMTBEventP();
        }

        private void tbEvP3_TextChanged(object sender, EventArgs e)
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

        private void btnSave_Click(object sender, EventArgs e)
        {
            btnOk(Ide,Eventunit1, Eventqty1, Eventunit2);
        }

        public void btnOk(int IdE,int[] EventUnit1, int[] EventQty1, int[] EventQty2)
        {
            if (cmbStatusEvent.Text != "" && cmbgr1.Text != "" && cmbgr2.Text != "" && cmbgr3.Text != "" && cmbgr4.Text != "" && cmbgr5.Text != "")
            {
                try
                {
                    int IdU = EventUnit1[1];

                    int IdQ0 = Convert.ToInt32(EventQty1[0].ToString());
                    int IdQ1 = Convert.ToInt32(EventQty1[1].ToString());
                    int IdQ2 = Convert.ToInt32(EventQty1[2].ToString());
                    int IdQ3 = Convert.ToInt32(EventQty1[3].ToString());
                    int IdQ4 = Convert.ToInt32(EventQty1[4].ToString());

                    int IdQ5 = Convert.ToInt32(EventQty2[0].ToString());
                    int IdQ6 = Convert.ToInt32(EventQty2[1].ToString());
                    int IdQ7 = Convert.ToInt32(EventQty2[2].ToString());
                    int IdQ8 = Convert.ToInt32(EventQty2[3].ToString());
                    int IdQ9 = Convert.ToInt32(EventQty2[4].ToString());

                    int IdQ10 = Convert.ToInt32(EventQty2[5].ToString());
                    int IdQ11 = Convert.ToInt32(EventQty2[6].ToString());
                    int IdQ12 = Convert.ToInt32(EventQty2[7].ToString());
                    int IdQ13 = Convert.ToInt32(EventQty2[8].ToString());
                    int IdQ14 = Convert.ToInt32(EventQty2[9].ToString());

                    int IdQ15 = Convert.ToInt32(EventQty2[10].ToString());
                    int IdQ16 = Convert.ToInt32(EventQty2[11].ToString());
                    int IdQ17 = Convert.ToInt32(EventQty2[12].ToString());
                    int IdQ18 = Convert.ToInt32(EventQty2[13].ToString());
                    int IdQ19 = Convert.ToInt32(EventQty2[14].ToString());

                    int IdQ20 = Convert.ToInt32(EventQty2[15].ToString());
                    int IdQ21 = Convert.ToInt32(EventQty2[16].ToString());
                    int IdQ22 = Convert.ToInt32(EventQty2[17].ToString());
                    int IdQ23 = Convert.ToInt32(EventQty2[18].ToString());
                    int IdQ24 = Convert.ToInt32(EventQty2[19].ToString());

                    int IdQ25 = Convert.ToInt32(EventQty2[20].ToString());
                    int IdQ26 = Convert.ToInt32(EventQty2[21].ToString());
                    int IdQ27 = Convert.ToInt32(EventQty2[22].ToString());
                    int IdQ28 = Convert.ToInt32(EventQty2[23].ToString());
                    int IdQ29 = Convert.ToInt32(EventQty2[24].ToString());


                    if (cmbStatusEvent.Text.Length > 0)
                    {
                        ConnectSDO sdo = new ConnectSDO();
                        sqlcom = new SqlCommand("spUppEventt", sdo.getConnectSDO());
                        sqlcom.CommandType = CommandType.StoredProcedure;
                        sqlcom.Parameters.AddWithValue("@Name", SqlDbType.NVarChar).Value = tbNameEvent.Text.Trim();
                        sqlcom.Parameters.AddWithValue("@Status", SqlDbType.Int).Value = cmbStatusEvent.Text.Trim();
                        sqlcom.Parameters.AddWithValue("@DateFirst", SqlDbType.Int).Value = mcEvent.SelectionRange.Start;
                        sqlcom.Parameters.AddWithValue("@IdE", SqlDbType.Int).Value = IdE;
                        sdo.OpenConnection();
                        sqlcom.ExecuteNonQuery();
                        sdo.CloseConnection();
                    }


                    if (cmbStatusQtyEvent1.Text.Length > 0)
                    {
                        string NameU = cmbStatusQtyEvent1.Text.Trim();
                        int Idu = IdU;
                        int Ide = IdE;
                        spUnit(NameU, Idu, Ide);
                        if (tbEventAllP.Text.Length >= 0)
                        {
                            string Name1 = lblEvent.Text;
                            string NameCateg1 = cmbStatusQtyEvent1.Text.Trim();
                            string NameE1 = lblP.Text;
                            int Qty1 = Int32.Parse(tbEventAllP.Text);
                            int IdU1 = IdU;
                            int Id0 = IdQ0;
                            spQtyUnit(Name1,NameCateg1, NameE1, Qty1, IdU1, Id0);

                            string Name2 = lblEvent.Text;
                            string NameCateg2 = cmbStatusQtyEvent1.Text.Trim();
                            string NameE2 = lblB.Text;
                            int Qty2 = Int32.Parse(tbEventAllB.Text);
                            int IdU2 = IdU;
                            int Id1 = IdQ1;
                            spQtyUnit(Name2, NameCateg2, NameE2, Qty2, IdU2, Id1);

                            string Name3 = lblPeople.Text;
                            string NameCateg3 = cmbStatusQtyEvent1.Text.Trim();
                            string NameE3 = lblP.Text;
                            int Qty3 = Int32.Parse(tbUnitAllP.Text);
                            int IdU3 = IdU;
                            int Id3 = IdQ2;
                            spQtyUnit(Name3, NameCateg3, NameE3, Qty3, IdU3, Id3);

                            string Name4 = lblPeople.Text;
                            string NameCateg4 = cmbStatusQtyEvent1.Text.Trim();
                            string NameE4 = lblB.Text;
                            int Qty4 = Int32.Parse(tbUnitAllB.Text);
                            int IdU4 = IdU;
                            int Id4 = IdQ3;
                            spQtyUnit(Name4, NameCateg4, NameE4, Qty4, IdU4, Id4);

                            string Name5 = lblParticial.Text;
                            string NameCateg5 = cmbStatusQtyEvent1.Text.Trim();
                            string NameE5 = lblB.Text;
                            int Qty5 = Int32.Parse(tbAllPlayer.Text);
                            int IdU5 = IdU;
                            int Id5 = IdQ4;
                            spQtyUnit(Name5, NameCateg5, NameE5, Qty5, IdU5, Id5);
                        }

                    }


                    if (cmbgr1.Text.Length > 0)
                    {
                        //string NameU2 = cmbgr1.Text.Trim();
                        int Idu = IdU;
                        int Ide = IdE;
                        //spUnit(NameU2, IdU, Ide);
                        if (tbEvP1.Text.Length >= 0 && tbEvB1.Text.Length >= 0 && tbpgr1.Text.Length >= 0 && tbPBgr1.Text.Length >= 0)
                        {
                            string Name1 = lblEvent.Text;
                            string NameCateg1 = cmbgr1.Text.Trim();
                            string NameE1 = lblP.Text;
                            int Qty1 = Int32.Parse(tbEvP1.Text);
                            int IdU1 = IdU;
                            int Id1 = IdQ5;
                            spQtyUnit(Name1, NameCateg1, NameE1, Qty1, IdU1, Id1);

                            string Name2 = lblEvent.Text;
                            string NameCateg2 = cmbgr1.Text.Trim();
                            string NameE2 = lblB.Text;
                            int Qty2 = Int32.Parse(tbEvB1.Text);
                            int IdU2 = IdU;
                            int Id2 = IdQ6;
                            spQtyUnit(Name2, NameCateg2, NameE2, Qty2, IdU2, Id2);

                            string Name3 = lblPeople.Text;
                            string NameCateg3 = cmbgr1.Text.Trim();
                            string NameE3 = lblP.Text;
                            int Qty3 = Int32.Parse(tbpgr1.Text);
                            int IdU3 = IdU;
                            int Id3 = IdQ7;
                            spQtyUnit(Name3, NameCateg3, NameE3, Qty3, IdU3, Id3);

                            string Name4 = lblPeople.Text;
                            string NameCateg4 = cmbgr1.Text.Trim();
                            string NameE4 = lblB.Text;
                            int Qty4 = Int32.Parse(tbPBgr1.Text);
                            int IdU4 = IdU;
                            int Id4 = IdQ8;
                            spQtyUnit(Name4, NameCateg4, NameE4, Qty4, IdU4, Id4);

                            string Name5 = lblParticial.Text;
                            string NameCateg5 = cmbgr1.Text.Trim();
                            string NameE5 = lblB.Text;
                            int Qty5 = Int32.Parse(tbPlayer1.Text);
                            int IdU5 = IdU;
                            int Id5 = IdQ9;
                            spQtyUnit(Name5, NameCateg5, NameE5, Qty5, IdU5, Id5);
                        }
                    }


                    if (cmbgr2.Text.Length > 0)
                    {
                        //string NameU3 = cmbgr2.Text.Trim();
                        int Idu = IdU;
                        int Ide = IdE;
                        //spUnit(NameU3, IdU, Ide);
                        if (tbEvP2.Text.Length >= 0 && tbEvB2.Text.Length >= 0 && tbpgr2.Text.Length >= 0 && tbPBgr2.Text.Length >= 0)
                        {
                            string Name1 = lblEvent.Text;
                            string NameCateg1 = cmbgr2.Text.Trim();
                            string NameE1 = lblP.Text;
                            int Qty1 = Int32.Parse(tbEvP2.Text);
                            int IdU1 = IdU;
                            int Id1 = IdQ10;
                            spQtyUnit(Name1, NameCateg1, NameE1, Qty1, IdU1, Id1);

                            string Name2 = lblEvent.Text;
                            string NameCateg2 = cmbgr2.Text.Trim();
                            string NameE2 = lblB.Text;
                            int Qty2 = Int32.Parse(tbEvB2.Text);
                            int IdU2 = IdU;
                            int Id2 = IdQ11;
                            spQtyUnit(Name2, NameCateg2, NameE2, Qty2, IdU2, Id2);

                            string Name3 = lblPeople.Text;
                            string NameCateg3 = cmbgr2.Text.Trim();
                            string NameE3 = lblP.Text;
                            int Qty3 = Int32.Parse(tbpgr2.Text);
                            int IdU3 = IdU;
                            int Id3 = IdQ12;
                            spQtyUnit(Name3, NameCateg3, NameE3, Qty3, IdU3, Id3);

                            string Name4 = lblPeople.Text;
                            string NameCateg4 = cmbgr2.Text.Trim();
                            string NameE4 = lblB.Text;
                            int Qty4 = Int32.Parse(tbPBgr2.Text);
                            int IdU4 = IdU;
                            int Id4 = IdQ13;
                            spQtyUnit(Name4, NameCateg4, NameE4, Qty4, IdU4, Id4);

                            string Name5 = lblParticial.Text;
                            string NameCateg5 = cmbgr2.Text.Trim();
                            string NameE5 = lblB.Text;
                            int Qty5 = Int32.Parse(tbPlayer2.Text);
                            int IdU5 = IdU;
                            int Id5 = IdQ14;
                            spQtyUnit(Name5, NameCateg5, NameE5, Qty5, IdU5, Id5);
                        }
                    }



                    if (cmbgr3.Text.Length > 0)
                    {
                        //string NameU4 = cmbgr3.Text.Trim();
                        int Idu = IdU;
                        int Ide = IdE;
                        //spUnit(NameU4, IdU, Ide);
                        if (tbEvP3.Text.Length >= 0 && tbEvB3.Text.Length >= 0 && tbpgr3.Text.Length >= 0 && tbPBgr3.Text.Length >= 0)
                        {
                            string Name1 = lblEvent.Text;
                            string NameCateg1 = cmbgr3.Text.Trim();
                            string NameE1 = lblP.Text;
                            int Qty1 = Int32.Parse(tbEvP3.Text);
                            int IdU1 = IdU;
                            int Id1 = IdQ15;
                            spQtyUnit(Name1, NameCateg1, NameE1, Qty1, IdU1, Id1);

                            string Name2 = lblEvent.Text;
                            string NameCateg2 = cmbgr3.Text.Trim();
                            string NameE2 = lblB.Text;
                            int Qty2 = Int32.Parse(tbEvB3.Text);
                            int IdU2 = IdU;
                            int Id2 = IdQ16;
                            spQtyUnit(Name2, NameCateg2, NameE2, Qty2, IdU2, Id2);

                            string Name3 = lblPeople.Text;
                            string NameCateg3 = cmbgr3.Text.Trim();
                            string NameE3 = lblP.Text;
                            int Qty3 = Int32.Parse(tbpgr3.Text);
                            int IdU3 = IdU;
                            int Id3 = IdQ17;
                            spQtyUnit(Name3, NameCateg3, NameE3, Qty3, IdU3, Id3);

                            string Name4 = lblPeople.Text;
                            string NameCateg4 = cmbgr3.Text.Trim();
                            string NameE4 = lblB.Text;
                            int Qty4 = Int32.Parse(tbPBgr3.Text);
                            int IdU4 = IdU;
                            int Id4 = IdQ18;
                            spQtyUnit(Name4, NameCateg4, NameE4, Qty4, IdU4, Id4);

                            string Name5 = lblParticial.Text;
                            string NameCateg5 = cmbgr3.Text.Trim();
                            string NameE5 = lblB.Text;
                            int Qty5 = Int32.Parse(tbPlayer3.Text);
                            int IdU5 = IdU;
                            int Id5 = IdQ19;
                            spQtyUnit(Name5, NameCateg5, NameE5, Qty5, IdU5, Id5);
                        }
                    }


                    if (cmbgr4.Text.Length > 0)
                    {
                        //string NameU5 = cmbgr4.Text.Trim();
                        int Idu = IdU;
                        int Ide = IdE;
                        //spUnit(NameU5, IdU, Ide);
                        if (tbEvP4.Text.Length >= 0 && tbEvB4.Text.Length >= 0 && tbpgr4.Text.Length >= 0 && tbPBgr4.Text.Length >= 0)
                        {
                            string Name1 = lblEvent.Text;
                            string NameCateg1 = cmbgr4.Text.Trim();
                            string NameE1 = lblP.Text;
                            int Qty1 = Int32.Parse(tbEvP4.Text);
                            int IdU1 = IdU;
                            int Id1 = IdQ20;
                            spQtyUnit(Name1, NameCateg1, NameE1, Qty1, IdU1, Id1);

                            string Name2 = lblEvent.Text;
                            string NameCateg2 = cmbgr4.Text.Trim();
                            string NameE2 = lblB.Text;
                            int Qty2 = Int32.Parse(tbEvB4.Text);
                            int IdU2 = IdU;
                            int Id2 = IdQ21;
                            spQtyUnit(Name2, NameCateg2, NameE2, Qty2, IdU2, Id2);

                            string Name3 = lblPeople.Text;
                            string NameCateg3 = cmbgr4.Text.Trim();
                            string NameE3 = lblP.Text;
                            int Qty3 = Int32.Parse(tbpgr4.Text);
                            int IdU3 = IdU;
                            int Id3 = IdQ22;
                            spQtyUnit(Name3, NameCateg3, NameE3, Qty3, IdU3, Id3);

                            string Name4 = lblPeople.Text;
                            string NameCateg4 = cmbgr4.Text.Trim();
                            string NameE4 = lblB.Text;
                            int Qty4 = Int32.Parse(tbPBgr4.Text);
                            int IdU4 = IdU;
                            int Id4 = IdQ23;
                            spQtyUnit(Name4, NameCateg4, NameE4, Qty4, IdU4, Id4);

                            string Name5 = lblParticial.Text;
                            string NameCateg5 = cmbgr4.Text.Trim();
                            string NameE5 = lblB.Text;
                            int Qty5 = Int32.Parse(tbPlayer4.Text);
                            int IdU5 = IdU;
                            int Id5 = IdQ24;
                            spQtyUnit(Name5, NameCateg5, NameE5, Qty5, IdU5, Id5);
                        }
                    }

                    if (cmbgr5.Text.Length > 0)
                    {
                        //string NameU5 = cmbgr5.Text.Trim();
                        int Idu = IdU;
                        int Ide = IdE;
                        //spUnit(NameU5, IdU, Ide);
                        if (tbEvP5.Text.Length >= 0 && tbEvB5.Text.Length >= 0 && tbpgr5.Text.Length >= 0 && tbPBgr5.Text.Length >= 0)
                        {
                            string Name1 = lblEvent.Text;
                            string NameCateg1 = cmbgr5.Text.Trim();
                            string NameE1 = lblP.Text;
                            int Qty1 = Int32.Parse(tbEvP5.Text);
                            int IdU1 = IdU;
                            int Id1 = IdQ25;
                            spQtyUnit(Name1, NameCateg1, NameE1, Qty1, IdU1, Id1);

                            string Name2 = lblEvent.Text;
                            string NameCateg2 = cmbgr5.Text.Trim();
                            string NameE2 = lblB.Text;
                            int Qty2 = Int32.Parse(tbEvB5.Text);
                            int IdU2 = IdU;
                            int Id2 = IdQ26;
                            spQtyUnit(Name2, NameCateg2, NameE2, Qty2, IdU2, Id2);

                            string Name3 = lblPeople.Text;
                            string NameCateg3 = cmbgr5.Text.Trim();
                            string NameE3 = lblP.Text;
                            int Qty3 = Int32.Parse(tbpgr5.Text);
                            int IdU3 = IdU;
                            int Id3 = IdQ27;
                            spQtyUnit(Name3, NameCateg3, NameE3, Qty3, IdU3, Id3);

                            string Name4 = lblPeople.Text;
                            string NameCateg4 = cmbgr5.Text.Trim();
                            string NameE4 = lblB.Text;
                            int Qty4 = Int32.Parse(tbPBgr5.Text);
                            int IdU4 = IdU;
                            int Id4 = IdQ28;
                            spQtyUnit(Name4, NameCateg4, NameE4, Qty4, IdU4, Id4);

                            string Name5 = lblParticial.Text;
                            string NameCateg5 = cmbgr5.Text.Trim();
                            string NameE5 = lblB.Text;
                            int Qty5 = Int32.Parse(tbPlayer5.Text);
                            int IdU5 = IdU;
                            int Id5 = IdQ29;
                            spQtyUnit(Name5, NameCateg5, NameE5, Qty5, IdU5, Id5);
                        }
                    }

                    MessageBox.Show("Mероприятие изменено!");
                    this.Hide();
                }
                catch (Exception)
                {
                    MessageBox.Show("Не удалось обновить данные!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
                MessageBox.Show("Заполните все поля!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            assignTB(Ide, Namee, Statuse, datef, Namee2, Eventunit1, Eventqty1, Eventunit2, Eventunitq2, Namee3);
        }

        public void spUnit(string Name, int IdE, int IdU)
        {
            ConnectSDO sdo = new ConnectSDO();
            SqlCommand sqlcom2 = new SqlCommand("spUppYearUnit", sdo.getConnectSDO());
            sqlcom2.CommandType = CommandType.StoredProcedure;
            sqlcom2.Parameters.AddWithValue("@Category", SqlDbType.NVarChar).Value = Name;
            sqlcom2.Parameters.AddWithValue("@IdU", SqlDbType.Int).Value = IdE;
            sqlcom2.Parameters.AddWithValue("@IdE", SqlDbType.Int).Value = IdU;
            sdo.OpenConnection();
            sqlcom2.ExecuteNonQuery();
            sdo.CloseConnection();
        }
        public void spQtyUnit(string Name,string NameCateg, string Categ, int Qty, int IdU, int IdQ)
        {
            ConnectSDO sdo = new ConnectSDO();
            SqlCommand sqlcom2 = new SqlCommand("spUppAssignQty", sdo.getConnectSDO());
            sqlcom2.CommandType = CommandType.StoredProcedure;
            sqlcom2.Parameters.AddWithValue("@IdU", SqlDbType.Int).Value = IdU;
            sqlcom2.Parameters.AddWithValue("@IdQ", SqlDbType.Int).Value = IdQ;
            sqlcom2.Parameters.AddWithValue("@Name", SqlDbType.NVarChar).Value = Name;
            sqlcom2.Parameters.AddWithValue("@NameUnit", SqlDbType.NVarChar).Value = NameCateg;
            sqlcom2.Parameters.AddWithValue("@Qty", SqlDbType.Int).Value = Qty;
            sqlcom2.Parameters.AddWithValue("@Category", SqlDbType.NVarChar).Value = Categ;
            sdo.OpenConnection();
            sqlcom2.ExecuteNonQuery();
            sdo.CloseConnection();
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
    }
}
