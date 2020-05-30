using System;
using System.Collections.Generic;
using System.Text;
using Nba.Core.Models.Entites;

namespace Nba.Core.IData
{
    public interface IUserAccountRepository:IBaseRepository<UserAccount>
    {
        UserAccount GetByUserID(int userid);
        void Add(UserAccount userAccount);
    }
}
