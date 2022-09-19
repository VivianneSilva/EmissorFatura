using System;

namespace cadastroCliente.Models
{
    public class cliente
    {
        public int clienteId { get; set; }
        public string nome { get; set; }
        public int rg { get; set; }
        public int cpf { get; set; }
        public int telefone { get; set; }
        public string email { get; set; }
        public DateTime dataNascimento { get; set; }
        public string endereco { get; set; }
        public int numero { get; set; }
        public string bairro { get; set; }
        public int cep { get; set; }
        public string cidade { get; set; }
        public string profissao { get; set; }
        public estadoCivil estadoCivil { get; set; }
        



    }
}
