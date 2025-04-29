using apiToDo.DTO;
using System;
using System.Collections.Generic;
using System.Linq;

namespace apiToDo.Models
{
    public class Tarefas
    {
        // Lista estática para persistir tarefas em memória
        private static readonly List<TarefaDTO> _tarefas = new List<TarefaDTO>
        {
            new TarefaDTO { ID_TAREFA = 1458, DS_TAREFA = "Tarefa Inicial" } // Inclui ID 1458
        };

        // Lista todas as tarefas
        public List<TarefaDTO> lstTarefas()
        {
            try
            {
                return _tarefas; // Retorna a lista atual
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao listar tarefas.", ex);
            }
        }

        // Insere uma nova tarefa e retorna a lista atualizada
        public List<TarefaDTO> InserirTarefa(TarefaDTO request)
        {
            try
            {
                // Valida a entrada
                if (request == null || string.IsNullOrEmpty(request.DS_TAREFA))
                {
                    throw new ArgumentException("A descrição da tarefa é obrigatória.");
                }

                // Gera um novo ID
                request.ID_TAREFA = _tarefas.Any() ? _tarefas.Max(t => t.ID_TAREFA) + 1 : 1;
                _tarefas.Add(request);
                return _tarefas;
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao inserir tarefa.", ex);
            }
        }

        // Deleta uma tarefa pelo ID e retorna a lista atualizada
        public List<TarefaDTO> DeletarTarefa(int ID_TAREFA)
        {
            try
            {
                // Busca a tarefa pelo ID
                var tarefa = _tarefas.FirstOrDefault(x => x.ID_TAREFA == ID_TAREFA);
                if (tarefa == null)
                {
                    throw new KeyNotFoundException($"Tarefa com ID {ID_TAREFA} não encontrada.");
                }

                // Remove a tarefa
                _tarefas.Remove(tarefa);
                return _tarefas;
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro ao deletar tarefa com ID {ID_TAREFA}.", ex);
            }
        }

        // Bônus: Atualiza uma tarefa
        public List<TarefaDTO> AtualizarTarefa(int ID_TAREFA, TarefaDTO request)
        {
            try
            {
                // Valida a entrada
                if (request == null || string.IsNullOrEmpty(request.DS_TAREFA))
                {
                    throw new ArgumentException("A descrição da tarefa é obrigatória.");
                }

                // Busca a tarefa
                var tarefa = _tarefas.FirstOrDefault(x => x.ID_TAREFA == ID_TAREFA);
                if (tarefa == null)
                {
                    throw new KeyNotFoundException($"Tarefa com ID {ID_TAREFA} não encontrada.");
                }

                // Atualiza a descrição
                tarefa.DS_TAREFA = request.DS_TAREFA;
                return _tarefas;
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro ao atualizar tarefa com ID {ID_TAREFA}.", ex);
            }
        }

        // Bônus: Obtém uma tarefa pelo ID
        public TarefaDTO ObterTarefa(int ID_TAREFA)
        {
            try
            {
                var tarefa = _tarefas.FirstOrDefault(x => x.ID_TAREFA == ID_TAREFA);
                if (tarefa == null)
                {
                    throw new KeyNotFoundException($"Tarefa com ID {ID_TAREFA} não encontrada.");
                }
                return tarefa;
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro ao obter tarefa com ID {ID_TAREFA}.", ex);
            }
        }
    }
}