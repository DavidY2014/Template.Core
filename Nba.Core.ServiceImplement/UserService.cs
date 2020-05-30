using System;
using System.Collections.Generic;
using System.Text;
using Nba.Core.Common;
using Nba.Core.IData;
using Nba.Core.IService;
using Nba.Core.Models.Entites;

namespace Nba.Core.ServiceImplement
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        private readonly IUserAccountRepository _userAccountRepository;
        public UserService(IUserRepository userRepository, IUserAccountRepository userAccountRepository)
        {
            _userRepository = userRepository;
            _userAccountRepository = userAccountRepository;
        }
        public UserInfo UserLogin(string username, string password)
        {
            return _userRepository.UserLogin(username, password);
        }

        public UserInfo GetByID(int id)
        {
            return _userRepository.GetByID(id);
        }

        public int AddUser(UserInfo user, string password)
        {
            int id = 0;
            try
            {
                var userinfo = _userRepository.AddUser(user);
                RegistUserAccount(userinfo, password);
                id = userinfo.Id;
            }
            catch (Exception ex)
            {
            }
            return id;
        }


        private void RegistUserAccount(UserInfo user, string password)
        {
            try
            {
                UserAccount account = new UserAccount();
                account.UserName = user.UserName;
                account.Password = password.MD5();
                account.UserID = user.Id;
                _userAccountRepository.Add(account);
            }
            catch (Exception ex)
            {
            }
        }
    }
 }
