using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace ITShopBusinessLogic.ViewModels
{
    public class ClientViewModel
    {
        [DisplayName("Идентификатор Клиента")]
        public int Id { get; set; }
        [DisplayName("Имя")]
        public string FirstName { get; set; }
        [DisplayName("Фамилия")]
        public string LastName { get; set; }
        [DisplayName("Логин")]
        public string Login { get; set; }
        [DisplayName("Пароль")]
        public string Password { get; set; }
    }
}
