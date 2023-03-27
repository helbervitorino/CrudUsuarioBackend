using CrudUsuarioBackend.Context;
using CrudUsuarioBackend.DTO;
using CrudUsuarioBackend.Entidades;
using CrudUsuarioBackend.Interface;
using System.Collections.Generic;
using System.Linq;

namespace CrudUsuarioBackend.Serviço
{
    public class UsuarioServico : IUsuarioServico
    {
        private readonly UsuarioContext _context;

        public UsuarioServico(UsuarioContext context)
        {
            _context = context;
        }

        public void Alterar(Usuario usuario)
        {
            var usuarioExistente = _context.Set<Usuario>().Find(usuario.IdUsuario);

            if (usuarioExistente != null)
            {
                usuarioExistente.NomeUsuario = usuario.NomeUsuario;
                usuarioExistente.DataCadastro = usuario.DataCadastro;
                usuarioExistente.MarcaCelular = usuario.MarcaCelular;
                usuarioExistente.Mac = usuario.Mac;
                usuarioExistente.Modelo = usuario.Modelo;
                usuarioExistente.SistemaOperacional = usuario.SistemaOperacional;

                _context.SaveChanges();
            }
        }

        public Usuario BuscarPorId(int id)
        {
            return _context.Set<Usuario>().Where(a => a.IdUsuario == id).FirstOrDefault();
        }

        public List<RegistrosPorDiaDTO> BuscarRegistrosPorDia()
        {
            var registrosPorDia = _context.Set<Usuario>()
             .GroupBy(u => u.DataCadastro.Date)
             .Select(g => new RegistrosPorDiaDTO { Data = g.Key, Quantidade = g.Count() })
             .ToList();

            return registrosPorDia;
        }

        public List<SistemasOperacionaisDTO> BuscarSistemasOperacionais()
        {
            var sistemasOperacionais = _context.Set<Usuario>()
            .GroupBy(u => u.SistemaOperacional)
            .Select(g => new SistemasOperacionaisDTO { Nome = g.Key, Quantidade = g.Count() })
            .ToList();

            return sistemasOperacionais;
        }

        public List<Usuario> BuscarTodos()
        {
            return _context.Set<Usuario>().OrderBy(u => u.NomeUsuario).ToList();
        }

        public void Cadastrar(Usuario usuario)
        {
            _context.Set<Usuario>().Add(usuario);
            _context.SaveChanges();
        }

        public void DeletarPorId(int id)
        {
            var usuario = _context.Set<Usuario>().Find(id);

            if (usuario != null)
            {
                _context.Set<Usuario>().Remove(usuario);
                _context.SaveChanges();
            }
        }
    }
}
