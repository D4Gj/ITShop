using ITShopBusinessLogic.BindingModels;
using ITShopBusinessLogic.BusinessLogic;
using ITShopBusinessLogic.Interfaces;
using ITShopBusinessLogic.ViewModels;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Windows.Forms;
using Unity;

namespace ITShopWindowsApp.Orders
{
    public partial class FormCreateOrder : Form
    {
        [Dependency]
        public new IUnityContainer Container { get; set; }
        public int Id { set { id = value; } }
        private int? id;
        private readonly IProductLogic logicP;
        private readonly IClientLogic logicC;
        private readonly IOrderLogic logicO;
        private readonly MainLogic logicM;
        private Dictionary<int, (string, int, decimal)> orderProduct;
        public FormCreateOrder(IProductLogic logicP, MainLogic logicM, IClientLogic logicC, IOrderLogic logicO)
        {
            InitializeComponent();
            this.logicP = logicP;
            this.logicM = logicM;
            this.logicC = logicC;
            this.logicO = logicO;
            orderProduct = new Dictionary<int, (string, int, decimal)>();
            dataGridView.Columns.Add("Id", "Id");
            dataGridView.Columns.Add("ProductName", "Продукт");
            dataGridView.Columns.Add("Count", "Количество");
            dataGridView.Columns.Add("ProductPrice", "Цена");
            dataGridView.Columns[0].Visible = false;
            dataGridView.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
        }

        private void FormCreateOrder_Load(object sender, EventArgs e)
        {
            try
            {
                List<ClientViewModel> listC = logicC.Read(null);
                if (listC != null)
                {
                    comboBoxClient.DisplayMember = "FirstName LastName";
                    comboBoxClient.ValueMember = "Id";
                    comboBoxClient.DataSource = listC;
                    comboBoxClient.SelectedItem = null;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void CalcSum()
        {
            if (orderProduct != null && orderProduct.Count > 0)
            {
                try
                {
                    textBoxCount.Text = orderProduct.Sum(x => x.Value.Item3).ToString();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK,
                   MessageBoxIcon.Error);
                }
            }
        }

        private void comboBoxProduct_SelectedIndexChanged(object sender, EventArgs e)
        {
            CalcSum();
        }

        private void textBoxCount_TextChanged(object sender, EventArgs e)
        {
            CalcSum();
        }

        private void buttonCreateOrder_Click(object sender, EventArgs e)
        {
            if (orderProduct != null && orderProduct.Count > 0)
            {
                MessageBox.Show("В корзине должен быть хотябы один товар", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (comboBoxClient.SelectedValue == null)
            {
                MessageBox.Show("Выберите клиента", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            try
            {
                logicM.CreateOrder(new CreateOrderBindingModel
                {
                    ReserveDate = DateTime.Now.AddDays(4),
                    DateCreate = DateTime.Now,
                    OrderProduct = orderProduct,
                    Sum = Convert.ToDecimal(textBoxSumm.Text),
                    ClientId = Convert.ToInt32(comboBoxClient.SelectedValue)
                }) ;
                MessageBox.Show("Сохранение прошло успешно", "Сообщение",
               MessageBoxButtons.OK, MessageBoxIcon.Information);
                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
