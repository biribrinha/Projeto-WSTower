using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WSTowerApi.ViewModels
{
    public class LoginViewModel
    {
        // Define que a propriedade é obrigatória
        [Required(ErrorMessage = "Informe o e-mail ou apelido do usuário!")]
        // Define que o tipo de dado
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        // Define que o tipo de dado
        [DataType(DataType.Text)]
        public string Apelido { get; set; }

        // Define que a propriedade é obrigatória
        [Required(ErrorMessage = "Informe a senha do usuário!")]
        // Define que o tipo de dado
        [DataType(DataType.Password)]
        public string Senha { get; set; }
    }
}
