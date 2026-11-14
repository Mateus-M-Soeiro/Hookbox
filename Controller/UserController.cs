using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Hookbox.Data;
using Hookbox.Dto;
using Hookbox.Models;
using Microsoft.AspNetCore.Mvc;

namespace Hookbox.Controller
{
    [ApiController]
    [Route("[Controller]")]
    public class UserController:ControllerBase
    {

        private readonly AppDbContext _context;
        public UserController(AppDbContext context){

            _context = context;
            
        }
        [HttpPost]
        public async Task<IActionResult> CreateUser(CreateUserDto dto)
        {
            

            var User = new User
            {
                Id = Guid.NewGuid(),
                Name = dto.Name,
                Email = dto.Email,
                PasswordHash = BCrypt.Net.BCrypt.HashPassword(dto.Password),
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow,

            };

            _context.Add(User);
            await _context.SaveChangesAsync();
            
            var Response = new UserResponseDto()
            {
                UserId = User.Id,
                Name = User.Name,
                Email = User.Email

            };

            return CreatedAtAction(nameof(GetUserById), new {UserId = User.Id},Response);
         

        }


        [HttpGet("{UserId}")]
        public async Task<IActionResult> GetUserById(Guid UserId)
        {

            var User = await _context.Users.FindAsync(UserId);

            if(User == null) return NotFound();
            var Response = new UserResponseDto()
            {
                UserId = User.Id,
                Name = User.Name,
                Email = User.Email

            };
            return Ok(Response);
        }

        [HttpDelete("{UserId}")]
        public async Task<IActionResult> DeleteUser(Guid UserId)
        {
            
            var User = await _context.Users.FindAsync(UserId);
            if (User == null) return NotFound();

            _context.Users.Remove(User);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}