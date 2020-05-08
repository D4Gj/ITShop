using ITShopBusinessLogic.BusinessLogic;
using ITShopBusinessLogic.Interfaces;
using ITShopWindowsApp.Orders;
using ITShopWindowsApp.Client;
using ITShopWindowsApp.Product;
using ITShopWindowsApp.Component;
using System;
using System.Windows.Forms;
using Unity;

namespace ITShopWindowsApp
{
    public partial class FormMain : Form
    {
        [Dependency]
        public new IUnityContainer Container { get; set; }
        private readonly MainLogic logic;
        private readonly IOrderLogic orderLogic;
        public FormMain(MainLogic logic, IOrderLogic orderLogic)
        {
            InitializeComponent();
            this.logic = logic;
            this.orderLogic = orderLogic;
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
            var form = Container.Resolve<FormProduct>();
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
    }
}
