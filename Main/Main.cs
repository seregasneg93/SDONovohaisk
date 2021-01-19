using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace SDONovohaisk
{
    public partial class MainForm : Form
    {
        SqlDataAdapter adapter;
        DataTable datTab;
        SqlCommand sqlcom;
        string[] NameArray;
        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            vwEvent();
            btnList.Visible = false;
            ActiveDataGridView();
        }

        public void vwEvent()
        {
                try
                {
                 dgvPlanEvent.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                 dgvPlanEvent.AllowUserToAddRows = false;
                ConnectSDO ConSDO = new ConnectSDO();
                ConSDO.OpenConnection();
                SqlCommand comSPM = new SqlCommand("SELECT * FROM vwYearEventt", ConSDO.getConnectSDO());
                adapter = new SqlDataAdapter(comSPM);
                datTab = new DataTable();
                adapter.Fill(datTab);
                ConSDO.CloseConnection();
                dgvPlanEvent.DataSource = datTab;
                dgvPlanEvent.Columns[0].Visible = false;
                dgvPlanEvent.Columns[1].Visible = false;
            }
                catch (Exception)
                {
                    MessageBox.Show("Не удалось загрузить данные!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            btnList.Visible = true;
            ConnectSDO sdo = new ConnectSDO();
            sdo.OpenConnection();           
            SqlCommand comSPM = new SqlCommand("SELECT * FROM vwYearEventt WHERE [Дата начала] = ' " + dtpPlanEvent.Value.ToString("yyy-MM-dd") + "'", sdo.getConnectSDO());
            sdo.OpenConnection();
            adapter = new SqlDataAdapter(comSPM);
            datTab = new DataTable();
            adapter.Fill(datTab);
            sdo.CloseConnection();
            sdo.CloseConnection();
            dgvPlanEvent.DataSource = datTab;
        }

        private void btnList_Click(object sender, EventArgs e)
        {
            btnList.Visible = false;
            vwEvent();
        }

        private void btnCorr_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvPlanEvent.SelectedRows == null)
                {
                    MessageBox.Show("Запись не выбрана!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                else
                {
                    int IdYP = Convert.ToInt32(dgvPlanEvent.Rows[dgvPlanEvent.CurrentRow.Index].Cells[0].Value);
                    string NameEvent = Convert.ToString(dgvPlanEvent.Rows[dgvPlanEvent.CurrentRow.Index].Cells[2].Value);
                    DateTime DataEvent = Convert.ToDateTime(dgvPlanEvent.Rows[dgvPlanEvent.CurrentRow.Index].Cells[5].Value);
                    int QtyEvent = Convert.ToInt32(dgvPlanEvent.Rows[dgvPlanEvent.CurrentRow.Index].Cells[7].Value);
                    int QtyUnit = Convert.ToInt32(dgvPlanEvent.Rows[dgvPlanEvent.CurrentRow.Index].Cells[9].Value);

                    int[] QtyIPKD;

                    QtyIPKD = new int[dgvInfYP.RowCount];
                    for (int i = 0; i < dgvInfYP.RowCount; i++)
                    {
                        QtyIPKD[i] = Convert.ToInt32(dgvInfYP[3, i].Value.ToString());
                    }

                    int[] EventtYear1;
                    EventtYear1 = new int[dgvInfAllEvent.RowCount];
                    for (int i = 0; i < dgvInfAllEvent.RowCount; i++)
                    {
                        EventtYear1[i] = Convert.ToInt32(dgvInfAllEvent[6, i].Value.ToString());
                    }

                    int[] EventtYear2;
                    EventtYear2 = new int[dgvInfQTy.RowCount];
                    for (int i = 0; i < dgvInfQTy.RowCount; i++)
                    {
                        EventtYear2[i] = Convert.ToInt32(dgvInfQTy[6, i].Value.ToString());
                    }

                    this.Hide();
                    EventForm ef = new EventForm(NameEvent, DataEvent,QtyEvent,QtyUnit,QtyIPKD,IdYP,EventtYear1,EventtYear2);
                    ef.ShowDialog();
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Запись не выбрана!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Information);
            } 
        }

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void btnDesc_Click(object sender, EventArgs e)
        {
            DescMainForm dmf = new DescMainForm();
            dmf.ShowDialog();
        }

        private void btnAddEvent_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            AddMainForm amf = new AddMainForm();
            amf.ShowDialog();
        }

        private void btnCorrEvent_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Вы дeйствительно хотите изменить данные?", "Изменение", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    if (dgvPlanEvent.SelectedRows == null)
                    {
                        MessageBox.Show("Запись не выбрана!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                    else
                    {
                        int  IdYP = Convert.ToInt32(dgvPlanEvent.Rows[dgvPlanEvent.CurrentRow.Index].Cells[0].Value);
                        int IdE = Convert.ToInt32(dgvPlanEvent.Rows[dgvPlanEvent.CurrentRow.Index].Cells[1].Value);
                        string NameE = Convert.ToString(dgvPlanEvent.Rows[dgvPlanEvent.CurrentRow.Index].Cells[2].Value);
                        string StatusE = Convert.ToString(dgvPlanEvent.Rows[dgvPlanEvent.CurrentRow.Index].Cells[3].Value);

                        //MessageBox.Show(IdYP.ToString(), IdE.ToString());

                        int[] UnitArray;
                        int[] UnitArray2;
                        string[] UnitArray3;
                        int[] UnitArray4;
                        UnitArray = new int[dgvInfAllEvent.RowCount];
                        UnitArray2 = new int[dgvInfAllEvent.RowCount];
                        UnitArray3 = new string[dgvInfAllEvent.RowCount];
                        UnitArray4 = new int[dgvInfAllEvent.RowCount];
                        for (int i = 0; i < dgvInfAllEvent.RowCount; i++)
                        {
                            UnitArray[i] =  Convert.ToInt32(dgvInfAllEvent[1, i].Value.ToString());
                            UnitArray2[i] = Convert.ToInt32(dgvInfAllEvent[2, i].Value.ToString());
                            UnitArray3[i] = Convert.ToString(dgvInfAllEvent[3, i].Value.ToString());
                            UnitArray4[i] = Convert.ToInt32(dgvInfAllEvent[6, i].Value.ToString());
                            //MessageBox.Show(dgvInfAllEvent[1, i].Value.ToString());
                        }
                        int[] UnitArrayQtyU;
                        int[] UnitArrayQtyU2;
                        int[] UnitArrayQtyU3;
                        UnitArrayQtyU = new int[dgvInfQTy.RowCount];
                        UnitArrayQtyU2 = new int[dgvInfQTy.RowCount];
                        UnitArrayQtyU3 = new int[dgvInfQTy.RowCount];
                        for (int i = 0; i < dgvInfQTy.RowCount; i++)
                        {
                            UnitArrayQtyU[i] = Convert.ToInt32(dgvInfQTy[1, i].Value.ToString());
                            UnitArrayQtyU2[i] = Convert.ToInt32(dgvInfQTy[2, i].Value.ToString());
                            UnitArrayQtyU3[i] = Convert.ToInt32(dgvInfQTy[6, i].Value.ToString());
                            //MessageBox.Show(dgvInfQTy[2, i].Value.ToString());
                        }

                        DateTime dateF = Convert.ToDateTime(dgvPlanEvent.Rows[dgvPlanEvent.CurrentRow.Index].Cells[4].Value);
                        DateTime dateE = Convert.ToDateTime(dgvPlanEvent.Rows[dgvPlanEvent.CurrentRow.Index].Cells[5].Value);
                        this.Hide();
                        UppMainForm umf = new UppMainForm(IdYP, IdE,NameE,StatusE,UnitArray, UnitArray2, UnitArray3, UnitArray4, UnitArrayQtyU, UnitArrayQtyU2, UnitArrayQtyU3, dateF,dateE);
                        umf.ShowDialog();
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

        private void btnDel_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Вы дeйствительно хотите удалить данные?", "Удаление", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                try
                {
                    ConnectSDO sdo = new ConnectSDO();
                    sqlcom = new SqlCommand("spDelYearPlan", sdo.getConnectSDO());
                    sqlcom.CommandType = CommandType.StoredProcedure;
                    sqlcom.Parameters.AddWithValue("@Id", SqlDbType.Int).Value = Convert.ToInt32(dgvPlanEvent.Rows[dgvPlanEvent.CurrentRow.Index].Cells[0].Value);
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

        public void vwInfEventt(int a)
        {
            try
            {
                dgvInfAllEvent.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                dgvInfAllEvent.AllowUserToAddRows = false;
                ConnectSDO ConSDO = new ConnectSDO();
                ConSDO.OpenConnection();
                SqlCommand comSPM = new SqlCommand("SELECT * FROM vwYearPlan3 WHERE IdE = " + a , ConSDO.getConnectSDO());
                adapter = new SqlDataAdapter(comSPM);
                datTab = new DataTable();
                adapter.Fill(datTab);
                ConSDO.CloseConnection();
                dgvInfAllEvent.DataSource = datTab;
                dgvInfAllEvent.Columns[0].Visible = false;
                dgvInfAllEvent.Columns[1].Visible = false;
                dgvInfAllEvent.Columns[2].Visible = false;
            }
            catch (Exception)
            {
                MessageBox.Show("Не удалось загрузить данные!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void dgvPlanEvent_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int a1 = Convert.ToInt32(dgvPlanEvent.Rows[dgvPlanEvent.CurrentRow.Index].Cells[1].Value);

            vwInfEventt(a1);
            vwInfEventt2(a1);
            vwInfEventt3(a1);
        }

        public void vwInfEventt2(int a)
        {
            try
            {
                dgvInfYP.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                dgvInfYP.AllowUserToAddRows = false;
                ConnectSDO ConSDO = new ConnectSDO();
                ConSDO.OpenConnection();
                SqlCommand comSPM = new SqlCommand("SELECT * FROM vwYearPlan1 WHERE IdE = " + a, ConSDO.getConnectSDO());
                adapter = new SqlDataAdapter(comSPM);
                datTab = new DataTable();
                adapter.Fill(datTab);
                ConSDO.CloseConnection();
                dgvInfYP.DataSource = datTab;
                dgvInfYP.Columns[0].Visible = false;
            }
            catch (Exception)
            {
                MessageBox.Show("Не удалось загрузить данные!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        public void vwInfEventt3(int a)
        {
            try
            {
                dgvInfQTy.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                dgvInfQTy.AllowUserToAddRows = false;
                ConnectSDO ConSDO = new ConnectSDO();
                ConSDO.OpenConnection();
                SqlCommand comSPM = new SqlCommand("SELECT * FROM vwInfYearPlan2 WHERE IdE = " + a, ConSDO.getConnectSDO());
                adapter = new SqlDataAdapter(comSPM);
                datTab = new DataTable();
                adapter.Fill(datTab);
                dgvInfQTy.DataSource = datTab;
                ConSDO.CloseConnection();
                dgvInfQTy.Columns[0].Visible = false;
                dgvInfQTy.Columns[1].Visible = false;
                dgvInfQTy.Columns[2].Visible = false;
            }
            catch (Exception)
            {
                MessageBox.Show("Не удалось загрузить данные!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        public void ActiveDataGridView()
        {
            this.ActiveControl = dgvPlanEvent;
            dgvPlanEvent.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            if (dgvPlanEvent.Rows.Count > 0)
            {
                dgvPlanEvent.Rows[0].Selected = true;
            }
            this.WindowState = FormWindowState.Maximized;
        }

        private void dgvInfYP_ColumnAdded(object sender, DataGridViewColumnEventArgs e)
        {
            dgvInfYP.Columns[e.Column.Index].SortMode = DataGridViewColumnSortMode.NotSortable;
        }

        private void dgvPlanEvent_ColumnAdded(object sender, DataGridViewColumnEventArgs e)
        {
            dgvPlanEvent.Columns[e.Column.Index].SortMode = DataGridViewColumnSortMode.NotSortable;
        }

        private void dgvInfAllEvent_ColumnAdded(object sender, DataGridViewColumnEventArgs e)
        {
            dgvInfAllEvent.Columns[e.Column.Index].SortMode = DataGridViewColumnSortMode.NotSortable;
        }

        private void dgvInfQTy_ColumnAdded(object sender, DataGridViewColumnEventArgs e)
        {
            dgvInfQTy.Columns[e.Column.Index].SortMode = DataGridViewColumnSortMode.NotSortable;
        }
    }
}
