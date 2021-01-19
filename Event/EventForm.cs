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
    public partial class EventForm : Form
    {
        SqlDataAdapter adapter;
        DataTable datTab;
        SqlCommand sqlcom;
        string Nameevent;
        DateTime Data;
        int Qtyevent, Qtyunit,Idyp;
        int[] Qtyipkd, EventYear1, EventYear2;
        public EventForm(string NameEvent, DateTime DataEvent,int QtyEvent,int QtyUnit , int[] QtyIPKD,int IdYP, int[] EventtYear1, int [] EventtYear2)
        {
            InitializeComponent();
            Nameevent = NameEvent;
            Data = DataEvent;
            Qtyevent = QtyEvent;
            Qtyunit = QtyUnit;
            Qtyipkd = QtyIPKD;
            Idyp = IdYP;
            EventYear1 = EventtYear1;
            EventYear2 = EventtYear2;
        }

        private void EventForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Hide();
            MainForm mf = new MainForm();
            mf.Show();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Hide();
            MainForm mf = new MainForm();
            mf.Show();
        }

        private void EventForm_Load(object sender, EventArgs e)
        {
            ActiveDataGridView();
            vwEvent();
            btnList.Visible = false;
            tbIdYP.Text = Convert.ToString(Idyp);
            lblText(Nameevent,Data, Qtyevent, Qtyunit, Qtyipkd);
            SumEvent(Idyp);
            Move();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            btnList.Visible = true;
            ConnectSDO sdo = new ConnectSDO();
            sdo.OpenConnection();
            SqlCommand comSPM = new SqlCommand("SELECT * FROM vwEventt WHERE [Дата проведения] = ' " + dtpEvent.Value.ToString("yyy-MM-dd") + "'", sdo.getConnectSDO());
            adapter = new SqlDataAdapter(comSPM);
            datTab = new DataTable();
            adapter.Fill(datTab);
            sdo.CloseConnection();
            dgvEvent.DataSource = datTab;
        }

        private void btnList_Click(object sender, EventArgs e)
        {
            btnList.Visible = false;
            vwEvent();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            int IdYP = Idyp;
            AddEventForm aef = new AddEventForm(IdYP);
            aef.ShowDialog();
        }

        private void btnDesc_Click(object sender, EventArgs e)
        {
            vwEvent();
            SumEvent(Idyp);
        }

        private void btnUnit_Click(object sender, EventArgs e)
        {
            UnitForm uf = new UnitForm();
            uf.ShowDialog();
        }

        private void tbTotalPeople_TextChanged(object sender, EventArgs e)
        {
            if (tbTotalPeople.Text.Length > 0 && tbPassedPeople.Text.Length > 0)
            {
                //int EvA = Int32.Parse(tbTotalPeople.Text) - Int32.Parse(tbPassedPeople.Text);
                //lblRemPeop.Text = "Остаток :" + " " + Convert.ToString(EvA);
            }
        }

        private void tbPassedPeople_TextChanged(object sender, EventArgs e)
        {

        }

        private void tbTotalTick_TextChanged(object sender, EventArgs e)
        {

        }

        public void lblText(string Name,DateTime Data,int QtyEventt, int QtyUnit , int [] QtyIPKD)
        {
            lblFullEventt.Text = Name + " " + Data.ToString("dd.MM.yyyy");
            tbTotalEvent.Text = Convert.ToString(QtyEventt);
            tbTotalPeople.Text = Convert.ToString(QtyUnit);
            tbEventtP.Text = Convert.ToString(QtyIPKD[3]);
            tbEventB.Text = Convert.ToString(QtyIPKD[1]);
            tbPepP.Text = Convert.ToString(QtyIPKD[2]);
            tbPepB.Text = Convert.ToString(QtyIPKD[0]);
        }

        private void tbEventPPas_TextChanged(object sender, EventArgs e)
        {
            if (tbEventPPas.Text != "")
            {
                int a = Convert.ToInt32(tbEventtP.Text);
                int b = Convert.ToInt32(tbPassedEvent.Text);

                int d = SUMTotal(a, b);

                lblEventP.Text = Convert.ToString(d);
            }
        }

        private void tbEventBPas_TextChanged(object sender, EventArgs e)
        {
            if (tbEventBPas.Text != "")
            {
                int a = Convert.ToInt32(tbEventB.Text);
                int b = Convert.ToInt32(tbEventBPas.Text);

                int d = SUMTotal(a, b);

                lblEventB.Text = Convert.ToString(d);
            }
        }

        private void tbPepPPas_TextChanged(object sender, EventArgs e)
        {
            if (tbPepPPas.Text != "")
            {
                int a = Convert.ToInt32(tbPepP.Text);
                int b = Convert.ToInt32(tbPepPPas.Text);

                int d = SUMTotal(a, b);

                lblPepP.Text = Convert.ToString(d);
            }
        }

        private void tbPepPasB_TextChanged(object sender, EventArgs e)
        {
            if (tbPepPasB.Text != "")
            {
                int a = Convert.ToInt32(tbPepB.Text);
                int b = Convert.ToInt32(tbPepPasB.Text);
                int d = SUMTotal(a, b);

                lblPepB.Text = Convert.ToString(d);
            }
        }

        private void tbTotalEvent_TextChanged(object sender, EventArgs e)
        {

        }

        public int SUMTotal(int a , int b)
        {
            int c = 0;
            if (tbTotalEvent.Text.Length >= 0 && tbPassedEvent.Text.Length >=0)
            {
                 c = a - b;
            }         
            return c;
        }

        private void tbPassedEvent_TextChanged(object sender, EventArgs e)
        {

        }

        private void dgvEvent_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int a = Convert.ToInt32(dgvEvent.Rows[dgvEvent.CurrentRow.Index].Cells[1].Value);
            vwInfEventt(a);
            vwInfEventt2(a);
        }

        public void vwInfEventt(int a)
        {
            try
            {
                dgvEventt2.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                dgvEventt2.AllowUserToAddRows = false;
                ConnectSDO ConSDO = new ConnectSDO();
                ConSDO.OpenConnection();
                SqlCommand comSPM = new SqlCommand("SELECT * FROM vwEventt2 WHERE IdE = " + a, ConSDO.getConnectSDO());
                adapter = new SqlDataAdapter(comSPM);
                datTab = new DataTable();
                adapter.Fill(datTab);
                ConSDO.CloseConnection();
                dgvEventt2.DataSource = datTab;
                dgvEventt2.Columns[0].Visible = false;
                dgvEventt2.Columns[1].Visible = false;
                dgvEventt2.Columns[2].Visible = false;
            }
            catch (Exception)
            {
                MessageBox.Show("Не удалось загрузить данные!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        public void vwInfEventt2(int a)
        {
            try
            {
                dgvEventt3.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                dgvEventt3.AllowUserToAddRows = false;
                ConnectSDO ConSDO = new ConnectSDO();
                ConSDO.OpenConnection();
                SqlCommand comSPM = new SqlCommand("SELECT * FROM vwEventt3 WHERE IdE = " + a, ConSDO.getConnectSDO());
                adapter = new SqlDataAdapter(comSPM);
                datTab = new DataTable();
                adapter.Fill(datTab);
                ConSDO.CloseConnection();
                dgvEventt3.DataSource = datTab;
                dgvEventt3.Columns[0].Visible = false;
                dgvEventt3.Columns[1].Visible = false;
                dgvEventt3.Columns[2].Visible = false;
            }
            catch (Exception)
            {
                MessageBox.Show("Не удалось загрузить данные!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnCorr_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Вы дeйствительно хотите изменить данные?", "Изменение", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    if (dgvEvent.SelectedRows == null)
                    {
                        MessageBox.Show("Запись не выбрана!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                    else                   
                    {
                        int IdE = Convert.ToInt32(dgvEvent.Rows[dgvEvent.CurrentRow.Index].Cells[1].Value);
                        string NameE = Convert.ToString(dgvEvent.Rows[dgvEvent.CurrentRow.Index].Cells[2].Value);
                        string StatusE = Convert.ToString(dgvEvent.Rows[dgvEvent.CurrentRow.Index].Cells[3].Value);
                        DateTime dateF = Convert.ToDateTime(dgvEvent.Rows[dgvEvent.CurrentRow.Index].Cells[4].Value);
                        string NameCateg = Convert.ToString(dgvEvent.Rows[dgvEvent.CurrentRow.Index].Cells[5].Value);

                        int[] EventIdUnit;
                        int[] EventIdQty;
                        EventIdUnit = new int[dgvEventt2.RowCount];
                        EventIdQty = new int[dgvEventt2.RowCount];
                        for (int i = 0; i < dgvEventt2.RowCount; i++)
                        {
                            EventIdUnit[i] = Convert.ToInt32(dgvEventt2[1, i].Value.ToString());
                            EventIdQty[i] = Convert.ToInt32(dgvEventt2[2, i].Value.ToString());
                            //MessageBox.Show(dgvEventt2[1, i].Value.ToString());
                            //MessageBox.Show(dgvEventt2[2, i].Value.ToString());
                        }

                        int[] EventIdQty2;
                        int[] EventQty2;
                        string[] NameE3;
                        EventIdQty2 = new int[dgvEventt3.RowCount];
                        NameE3 = new string[dgvEventt3.RowCount];
                        EventQty2 = new int[dgvEventt3.RowCount];
                        for (int i = 0; i < dgvEventt3.RowCount; i++)
                        {
                            EventIdQty2[i] = Convert.ToInt32(dgvEventt3[2, i].Value.ToString());
                            NameE3[i] = Convert.ToString(dgvEventt3[3, i].Value.ToString());
                            EventQty2[i] = Convert.ToInt32(dgvEventt3[6, i].Value.ToString());
                            //MessageBox.Show(dgvEventt3[1, i].Value.ToString());
                        }

                        UppEventForm of = new UppEventForm(IdE,NameE,StatusE,dateF,NameCateg, EventIdUnit, EventIdQty, EventIdQty2, EventQty2,NameE3);
                        of.ShowDialog();


                    }
                }
                catch (Exception)
                {
                    MessageBox.Show("Запись не выбрана!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
                MessageBox.Show("Отмена", "Отмена изменений!", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void dgvEventt2_ColumnAdded(object sender, DataGridViewColumnEventArgs e)
        {
            dgvEventt2.Columns[e.Column.Index].SortMode = DataGridViewColumnSortMode.NotSortable;
        }

        private void dgvEventt3_ColumnAdded(object sender, DataGridViewColumnEventArgs e)
        {
            dgvEventt3.Columns[e.Column.Index].SortMode = DataGridViewColumnSortMode.NotSortable;
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
                if (MessageBox.Show("Вы дeйствительно хотите удалить данные?", "Удаление", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    try
                    {
                        ConnectSDO sdo = new ConnectSDO();
                        sqlcom = new SqlCommand("spDelEventt", sdo.getConnectSDO());
                        sqlcom.CommandType = CommandType.StoredProcedure;
                        sqlcom.Parameters.AddWithValue("@Id", SqlDbType.Int).Value = Convert.ToInt32(dgvEvent.Rows[dgvEvent.CurrentRow.Index].Cells[1].Value);
                        sdo.OpenConnection();
                        sqlcom.ExecuteNonQuery();
                        MessageBox.Show("Мероприятие удалено!");
                        sdo.CloseConnection();
                        vwEvent();
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Не удалось удалить данные!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                else
                    MessageBox.Show("Отмена", "Отмена удаления", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void EventForm_Activated(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        public void Move()
        {
            //btnStrRefresh.BackColor = Color.(202; 112; 211)
        }

        private void timer1_Tick(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        public void ActiveDataGridView()
        {
            this.ActiveControl = dgvEvent;
            dgvEvent.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            if (dgvEvent.Rows.Count > 0)
            {
                dgvEvent.Rows[0].Selected = true;
            }
            this.WindowState = FormWindowState.Maximized;
        }

        private void btnInfEvent_Click(object sender, EventArgs e)
        {
            DescEventForm ds = new DescEventForm(EventYear1, EventYear2, Idyp);
            ds.ShowDialog();
        }

        public void vwEvent()
        {
            try
            {
                dgvEvent.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                dgvEvent.AllowUserToAddRows = false;
                ConnectSDO ConSDO = new ConnectSDO();
                ConSDO.OpenConnection();
                SqlCommand comSPM = new SqlCommand("SELECT * FROM vwEventt", ConSDO.getConnectSDO());
                adapter = new SqlDataAdapter(comSPM);
                datTab = new DataTable();
                adapter.Fill(datTab);
                ConSDO.CloseConnection();
                dgvEvent.DataSource = datTab;
                dgvEvent.Columns[0].Visible = false;
                dgvEvent.Columns[1].Visible = false;
            }
            catch (Exception)
            {
                MessageBox.Show("Не удалось загрузить данные!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        public void SumEvent(int IdYP)
        {
            int Id = IdYP;

            int[] Event;
            int sum = 0;
            Event = new int[dgvEvent.RowCount];
            for (int i = 0; i < dgvEvent.RowCount; i++)
            {
                Event[i] = Convert.ToInt32(dgvEvent[6, i].Value.ToString());
                //MessageBox.Show(dgvEventt3[1, i].Value.ToString());
            }

            foreach (var num in Event)
            {
                sum += num;
            }

            tbPassedEvent.Text = Convert.ToString(sum);
            if (tbPassedEvent.Text != "")
            {
                int a = Convert.ToInt32(tbTotalEvent.Text);
                int b = Convert.ToInt32(tbPassedEvent.Text);

                int d = SUMTotal(a, b);

                lblEvFull.Text = Convert.ToString(d);
            }

            int[] EventPeop;
            int sum2 = 0;
            EventPeop = new int[dgvEvent.RowCount];
            for (int i = 0; i < dgvEvent.RowCount; i++)
            {
                EventPeop[i] = Convert.ToInt32(dgvEvent[7, i].Value.ToString());
                //MessageBox.Show(dgvEventt3[1, i].Value.ToString());
            }

            foreach (var num1 in EventPeop)
            {
                sum2 += num1;
            }

            tbPassedPeople.Text = Convert.ToString(sum2);
            if (tbPassedPeople.Text != "")
            {
                int a = Convert.ToInt32(tbTotalPeople.Text);
                int b = Convert.ToInt32(tbPassedPeople.Text);

                int d = SUMTotal(a, b);

                lblPepFull.Text = Convert.ToString(d);
            }

            try
            {
                ConnectSDO ConSDO = new ConnectSDO();
                ConSDO.OpenConnection();
                SqlCommand comSPM = new SqlCommand("SELECT SUMALL FROM vwEventP WHERE YearPlanId =" + Id, ConSDO.getConnectSDO());
                adapter = new SqlDataAdapter(comSPM);
                datTab = new DataTable();
                adapter.Fill(datTab);
                ConSDO.CloseConnection();
                foreach (DataRow DR in datTab.Rows)
                {
                    tbEventPPas.Text = (DR["SUMALL"].ToString());
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
                SqlCommand comSPM = new SqlCommand("SELECT SUMALL FROM vwEventB WHERE YearPlanId =" + Id, ConSDO.getConnectSDO());
                adapter = new SqlDataAdapter(comSPM);
                datTab = new DataTable();
                adapter.Fill(datTab);
                ConSDO.CloseConnection();
                foreach (DataRow DR in datTab.Rows)
                {
                    tbEventBPas.Text = (DR["SUMALL"].ToString());
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
                SqlCommand comSPM = new SqlCommand("SELECT SUMALL FROM vwPeopP WHERE YearPlanId =" + Id, ConSDO.getConnectSDO());
                adapter = new SqlDataAdapter(comSPM);
                datTab = new DataTable();
                adapter.Fill(datTab);
                ConSDO.CloseConnection();
                foreach (DataRow DR in datTab.Rows)
                {
                    tbPepPPas.Text = (DR["SUMALL"].ToString());
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
                SqlCommand comSPM = new SqlCommand("SELECT SUMALL FROM vwPeopB WHERE YearPlanId =" + Id, ConSDO.getConnectSDO());
                adapter = new SqlDataAdapter(comSPM);
                datTab = new DataTable();
                adapter.Fill(datTab);
                ConSDO.CloseConnection();
                foreach (DataRow DR in datTab.Rows)
                {
                    tbPepPasB.Text = (DR["SUMALL"].ToString());
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
                SqlCommand comSPM = new SqlCommand("SELECT SUMALL FROM vwPalyear WHERE YearPlanId =" + Id, ConSDO.getConnectSDO());
                adapter = new SqlDataAdapter(comSPM);
                datTab = new DataTable();
                adapter.Fill(datTab);
                ConSDO.CloseConnection();
                foreach (DataRow DR in datTab.Rows)
                {
                    tbPlayer.Text = (DR["SUMALL"].ToString());
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Не удалось загрузить данные!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

    }
}
