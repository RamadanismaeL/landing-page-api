using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using landing_page_api.src.models;
/**
** @author Ramadan Ismael
*/
namespace landing_page_api.src.interfaces
{
    public interface IClientConfig
    {
        Task<ClientModel> Create(ClientModel clientModel);
        Task<List<ClientModel>> ReadAll();
        Task<ClientModel> Update(ClientModel clientModel, int id);
        Task<bool> Delete(int id);
        Task<ClientModel> FindByID(int id);
    }
}