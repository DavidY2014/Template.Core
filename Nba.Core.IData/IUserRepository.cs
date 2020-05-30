using System;
using System.Collections.Generic;
using System.Text;
using Nba.Core.Models.Entites;

namespace Nba.Core.IData
{
    public interface IUserRepository : IBaseRepository<UserInfo>
    {
        UserInfo UserLogin(string username, string password);
        Tuple<List<UserInfo>, long> GetList(string name, int pageIndex, int pageSize);
        UserInfo GetByID(int id);

        UserInfo AddUser(UserInfo userInfo);
    }
}
