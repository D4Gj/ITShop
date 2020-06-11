using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ITShopBusinessLogic.BindingModels;

namespace ITShopClientView
{
    public partial class FormUpdateData : Form
    {
        public FormUpdateData()
        {
            InitializeComponent();
            textBoxClientLastName.Text = Program.Client.LastName;
            textBoxEmail.Text = Program.Client.Login;
            textBoxPassword.Text = Program.Client.Password;
            textBoxFirstname.Text = Program.Client.FirstName;
            textBoxPhone.Text = Program.Client.Phone;
        }
        private void ButtonUpdate_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(textBoxEmail.Text) && !string.IsNullOrEmpty(textBoxPassword.Text) && !string.IsNullOrEmpty(textBoxClientLastName.Text)
                && !string.IsNullOrEmpty(textBoxFirstname.Text))
            {
                try
                {
                    APIClient.PostRequest($"api/client/updatedata", new ClientBindingModel()
                    {
                        Id = Program.Client.Id,
                        LastName = textBoxClientLastName.Text,
                        Login = textBoxEmail.Text,
                        Password = textBoxPassword.Text,
                        FirstName= textBoxFirstname.Text,
                        Phone = textBoxPhone.Text
                    });
                    MessageBox.Show("Обновление прошло успешно", "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Program.Client.LastName = textBoxClientLastName.Text;
                    Program.Client.Login = textBoxEmail.Text;
                    Program.Client.Password = textBoxPassword.Text;
                    Program.Client.FirstName = textBoxFirstname.Text;
                    Program.Client.Phone = textBoxPhone.Text;
                    Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Введите логин, пароль и ФИО", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
