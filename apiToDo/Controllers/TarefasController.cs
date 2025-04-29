using apiToDo.DTO;
using apiToDo.Models;
using Microsoft.AspNetCore.Mvc;
using System;

namespace apiToDo.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TarefasController : ControllerBase
    {
        private readonly Tarefas _tarefas;

        public TarefasController()
        {
            _tarefas = new Tarefas(); 
        }

        
        [HttpGet("lstTarefas")]
        public IActionResult lstTarefas()
        {
            try
            {
                var tarefas = _tarefas.lstTarefas();
                return Ok(tarefas); // 
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro ao listar tarefas: {ex.Message}");
            }
        }

       
        [HttpPost("InserirTarefa")]
        public IActionResult InserirTarefa([FromBody] TarefaDTO request)
        {
            try
            {
                var tarefas = _tarefas.InserirTarefa(request);
                return Ok(tarefas); 
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message); 
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro ao inserir tarefa: {ex.Message}");
            }
        }

        
        [HttpDelete("DeleteTask/{id}")] // Define a rota HTTP DELETE com o parâmetro id na URL
public IActionResult DeletarTarefa(int id) // Método que recebe o ID da tarefa a ser deletada
{
    // Verifica se o ID fornecido é válido (ex.: 1458, conforme o cenário)
    if (id <= 0) // Condicional para validar se o ID é positivo
    {
        // Retorna erro 400 (Bad Request) se o ID for inválido
        return BadRequest("ID da tarefa inválido."); // Envia uma mensagem de erro ao cliente
    }

    try // Bloco try para capturar exceções durante a execução
    {
        // Tenta deletar a tarefa com o ID especificado
        var tarefas = _tarefas.DeletarTarefa(id); // Chama o método DeletarTarefa da classe Tarefas

        // Retorna código 200 (OK) com a lista de tarefas restante
        return Ok(tarefas); // Envia a lista atualizada como resposta JSON
    }
    catch (KeyNotFoundException ex) // Captura exceção se a tarefa não for encontrada
    {
        // Retorna erro 404 (Not Found) se a tarefa não existir
        return NotFound(ex.Message); // Envia a mensagem de erro específica
    }
    catch (Exception ex) // Captura qualquer outra exceção inesperada
    {
        // Retorna erro 500 (Internal Server Error) para erros gerais
        return StatusCode(500, $"Erro ao deletar tarefa: {ex.Message}"); // Envia mensagem de erro detalhada
    }
}

        
        [HttpPut("AtualizarTarefa/{id}")]
        public IActionResult AtualizarTarefa(int id, [FromBody] TarefaDTO request)
        {
            try
            {
                var tarefas = _tarefas.AtualizarTarefa(id, request);
                return Ok(tarefas); 
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message); 
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ex.Message); 
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro ao atualizar tarefa: {ex.Message}");
            }
        }

        
        [HttpGet("ObterTarefa/{id}")]
        public IActionResult ObterTarefa(int id)
        {
            try
            {
                var tarefa = _tarefas.ObterTarefa(id);
                return Ok(tarefa); 
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ex.Message); 
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro ao obter tarefa: {ex.Message}");
            }
        }
    }
}