using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace AspStore.WebUI.Models
{
    public class ContatoModel
    {
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        public string Telefone { get; set; }
        public string Rua { get; set; }
        public string Bairro { get; set; }
        public string CEP { get; set; }
        [DisplayName(displayName: "Número do endereço")]
        public string NumeroEndereco { get; set; }
        public string Cidade { get; set; }
        [DisplayName(displayName: "Link do Facebook")]
        public string LinkFacebook { get; set; }
        [DisplayName(displayName: "Link da Twitter")]
        public string LinkTwitter { get; set; }
    }
}
