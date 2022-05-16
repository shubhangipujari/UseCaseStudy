using AdminService.DBContext;
using AdminService.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace AdminService.Repository
{
    public class UserRepository : IUser
    {
        private readonly UserContext _dbContext;
        private readonly IConfiguration configuartion;

        public UserRepository(UserContext dbContext)
        {
            _dbContext = dbContext;
           
        }
        public UserRepository(UserContext dbContext, IConfiguration iconfiguration)
        {
            _dbContext = dbContext;
            configuartion = iconfiguration;
        }

      
       
        public void CreateUser(UserDetail user)
        {
           
                _dbContext.Add(user);
                Save();
           
        }

        public void DeleteUser(int userId)
        {
           
                var user = _dbContext.UserDetails.Find(userId);
                _dbContext.UserDetails.Remove(user);
                Save();
            
        }

        public UserDetail GetUserById(int userId)
        {
           
                return _dbContext.UserDetails.Find(userId);

            
        }

        public IEnumerable<UserDetail> GetUsers()
        {
            return _dbContext.UserDetails.ToList();
        }

        public void Save()
        {
           _dbContext.SaveChanges();
        }

        public void UpdateUser(UserDetail user)
        {
                _dbContext.Entry(user).State = EntityState.Modified;
                Save();
        }
        public Tokan Login(string emailid, string password)
        {
          
                Boolean result = _dbContext.UserDetails.Any((x => x.Email == emailid && x.Password == password));
                //return result;
                if (result)
                {
                    var tokenHandler = new JwtSecurityTokenHandler();
                    var tokenKey = Encoding.UTF8.GetBytes(configuartion["JWT:Key"]);

                    var tokenDescriptor = new SecurityTokenDescriptor
                    {
                        Subject = new ClaimsIdentity(new Claim[]
                        {
                    new Claim(ClaimTypes.Email,emailid)
                        }),
                        Expires = DateTime.UtcNow.AddMinutes(10),
                        SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(tokenKey), SecurityAlgorithms.HmacSha256Signature)
                    };
                    var token = tokenHandler.CreateToken(tokenDescriptor);
                    // var user = _dbContext.UserDetails.Where((x => x.Email == emailid));
                    var tokanstring = new Tokan { Token = tokenHandler.WriteToken(token) };
                    return tokanstring;
                }
                else
                {
                    return null;
                }
            }
    }
}
