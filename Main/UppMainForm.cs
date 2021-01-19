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
    public partial class UppMainForm : Form
    {
        int Idyp, Ide;
        string Namee, Statuse;
        string[] ArrayUnit3;
        int[] ArrayQtyU, ArrayQtyU2, ArrayQtyU3, ArrayUnit, ArrayUnit2,ArrayUnit4;
        DateTime dataf,datae;
        SqlDataAdapter adapter;
        DataTable datTab;
        SqlCommand sqlcom;
        public UppMainForm(int IdYP, int IdE, string NameE, string StatusE, int[] UnitArray, int[] UnitArray2, string[] UnitArray3, int[] UnitArray4, int[] UnitArrayQtyU, int[] UnitArrayQtyU2, int[] UnitArrayQtyU3, DateTime dateF, DateTime dateE)
        {
            InitializeComponent();
            Idyp = IdYP;
            Ide = IdE;
            ArrayUnit = UnitArray; 
            ArrayUnit2 = UnitArray2;
            ArrayUnit3 = UnitArray3;
            ArrayUnit4 = UnitArray4;
            ArrayQtyU = UnitArrayQtyU;
            ArrayQtyU2 = UnitArrayQtyU2;
            ArrayQtyU3 = UnitArrayQtyU3;
            Namee = NameE;
            Statuse = StatusE;
            dataf = dateF;
            datae = dateE;
        }

        private void UppMainForm_Load(object sender, EventArgs e)
        {
            assignTB(Idyp, Ide,Namee, ArrayUnit, ArrayUnit2, ArrayUnit3, ArrayUnit4, ArrayQtyU, ArrayQtyU2, ArrayQtyU3, Statuse, dataf, datae);
            vwId(ArrayQtyU, ArrayQtyU2, ArrayUnit, ArrayUnit2);
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Hide();
            MainForm m = new MainForm();
            m.Show();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Hide();
            MainForm m = new MainForm();
            m.Show();
        }

        public void ekeyTB(KeyPressEventArgs e)
        {
            if ((e.KeyChar <= 47 || e.KeyChar >= 58) && e.KeyChar != 8)
                e.Handled = true;
        }
        public void ClearTB()
        {
            //tbEvent.Clear();
            //tbEventB.Text = "0";
            //tbEventP.Text = "0";
            //tbQtyE.Text = "0";
            //tbEventAll.Text = "0";
            //tbQtyPeople.Text = "0";
            //tbTick.Text = "0";
            //tbTickB.Text = "0";
            //tbTickP.Text = "0";
            //tbAllTick.Text = "0";
        }

        public void assignTB(int IdYP, int IdE,string NameE, int[] UnitArray, int[] UnitArray2, string[] UnitArray3, int[] UnitArray4, int[] UnitArrayQty, int[] UnitArrayQty2, int[] UnitArrayQty3, string StatusE, DateTime dateF, DateTime dateE)
        {
            tbIdYP.Text = Convert.ToString(IdYP);
            tbIdE.Text = Convert.ToString(IdE);
            tbEvent.Text = NameE;
            cmbStatusEvent.Text = StatusE;

            cmbgr1.Text = UnitArray3[0].ToString();
            cmbgr1.Text = cmbgr1.Items[0].ToString();
            tbEvP1.Text = UnitArray4[0].ToString();
            tbEvB1.Text = UnitArray4[1].ToString();
            tbpgr1.Text = UnitArray4[2].ToString();
            tbPBgr1.Text = UnitArray4[3].ToString();

            cmbgr2.Text = UnitArray3[1].ToString();
            cmbgr2.Text = cmbgr2.Items[1].ToString();
            tbEvP2.Text = UnitArray4[4].ToString();
            tbEvB2.Text = UnitArray4[5].ToString();
            tbpgr2.Text = UnitArray4[6].ToString();
            tbPBgr2.Text = UnitArray4[7].ToString();

            cmbgr3.Text = UnitArray3[2].ToString();
            cmbgr3.Text = cmbgr2.Items[2].ToString();
            tbEvP3.Text = UnitArray4[8].ToString();
            tbEvB3.Text = UnitArray4[9].ToString();
            tbpgr3.Text = UnitArray4[10].ToString();
            tbPBgr3.Text = UnitArray4[11].ToString();

            cmbgr4.Text = UnitArray3[3].ToString();
            cmbgr4.Text = cmbgr2.Items[3].ToString();
            tbEvP4.Text = UnitArray4[12].ToString();
            tbEvB4.Text = UnitArray4[13].ToString();
            tbpgr4.Text = UnitArray4[14].ToString();
            tbPBgr4.Text = UnitArray4[15].ToString();

            cmbGR21.Text = UnitArray3[0].ToString();
            cmbGR21.Text = cmbGR21.Items[0].ToString();
            tbEventP21.Text = UnitArray4[16].ToString();
            tbEventB21.Text = UnitArray4[17].ToString();
            tbPgr21.Text = UnitArray4[18].ToString();
            tbPBgr21.Text = UnitArray4[19].ToString();

            cmbGR22.Text = UnitArray3[1].ToString();
            cmbGR22.Text = cmbGR22.Items[1].ToString();
            tbEventP22.Text = UnitArray4[20].ToString();
            tbEventB22.Text = UnitArray4[21].ToString();
            tbPgr22.Text = UnitArray4[22].ToString();
            tbPBgr22.Text = UnitArray4[23].ToString();

            cmbGR23.Text = UnitArray3[2].ToString();
            cmbGR23.Text = cmbGR23.Items[2].ToString();
            tbEventP23.Text = UnitArray4[24].ToString();
            tbEventB23.Text = UnitArray4[25].ToString();
            tbPgr23.Text = UnitArray4[26].ToString();
            tbPBgr23.Text = UnitArray4[27].ToString();

            cmbGR24.Text = UnitArray3[3].ToString();
            cmbGR24.Text = cmbGR24.Items[3].ToString();
            tbEventP24.Text = UnitArray4[28].ToString();
            tbEventB24.Text = UnitArray4[29].ToString();
            tbPgr24.Text = UnitArray4[30].ToString();
            tbPBgr24.Text = UnitArray4[31].ToString();

            cmbStatusQtyEvent1.Text = cmbStatusQtyEvent1.Items[0].ToString();
            cmbStatusQtyEventt2.Text = cmbStatusQtyEventt2.Items[0].ToString();
            mcDataEvent.SetDate(dateF);
            mcEndEvent.SetDate(dateE);

            sumTBEP1();
            sumTBEB1();
            sumTBEP2();
            sumTBEB2();
            sumTBPP1();
            sumTBPB1();
            sumTBPP2();
            sumTBPB2();
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

        public void sumTBPP2()
        {
            if (tbPgr21.Text.Length > 0 && tbPgr22.Text.Length > 0 && tbPgr23.Text.Length > 0 && tbPgr24.Text.Length > 0)
            {
                int a = Convert.ToInt32(tbPgr21.Text);
                int b = Convert.ToInt32(tbPgr22.Text);
                int c = Convert.ToInt32(tbPgr23.Text);
                int d = Convert.ToInt32(tbPgr24.Text);
                int s = a + b + c + d;
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

        private void tbPgr24_KeyPress(object sender, KeyPressEventArgs e)
        {
            ekeyTB(e);
        }

        private void tbPgr23_KeyPress(object sender, KeyPressEventArgs e)
        {
            ekeyTB(e);
        }

        private void tbPgr22_KeyPress(object sender, KeyPressEventArgs e)
        {
            ekeyTB(e);
        }

        private void tbPgr21_KeyPress(object sender, KeyPressEventArgs e)
        {
            ekeyTB(e);
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

        private void tbPBgr24_KeyPress(object sender, KeyPressEventArgs e)
        {
            ekeyTB(e);
        }

        private void tbPBgr23_KeyPress(object sender, KeyPressEventArgs e)
        {
            ekeyTB(e);
        }

        private void tbPBgr22_KeyPress(object sender, KeyPressEventArgs e)
        {
            ekeyTB(e);
        }

        private void tbPBgr21_KeyPress(object sender, KeyPressEventArgs e)
        {
            ekeyTB(e);
        }

        private void tbgr24_KeyPress(object sender, KeyPressEventArgs e)
        {
            ekeyTB(e);
        }

        private void tbgr23_KeyPress(object sender, KeyPressEventArgs e)
        {
            ekeyTB(e);
        }

        private void tbgr22_KeyPress(object sender, KeyPressEventArgs e)
        {
            ekeyTB(e);
        }

        private void tbgr21_KeyPress(object sender, KeyPressEventArgs e)
        {
            ekeyTB(e);
        }

        private void tbTickB24_KeyPress(object sender, KeyPressEventArgs e)
        {
            ekeyTB(e);
        }

        private void tbTickB23_KeyPress(object sender, KeyPressEventArgs e)
        {
            ekeyTB(e);
        }

        private void tbTickB22_KeyPress(object sender, KeyPressEventArgs e)
        {
            ekeyTB(e);
        }

        private void tbTickB21_KeyPress(object sender, KeyPressEventArgs e)
        {
            ekeyTB(e);
        }

        private void tbEvP4_TextChanged(object sender, EventArgs e)
        {
            sumTBEP1();
        }

        private void UppMainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Hide();
            MainForm m = new MainForm();
            m.Show();
        }

        private void btnCancel_Click_1(object sender, EventArgs e)
        {
            assignTB(Idyp, Ide, Namee, ArrayUnit, ArrayUnit2, ArrayUnit3, ArrayUnit4, ArrayQtyU, ArrayQtyU2, ArrayQtyU3, Statuse, dataf, datae);
        }

        private void tbpgr2_TextChanged(object sender, EventArgs e)
        {
            sumTBPP1();
        }

        private void tbpgr3_TextChanged(object sender, EventArgs e)
        {
            sumTBPP1();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            btnOk_(ArrayQtyU, ArrayQtyU2, ArrayUnit, ArrayUnit2);
        }

        public void btnOk_(int[] UnitArrayQty, int[] UnitArrayQty2, int[] UnitArray, int[] UnitArray2)
        {
            if (Int32.Parse(tbEventSUM.Text) > 0 && Int32.Parse(tbUnitSUM.Text) > 0)
            {
                try
                {
                    int CatIP = Convert.ToInt32(UnitArrayQty[1].ToString());
                    int CatIP1 = Convert.ToInt32(UnitArrayQty2[0].ToString());
                    int CatIP2 = Convert.ToInt32(UnitArrayQty2[1].ToString());
                    int CatIP3 = Convert.ToInt32(UnitArrayQty2[2].ToString());
                    int CatIP4 = Convert.ToInt32(UnitArrayQty2[3].ToString());

                    int CatKD = Convert.ToInt32(UnitArrayQty[6].ToString());
                    int CatKD1 = Convert.ToInt32(UnitArrayQty2[4].ToString());
                    int CatKD2 = Convert.ToInt32(UnitArrayQty2[5].ToString());
                    int CatKD3 = Convert.ToInt32(UnitArrayQty2[6].ToString());
                    int CatKD4 = Convert.ToInt32(UnitArrayQty2[7].ToString());

                    int CatIP4U1 = Convert.ToInt32(UnitArray[0].ToString());
                    int CatIP14Q0 = Convert.ToInt32(UnitArray2[0].ToString());
                    int CatIP14Q1 = Convert.ToInt32(UnitArray2[1].ToString());
                    int CatIP14Q2 = Convert.ToInt32(UnitArray2[2].ToString());
                    int CatIP14Q3 = Convert.ToInt32(UnitArray2[3].ToString());

                    int CatIP4U2 = Convert.ToInt32(UnitArray[5].ToString());
                    int CatIP14Q4 = Convert.ToInt32(UnitArray2[4].ToString());
                    int CatIP14Q5 = Convert.ToInt32(UnitArray2[5].ToString());
                    int CatIP14Q6 = Convert.ToInt32(UnitArray2[6].ToString());
                    int CatIP14Q7 = Convert.ToInt32(UnitArray2[7].ToString());

                    int CatIP4U3 = Convert.ToInt32(UnitArray[9].ToString());
                    int CatIP14Q8 = Convert.ToInt32(UnitArray2[8].ToString());
                    int CatIP14Q9 = Convert.ToInt32(UnitArray2[9].ToString());
                    int CatIP14Q10 = Convert.ToInt32(UnitArray2[10].ToString());
                    int CatIP14Q11 = Convert.ToInt32(UnitArray2[11].ToString());

                    int CatIP4U4 = Convert.ToInt32(UnitArray[14].ToString());
                    int CatIP14Q12 = Convert.ToInt32(UnitArray2[12].ToString());
                    int CatIP14Q13 = Convert.ToInt32(UnitArray2[13].ToString());
                    int CatIP14Q14 = Convert.ToInt32(UnitArray2[14].ToString());
                    int CatIP14Q15 = Convert.ToInt32(UnitArray2[15].ToString());

                    int CatIP4U5 = Convert.ToInt32(UnitArray[17].ToString());
                    int CatIP14Q16 = Convert.ToInt32(UnitArray2[16].ToString());
                    int CatIP14Q17 = Convert.ToInt32(UnitArray2[17].ToString());
                    int CatIP14Q18 = Convert.ToInt32(UnitArray2[18].ToString());
                    int CatIP14Q19 = Convert.ToInt32(UnitArray2[19].ToString());

                    int CatIP4U6 = Convert.ToInt32(UnitArray[22].ToString());
                    int CatIP14Q20 = Convert.ToInt32(UnitArray2[20].ToString());
                    int CatIP14Q21 = Convert.ToInt32(UnitArray2[21].ToString());
                    int CatIP14Q22 = Convert.ToInt32(UnitArray2[22].ToString());
                    int CatIP14Q23 = Convert.ToInt32(UnitArray2[23].ToString());

                    int CatIP4U7 = Convert.ToInt32(UnitArray[25].ToString());
                    int CatIP14Q24 = Convert.ToInt32(UnitArray2[24].ToString());
                    int CatIP14Q25 = Convert.ToInt32(UnitArray2[25].ToString());
                    int CatIP14Q26 = Convert.ToInt32(UnitArray2[26].ToString());
                    int CatIP14Q27 = Convert.ToInt32(UnitArray2[27].ToString());

                    int CatIP4U8 = Convert.ToInt32(UnitArray[30].ToString());
                    int CatIP14Q28 = Convert.ToInt32(UnitArray2[28].ToString());
                    int CatIP14Q29 = Convert.ToInt32(UnitArray2[29].ToString());
                    int CatIP14Q30 = Convert.ToInt32(UnitArray2[30].ToString());
                    int CatIP14Q31 = Convert.ToInt32(UnitArray2[31].ToString());


                    if (tbEvent.Text.Length > 0 && cmbStatusEvent.Text.Length > 0)
                    {
                        ConnectSDO sdo = new ConnectSDO();
                        sqlcom = new SqlCommand("spUppYearsEventt", sdo.getConnectSDO());
                        sqlcom.CommandType = CommandType.StoredProcedure;
                        sqlcom.Parameters.AddWithValue("@Name", SqlDbType.NVarChar).Value = tbEvent.Text.Trim();
                        sqlcom.Parameters.AddWithValue("@Status", SqlDbType.Int).Value = cmbStatusEvent.Text.Trim();
                        sqlcom.Parameters.AddWithValue("@DateFirst", SqlDbType.Int).Value = mcDataEvent.SelectionRange.Start;
                        sqlcom.Parameters.AddWithValue("@DataEnd", SqlDbType.Int).Value = mcEndEvent.SelectionRange.Start;
                        sqlcom.Parameters.AddWithValue("@IdY", SqlDbType.Int).Value = Int32.Parse(tbIdYP.Text.Trim());
                        sqlcom.Parameters.AddWithValue("@IdE", SqlDbType.Int).Value = Int32.Parse(tbIdE.Text.Trim());
                        sdo.OpenConnection();
                        sqlcom.ExecuteNonQuery();
                        sdo.CloseConnection();
                    }

                    if (cmbStatusQtyEvent1.Text.Length > 0)
                    {
                        string NameU1 = cmbStatusQtyEvent1.Text.Trim();
                        int IdU = CatIP;
                        int IdE = Convert.ToInt32(tbIdE.Text);
                        spUnit(NameU1, IdU, IdE);
                        if (tbEventAllP.Text.Length >= 0)
                        {
                            string Name1 = lblEvent.Text;
                            string NameE1 = lblP.Text;
                            int Qty1 = Int32.Parse(tbEventAllP.Text);
                            int IdU1 = IdU;
                            int IdQ1 = CatIP1;
                            spQtyUnit(Name1, NameE1, Qty1, IdU1, IdQ1);

                            string Name2 = lblEvent.Text;
                            string NameE2 = lblB.Text;
                            int Qty2 = Int32.Parse(tbEventAllB.Text);
                            int IdU2 = IdU;
                            int IdQ2 = CatIP2;
                            spQtyUnit(Name2, NameE2, Qty2, IdU2, IdQ2);

                            string Name3 = lblPeople.Text;
                            string NameE3 = lblP.Text;
                            int Qty3 = Int32.Parse(tbUnitAllP.Text);
                            int IdU3 = IdU;
                            int IdQ3 = CatIP3;
                            spQtyUnit(Name3, NameE3, Qty3, IdU3, IdQ3);

                            string Name4 = lblPeople.Text;
                            string NameE4 = lblB.Text;
                            int Qty4 = Int32.Parse(tbUnitAllB.Text);
                            int IdU4 = IdU;
                            int IdQ4 = CatIP4;
                            spQtyUnit(Name4, NameE4, Qty4, IdU4, IdQ4);
                        }
                        else
                            MessageBox.Show("Не удалось добавить подразделение!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }

                    if (cmbgr1.Text.Length > 0)
                    {
                        string NameU2 = cmbgr1.Text.Trim();
                        int IdU = CatIP4U1;
                        int IdE = Convert.ToInt32(tbIdE.Text);
                        spUnit(NameU2, IdU, IdE);
                        if (tbEvP1.Text.Length >= 0 && tbEvB1.Text.Length >= 0 && tbpgr1.Text.Length >= 0 && tbPBgr1.Text.Length >= 0)
                        {
                            string Name1 = lblEvent.Text;
                            string NameE1 = lblP.Text;
                            int Qty1 = Int32.Parse(tbEvP1.Text);
                            int IdU1 = IdU;
                            int IdQ1 = CatIP14Q0;
                            spQtyUnit(Name1, NameE1, Qty1, IdU1, IdQ1);

                            string Name2 = lblEvent.Text;
                            string NameE2 = lblB.Text;
                            int Qty2 = Int32.Parse(tbEvB1.Text);
                            int IdU2 = IdU;
                            int IdQ2 = CatIP14Q1;
                            spQtyUnit(Name2, NameE2, Qty2, IdU2, IdQ2);

                            string Name3 = lblPeople.Text;
                            string NameE3 = lblP.Text;
                            int Qty3 = Int32.Parse(tbpgr1.Text);
                            int IdU3 = IdU;
                            int IdQ3 = CatIP14Q2;
                            spQtyUnit(Name3, NameE3, Qty3, IdU3, IdQ3);

                            string Name4 = lblPeople.Text;
                            string NameE4 = lblB.Text;
                            int Qty4 = Int32.Parse(tbPBgr1.Text);
                            int IdU4 = IdU;
                            int IdQ4 = CatIP14Q3;
                            spQtyUnit(Name4, NameE4, Qty4, IdU4, IdQ4);
                        }
                        else
                            MessageBox.Show("Не удалось добавить подразделение!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }

                    if (cmbgr2.Text.Length > 0)
                    {
                        string NameU3 = cmbgr2.Text.Trim();
                        int IdU = CatIP4U2;
                        int IdE = Convert.ToInt32(tbIdE.Text);
                        spUnit(NameU3, IdU, IdE);
                        if (tbEvP2.Text.Length >= 0 && tbEvB2.Text.Length >= 0 && tbpgr2.Text.Length >= 0 && tbPBgr2.Text.Length >= 0)
                        {
                            string Name1 = lblEvent.Text;
                            string NameE1 = lblP.Text;
                            int Qty1 = Int32.Parse(tbEvP2.Text);
                            int IdU1 = IdU;
                            int IdQ1 = CatIP14Q4;
                            spQtyUnit(Name1, NameE1, Qty1, IdU1, IdQ1);

                            string Name2 = lblEvent.Text;
                            string NameE2 = lblB.Text;
                            int Qty2 = Int32.Parse(tbEvB2.Text);
                            int IdU2 = IdU;
                            int IdQ2 = CatIP14Q5;
                            spQtyUnit(Name2, NameE2, Qty2, IdU2, IdQ2);

                            string Name3 = lblPeople.Text;
                            string NameE3 = lblP.Text;
                            int Qty3 = Int32.Parse(tbpgr2.Text);
                            int IdU3 = IdU;
                            int IdQ3 = CatIP14Q6;
                            spQtyUnit(Name3, NameE3, Qty3, IdU3, IdQ3);

                            string Name4 = lblPeople.Text;
                            string NameE4 = lblB.Text;
                            int Qty4 = Int32.Parse(tbPBgr2.Text);
                            int IdU4 = IdU;
                            int IdQ4 = CatIP14Q7;
                            spQtyUnit(Name4, NameE4, Qty4, IdU4, IdQ4);
                        }
                        else
                            MessageBox.Show("Не удалось добавить подразделение!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }

                    if (cmbgr3.Text.Length > 0)
                    {
                        string NameU4 = cmbgr3.Text.Trim();
                        int IdU = CatIP4U3;
                        int IdE = Convert.ToInt32(tbIdE.Text);
                        spUnit(NameU4, IdU, IdE);
                        if (tbEvP3.Text.Length >= 0 && tbEvB3.Text.Length >= 0 && tbpgr3.Text.Length >= 0 && tbPBgr3.Text.Length >=0)
                        {
                            string Name1 = lblEvent.Text;
                            string NameE1 = lblP.Text;
                            int Qty1 = Int32.Parse(tbEvP3.Text);
                            int IdU1 = IdU;
                            int IdQ1 = CatIP14Q8;
                            spQtyUnit(Name1, NameE1, Qty1, IdU1, IdQ1);

                            string Name2 = lblEvent.Text;
                            string NameE2 = lblB.Text;
                            int Qty2 = Int32.Parse(tbEvB3.Text);
                            int IdU2 = IdU;
                            int IdQ2 = CatIP14Q9;
                            spQtyUnit(Name2, NameE2, Qty2, IdU2, IdQ2);

                            string Name3 = lblPeople.Text;
                            string NameE3 = lblP.Text;
                            int Qty3 = Int32.Parse(tbpgr3.Text);
                            int IdU3 = IdU;
                            int IdQ3 = CatIP14Q10;
                            spQtyUnit(Name3, NameE3, Qty3, IdU3, IdQ3);

                            string Name4 = lblPeople.Text;
                            string NameE4 = lblB.Text;
                            int Qty4 = Int32.Parse(tbPBgr3.Text);
                            int IdU4 = IdU;
                            int IdQ4 = CatIP14Q11;
                            spQtyUnit(Name4, NameE4, Qty4, IdU4, IdQ4);

                        }
                        else
                            MessageBox.Show("Не удалось добавить подразделение!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }

                    if (cmbgr4.Text.Length > 0)
                    {
                        string NameU5 = cmbgr4.Text.Trim();
                        int IdU = CatIP4U4;
                        int IdE = Convert.ToInt32(tbIdE.Text);
                        spUnit(NameU5, IdU, IdE);
                        if (tbEvP4.Text.Length >= 0 && tbEvB4.Text.Length >= 0 && tbpgr4.Text.Length >= 0 && tbPBgr4.Text.Length >= 0)
                        {
                            string Name1 = lblEvent.Text;
                            string NameE1 = lblP.Text;
                            int Qty1 = Int32.Parse(tbEvP4.Text);
                            int IdU1 = IdU;
                            int IdQ1 = CatIP14Q12;
                            spQtyUnit(Name1, NameE1, Qty1, IdU1, IdQ1);

                            string Name2 = lblEvent.Text;
                            string NameE2 = lblB.Text;
                            int Qty2 = Int32.Parse(tbEvB4.Text);
                            int IdU2 = IdU;
                            int IdQ2 = CatIP14Q13;
                            spQtyUnit(Name2, NameE2, Qty2, IdU2, IdQ2);

                            string Name3 = lblPeople.Text;
                            string NameE3 = lblP.Text;
                            int Qty3 = Int32.Parse(tbpgr4.Text);
                            int IdU3 = IdU;
                            int IdQ3 = CatIP14Q14;
                            spQtyUnit(Name3, NameE3, Qty3, IdU3, IdQ3);

                            string Name4 = lblPeople.Text;
                            string NameE4 = lblB.Text;
                            int Qty4 = Int32.Parse(tbPBgr4.Text);
                            int IdU4 = IdU;
                            int IdQ4 = CatIP14Q15;
                            spQtyUnit(Name4, NameE4, Qty4, IdU4, IdQ4);
                        }
                        else
                            MessageBox.Show("Не удалось добавить подразделение!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }

                    if (cmbStatusQtyEventt2.Text.Length >= 0)
                    {
                        string NameU6 = cmbStatusQtyEventt2.Text.Trim();
                        int IdU = CatKD;
                        int IdE = Convert.ToInt32(tbIdE.Text);
                        spUnit(NameU6, IdU, IdE);


                        if (tbEventAllP2.Text.Length >= 0)
                        {
                            string Name1 = lblEvent.Text;
                            string NameE1 = lblP.Text;
                            int Qty1 = Int32.Parse(tbEventAllP2.Text);
                            int IdU1 = IdU;
                            int IdQ1 = CatKD1;
                            spQtyUnit(Name1, NameE1, Qty1, IdU1, IdQ1);

                            string Name2 = lblEvent.Text;
                            string NameE2 = lblB.Text;
                            int Qty2 = Int32.Parse(tbEventAllB2.Text);
                            int IdU2 = IdU;
                            int IdQ2 = CatKD2;
                            spQtyUnit(Name2, NameE2, Qty2, IdU2, IdQ2);

                            string Name3 = lblPeople.Text;
                            string NameE3 = lblP.Text;
                            int Qty3 = Int32.Parse(tbUnitAllP2.Text);
                            int IdU3 = IdU;
                            int IdQ3 = CatKD3;
                            spQtyUnit(Name3, NameE3, Qty3, IdU3, IdQ3);

                            string Name4 = lblPeople.Text;
                            string NameE4 = lblB.Text;
                            int Qty4 = Int32.Parse(tbUnitAllB2.Text);
                            int IdU4 = IdU;
                            int IdQ4 = CatKD4;
                            spQtyUnit(Name4, NameE4, Qty4, IdU4, IdQ4);
                        }
                        else
                            MessageBox.Show("Не удалось добавить подразделение!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }

                    if (cmbGR21.Text.Length > 0)
                    {
                        string NameU6 = cmbGR21.Text.Trim();
                        int IdU = CatIP4U5;
                        int IdE = Convert.ToInt32(tbIdE.Text);
                        spUnit(NameU6, IdU, IdE);
                        if (tbEventP21.Text.Length >= 0 && tbEventB21.Text.Length >= 0 && tbPgr21.Text.Length >= 0 && tbPBgr21.Text.Length >= 0)
                        {
                            string Name1 = lblEvent.Text;
                            string NameE1 = lblP.Text;
                            int Qty1 = Int32.Parse(tbEventP21.Text);
                            int IdU1 = IdU;
                            int IdQ1 = CatIP14Q16;
                            spQtyUnit(Name1, NameE1, Qty1, IdU1, IdQ1);

                            string Name2 = lblEvent.Text;
                            string NameE2 = lblB.Text;
                            int Qty2 = Int32.Parse(tbEventB21.Text);
                            int IdU2 = IdU;
                            int IdQ2 = CatIP14Q17;
                            spQtyUnit(Name2, NameE2, Qty2, IdU2, IdQ2);

                            string Name3 = lblPeople.Text;
                            string NameE3 = lblP.Text;
                            int Qty3 = Int32.Parse(tbPgr21.Text);
                            int IdU3 = IdU;
                            int IdQ3 = CatIP14Q18;
                            spQtyUnit(Name3, NameE3, Qty3, IdU3, IdQ3);

                            string Name4 = lblPeople.Text;
                            string NameE4 = lblB.Text;
                            int Qty4 = Int32.Parse(tbPBgr21.Text);
                            int IdU4 = IdU;
                            int IdQ4 = CatIP14Q19;
                            spQtyUnit(Name4, NameE4, Qty4, IdU4, IdQ4);
                        }
                        else
                            MessageBox.Show("Не удалось добавить подразделение!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }

                    if (cmbGR22.Text.Length > 0)
                    {
                        string NameU7 = cmbGR22.Text.Trim();
                        int IdU = CatIP4U6;
                        int IdE = Convert.ToInt32(tbIdE.Text);
                        spUnit(NameU7, IdU, IdE);
                        if (tbEventP22.Text.Length >= 0 && tbEventB22.Text.Length >= 0 && tbPgr22.Text.Length >= 0 && tbPBgr22.Text.Length >= 0)
                        {
                            string Name1 = lblEvent.Text;
                            string NameE1 = lblP.Text;
                            int Qty1 = Int32.Parse(tbEventP22.Text);
                            int IdU1 = IdU;
                            int IdQ1 = CatIP14Q20;
                            spQtyUnit(Name1, NameE1, Qty1, IdU1, IdQ1);

                            string Name2 = lblEvent.Text;
                            string NameE2 = lblB.Text;
                            int Qty2 = Int32.Parse(tbEventB22.Text);
                            int IdU2 = IdU;
                            int IdQ2 = CatIP14Q21;
                            spQtyUnit(Name2, NameE2, Qty2, IdU2, IdQ2);

                            string Name3 = lblPeople.Text;
                            string NameE3 = lblP.Text;
                            int Qty3 = Int32.Parse(tbPgr22.Text);
                            int IdU3 = IdU;
                            int IdQ3 = CatIP14Q22;
                            spQtyUnit(Name3, NameE3, Qty3, IdU3, IdQ3);

                            string Name4 = lblPeople.Text;
                            string NameE4 = lblB.Text;
                            int Qty4 = Int32.Parse(tbPBgr22.Text);
                            int IdU4 = IdU;
                            int IdQ4 = CatIP14Q23;
                            spQtyUnit(Name4, NameE4, Qty4, IdU4, IdQ4);
                        }
                        else
                            MessageBox.Show("Не удалось добавить подразделение!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }

                    if (cmbGR23.Text.Length > 0)
                    {
                        string NameU8 = cmbGR23.Text.Trim();
                        int IdU = CatIP4U7;
                        int IdE = Convert.ToInt32(tbIdE.Text);
                        spUnit(NameU8, IdU, IdE);
                        if (tbEventP23.Text.Length >= 0 && tbEventB23.Text.Length >= 0 && tbPgr23.Text.Length >= 0 && tbPBgr23.Text.Length >= 0)
                        {
                            string Name1 = lblEvent.Text;
                            string NameE1 = lblP.Text;
                            int Qty1 = Int32.Parse(tbEventP23.Text);
                            int IdU1 = IdU;
                            int IdQ1 = CatIP14Q24;
                            spQtyUnit(Name1, NameE1, Qty1, IdU1, IdQ1);

                            string Name2 = lblEvent.Text;
                            string NameE2 = lblB.Text;
                            int Qty2 = Int32.Parse(tbEventB23.Text);
                            int IdU2 = IdU;
                            int IdQ2 = CatIP14Q25;
                            spQtyUnit(Name2, NameE2, Qty2, IdU2, IdQ2);

                            string Name3 = lblPeople.Text;
                            string NameE3 = lblP.Text;
                            int Qty3 = Int32.Parse(tbPgr23.Text);
                            int IdU3 = IdU;
                            int IdQ3 = CatIP14Q26;
                            spQtyUnit(Name3, NameE3, Qty3, IdU3, IdQ3);

                            string Name4 = lblPeople.Text;
                            string NameE4 = lblB.Text;
                            int Qty4 = Int32.Parse(tbPBgr23.Text);
                            int IdU4 = IdU;
                            int IdQ4 = CatIP14Q27;
                            spQtyUnit(Name4, NameE4, Qty4, IdU4, IdQ4);
                        }
                        else
                            MessageBox.Show("Не удалось добавить подразделение!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }

                    if (cmbGR24.Text.Length > 0)
                    {
                        string NameU9 = cmbGR24.Text.Trim();
                        int IdU = CatIP4U8;
                        int IdE = Convert.ToInt32(tbIdE.Text);
                        spUnit(NameU9, IdU, IdE);
                        if (tbEventP24.Text.Length >= 0 && tbEventB24.Text.Length >= 0 && tbPgr24.Text.Length >= 0 && tbPBgr24.Text.Length >= 0)
                        {
                            string Name1 = lblEvent.Text;
                            string NameE1 = lblP.Text;
                            int Qty1 = Int32.Parse(tbEventP24.Text);
                            int IdU1 = IdU;
                            int IdQ1 = CatIP14Q28;
                            spQtyUnit(Name1, NameE1, Qty1, IdU1, IdQ1);

                            string Name2 = lblEvent.Text;
                            string NameE2 = lblB.Text;
                            int Qty2 = Int32.Parse(tbEventB24.Text);
                            int IdU2 = IdU;
                            int IdQ2 = CatIP14Q29;
                            spQtyUnit(Name2, NameE2, Qty2, IdU2, IdQ2);

                            string Name3 = lblPeople.Text;
                            string NameE3 = lblP.Text;
                            int Qty3 = Int32.Parse(tbPgr24.Text);
                            int IdU3 = IdU;
                            int IdQ3 = CatIP14Q30;
                            spQtyUnit(Name3, NameE3, Qty3, IdU3, IdQ3);

                            string Name4 = lblPeople.Text;
                            string NameE4 = lblB.Text;
                            int Qty4 = Int32.Parse(tbPBgr24.Text);
                            int IdU4 = IdU;
                            int IdQ4 = CatIP14Q31;
                            spQtyUnit(Name4, NameE4, Qty4, IdU4, IdQ4);
                        }
                        else
                            MessageBox.Show("Не удалось добавить подразделение!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }

                    MessageBox.Show("Годовое мероприятие изменено!");
                    this.Hide();
                    MainForm m = new MainForm();
                    m.Show();
                }
                catch (Exception)
                {
                    MessageBox.Show("Не удалось обновить данные!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

            }
            else
                MessageBox.Show("Не удалось изменинть мероприятие!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void tbpgr4_TextChanged(object sender, EventArgs e)
        {
            sumTBPP1();
        }
        private void tbpgr1_TextChanged(object sender, EventArgs e)
        {
            sumTBPP1();
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
        public void vwId(int[] UnitArrayQty, int [] UnitArrayQty2, int [] UnitArray,int[] UnitArray2)
        {
            int CatIP = Convert.ToInt32(UnitArrayQty[1].ToString());
            int CatIP1 = Convert.ToInt32(UnitArrayQty2[0].ToString());
            int CatIP2 = Convert.ToInt32(UnitArrayQty2[1].ToString());
            int CatIP3 = Convert.ToInt32(UnitArrayQty2[2].ToString());
            int CatIP4 = Convert.ToInt32(UnitArrayQty2[3].ToString());

            //MessageBox.Show(CatIP.ToString());

            int CatKD = Convert.ToInt32(UnitArrayQty[6].ToString());
            int CatKD1 = Convert.ToInt32(UnitArrayQty2[4].ToString());
            int CatKD2 = Convert.ToInt32(UnitArrayQty2[5].ToString());
            int CatKD3 = Convert.ToInt32(UnitArrayQty2[6].ToString());
            int CatKD4 = Convert.ToInt32(UnitArrayQty2[7].ToString());

            //MessageBox.Show(CatKD.ToString());

            int CatIP4U1 = Convert.ToInt32(UnitArray[0].ToString());
            int CatIP14Q0 = Convert.ToInt32(UnitArray2[0].ToString());
            int CatIP14Q1 = Convert.ToInt32(UnitArray2[1].ToString());
            int CatIP14Q2 = Convert.ToInt32(UnitArray2[2].ToString());
            int CatIP14Q3 = Convert.ToInt32(UnitArray2[3].ToString());

            int CatIP4U2 = Convert.ToInt32(UnitArray[5].ToString());
            int CatIP14Q4 = Convert.ToInt32(UnitArray2[4].ToString());
            int CatIP14Q5 = Convert.ToInt32(UnitArray2[5].ToString());
            int CatIP14Q6 = Convert.ToInt32(UnitArray2[6].ToString());
            int CatIP14Q7 = Convert.ToInt32(UnitArray2[7].ToString());

            int CatIP4U3 = Convert.ToInt32(UnitArray[9].ToString());
            int CatIP14Q8 = Convert.ToInt32(UnitArray2[8].ToString());
            int CatIP14Q9 = Convert.ToInt32(UnitArray2[9].ToString());
            int CatIP14Q10 = Convert.ToInt32(UnitArray2[10].ToString());
            int CatIP14Q11 = Convert.ToInt32(UnitArray2[11].ToString());

            int CatIP4U4 = Convert.ToInt32(UnitArray[14].ToString());
            int CatIP14Q12 = Convert.ToInt32(UnitArray2[12].ToString());
            int CatIP14Q13 = Convert.ToInt32(UnitArray2[13].ToString());
            int CatIP14Q14 = Convert.ToInt32(UnitArray2[14].ToString());
            int CatIP14Q15 = Convert.ToInt32(UnitArray2[15].ToString());

            int CatIP4U5 = Convert.ToInt32(UnitArray[17].ToString());
            int CatIP14Q16 = Convert.ToInt32(UnitArray2[16].ToString());
            int CatIP14Q17 = Convert.ToInt32(UnitArray2[17].ToString());
            int CatIP14Q18 = Convert.ToInt32(UnitArray2[18].ToString());
            int CatIP14Q19 = Convert.ToInt32(UnitArray2[19].ToString());

            int CatIP4U6 = Convert.ToInt32(UnitArray[22].ToString());
            int CatIP14Q20 = Convert.ToInt32(UnitArray2[20].ToString());
            int CatIP14Q21 = Convert.ToInt32(UnitArray2[21].ToString());
            int CatIP14Q22 = Convert.ToInt32(UnitArray2[22].ToString());
            int CatIP14Q23 = Convert.ToInt32(UnitArray2[23].ToString());

            int CatIP4U7 = Convert.ToInt32(UnitArray[25].ToString());
            int CatIP14Q24 = Convert.ToInt32(UnitArray2[24].ToString());
            int CatIP14Q25 = Convert.ToInt32(UnitArray2[25].ToString());
            int CatIP14Q26 = Convert.ToInt32(UnitArray2[26].ToString());
            int CatIP14Q27 = Convert.ToInt32(UnitArray2[27].ToString());

            int CatIP4U8 = Convert.ToInt32(UnitArray[30].ToString());
            int CatIP14Q28 = Convert.ToInt32(UnitArray2[28].ToString());
            int CatIP14Q29 = Convert.ToInt32(UnitArray2[29].ToString());
            int CatIP14Q30 = Convert.ToInt32(UnitArray2[30].ToString());
            int CatIP14Q31 = Convert.ToInt32(UnitArray2[31].ToString());

            richTextBox1.Text = CatIP.ToString() + " " + CatIP1.ToString() + " " + CatIP2.ToString() +
                " " + CatIP3.ToString() + " " + CatIP4.ToString() + " "
                //1
                + CatKD.ToString() + " " + CatKD1.ToString() + " " + CatKD2.ToString() + " " + CatKD3.ToString() + " "
                + CatKD4.ToString() + " " + CatIP4U1.ToString() + " " + CatIP14Q0.ToString() + " " + CatIP14Q1.ToString() +
                 //2
                 " " + CatIP14Q2.ToString() + " " + CatIP14Q3.ToString() + " " + CatIP4U2.ToString() + " " + CatIP14Q6.ToString() +

                 //3
                 " " + CatIP14Q7.ToString() + " " + CatIP14Q8.ToString() + " " + CatIP14Q9.ToString() + " "

                //4
                + CatIP4U3.ToString() + " " + CatIP14Q12.ToString() + " " + CatIP14Q13.ToString() + " " + CatIP14Q14.ToString() + " " + CatIP14Q15.ToString()
                 + " "
                //5
                + CatIP4U4.ToString() + " " + CatIP14Q18.ToString() + " " + CatIP14Q19.ToString() + " " + CatIP14Q20.ToString() + " " + CatIP14Q21.ToString()
                 + " "
                //6 +
                + CatIP4U5.ToString() + " " + CatIP14Q24.ToString() + " " + CatIP14Q25.ToString() + " " + CatIP14Q26.ToString() + " " + CatIP14Q27.ToString()
                 + " " +
                 //7
                 CatIP4U6.ToString() + " " + CatIP14Q30.ToString() + " " + CatIP14Q31.ToString();/*+ " " + CatIP14Q32.ToString() + " " + CatIP14Q33.ToString();*/
                 //+ " " +
                 ////8
                // CatIP4U7.ToString() + " " + CatIP14Q36.ToString() + " " + CatIP14Q37.ToString() + " " + CatIP14Q38.ToString() + " " + CatIP14Q39.ToString()
                // + " " + " "
                ////9
                //+ CatIP4U8.ToString() + " " + CatIP14Q42.ToString() + " " + CatIP14Q43.ToString() + " " + CatIP14Q44.ToString() + " " + CatIP14Q45.ToString();
                
        }

        public void spUnit(string  Name , int IdE, int IdU)
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
        public void spQtyUnit(string Name,string Categ,int Qty,int IdU,int IdQ)
        {
            ConnectSDO sdo = new ConnectSDO();
            SqlCommand sqlcom2 = new SqlCommand("spUppQtyYearUnit", sdo.getConnectSDO());
            sqlcom2.CommandType = CommandType.StoredProcedure;
            sqlcom2.Parameters.AddWithValue("@IdU", SqlDbType.Int).Value = IdU;
            sqlcom2.Parameters.AddWithValue("@IdQ", SqlDbType.Int).Value = IdQ;
            sqlcom2.Parameters.AddWithValue("@Name", SqlDbType.NVarChar).Value = Name;
            sqlcom2.Parameters.AddWithValue("@Qty", SqlDbType.Int).Value = Qty;
            sqlcom2.Parameters.AddWithValue("@Category", SqlDbType.NVarChar).Value = Categ;
            sdo.OpenConnection();
            sqlcom2.ExecuteNonQuery();
            sdo.CloseConnection();
        }
    }
}
