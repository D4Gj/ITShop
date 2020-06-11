using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ITShopBusinessLogic.ViewModels;
using ITShopBusinessLogic.BindingModels;
using iTextSharp.text.pdf.parser;

namespace ITShopClientView
{
    public partial class FormReportOrders : Form
    {
        public FormReportOrders()
        {
            InitializeComponent();
        }
        private void Form_Load(object sender, EventArgs e)
        {
            List<int?> ids = new List<int?>();
            var deals = APIClient.GetRequest<List<OrderViewModel>>($"api/main/getOrders?clientId={Program.Client.Id}");
            foreach (var order in deals)
            {
                if (order.TookDate != null)
                {
                    ids.Add(order.Id);
                }
            }
            APIClient.PostRequest($"api/main/OrdersDone", new ReportBindingModel
            {
                FileName = "D:\\Orders.pdf",
                ClientId = Program.Client.Id,
                Orders = ids
            });
            try
            {
                pdfWindow.src = "D:\\Orders.pdf";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK,
               MessageBoxIcon.Error);
            }
        }
        private void buttonSend_Click(object sender, EventArgs e)
        {
            List<int?> ids = new List<int?>();
            var deals = APIClient.GetRequest<List<OrderViewModel>>($"api/main/getOrders?clientId={Program.Client.Id}");
            foreach (var deal in deals)
            {
                if (deal.TookDate != null)
                {
                    ids.Add(deal.Id);
                }
            }
            APIClient.PostRequest($"api/main/OrdersDone", new ReportBindingModel
            {
                FileName = "D:\\Orders.pdf",
                ClientId = Program.Client.Id,
                Orders = ids
            });
            APIClient.PostRequest($"api/main/sendmessage", new ReportBindingModel
            {
                FileName = "D:\\Orders.pdf",
                Login = Program.Client.Login
            });
            MessageBox.Show("Выполнено", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
