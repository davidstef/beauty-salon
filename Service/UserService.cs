using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace WindowsFormsApp1.BL
{
    class UserService
    {
        private UserRepository userRepository = UserRepository.getInstance();

        public User login(string username, string password)
        {
            User u = userRepository.getUser(username, encryptPassword(password));
            return u;
        }

        public bool createUser(User u)
        {
            return userRepository.createUser(u, encryptPassword(u.getPassword()));
        }

        public bool updateUser(User u)
        {
            return userRepository.updateUser(u, encryptPassword(u.getPassword())) ? true : false;
        }

        public bool deleteUser(String username)
        {
            return userRepository.deleteUser(username) ? true : false;
        }
        public static string encryptPassword(string password)
        {
            MD5 md5 = MD5.Create();

            byte[] data = md5.ComputeHash(Encoding.Default.GetBytes(password));

            StringBuilder stringEncoded = new StringBuilder();

            for (int i = 0; i < data.Length; i++)
            {
                stringEncoded.Append(data[i].ToString("x2"));
            } 

            return stringEncoded.ToString();
        }
    }
}
