using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace XamarinFirebaseCRUD.Service
{
    public interface IScheduleService
    {

        Task<bool> RegisterContact(string name, string telefone1, string telefone2,
            string email, string cep, string logradouro, string numero, string bairro, string complemento, string cidade, string uf);
    }
}
