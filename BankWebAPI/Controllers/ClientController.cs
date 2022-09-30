using BankWebAPI.DTOs;
using BankWebAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace BankWebAPI.Controllers
{
    [ApiController]
    [Route("Clients")]
    public class ClientController : Controller
    {
       private readonly ClientService _clientService;

        public ClientController(ClientService clientService)
        {
            _clientService = clientService;
        }

        [HttpPost]
        public async Task<IActionResult> Insert(ClientInsertDTO client)
        {
            await _clientService.InsertClientAsync(client);

            return NoContent();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, ClientInsertDTO client)
        {
            await _clientService.UpdateClientAsync(id, client);

            return NoContent();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            return Ok(await _clientService.GetClientByIdAsync(id));
        }

        [HttpPut]
        public async Task<IActionResult> AssignAccountToClient(AssignAccountClientDTO ids)
        {
            await _clientService.AssignAccountToClientAsync(ids);

            return NoContent();
        }

        [HttpPost("Transaction")]
        public async Task<IActionResult> Transaction(TransactionDTO values)
        {
            await _clientService.MakeTransaction(values);

            return NoContent();
        }
    }
}
