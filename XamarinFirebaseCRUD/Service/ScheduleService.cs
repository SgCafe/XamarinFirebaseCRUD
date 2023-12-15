using Firebase.Database;
using Firebase.Database.Query;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using XamarinFirebaseCRUD.Models;

namespace XamarinFirebaseCRUD.Service
{
    public class ScheduleService : IScheduleService
    {
        protected static string PasswordFirebase = "JQewHX09K0fjaEnxxoAeEtaxWvhTV40dgUEVQEzH";
        FirebaseClient Client = new FirebaseClient("https://agendaapp-aace7-default-rtdb.firebaseio.com/",
            new FirebaseOptions { AuthTokenAsyncFactory = () => Task.FromResult(PasswordFirebase) });

        public async Task<bool> RegisterContact(string name, string telefone1, string telefone2, string email, string cep, string logradouro, string numero, string bairro, string complemento, string cidade, string uf)
        {
            try
            {
                await Client.Child("Registrations")
                    .PostAsync(new Contacts()
                    {
                        Name = name,
                        Tell1 = telefone1,
                        Tell2 = telefone2,
                        Email = email,
                        Cep = cep,
                        Logradouro = logradouro,
                        Numero = numero,
                        Bairro = bairro,
                        Complemento = complemento,
                        Cidade = cidade,
                        Uf = uf
                    });

                return true;


            }
            catch (Exception)
            {
                return false;

            }
        }
    }
}
