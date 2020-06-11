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
    public partial class FormRegister : Form
    {
        public FormRegister()
        {
            InitializeComponent();
        }
        private void ButtonRegister_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(textBoxEmail.Text) && !string.IsNullOrEmpty(textBoxPassword.Text) 
                && !string.IsNullOrEmpty(textBoxFirstName.Text) && !string.IsNullOrEmpty(textBoxLastName.Text))
            {
                try
                {
                    APIClient.PostRequest("api/client/register", new ClientBindingModel
                    {
                        FirstName = textBoxFirstName.Text,
                        LastName = textBoxLastName.Text,
                        Phone = textBoxPhone.Text,
                        Login = textBoxEmail.Text,
                        Password = textBoxPassword.Text
                    });

                    MessageBox.Show("Регистрация прошла успешно", "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
        private void buttonCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
