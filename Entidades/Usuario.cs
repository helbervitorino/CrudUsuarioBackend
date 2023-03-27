using System;

namespace CrudUsuarioBackend.Entidades
{
    public class Usuario
    {
        public int IdUsuario { get; set; }
        public string NomeUsuario { get; set; }
        public DateTime DataCadastro { get; set; }
        public string MarcaCelular { get; set; }
        public string Mac { get; set; }
        public string Modelo { get; set; }
        public string SistemaOperacional { get; set; }
    }
}
