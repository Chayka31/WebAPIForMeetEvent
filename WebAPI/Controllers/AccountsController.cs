using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAPI.Data;
using WebAPI.Models;
using WebAPI.Services;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountsController : ControllerBase
    {
        private readonly IMeetEventService _service;

        public AccountsController(IMeetEventService service)
        {
            _service = service;
        }

        [HttpGet("test")]
        public async Task<IActionResult> TestConnection()
        {
            var result = await _service.TestConnectionAsync();
            return Ok(new { connected = result, message = "API работает!" });
        }

        // GET: api/Accounts
        [HttpGet("{id}")]
        public async Task<ActionResult<Account>> GetById(long id)
        {
            var account = await _service.GetAccountByIdAsync(id);
            if (account == null)
                return NotFound();
            return Ok(account);
        }

        // POST: api/Accounts/get-or-create
        [HttpPost("get-or-create")]
        public async Task<ActionResult<Account>> GetOrCreate([FromBody] string email)
        {
            try
            {
                var account = await _service.GetOrCreateAccountAsync(email);
                return Ok(account);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Ошибка: {ex.Message}");
            }
        }

        // PUT: api/Accounts/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(long id, Account account)
        {
            if (id != account.id)
                return BadRequest("ID не совпадают");

            var updated = await _service.UpdateAccountAsync(account);
            return Ok(updated);
        }

        // DELETE: api/Accounts/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(long id)
        {
            var result = await _service.DeleteAccountAsync(id);
            if (!result)
                return NotFound();
            return NoContent();
        }
    }
}
