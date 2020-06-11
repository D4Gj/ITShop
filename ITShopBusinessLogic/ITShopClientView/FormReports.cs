using ITShopBusinessLogic.BindingModels;
using ITShopBusinessLogic.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Windows.Forms;

namespace ITShopClientView
{
    public partial class FormReports : Form
    {
        private List<int?> ids = new List<int?>();
        private string str = "";
        private readonly string pathDocx = "D:\\Products.docx";
        private readonly string pathExcel = "D:\\Products.xlsx";
        private List<OrderViewModel> products = APIClient.GetRequest<List<OrderViewModel>>($"api/main/getorders?clientId={Program.Client.Id}");

        public FormReports()
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
                dataGridView.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                dataGridView.Columns[3].Visible = false;
                dataGridView.Columns[9].Visible = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            ids.Add(Convert.ToInt32(dataGridView.SelectedRows[0].Cells[0].Value));
            foreach (var product in products)
            {
                if (product.Id == Convert.ToInt32(dataGridView.SelectedRows[0].Cells[0].Value))
                {
                    str += product.OrderDate + Environment.NewLine;
                }
            }
            textBox.Text = str;
        }
        private void buttonOk_Click(object sender, EventArgs e)
        {
            

            APIClient.PostRequest($"api/main/docproducts", new ReportBindingModel
            {
                FileName = pathDocx,
                ClientId = Program.Client.Id,
                Orders = ids
            });
            APIClient.PostRequest($"api/main/sendmessage", new ReportBindingModel
            {
                FileName = pathDocx,
                Login = Program.Client.Login
            });
            MessageBox.Show("Выполнено", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        private void buttonOkExcel_Click(object sender, EventArgs e)
        {
            APIClient.PostRequest($"api/main/excelproducts", new ReportBindingModel
            {
                FileName = pathExcel,
                ClientId = Program.Client.Id,
                Orders = ids
            });
            APIClient.PostRequest($"api/main/sendmessage", new ReportBindingModel
            {
                FileName = pathExcel,
                Login = Program.Client.Login
            });
            MessageBox.Show("Выполнено", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
