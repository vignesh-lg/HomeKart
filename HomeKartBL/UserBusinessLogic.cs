using HomeKartDAL;
using HomeKartEntity;
using System.Collections.Generic;
using System.Linq;


namespace HomeKartBL
{
    public class UserBusinessLogic
    {
        I_UserDataManipulation userRepository = new UserRepository();
        public User CheckLogin(User user)
        {
            return userRepository.CheckLogin(user);
        }
        public bool ToRegister(User user)
        {
            return userRepository.ToRegister(user);

        }
        public List<User> CustomerView()
        {
            return userRepository.CustomerView();
        }
        public object ToDisplay(int UserId)
        {
            return userRepository.ToDisplay(UserId);
        }
        public bool ToUpdate(User user)
        {
            return userRepository.ToUpdate(user);
        }
        public bool ToDelete(int UserId, User user)
        {
            return userRepository.ToDelete(UserId, user);
        }
        public object ToSearchCustomer(string UserName)
        {
            return userRepository.ToSearchCustomer(UserName);
        }
        
             public bool ToRegisterOrder(Orders order)
        {
            return userRepository.ToRegisterOrder(order);

        }
        public List<Orders> OrdersView()
        {
            return userRepository.OrdersView();
        }
    }
}
