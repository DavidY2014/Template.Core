using System;
using System.Collections.Generic;
using System.Text;
using Nba.Core.Models.Entites;

namespace Nba.Core.IService
{
    public interface IUserService:IAppService
    {
        UserInfo UserLogin(string username, string password);
        UserInfo GetByID(int id);
        int AddUser(UserInfo user, string password);
    }
}
