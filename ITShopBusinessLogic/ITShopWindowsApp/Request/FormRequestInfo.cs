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

namespace ITShopWindowsApp.Request
{
    public partial class FormRequestInfo : Form
    {
        [Dependency]
        public new IUnityContainer Container { get; set; }
        public int Id { set { id = value; } }
        private readonly IRequestLogic logic;
        private int? id;
        private Dictionary<int, (string, int, int)> requestComponents;
        public FormRequestInfo(IRequestLogic logic)
        {
            InitializeComponent();
            this.logic = logic;
            dataGridView.Columns.Add("Id", "Id");
            dataGridView.Columns.Add("ComponentName", "Компонент");
            dataGridView.Columns.Add("Count", "Заказано");
            dataGridView.Columns.Add("Left", "Осталось");
            dataGridView.Columns[0].Visible = false;
            dataGridView.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
        }
        private void FormRequestInfo_Load(object sender, EventArgs e)
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
    }
}
