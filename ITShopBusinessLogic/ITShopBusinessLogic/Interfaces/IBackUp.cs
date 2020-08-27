using System;
using System.Collections.Generic;
using System.Text;
using ITShopBusinessLogic.BindingModels;

namespace ITShopBusinessLogic.Interfaces
{
    public interface IBackUp
    {
        void SaveJson(string folder);
        void SaveXml(string folder);
        void SaveJsonClient(BackupBindingModel model);
        void SaveXmlClient(BackupBindingModel model);
    }
}
