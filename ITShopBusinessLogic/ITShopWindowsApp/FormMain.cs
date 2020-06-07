using ITShopBusinessLogic.BusinessLogic;
using ITShopBusinessLogic.Interfaces;
using ITShopWindowsApp.Orders;
using ITShopWindowsApp.Client;
using ITShopWindowsApp.Product;
using ITShopWindowsApp.Component;
using System;
using System.Windows.Forms;
using Unity;
using ITShopWindowsApp.Request;
using ITShopBusinessLogic.BindingModels;
using ITShopWindowsApp.Report;

namespace ITShopWindowsApp
{
    public partial class FormMain : Form
    {
        [Dependency]
        public new IUnityContainer Container { get; set; }
        private readonly MainLogic logic;
        private readonly IOrderLogic orderLogic;
        private readonly ReportLogic reportLogic;
        public FormMain(MainLogic logic, IOrderLogic orderLogic,ReportLogic reportLogic)
        {
            InitializeComponent();
            this.logic = logic;
            this.orderLogic = orderLogic;
            this.reportLogic = reportLogic;
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void LoadData()
        {
            try
            {
                var list = orderLogic.Read(null);
                if (list != null)
                {
                    dataGridView.DataSource = list;
                    dataGridView.Columns[0].Visible = false;
                    dataGridView.Columns[1].Visible = false;
                    dataGridView.Columns[2].Visible = false;
                    dataGridView.Columns[9].Visible = false;
                    dataGridView.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonCreateOrder_Click(object sender, EventArgs e)
        {
            var form = Container.Resolve<FormCreateOrder>();
            form.ShowDialog(); 
            LoadData();
        }

        private void КомпонентыToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = Container.Resolve<FormComponents>();
            form.ShowDialog();
        }

        private void изделияToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = Container.Resolve<FormProducts>();
            form.ShowDialog();
        }

        private void клиентыToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = Container.Resolve<FormClient>();
            form.ShowDialog();
        }

        private void buttonUpd_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        private void запросыToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = Container.Resolve<FormRequests>();
            form.ShowDialog();
        }

        private void buttonInfo_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataGridView.SelectedRows.Count == 1)
                {
                    var form = Container.Resolve<FormAboutOrder>();
                    int id = Convert.ToInt32(dataGridView.SelectedRows[0].Cells[0].Value);
                    form.Id = id;
                    if (form.ShowDialog() == DialogResult.OK)
                    {
                        LoadData();
                    }
                }
            } 
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);  
            }
        }

        private void buttonFinalOrder_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataGridView.SelectedRows.Count == 1)
                {                  
                    logic.TookOrder(new DateRecordingInOrderBindingModel(){
                        OrderId = Convert.ToInt32(dataGridView.SelectedRows[0].Cells[0].Value),
                    });
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void движениеКомпонентовToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = Container.Resolve<FormReportPdf>();
            form.ShowDialog();
        }

        private void запросВФорматеWordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (var dialog = new SaveFileDialog { Filter = "docx|*.docx" })
            {
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    reportLogic.RequestInWord(new ReportBindingModel
                    {
                        FileName = dialog.FileName,
                        RequestId = 9,
                    });
                    MessageBox.Show("Выполнено", "Успех", MessageBoxButtons.OK,
                   MessageBoxIcon.Information);
                }
            }
        }
    }
}
