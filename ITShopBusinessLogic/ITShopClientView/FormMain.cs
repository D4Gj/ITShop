using ITShopBusinessLogic.BindingModels;
using ITShopBusinessLogic.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ITShopClientView
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();
            LoadList();
        }
        private void LoadList()
        {
            try
            {
                dataGridView.DataSource = APIClient.GetRequest<List<OrderViewModel>>($"api/main/getorders?clientId={Program.Client.Id}");

                dataGridView.Columns[0].Visible = false;
                dataGridView.Columns[1].Visible = false;
                dataGridView.Columns[2].Visible = false;
                dataGridView.Columns[9].Visible = false;
                dataGridView.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void UpdateDataToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = new FormUpdateData();
            form.ShowDialog();
        }

        private void CreateOrderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = new FormCreateOrder();

            if (form.ShowDialog() == DialogResult.OK)
            {
                LoadList();
            }
        }

        private void RefreshOrderListToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LoadList();
        }
        private void сообщенияToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = new FormReports();
            if (form.ShowDialog() == DialogResult.OK)
            {
                LoadList();
            }
        }
        private void отчётПоЗаказамToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = new FormReportOrders();
            if (form.ShowDialog() == DialogResult.OK)
            {
                LoadList();
            }
        }
        private void ДанныеОЗаказеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataGridView.SelectedRows.Count == 1)
                {
                    var form = new FormAboutOrder();
                    int id = Convert.ToInt32(dataGridView.SelectedRows[0].Cells[0].Value);
                    form.Id = id;
                    if (form.ShowDialog() == DialogResult.OK)
                    {
                        LoadList();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void xmlBackupToolStripMenuItem_Click(object sender, EventArgs e)
        {
            APIClient.PostRequest($"api/main/saveXml", new ReportBindingModel
            {
                FileName = "",
                ClientId = Program.Client.Id,
            });
            APIClient.PostRequest($"api/main/sendmessage", new ReportBindingModel
            {
                FileName = "",
                Login = Program.Client.Login
            });
            MessageBox.Show("Выполнено", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void jsonBackupToolStripMenuItem_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }
    }
}
