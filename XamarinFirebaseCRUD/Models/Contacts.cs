using System;
using System.Collections.Generic;
using System.Text;

namespace XamarinFirebaseCRUD.Models
{
    public class Contacts
    {
        public string Name { get; set; }
        public string Tell1 { get; set; }
        public string Tell2 { get; set;}
        public string Email { get; set;}

        //Endereço

        public string Cep { get; set; }
        public string Logradouro { get; set;}
        public string Numero { get; set;}
        public string Bairro { get; set;}
        public string Complemento { get; set; }
        public string Cidade { get; set; }
        public string Uf { get; set;}
    }
}
