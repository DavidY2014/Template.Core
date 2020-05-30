using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Nba.Core.Common;
using Nba.Core.EntityFramework;
using Nba.Core.IData;
using Nba.Core.Models.Entites;
using Nba.Core.Models.Enums;

namespace Nba.Core.DataImplement
{
    public class UserRepository : BaseRepository<NbaCoreDbContext, UserInfo>, IUserRepository
    {
        public UserRepository(NbaCoreDbContext dbContext) : base(dbContext)
        {

        }

        public UserInfo UserLogin(string username, string password)
        {
            try
            {
                password = password.MD5();
                UserInfo user = null;
                var list = Master.UserAccounts.Where(x => x.UserName == username && x.Password == password).ToList();
                if (list != null && list.Count > 0)
                {
                    int userid = list.FirstOrDefault().UserID;
                    user = GetByID(userid);
                }
                return user;
            }
            catch (Exception ex)
            {
            }
            return null;
        }

        public UserInfo GetByID(int id)
        {
            try
            {
                var userinfo = Master.Users.Find(id);
                return userinfo;
            }
            catch (Exception ex)
            {
            }
            return null;
        }

        public Tuple<List<UserInfo>, long> GetList(string name, int pageIndex, int pageSize)
        {
            try
            {
                List<UserInfo> userlist = new List<UserInfo>();
                long count = 0;
                if (!string.IsNullOrEmpty(name))
                {
                    var query = Master.Users.Where(x => x.State == StateEnum.Invalid && x.Name.Contains(name));
                    userlist = query.OrderByDescending(x => x.Id).Skip((pageIndex - 1) * pageSize).Take(pageSize).ToList();
                    count = query.LongCount();
                }
                else
                {
                    userlist = Master.Users.Where(x => x.State == StateEnum.Invalid).ToList();
                    count = Master.Users.Where(x => x.State == StateEnum.Invalid).LongCount();
                }

                return Tuple.Create(userlist, count);
            }
            catch (Exception ex)
            {
            }
            return Tuple.Create<List<UserInfo>, long>(new List<UserInfo>(), 0);
        }

        public bool UpdateUserInfo(UserInfo user)
        {
            bool flag = false;
            try
            {
                Master.Users.Update(user);
                Master.SaveChangesAsync();
                flag = true;
            }
            catch (Exception ex)
            {
            }
            return flag;
        }

        public UserInfo AddUser(UserInfo userInfo)
        {
            Master.Users.Add(userInfo);
            Master.SaveChanges();
            return Master.Users.Find(userInfo.Id);
        }



    }
}
