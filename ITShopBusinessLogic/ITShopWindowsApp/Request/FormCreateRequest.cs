using ITShopBusinessLogic.BindingModels;
using ITShopBusinessLogic.BusinessLogic;
using ITShopBusinessLogic.Interfaces;
using ITShopBusinessLogic.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using Unity;

namespace ITShopWindowsApp.Request
{
    public partial class FormCreateRequest : Form
    {
        [Dependency]
        public new IUnityContainer Container { get; set; }
        public int Id { set { id = value; } }
        private readonly IRequestLogic logic;
        private readonly MainLogic mainLogic;
        private int? id;
        private Dictionary<int, (string, int, int)> requestComponents;
        public FormCreateRequest(IRequestLogic logic,MainLogic mainLogic)
        {
            
            InitializeComponent();
            this.logic = logic;
            this.mainLogic = mainLogic;
            dataGridView.Columns.Add("Id", "Id");
            dataGridView.Columns.Add("ComponentName", "Компонент");
            dataGridView.Columns.Add("Count", "Заказано");
            dataGridView.Columns.Add("Left", "Осталось");
            dataGridView.Columns[0].Visible = false;
            dataGridView.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
        }
        private void FormProduct_Load(object sender, EventArgs e)
        {
            if (id.HasValue)
            {
                try
                {
                    RequestViewModel view = logic.Read(new RequestBindingModel
                    {
                        Id = id.Value
                    })?[0];
                    if (view != null)
                    {
                        textBoxName.Text = view.RequestName;
                        requestComponents = view.RequestComponents;
                        LoadData();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK,
                   MessageBoxIcon.Error);
                }
            }
            else
            {
                requestComponents = new Dictionary<int, (string, int, int)>();
            }
        }
        private void LoadData()
        {
            try
            {
                if (requestComponents != null)
                {
                    dataGridView.Rows.Clear();
                    foreach (var pc in requestComponents)
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

        private void ButtonAdd_Click(object sender, EventArgs e)
        {
            var form = Container.Resolve<FormRequestComponent>();
            if (form.ShowDialog() == DialogResult.OK)
            {
                if (requestComponents.ContainsKey(form.Id))
                {
                    requestComponents[form.Id] = (form.ComponentName, form.Count,form.Count);
                }
                else
                {
                    requestComponents.Add(form.Id, (form.ComponentName, form.Count,form.Count));
                }
                LoadData();
            }
        }

        private void ButtonUpd_Click(object sender, EventArgs e)
        {
            if (dataGridView.SelectedRows.Count == 1)
            {
                var form = Container.Resolve<FormRequestComponent>();
                int id = Convert.ToInt32(dataGridView.SelectedRows[0].Cells[0].Value);
                form.Id = id;
                form.Count = requestComponents[id].Item2;
                if (form.ShowDialog() == DialogResult.OK)
                {
                    requestComponents[form.Id] = (form.ComponentName, form.Count, form.Count);
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
                        requestComponents.Remove(Convert.ToInt32(dataGridView.SelectedRows[0].Cells[0].Value));
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

        private void ButtonRef_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        private void ButtonSave_Click(object sender, EventArgs e)
        {
            if (radioButtonWord.Checked==false && radioButtonExel.Checked == false)
            {
                MessageBox.Show("Выберите формат письма", "Ошибка", MessageBoxButtons.OK,
               MessageBoxIcon.Error);
                return;
            }
            if (string.IsNullOrEmpty(textBoxName.Text))
            {
                MessageBox.Show("Заполните название", "Ошибка", MessageBoxButtons.OK,
               MessageBoxIcon.Error);
                return;
            }
            if (requestComponents == null || requestComponents.Count == 0)
            {
                MessageBox.Show("Заполните компоненты", "Ошибка", MessageBoxButtons.OK,
               MessageBoxIcon.Error);
                return;
            }
            if (!Regex.IsMatch(textBoxMail.Text, @"^([\w.-]+)@([\w-]+)((.(\w){2,3})+)$")) {
                MessageBox.Show("Почта указана некоректно", "Ошибка", MessageBoxButtons.OK,
               MessageBoxIcon.Error);
            }
            try
            {
                logic.CreateOrUpdate(new RequestBindingModel
                {
                    Id = id,
                    RequestName = textBoxName.Text,
                    RequestComponents = requestComponents,
                    RequestDate = DateTime.Now,
                });
                mainLogic.SendRequest(logic.Read(null).Where(x => x.RequestName == textBoxName.Text).FirstOrDefault().Id, textBoxMail.Text, radioButtonExel.Checked, radioButtonWord.Checked);
                MessageBox.Show("Сохранение прошло успешно", "Сообщение",
               MessageBoxButtons.OK, MessageBoxIcon.Information);
                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK,
               MessageBoxIcon.Error);
            }
        }

        private void ButtonCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void RadioButtonWord_Click(object sender, EventArgs e)
        {
            radioButtonExel.Checked = false;
        }

        private void RadioButtonExel_Click(object sender, EventArgs e)
        {
            radioButtonWord.Checked = false;
        }
    }
}
