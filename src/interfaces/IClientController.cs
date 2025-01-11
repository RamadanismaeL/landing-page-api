using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using landing_page_api.src.models;
using Microsoft.AspNetCore.Mvc;
/**
** @author Ramadan Ismael
*/
namespace landing_page_api.src.interfaces
{
    public interface IClientController
    {
        Task<ActionResult<ClientModel>> Create([FromBody] ClientModel clientModel);
        Task<ActionResult<List<ClientModel>>> ReadAll();
        Task<ActionResult<ClientModel>> Update([FromBody] ClientModel clientModel, int id);
        Task<ActionResult<ClientModel>> Delete(int id);
        Task<ActionResult<ClientModel>> FintdByID(int id);
    }
}