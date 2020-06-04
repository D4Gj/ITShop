using ITShopBusinessLogic.BindingModels;
using ITShopBusinessLogic.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Windows.Forms;

namespace ITShopClientView
{
    public partial class FormReports : Form
    {
        private List<int> ids = new List<int>();
        private string str = "";
        private List<ProductViewModel> products = APIClient.GetRequest<List<ProductViewModel>>($"api/main/getproductlist");

        public FormReports()
        {
            InitializeComponent();
            LoadList();
        }
        private void LoadList()
        {
            try
            {
                dataGridView.DataSource = APIClient.GetRequest<List<ProductViewModel>>($"api/main/getproductlist");
                //dataGridView.Columns[0].Visible = false;
                //dataGridView.Columns[1].Visible = false;
                dataGridView.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                //dataGridView.Columns[3].Visible = true;
                //dataGridView.Columns[5].Visible = false;
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
                    str += product.ProductName + Environment.NewLine;
                }
            }
            textBox.Text = str;
        }
        private void buttonOk_Click(object sender, EventArgs e)
        {
            
            APIClient.PostRequest($"api/main/docproducts", new ReportBindingModel
            {
                FileName = "D:\\Products.docx",
                ClientId = Program.Client.Id,
                ProductsId = ids
            });
            MessageBox.Show("Выполнено", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
            // отправитель - устанавливаем адрес и отображаемое в письме имя
            MailAddress from = new MailAddress("labwork15kafis@gmail.com");
            // кому отправляем
            MailAddress to = new MailAddress("inzadimonax@gmail.com");
            // создаем объект сообщения
            MailMessage m = new MailMessage(from, to);
            m.Attachments.Add(new Attachment("D:\\Products.docx"));
            // письмо представляет код html
            m.IsBodyHtml = true;
            // адрес smtp-сервера и порт, с которого будем отправлять письмо
            SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587);
            // логин и пароль
            smtp.Credentials = new NetworkCredential("labwork15kafis@gmail.com", "passlab15");
            smtp.EnableSsl = true;
            smtp.Send(m);
        }
    }
}
