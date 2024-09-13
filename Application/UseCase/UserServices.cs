using Application.Interfaces;
using Application.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.UseCase
{
    public class UserServices : IUserServices
    {
        private readonly IUserQuery _userQuery;

        public UserServices(IUserQuery query)
        {
            _userQuery = query;
        }

        public async Task<List<Users>> GetAll()
        {
            var users = await _userQuery.GetListUsers();
            
            var result = users.Select(x => new Users
            {
                UserID = x.UserID,
                Name = x.Name,
                Email = x.Email

            }).ToList();

            return result;
        }
    }
}
