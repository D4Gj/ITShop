﻿using System;
using System.Collections.Generic;
using System.Text;
using ITShopBusinessLogic.ViewModels;

namespace ITShopBusinessLogic.BindingModels
{
    public class ReportBindingModel
    {
        public string FileName { get; set; }
        public int ClientId { get; set; }
        public List<int> ProductsId { get; set; }
        public List<int> Orders { get; set; }
        public string Login { get; set; }
    }
}
