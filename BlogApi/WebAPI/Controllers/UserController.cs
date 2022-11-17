using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAPI.Data;
using WebAPI.IRepository;
using WebAPI.Models.Dto;
using WebAPI.Models.Entities;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly DataContext context;
        private readonly IMapper map;
        private readonly IUserRepository userRepository;
        public UserController(DataContext _context , IMapper map , IUserRepository userRepository)
        {
            this.context = _context;
            this.map = map;
            this.userRepository = userRepository;   
        }

        // Get
        [HttpGet]
        public async Task<IActionResult> GetUsers()
        {
            var users = await context.Users.ToListAsync();
            return Ok(users);
        }

        [HttpGet("get/{name}")]
        public async Task<IActionResult> GetUserByName(string name)
        {
            var user = await context.Users.FirstOrDefaultAsync(a => a.userName == name);
            return Ok(user);
        }

        //Add
        [HttpPost("add")]
        [HttpPost("post")]
        //public async Task<IActionResult> AddUser(string userName, string email, string password)
        public async Task<IActionResult> AddUser(User user)
        {
            //User user = new User();
            //user.userName = userName;
            //user.email = email;
            //user.password = password;

            await context.Users.AddAsync(user);
            await context.SaveChangesAsync();

            return Ok(user);
        }

        //update
        [HttpPut("ban/{id}")]
        public async Task<IActionResult> BanUser(int id)
        {
            var user = await context.Users.FirstOrDefaultAsync(a => a.Id == id);
            if (user.ban == true)
                user.ban = false;
            else
                user.ban = true;

            context.Users.Update(user);
            await context.SaveChangesAsync();
            return Ok(user);
        }

        [HttpPut("admin/{id}")]
        public async Task<IActionResult> AdminUser(int id)
        {
            //var user = await context.Users.FirstOrDefaultAsync(a => a.Id == id);
            //if (user.admin == true)
            //    user.admin = false;
            //else
            //    user.admin = true;

            //context.Users.Update(user);
            //await context.SaveChangesAsync();
            //return Ok(user);

            User user = await  userRepository.GetByIdAsync(id);

            if (user.admin == true)
               user.admin = false;


            else if (user.admin == false)
                user.admin = true;

           context.Users.Update(user);
          await  userRepository.SaveAsync();
            
            return Ok((user));
        }

        //delete
        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            var user = await context.Users.FindAsync(id);

            context.Users.Remove(user);
            await context.SaveChangesAsync();
            return Ok(id);
        }
    }
}
