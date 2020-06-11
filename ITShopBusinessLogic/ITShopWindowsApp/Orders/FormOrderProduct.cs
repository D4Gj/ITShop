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

namespace ITShopWindowsApp.Orders
{
    public partial class FormOrderProduct : Form
    {
        private readonly IProductLogic productLogic;
        public int Id
        {
            get { return Convert.ToInt32(comboBoxProduct.SelectedValue); }
            set { comboBoxProduct.SelectedValue = value; }
        }
        public string ProductName { get { return comboBoxProduct.Text; } }

        public decimal Sum
        {
            get { return Convert.ToDecimal(textBoxSum.Text); }
        }

        private void CalcSumm()
        {
            if (comboBoxProduct.SelectedValue != null && !string.IsNullOrEmpty(textBoxCount.Text))
            {
                try
                {
                    int id = Convert.ToInt32(comboBoxProduct.SelectedValue);
                    ProductViewModel product = productLogic.Read(new ProductBindingModel
                    {
                        Id = id
                    })?[0];
                    int count = Convert.ToInt32(textBoxCount.Text);
                    textBoxSum.Text = (count * product?.Price ?? 0).ToString();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK,
                   MessageBoxIcon.Error);
                }
            }
        }
        
        public int Count
        {
            get { return Convert.ToInt32(textBoxCount.Text); }
            set
            {
                textBoxCount.Text = value.ToString();
                CalcSumm();
            }
        }
        public FormOrderProduct(IProductLogic logic)
        {
            InitializeComponent();
            productLogic = logic;
            List<ProductViewModel> list = logic.Read(null);
            if (list != null)
            {
                comboBoxProduct.DisplayMember = "ProductName";
                comboBoxProduct.ValueMember = "Id";
                comboBoxProduct.DataSource = list;
                comboBoxProduct.SelectedItem = null;
            }
        }
        private void ButtonSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBoxCount.Text))
            {
                MessageBox.Show("Заполните поле Количество", "Ошибка",
               MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (comboBoxProduct.SelectedValue == null)
            {
                MessageBox.Show("Выберите продукт", "Ошибка", MessageBoxButtons.OK,
               MessageBoxIcon.Error);
                return;
            }
            DialogResult = DialogResult.OK;
            Close();
        }
        private void ButtonCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void ComboBoxProduct_SelectedIndexChanged(object sender, EventArgs e)
        {
            CalcSumm();
        }

        private void TextBoxCount_TextChanged(object sender, EventArgs e)
        {
            CalcSumm();
        }
    }
}
