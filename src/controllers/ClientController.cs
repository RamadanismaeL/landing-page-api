using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using landing_page_api.src.interfaces;
using landing_page_api.src.models;
using Microsoft.AspNetCore.Mvc;
/**
** @author Ramadan Ismael
*/
namespace landing_page_api.src.controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ClientController(IClientConfig clientConfig, ILogger<ClientController> logger) : ControllerBase, IClientController
    {
        private readonly IClientConfig _clientConfig = clientConfig;
        private readonly ILogger<ClientController> _logger = logger;

        [Route("/api/client/create")]
        [HttpPost]
        public async Task<ActionResult<ClientModel>> Create([FromBody] ClientModel clientModel)
        {
             try
            {
                if(!ModelState.IsValid) return BadRequest(ModelState);
                ClientModel _clientModel = await _clientConfig.Create(clientModel);
                return Ok(_clientModel);
            }
            catch(Exception error)
            {
                _logger.LogError(error, "An error occured!");
                return StatusCode(400, "Error Message");
            }
        }

        [Route("/api/client/readAll")]
        [HttpGet]
        public async Task<ActionResult<List<ClientModel>>> ReadAll()
        {
            try
            {
                var clientModel = await _clientConfig.ReadAll();
                return Ok(clientModel);
            }
            catch(Exception error)
            {
                _logger.LogError(error, "An error occured!");
                return StatusCode(401, "Error Message");
            }
        }

        [HttpPut]
        public async Task<ActionResult<ClientModel>> Update([FromBody] ClientModel clientModel, int id)
        {
            try
            {
                if(!ModelState.IsValid) return BadRequest(ModelState);
                var clientID = await _clientConfig.FindByID(id);
                if(clientID == null) return NotFound($"Client with ID {id} not found.");
                ClientModel _client = await _clientConfig.Update(clientModel, id);
                return Ok(_client);
            }
            catch(Exception error)
            {
                _logger.LogError(error, "An error occured!");
                return StatusCode(402, "Error Message");
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<ClientModel>> Delete(int id)
        {
            try
            {
                if(!ModelState.IsValid) return BadRequest(ModelState);
                var clientID = await _clientConfig.FindByID(id);
                if(clientID == null) return NotFound($"Client with ID {id} not found.");
                await _clientConfig.Delete(id);
                return NoContent();
            }
            catch(Exception error)
            {
                _logger.LogError(error, "An error occured!");
                return StatusCode(403, "Error Message");
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ClientModel>> FintdByID(int id)
        {
            try
            {
                if(!ModelState.IsValid) return BadRequest(ModelState);
                ClientModel clientID = await _clientConfig.FindByID(id);
                if(clientID == null) return NotFound($"Client with ID {id} not found.");
                return Ok(clientID);
            }
            catch(Exception error)
            {
                _logger.LogError(error, "An error occured!");
                return StatusCode(404, "Error Message");
            }
        }
    }
}