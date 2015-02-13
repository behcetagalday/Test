using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using EticaretMVC.Models.DTO;
namespace EticaretMVC.Models.Repository
{
    public class UserService : ServiceBase, IService<UserDTO>
    {

        public List<UserDTO> GetALL()
        {
            throw new NotImplementedException();
        }
        //Kullanıcı Giris
        public UserDTO GetUserData(UserDTO user)
        {
            var result = from u in DB.Users
                         where u.Name == user.UserName && u.Password == user.Password
                         select new UserDTO()
                         {
                             ID = u.ID,
                             UserName = u.Name,
                             FirstName = u.FirstName,
                             LastName = u.LastName,
                             Password = u.Password,
                             Email = u.Mail,
                             Phone = u.Phone

                         };
            return result.FirstOrDefault();
        }
        public UserDTO GetByID(int EntityId)
        {
            throw new NotImplementedException();
        }

       //Kullanıcı Kayıt
        public int Save(UserDTO Entity)
        {
            User us = new User()
            {
                ID = Entity.ID,
                Name = Entity.UserName,
                FirstName = Entity.FirstName,
                LastName = Entity.LastName,
                Password = Entity.Password,
                Phone = Entity.Phone,
                Mail = Entity.Email

            };
            DB.Users.Add(us);
            return DB.SaveChanges();
        }
        public int Update(UserDTO Entity)
        {
            throw new NotImplementedException();
        }

        public int Delete(UserDTO Entity)
        {
            throw new NotImplementedException();
        }
        public void Save1(UserDTO Entity)
        {
            User us = new User()
            {
                ID = Entity.ID,
                Name = Entity.UserName,
                FirstName = Entity.FirstName,
                LastName = Entity.LastName,
                Password = Entity.Password,
                Phone = Entity.Phone,
                Mail = Entity.Email

            };
            DB.Users.Add(us);
          DB.SaveChanges();
        }
    }
}