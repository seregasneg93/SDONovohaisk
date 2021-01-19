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
    public partial class DescEventForm : Form
    {
        SqlDataAdapter adapter;
        DataTable datTab;
        SqlCommand sqlcom;
        int[] Event2, Event3;
        int Id;
        public DescEventForm(int[] EventYear1, int[] EventYear2,int Idyp)
        {
            InitializeComponent();
            Event2 = EventYear1;
            Event3 = EventYear2;
            Id = Idyp;
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void DescEventForm_Load(object sender, EventArgs e)
        {
            TBSet(Event2, Event3);
        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }

        public void TBSet(int [] EventYear1,int [] EventYear2)
        {
            int IPEventP = EventYear2[0];
            int IPEventB = EventYear2[1];
            int IPPeopP = EventYear2[2];
            int IPPeopB = EventYear2[3];
            int KDEventP = EventYear2[4];
            int KDEventB = EventYear2[5];
            int KDPeopP = EventYear2[6];
            int KDPeopB = EventYear2[7];

            tbIPEventAllP.Text = Convert.ToString(IPEventP);
            tbIPEventAllB.Text = Convert.ToString(IPEventB);
            tbIPPeopAllP.Text = Convert.ToString(IPPeopP);
            tbIPPeopAllB.Text = Convert.ToString(IPPeopB);
            tbKDEventtAllP.Text = Convert.ToString(KDEventP);
            tbKDEventtAllB.Text = Convert.ToString(KDEventB);
            tbKDPeopP.Text = Convert.ToString(KDPeopP);
            tbKDPeopB.Text = Convert.ToString(KDPeopB);

            int P1 = EventYear1[0];
            int B1 = EventYear1[1];
            int P2 = EventYear1[2];
            int B2 = EventYear1[3];
            int P3 = EventYear1[4];
            int B3 = EventYear1[5];
            int P4 = EventYear1[6];
            int B4 = EventYear1[7];
            int P5 = EventYear1[8];
            int B5 = EventYear1[9];
            int P6 = EventYear1[10];
            int B6 = EventYear1[11];
            int P7 = EventYear1[12];
            int B7 = EventYear1[13];
            int P8 = EventYear1[14];
            int B8 = EventYear1[15];

            tbP1.Text = Convert.ToString(P1);
            tbB1.Text = Convert.ToString(B1);
            tbP2.Text = Convert.ToString(P2);
            tbB2.Text = Convert.ToString(B2);
            tbP3.Text = Convert.ToString(P3);
            tbB3.Text = Convert.ToString(B3);
            tbP4.Text = Convert.ToString(P4);
            tbB4.Text = Convert.ToString(B4);
            tbP5.Text = Convert.ToString(P5);
            tbB5.Text = Convert.ToString(B5);
            tbP6.Text = Convert.ToString(P6);
            tbB6.Text = Convert.ToString(B6);
            tbP7.Text = Convert.ToString(P7);
            tbB7.Text = Convert.ToString(B7);
            tbP8.Text = Convert.ToString(P8);
            tbB8.Text = Convert.ToString(B8);

            int P9 = EventYear1[16];
            int B9 = EventYear1[17];
            int P10 = EventYear1[18];
            int B10 = EventYear1[19];
            int P11 = EventYear1[20];
            int B11 = EventYear1[21];
            int P12 = EventYear1[22];
            int B12 = EventYear1[23];
            int P13 = EventYear1[24];
            int B13 = EventYear1[25];
            int P14 = EventYear1[26];
            int B14 = EventYear1[27];
            int P15 = EventYear1[28];
            int B15 = EventYear1[29];
            int P16 = EventYear1[30];
            int B16 = EventYear1[31];

            tbPP1.Text = Convert.ToString(P9);
            tbPPB1.Text = Convert.ToString(B9);
            tbPP2.Text = Convert.ToString(P10);
            tbPPB2.Text = Convert.ToString(B10);
            tbPP3.Text = Convert.ToString(P11);
            tbPPB3.Text = Convert.ToString(B11);
            tbPP4.Text = Convert.ToString(P12);
            tbPPB4.Text = Convert.ToString(B12);
            tbPP5.Text = Convert.ToString(P13);
            tbPPB5.Text = Convert.ToString(B13);
            tbPP6.Text = Convert.ToString(P14);
            tbPPB6.Text = Convert.ToString(B14);
            tbPP7.Text = Convert.ToString(P15);
            tbPPB7.Text = Convert.ToString(B15);
            tbPP8.Text = Convert.ToString(P16);
            tbPPB8.Text = Convert.ToString(B16);

            try
            {
                ConnectSDO ConSDO = new ConnectSDO();
                ConSDO.OpenConnection();
                SqlCommand comSPM = new SqlCommand("SELECT QtyIPP,QtyIPB,QtyKDP,QtyKDB,QtyIPPeopP,QtyIPPeopB,QtyKDPeopP,QtyKDPeopB FROM vwAllUnit WHERE Id =" + Id, ConSDO.getConnectSDO());
                adapter = new SqlDataAdapter(comSPM);
                datTab = new DataTable();
                adapter.Fill(datTab);
                ConSDO.CloseConnection();
                foreach (DataRow DR in datTab.Rows)
                {
                    tbIPEventtAllPD.Text = (DR["QtyIPP"].ToString());
                    tbIPEventAllBD.Text = (DR["QtyIPB"].ToString());
                    tbKDEventtAllPD.Text = (DR["QtyKDP"].ToString());
                    tbKDEventtAllBD.Text = (DR["QtyKDB"].ToString());
                    tbIPPeopAllPD.Text = (DR["QtyIPPeopP"].ToString());
                    tbIPPeopAllBD.Text = (DR["QtyIPPeopB"].ToString());
                    tbKDPeopPD.Text = (DR["QtyKDPeopP"].ToString());
                    tbKDPeopBD.Text = (DR["QtyKDPeopB"].ToString());
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Не удалось загрузить данные!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            
           try
            {
                ConnectSDO ConSDO = new ConnectSDO();
                ConSDO.OpenConnection();
                SqlCommand comSPM = new SqlCommand("SELECT QtyIP14P,QtyIP14B,QtyIP25P,QtyIP25B,QtyIP55P,QtyIP55B,QtyIP55PP,QtyIP55PB,QtyKD14P,QtyKD14B,QtyKD25P,QtyKD25B,QtyKD55P,QtyKD55B,QtyKDPP,QtyKDPB FROM vwAllEventtIPKD WHERE Id =" + Id, ConSDO.getConnectSDO());
                adapter = new SqlDataAdapter(comSPM);
                datTab = new DataTable();
                adapter.Fill(datTab);
                ConSDO.CloseConnection();
                foreach (DataRow DR in datTab.Rows)
                {
                    tbP1Dd.Text = (DR["QtyIP14P"].ToString());
                    tbB1D.Text = (DR["QtyIP14B"].ToString());
                    tbP2D.Text = (DR["QtyIP25P"].ToString());
                    tbB2D.Text = (DR["QtyIP25B"].ToString());
                    tbP3D.Text = (DR["QtyIP55P"].ToString());
                    tbB3D.Text = (DR["QtyIP55B"].ToString());
                    tbP4D.Text = (DR["QtyIP55PP"].ToString());
                    tbB4D.Text = (DR["QtyIP55PB"].ToString());
                    tbPP1D.Text = (DR["QtyKD14P"].ToString());
                    tbBB1D.Text = (DR["QtyKD14B"].ToString());
                    tbPP2D.Text = (DR["QtyKD25P"].ToString());
                    tbBB2D.Text = (DR["QtyKD25B"].ToString());
                    tbPP3D.Text = (DR["QtyKD55P"].ToString());
                    tbBB3D.Text = (DR["QtyKD55B"].ToString());
                    tbPP4D.Text = (DR["QtyKDPP"].ToString());
                    tbBB4D.Text = (DR["QtyKDPB"].ToString());
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Не удалось загрузить данные!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            try
            {
                ConnectSDO ConSDO = new ConnectSDO();
                ConSDO.OpenConnection();
                SqlCommand comSPM = new SqlCommand("SELECT QtyIP14P,QtyIP14B,QtyIP25P,QtyIP25B,QtyIP55P,QtyIP55B,QtyIP55PP,QtyIP55PB,QtyKD14P,QtyKD14B,QtyKD25P,QtyKD25B,QtyKD55P,QtyKD55B,QtyKDPP,QtyKDPB FROM vwAllPeopleIPKD WHERE Id =" + Id, ConSDO.getConnectSDO());
                adapter = new SqlDataAdapter(comSPM);
                datTab = new DataTable();
                adapter.Fill(datTab);
                ConSDO.CloseConnection();
                foreach (DataRow DR in datTab.Rows)
                {
                    tbPep1PD.Text = (DR["QtyIP14P"].ToString());
                    tbPep1BD.Text = (DR["QtyIP14B"].ToString());
                    tbPep2PD.Text = (DR["QtyIP25P"].ToString());
                    tbPep2BD.Text = (DR["QtyIP25B"].ToString());
                    tbPep3PD.Text = (DR["QtyIP55P"].ToString());
                    tbPep3BD.Text = (DR["QtyIP55B"].ToString());
                    tbPep4PD.Text = (DR["QtyIP55PP"].ToString());
                    tbPep4BD.Text = (DR["QtyIP55PB"].ToString());
                    tbPep1PPD.Text = (DR["QtyKD14P"].ToString());
                    tbPep1BBD.Text = (DR["QtyKD14B"].ToString());
                    tbPep2PPD.Text = (DR["QtyKD25P"].ToString());
                    tbPep2BBD.Text = (DR["QtyKD25B"].ToString());
                    tbPep3PPD.Text = (DR["QtyKD55P"].ToString());
                    tbPep3BBD.Text = (DR["QtyKD55B"].ToString());
                    tbPep4PPD.Text = (DR["QtyKDPP"].ToString());
                    tbPep4BBD.Text = (DR["QtyKDPB"].ToString());
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Не удалось загрузить данные!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            int a1 = Convert.ToInt32(tbIPEventAllP.Text);
            int a2 = Convert.ToInt32(tbIPEventtAllPD.Text);
            int s1 = RetLbl(a1, a2);
            lbl1.Text = Convert.ToString(s1);
            int a3 = Convert.ToInt32(tbIPEventAllB.Text);
            int a4 = Convert.ToInt32(tbIPEventAllBD.Text);
            int s2 = RetLbl(a3, a4);
            lbl2.Text = Convert.ToString(s2);
            int a5 = Convert.ToInt32(tbP1.Text);
            int a6 = Convert.ToInt32(tbP1Dd.Text);
            int s3 = RetLbl(a5, a6);
            lbl3.Text = Convert.ToString(s3);
            int a7 = Convert.ToInt32(tbP3.Text);
            int a8 = Convert.ToInt32(tbP2D.Text);
            int s4 = RetLbl(a7, a8);
            lbl4.Text = Convert.ToString(s4);
            int a9 = Convert.ToInt32(tbP5.Text);
            int a10 = Convert.ToInt32(tbP3D.Text);
            int s5 = RetLbl(a9, a10);
            lbl5.Text = Convert.ToString(s5);
            int a11 = Convert.ToInt32(tbP7.Text);
            int a12 = Convert.ToInt32(tbP4D.Text);
            int s6 = RetLbl(a11, a12);
            lbl6.Text = Convert.ToString(s6);
            int a13 = Convert.ToInt32(tbB1.Text);
            int a14 = Convert.ToInt32(tbB1D.Text);
            int s7 = RetLbl(a13, a14);
            lbl7.Text = Convert.ToString(s7);
            int a15 = Convert.ToInt32(tbB3.Text);
            int a16 = Convert.ToInt32(tbB2D.Text);
            int s8 = RetLbl(a15, a16);
            lbl8.Text = Convert.ToString(s8);
            int a17 = Convert.ToInt32(tbB5.Text);
            int a18 = Convert.ToInt32(tbB3D.Text);
            int s9 = RetLbl(a17, a18);
            lbl9.Text = Convert.ToString(s9);
            int a19 = Convert.ToInt32(tbB7.Text);
            int a20 = Convert.ToInt32(tbB4D.Text);
            int s10 = RetLbl(a19, a20);
            lbl10.Text = Convert.ToString(s10);

            int a21 = Convert.ToInt32(tbIPPeopAllP.Text);
            int a22 = Convert.ToInt32(tbIPPeopAllPD.Text);
            int s11 = RetLbl(a21, a22);
            lbl11.Text = Convert.ToString(s11);
            int a23 = Convert.ToInt32(tbIPPeopAllB.Text);
            int a24 = Convert.ToInt32(tbIPPeopAllBD.Text);
            int s12 = RetLbl(a23, a24);
            lbl12.Text = Convert.ToString(s12);

            int a25 = Convert.ToInt32(tbP2.Text);
            int a26 = Convert.ToInt32(tbPep1PD.Text);
            int s13 = RetLbl(a25, a26);
            lbl13.Text = Convert.ToString(s13);
            int a27 = Convert.ToInt32(tbP4.Text);
            int a28 = Convert.ToInt32(tbPep2PD.Text);
            int s14 = RetLbl(a27, a28);
            lbl14.Text = Convert.ToString(s14);
            int a29 = Convert.ToInt32(tbP6.Text);
            int a30 = Convert.ToInt32(tbPep3PD.Text);
            int s15 = RetLbl(a29, a30);
            lbl15.Text = Convert.ToString(s15);
            int a31 = Convert.ToInt32(tbP8.Text);
            int a32 = Convert.ToInt32(tbPep4PD.Text);
            int s16 = RetLbl(a31, a32);
            lbl16.Text = Convert.ToString(s16);
            int a33 = Convert.ToInt32(tbB2.Text);
            int a34 = Convert.ToInt32(tbPep1BD.Text);
            int s17 = RetLbl(a33, a34);
            lbl17.Text = Convert.ToString(s17);
            int a35 = Convert.ToInt32(tbB4.Text);
            int a36 = Convert.ToInt32(tbPep2BD.Text);
            int s18 = RetLbl(a35, a36);
            lbl18.Text = Convert.ToString(s18);
            int a37 = Convert.ToInt32(tbB6.Text);
            int a38 = Convert.ToInt32(tbPep3BD.Text);
            int s19 = RetLbl(a37, a38);
            lbl19.Text = Convert.ToString(s19);
            int a39 = Convert.ToInt32(tbB8.Text);
            int a40 = Convert.ToInt32(tbPep4BD.Text);
            int s20 = RetLbl(a39, a40);
            lbl20.Text = Convert.ToString(s20);


            int b1 = Convert.ToInt32(tbKDEventtAllP.Text);
            int b2 = Convert.ToInt32(tbKDEventtAllPD.Text);
            int s21 = RetLbl(b1, b2);
            lbl21.Text = Convert.ToString(s21);
            int b3 = Convert.ToInt32(tbKDEventtAllB.Text);
            int b4 = Convert.ToInt32(tbKDEventtAllBD.Text);
            int s22 = RetLbl(b3, b4);
            lbl22.Text = Convert.ToString(s22);

            int b5 = Convert.ToInt32(tbPP1.Text);
            int b6 = Convert.ToInt32(tbPP1D.Text);
            int s23 = RetLbl(b5, b6);
            lbl23.Text = Convert.ToString(s23);
            int b7 = Convert.ToInt32(tbPP3.Text);
            int b8 = Convert.ToInt32(tbPP2D.Text);
            int s24 = RetLbl(b7, b8);
            lbl24.Text = Convert.ToString(s24);
            int b9 = Convert.ToInt32(tbPP5.Text);
            int b10 = Convert.ToInt32(tbPP3D.Text);
            int s25 = RetLbl(b9, b10);
            lbl25.Text = Convert.ToString(s25);
            int b11 = Convert.ToInt32(tbPP7.Text);
            int b12 = Convert.ToInt32(tbPP4D.Text);
            int s26 = RetLbl(b11, b12);
            lbl26.Text = Convert.ToString(s26);
            int b13 = Convert.ToInt32(tbPPB1.Text);
            int b14 = Convert.ToInt32(tbBB1D.Text);
            int s27 = RetLbl(b13, b14);
            lbl27.Text = Convert.ToString(27);
            int b15 = Convert.ToInt32(tbPPB3.Text);
            int b16 = Convert.ToInt32(tbBB2D.Text);
            int s28 = RetLbl(b15, b16);
            lbl28.Text = Convert.ToString(s28);
            int b17 = Convert.ToInt32(tbPPB5.Text);
            int b18 = Convert.ToInt32(tbBB3D.Text);
            int s29 = RetLbl(b17, b18);
            lbl29.Text = Convert.ToString(s29);
            int b19 = Convert.ToInt32(tbPPB7.Text);
            int b20 = Convert.ToInt32(tbBB4D.Text);
            int s30 = RetLbl(b19, b20);
            lbl30.Text = Convert.ToString(s30);

            int b21 = Convert.ToInt32(tbKDPeopP.Text);
            int b22 = Convert.ToInt32(tbKDPeopPD.Text);
            int s31 = RetLbl(b21, b22);
            lbl31.Text = Convert.ToString(s31);
            int b23 = Convert.ToInt32(tbKDPeopB.Text);
            int b24 = Convert.ToInt32(tbKDPeopBD.Text);
            int s32 = RetLbl(b23, b24);
            lbl32.Text = Convert.ToString(s32);

            int b25 = Convert.ToInt32(tbPP2.Text);
            int b26 = Convert.ToInt32(tbPep1PPD.Text);
            int s33 = RetLbl(b25, b26);
            lbl33.Text = Convert.ToString(s33);
            int b27 = Convert.ToInt32(tbPP4.Text);
            int b28 = Convert.ToInt32(tbPep2PPD.Text);
            int s34 = RetLbl(b27, b28);
            lbl34.Text = Convert.ToString(s34);
            int b29 = Convert.ToInt32(tbPP6.Text);
            int b30 = Convert.ToInt32(tbPep3PPD.Text);
            int s35 = RetLbl(b29, b30);
            lbl35.Text = Convert.ToString(s35);
            int b31 = Convert.ToInt32(tbPP8.Text);
            int b32 = Convert.ToInt32(tbPep4PPD.Text);
            int s36 = RetLbl(b31, b32);
            lbl36.Text = Convert.ToString(s36);
            int b33 = Convert.ToInt32(tbPPB2.Text);
            int b34 = Convert.ToInt32(tbPep1BBD.Text);
            int s37 = RetLbl(b33, b34);
            lbl37.Text = Convert.ToString(s37);
            int b35 = Convert.ToInt32(tbPPB4.Text);
            int b36 = Convert.ToInt32(tbPep2BBD.Text);
            int s38 = RetLbl(b35, b36);
            lbl38.Text = Convert.ToString(s38);
            int b37 = Convert.ToInt32(tbPPB6.Text);
            int b38 = Convert.ToInt32(tbPep3BBD.Text);
            int s39 = RetLbl(b37, b38);
            lbl39.Text = Convert.ToString(s39);
            int b39 = Convert.ToInt32(tbPPB8.Text);
            int b40 = Convert.ToInt32(tbPep4BBD.Text);
            int s40 = RetLbl(b39, b40);
            lbl40.Text = Convert.ToString(s40);

        }

        public int RetLbl(int a,int b)
        {
            int s = 0;
             s = a - b;
            return s;
        }
    }
}
