using ITShopBusinessLogic.BindingModels;
using ITShopBusinessLogic.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ITShopBusinessLogic.Interfaces;
using System.Linq;
using DocumentFormat.OpenXml.Drawing.Charts;

namespace ITShopClientView
{
    public partial class FormCreateOrder : Form
    {        
        private Dictionary<int, (string, int, decimal)> orderProduct;
        public FormCreateOrder()
        {
            InitializeComponent();
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
            if (orderProduct != null && orderProduct.Count < 1)
            {
                MessageBox.Show("В корзине должен быть хотябы один товар", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }            
            try
            {
                APIClient.PostRequest("api/main/createorder", new CreateOrderBindingModel
                {
                    ClientId = Program.Client.Id,
                    DateCreate = DateTime.Now,
                    ReserveDate = DateTime.Now.AddDays(7),
                    OrderProduct = orderProduct,
                    Sum = Convert.ToDecimal(textBoxSumm.Text)
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

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            var form = new FormOrderProduct();
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

        private void buttonUpd_Click(object sender, EventArgs e)
        {
            if (dataGridView.SelectedRows.Count == 1)
            {
                var form = new FormOrderProduct();
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
        private void buttonDel_Click(object sender, EventArgs e)
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
