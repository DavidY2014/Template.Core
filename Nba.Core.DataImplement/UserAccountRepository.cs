using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Nba.Core.EntityFramework;
using Nba.Core.IData;
using Nba.Core.Models.Entites;

namespace Nba.Core.DataImplement
{
    public class UserAccountRepository : BaseRepository<NbaCoreDbContext, UserAccount>, IUserAccountRepository
    {
        public UserAccountRepository(NbaCoreDbContext dbContext) : base(dbContext)
        {

        }

        public UserAccount GetByUserID(int userid)
        {
            return Master.UserAccounts.Where(x => x.UserID == userid).FirstOrDefault();
        }

        public void Add(UserAccount userAccount)
        {
            Master.UserAccounts.Add(userAccount);
            Master.SaveChanges();
        }
    }
}
