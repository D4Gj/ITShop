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
        private readonly IClientLogic logicC;
        private readonly IOrderLogic logicO;
        private readonly MainLogic logicM;
        private readonly Dictionary<int, (string, int, decimal)> orderProduct;
        public FormCreateOrder(MainLogic logicM, IClientLogic logicC, IOrderLogic logicO)
        {
            InitializeComponent();
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
                    comboBoxClient.DisplayMember = "Login";
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
                    textBoxSumm.Text = orderProduct.Sum(x => x.Value.Item3).ToString();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK,
                   MessageBoxIcon.Error);
                }
            }
        }

        private void ComboBoxProduct_SelectedIndexChanged(object sender, EventArgs e)
        {
            CalcSum();
        }

        private void TextBoxCount_TextChanged(object sender, EventArgs e)
        {
            CalcSum();
        }

        private void ButtonCreateOrder_Click(object sender, EventArgs e)
        {
            if (orderProduct != null && orderProduct.Count < 1)
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
                    OrderProduct = orderProduct,
                    Sum = Convert.ToDecimal(textBoxSumm.Text),
                    ClientId = Convert.ToInt32(comboBoxClient.SelectedValue),
                });

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

        private void ButtonCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void ButtonAdd_Click(object sender, EventArgs e)
        {
            var form = Container.Resolve<FormOrderProduct>();
            if (form.ShowDialog() == DialogResult.OK)
            {
                if (orderProduct.ContainsKey(form.Id))
                {
                    orderProduct[form.Id] = (form.ProductName, form.Count, form.Sum);
                }
                else
                {
                    orderProduct.Add(form.Id, (form.ProductName, form.Count, form.Sum));
                }
                LoadData();
                CalcSum();
            }
           
        }

        private void ButtonUpd_Click(object sender, EventArgs e)
        {
            if (dataGridView.SelectedRows.Count == 1)
            {
                var form = Container.Resolve<FormOrderProduct>();
                int id = Convert.ToInt32(dataGridView.SelectedRows[0].Cells[0].Value);
                int count = Convert.ToInt32(dataGridView.SelectedRows[0].Cells[2].Value);
                form.Id = id;
                form.Count = count;
                if (form.ShowDialog() == DialogResult.OK)
                {
                    orderProduct[form.Id] = (form.ProductName, form.Count, form.Sum);
                    LoadData();
                }
            }
        }
        private void ButtonDel_Click(object sender, EventArgs e)
        {
            if (dataGridView.SelectedRows.Count == 1)
            {
                if (MessageBox.Show("Удалить запись", "Вопрос", MessageBoxButtons.YesNo,
               MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    try
                    {
                        orderProduct.Remove(Convert.ToInt32(dataGridView.SelectedRows[0].Cells[0].Value));
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK,
                       MessageBoxIcon.Error);
                    }
                    LoadData();
                }
            }
        }
        private void LoadData()
        {
            try
            {
                if (orderProduct != null)
                {
                    dataGridView.Rows.Clear();
                    foreach (var pc in orderProduct)
                    {
                        dataGridView.Rows.Add(new object[] { pc.Key, pc.Value.Item1, pc.Value.Item2 ,pc.Value.Item3});
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
