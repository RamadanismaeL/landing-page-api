using landing_page_api.src.data;
using landing_page_api.src.interfaces;
using landing_page_api.src.models;
using Microsoft.EntityFrameworkCore;
/**
** @author Ramadan Ismael
*/
namespace landing_page_api.src.configs
{
    public class ClientConfig(Contextdb contextdb) : IClientConfig
    {
        private readonly Contextdb _contextdb = contextdb;

        public async Task<ClientModel> Create(ClientModel clientModel)
        {
            await _contextdb.Clients.AddAsync( clientModel );
            await _contextdb.SaveChangesAsync();
            return clientModel;
        }

        public async Task<List<ClientModel>> ReadAll()
        {
            return await _contextdb.Clients.ToListAsync();
        }

        public async Task<ClientModel> Update(ClientModel clientModel, int id)
        {
            ClientModel clientID = await FindByID(id) ?? throw new KeyNotFoundException($"Contact with ID : {id}, not found.");
            clientID.Name = clientModel.Name;
            clientID.Email = clientModel.Email;
            _contextdb.Clients.Update(clientID);
            await _contextdb.SaveChangesAsync();
            return clientID;
        }

        public async Task<bool> Delete(int id)
        {
            ClientModel clientID = await FindByID(id) ?? throw new KeyNotFoundException($"Contact with ID : {id}, not found.");
            _contextdb.Clients.Remove(clientID);
            await _contextdb.SaveChangesAsync();
            return true;
        }

        public async Task<ClientModel> FindByID(int id)
        {
            return await _contextdb.Clients.FirstOrDefaultAsync(c => c.Id == id) ?? throw new KeyNotFoundException($"{id} is not registered.");
        }
    }
}