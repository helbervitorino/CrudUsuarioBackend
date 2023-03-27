using AutoMapper;
using CrudUsuarioBackend.DTO;
using CrudUsuarioBackend.Entidades;
using CrudUsuarioBackend.Interface;
using Microsoft.AspNetCore.Mvc;
using System;

namespace crud_usuario_backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioServico _usuarioServico;
        private readonly IMapper _mapper;

        public UsuarioController(IMapper mapper, IUsuarioServico usuarioServico)
        {
            _usuarioServico = usuarioServico;
            _mapper = mapper;
        }

        [HttpGet("BuscarTodos")]
        public IActionResult BuscarTodos()
        {
            var resultado = _usuarioServico.BuscarTodos();

            return Ok(resultado);
        }

        [HttpGet("BuscarPorId/{id}")]
        public IActionResult BuscarPorId(int id)
        {
            var resultado = _usuarioServico.BuscarPorId(id);

            return Ok(resultado);
        }

        [HttpPost("Cadastrar")]
        public IActionResult Cadastrar(UsuarioDTO usuarioDTO)
        {
            try
            {
                var usuario = _mapper.Map<Usuario>(usuarioDTO);

                _usuarioServico.Cadastrar(usuario);

                return Ok("Usuario cadastrado com sucesso.");
            }
            catch (Exception ex)
            {
                return Ok("Erro ao cadastrar Usuario." + ex.Message);
            }
        }

        [HttpPut("Alterar")]
        public IActionResult Alterar(UsuarioDTO usuarioDTO)
        {
            try
            {
                var usuario = _mapper.Map<Usuario>(usuarioDTO);

                _usuarioServico.Alterar(usuario);

                return Ok("Usuario alterado com Sucesso.");
            }
            catch (Exception ex)
            {
                return Ok("Erro ao alterar cadastro." + ex.Message);
            }
        }

        [HttpDelete("DeletarPorId/{id}")]
        public IActionResult DeletarPorId(int id)
        {
            try
            {
                _usuarioServico.DeletarPorId(id);

                return Ok("Cadastro deletado com sucesso.");
            }
            catch (Exception ex)
            {
                return Ok("Erro ao excluir cadastro." + ex);
            }
        }

        [HttpGet("graficos/sistemasOperacionais")]
        public IActionResult GerarGraficoSistemasOperacionais()
        {
            var sistemasOperacionais = _usuarioServico.BuscarSistemasOperacionais();

            return Ok(sistemasOperacionais);
        }

        [HttpGet("graficos/registrosPorDia")]
        public IActionResult GerarGraficoRegistrosPorDia()
        {
            var sistemasOperacionais = _usuarioServico.BuscarRegistrosPorDia();

            return Ok(sistemasOperacionais);
        }
    }
}
