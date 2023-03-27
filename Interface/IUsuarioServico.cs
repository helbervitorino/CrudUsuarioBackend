using CrudUsuarioBackend.DTO;
using CrudUsuarioBackend.Entidades;
using System.Collections.Generic;

namespace CrudUsuarioBackend.Interface
{
    public interface IUsuarioServico
    {
        public void Cadastrar(Usuario usuario);
        public void Alterar(Usuario usuario);
        public void DeletarPorId(int id);
        public Usuario BuscarPorId(int id);
        public List<Usuario> BuscarTodos();
        public List<RegistrosPorDiaDTO> BuscarRegistrosPorDia();
        public List<SistemasOperacionaisDTO> BuscarSistemasOperacionais();
    }
}
