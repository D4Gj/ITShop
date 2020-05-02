using System;
using System.Collections.Generic;
using System.Text;

namespace ITShopBusinessLogic.Enums
{
    public enum OrderStatus
    {
        // По нашей диограмме нет статуса
        Принят = 0,
        Выполняется = 1,
        Готов = 2,
        Оплачен = 3
    }
}
