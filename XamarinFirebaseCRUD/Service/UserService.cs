using Firebase.Database;
using Firebase.Database.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using XamarinFirebaseCRUD.Models;

namespace XamarinFirebaseCRUD.Service
{
    public class UserService : IUserService
    {
        protected static string PasswordFirebase = "JQewHX09K0fjaEnxxoAeEtaxWvhTV40dgUEVQEzH";
        FirebaseClient Client = new FirebaseClient("https://agendaapp-aace7-default-rtdb.firebaseio.com/",
            new FirebaseOptions { AuthTokenAsyncFactory = () => Task.FromResult(PasswordFirebase)});

        public async Task<bool> RegisterUser(string username, string password)
        {
            try
            {
                if(await UserExist(username, password))
                {
                    throw new Exception("O usuário já existe");
                }

                await Client.Child("Users")
                    .PostAsync(new Users()
                    {
                        User = username,
                        Password = password
                    });
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<bool> UserExist(string login, string loginPassword)
        {
            try
            {
                var consult = (await Client.Child("Users")
                    .OnceAsync<Users>())
                    .Where(u => u.Object.User == login & u.Object.Password == loginPassword)
                    .FirstOrDefault();
                return consult != null;
            }
            catch (Exception)
            {
                await Shell.Current.DisplayAlert("Usuario já criado", "O usuário existe, por favor, utilize outro email ou acesse o email criado.", "Ok");
                return false;
            }
        }
    }
}
