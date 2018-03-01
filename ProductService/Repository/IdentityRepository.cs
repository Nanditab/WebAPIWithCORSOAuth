
namespace ProductService.Repository
{
    #region -- Using --
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using Models;
    #endregion
    public class IdentityRepository
    {
        #region -- Propeties --
        private static List<User> UserList { get; set; }
        #endregion

        #region -- Constructors --
        static IdentityRepository()
        {
            UserList = new List<User>
            {
                new User{ UserName = "User1", Password = "Something1$", ConfirmPassword="Something1$"},
                new User{ UserName = "User2", Password = "Something2$", ConfirmPassword="Something1$"},
                new User{ UserName = "User3", Password = "Something3$", ConfirmPassword="Something1$"},
            };

        }

        #endregion

        #region -- Methods --
        public User FindUser(string userName, string password)
        {
            var user = UserList.FirstOrDefault(u => u.UserName == userName && u.Password == password);
            return user;
        }

        public bool Register(User userModel)
        {
            UserList.Add(userModel);
            return true;
        }
        #endregion
    }
}