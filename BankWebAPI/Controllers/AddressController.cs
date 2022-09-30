using BankWebAPI.DTOs;
using BankWebAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace BankWebAPI.Controllers
{
    [ApiController]
    [Route("Addresses")]
    public class AddressController : Controller
    {
        private readonly AddressService _addressService;

        public AddressController(AddressService addressService)
        {
            _addressService = addressService;
        }

        [HttpPost]
        public async Task<IActionResult> Insert(AddressDTO address)
        {
            await _addressService.InsertAddressAsync(address);

            return NoContent();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            return Ok(await _addressService.GetAddressById(id));
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _addressService.GetAdressesAsync());
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, AddressDTO address)
        {
            await _addressService.UpdateAddressAsync(id, address);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _addressService.DeleteAddressAsync(id);

            return NoContent();
        }

        [HttpPut]
        public async Task<IActionResult> AssignPersonToAddress(AssignPersonToAddressDTO ids)
        {
            await _addressService.AssignPersonToAddressAsync(ids);

            return NoContent();
        }
    }
}
