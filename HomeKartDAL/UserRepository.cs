using HomeKartEntity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace HomeKartDAL
{
    public interface I_UserDataManipulation
    {
        User CheckLogin(User user);
        bool ToRegister(User user);
        List<User> CustomerView();
        object ToDisplay(int UserId);
        bool ToUpdate(User user);
        bool ToDelete(int UserId, User user);
        object ToSearchCustomer(string UserName);
        bool ToRegisterOrder(Orders order);
        List<Orders> OrdersView();


    }
    public class UserRepository : I_UserDataManipulation
    {
        public User CheckLogin(User user)
        {
            using (UserDataBase userContext = new UserDataBase())
            {
                var userdata = (from a in userContext.user where a.Email == user.Email || a.Email == user.Email select a).FirstOrDefault();
                var hashcode = userdata.HashCode;
                var encodingPasswordString = Helper.EncodePassword(user.Password, hashcode);
                var obj = userContext.user.Where(a => a.Email == user.Email && a.Password.Equals(encodingPasswordString)).FirstOrDefault();
                return obj;
            }
        }
        public bool ToRegister(User user)
        {
            using (UserDataBase userDataBase = new UserDataBase())
            {
                userDataBase.user.Add(user);
                userDataBase.SaveChanges();
                return true;
            }
        }
        public List<User> CustomerView()
        {
            using (UserDataBase userDataBase = new UserDataBase())
            {
                return userDataBase.user.ToList();
            }

        }
        public object ToDisplay(int UserId)
        {
            using (UserDataBase userDataBase = new UserDataBase())
            {
                return userDataBase.user.Where(model => model.UserId == UserId).FirstOrDefault();

            }

        }

        public bool ToUpdate(User user)
        {
            using (UserDataBase userDataBase = new UserDataBase())
            {
                userDataBase.Entry(user).State = EntityState.Modified;
                userDataBase.SaveChanges();
                return true;
            }

        }
        public bool ToDelete(int UserId, User user)
        {
            using (UserDataBase userDataBase = new UserDataBase())
            {
                user = userDataBase.user.Where(model => model.UserId == UserId).FirstOrDefault();
                userDataBase.user.Remove(user);
                userDataBase.SaveChanges();
                return true;
            }
        }
        public object ToSearchCustomer(string UserName)
        {
            using (UserDataBase userDataBase = new UserDataBase())
            {
                return userDataBase.user.Where(model => model.Email == UserName).FirstOrDefault();

            }

        }
        public bool ToRegisterOrder(Orders order)
        {
            using (UserDataBase userDataBase = new UserDataBase())
            {
                userDataBase.orders.Add(order);
                userDataBase.SaveChanges();
                return true;
            }
        }
        public List<Orders> OrdersView()
        {
            using (UserDataBase userDataBase = new UserDataBase())
            {
                return userDataBase.orders.ToList();
            }

        }
    }
    public static class Helper
    {
        public static string GeneratePassword(int length) 
        {
            const string allowedChars = "abcdefghijkmnopqrstuvwxyzABCDEFGHJKLMNOPQRSTUVWXYZ0123456789";
            var randNum = new Random();
            var chars = new char[length];
            var allowedCharCount = allowedChars.Length;
            for (var i = 0; i <= length - 1; i++)
            {
                chars[i] = allowedChars[Convert.ToInt32((allowedChars.Length) * randNum.NextDouble())];
            }
            return new string(chars);
        }
        public static string EncodePassword(string pass, string salt)    
        {
            byte[] bytes = Encoding.Unicode.GetBytes(pass);
            byte[] src = Encoding.Unicode.GetBytes(salt);
            byte[] dst = new byte[src.Length + bytes.Length];
            System.Buffer.BlockCopy(src, 0, dst, 0, src.Length);
            System.Buffer.BlockCopy(bytes, 0, dst, src.Length, bytes.Length);
            HashAlgorithm algorithm = HashAlgorithm.Create("SHA1");
            byte[] inArray = algorithm.ComputeHash(dst);
            //return Convert.ToBase64String(inArray);    
            return EncodePasswordMd5(Convert.ToBase64String(inArray));
        }
        public static string EncodePasswordMd5(string pass)  
        {
            Byte[] originalBytes;
            Byte[] encodedBytes;
            MD5 md5;  
            md5 = new MD5CryptoServiceProvider();
            originalBytes = ASCIIEncoding.Default.GetBytes(pass);
            encodedBytes = md5.ComputeHash(originalBytes);
   
            return BitConverter.ToString(encodedBytes);
        }
        public static string base64Encode(string sData)
        {
            try
            {
                byte[] encData_byte = new byte[sData.Length];
                encData_byte = System.Text.Encoding.UTF8.GetBytes(sData);
                string encodedData = Convert.ToBase64String(encData_byte);
                return encodedData;
            }
            catch (Exception ex)
            {
                throw new Exception("Error in base64Encode" + ex.Message);
            }
        }
        public static string base64Decode(string sData) //Decode    
        {
            try
            {
                var encoder = new System.Text.UTF8Encoding();
                System.Text.Decoder utf8Decode = encoder.GetDecoder();
                byte[] todecodeByte = Convert.FromBase64String(sData);
                int charCount = utf8Decode.GetCharCount(todecodeByte, 0, todecodeByte.Length);
                char[] decodedChar = new char[charCount];
                utf8Decode.GetChars(todecodeByte, 0, todecodeByte.Length, decodedChar, 0);
                string result = new String(decodedChar);
                return result;
            }
            catch (Exception ex)
            {
                throw new Exception("Error in base64Decode" + ex.Message);
            }
        }
       
    }

  
}
