using System;
using System.Collections.Generic;
using System.Text;

namespace ITShopBusinessLogic.Interfaces
{
    public interface IBackUp
    {
        void SaveJson(string folder);
        void SaveXml(string folder);
        void SaveJsonClient(string folder,int clientId);
        void SaveXmlClient(string folder,int clientId);
    }
}
