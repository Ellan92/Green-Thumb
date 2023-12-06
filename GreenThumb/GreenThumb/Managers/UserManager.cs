using GreenThumb.Database;
using GreenThumb.Models;

namespace GreenThumb.Managers
{

    public static class UserManager
    {
        public static UserModel? signedInUser { get; set; }
        //public static List<UserModel> Users { get; set; } = new()
        //{
        //    new UserModel(1, "user", "password"){
        //    Garden = new GardenModel(1, "userGarden")}
        //};

        public static async Task<bool> SigninUser(string username, string password)
        {
            using (GreenThumbDbContext context = new())
            {
                GreenThumbUow uow = new(context);

                var allUsers = await uow.UserRepository.GetAllAsync();
                var Users = allUsers.ToList();

                foreach (var user in Users)
                {
                    if (user.Username == username && user.Password == password)
                    {
                        signedInUser = user;

                        //await uow.Complete();
                        return true;
                    }
                }
                return false;
            }

        }

        public static void SignOutUser()
        {
            signedInUser = null;
        }

        public static async Task<bool> ValidateUsername(string username)
        {
            using (GreenThumbDbContext context = new())
            {
                GreenThumbUow uow = new(context);

                var allUsers = await uow.UserRepository.GetAllAsync();
                var Users = allUsers.ToList();

                bool isValidUsername = true;

                foreach (var user in Users)
                {
                    if (user.Username == username)
                    {
                        isValidUsername = false;
                    }
                }
                return isValidUsername;
            }

        }
        public static async Task<UserModel> RegisterUser(string username, string password)
        {
            using (GreenThumbDbContext context = new())
            {
                GreenThumbUow uow = new(context);

                if (await ValidateUsername(username))
                {
                    UserModel newUser = new()
                    {
                        Username = username,
                        Password = password
                    };

                    await uow.UserRepository.Add(newUser);
                    await uow.Complete();

                    return newUser;
                }
                return null;
            }



        }
    }
}
