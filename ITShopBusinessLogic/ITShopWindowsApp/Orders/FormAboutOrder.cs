using ITShopBusinessLogic.BindingModels;
using ITShopBusinessLogic.Interfaces;
using ITShopBusinessLogic.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Unity;

namespace ITShopWindowsApp.Orders
{
    public partial class FormAboutOrder : Form
    {
        [Dependency]
        public new IUnityContainer Container { get; set; }
        public int Id { set { id = value; } }
        private int? id;
        private readonly IOrderLogic orderLogic;
        private Dictionary<int, (string, int, decimal)> orderProduct;
        public FormAboutOrder(IOrderLogic orderLogic)
        {
            InitializeComponent();
            this.orderLogic = orderLogic;
            orderProduct = new Dictionary<int, (string, int, decimal)>();
            dataGridView.Columns.Add("Id", "Id");
            dataGridView.Columns.Add("ProductName", "Продукт");
            dataGridView.Columns.Add("Count", "Количество");
            dataGridView.Columns.Add("ProductPrice", "Цена");
            dataGridView.Columns[0].Visible = false;
            dataGridView.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
        }
        private void FormAboutOrder_Load(object sender, EventArgs e)
        {
            try
            {
                var order = orderLogic.Read(new OrderBindingModel {Id = id.Value }).First();
                orderProduct = order.OrderProducts;
                if(order != null)
                {
                    textBoxClientName.Text = order.ClientFirstName + " " + order.ClientLastName;
                    textBoxSumm.Text = order.Sum.ToString();
                }
                if (orderProduct != null)
                {
                    dataGridView.Rows.Clear();
                    foreach (var pc in orderProduct)
                    {
                        dataGridView.Rows.Add(new object[] { pc.Key, pc.Value.Item1, pc.Value.Item2, pc.Value.Item3 });
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK,
                MessageBoxIcon.Error);
            }
        }
    }
}
