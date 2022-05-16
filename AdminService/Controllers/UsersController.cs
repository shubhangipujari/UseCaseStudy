using AdminService.Models;
using AdminService.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Transactions;

namespace AdminService.Controllers
{
  
    [Route("api/[controller]")]
    [ApiController]
   
    public class UsersController : ControllerBase
    {
        private readonly IUser _userRepository;

        public UsersController(IUser userRepository)
        {
            _userRepository = userRepository;
        }

        [HttpGet]
        [Route("getUser")]

        public IActionResult getUser()
        {
            try
            {
                var users = _userRepository.GetUsers();
                return new OkObjectResult(users);
            }
            catch (Exception ex)
            {
                ex.Message.ToString();
                return BadRequest();
            }

          
        }

        //[HttpGet("{id}", Name = "getUserById")]
        //[Route("getUserById")]

        //public IActionResult getUserById(int id)
        //{
        //    try
        //    {
        //        var user = _userRepository.GetUserById(id);
        //        return new OkObjectResult(user);
        //    }
        //    catch (Exception ex)
        //    {
        //        return null;
        //    }
        //}

        [HttpPost]
        [Route("createUser")]


        public IActionResult CreateUser([FromBody] UserDetail user)
        {
            try
            {

                using (var scope = new TransactionScope())
                {
                    _userRepository.CreateUser(user);
                    scope.Complete();
                    return CreatedAtAction(nameof(getUser), user);
                }
            }
            catch (Exception ex)
            {
                ex.Message.ToString();
                return null;
            }
        }

        //[HttpPut]
        //[Route("updateUser")]
        //public IActionResult UpdateUser([FromBody] UserDetail user)
        //{
        //    try
        //    {
        //        if (user != null)
        //        {
        //            using (var scope = new TransactionScope())
        //            {
        //                _userRepository.UpdateUser(user);
        //                scope.Complete();
        //                return new OkResult();
        //            }
        //        }
        //        return new NoContentResult();
        //    }
        //    catch (Exception ex)
        //    {
        //        return null;
        //    }
        //}

        //[HttpDelete("{id}")]
        //[Route("deleteUser")]

        //public IActionResult Delete(int id)
        //{
        //    try
        //    {
        //        _userRepository.DeleteUser(id);
        //        return new OkResult();
        //    }
        //    catch (Exception ex)
        //    {
        //        return null;
        //    }
        //}

        [AllowAnonymous]
       
        [HttpPost]
        [Route("login")]
       
        public IActionResult login(string emailId, string password)
        {
            try
            {
                var tokan = _userRepository.Login(emailId, password);

                if (tokan == null)
                {
                    return BadRequest();

                }
                return new OkObjectResult(tokan);

            }
            catch (Exception ex)
            {
                ex.Message.ToString();
                return BadRequest();
            }

        }

    }
}
