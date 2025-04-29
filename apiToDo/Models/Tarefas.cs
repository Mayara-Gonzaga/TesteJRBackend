using apiToDo.DTO;
using System;
using System.Collections.Generic;
using System.Linq;

namespace apiToDo.Models
{
    public class Tarefas
    {
        
        private static readonly List<TarefaDTO> _tarefas = new List<TarefaDTO>
        {
            new TarefaDTO { ID_TAREFA = 1458, DS_TAREFA = "Tarefa Inicial" } 
            
        };

        
        public List<TarefaDTO> lstTarefas()
        {
            try
            {
                return _tarefas; 
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao listar tarefas.", ex); 
            }
        }

        
        public List<TarefaDTO> InserirTarefa(TarefaDTO request)
        {
            try
            {
                
                if (request == null || string.IsNullOrEmpty(request.DS_TAREFA))
                {
                    throw new ArgumentException("A descrição da tarefa é obrigatória.");
                }

                
                request.ID_TAREFA = _tarefas.Any() ? _tarefas.Max(t => t.ID_TAREFA) + 1 : 1;
                _tarefas.Add(request); 
                return _tarefas; 
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao inserir tarefa.", ex);
            }
        }

        
        public List<TarefaDTO> DeletarTarefa(int ID_TAREFA)
        {
            try
            {
                
                var tarefa = _tarefas.FirstOrDefault(x => x.ID_TAREFA == ID_TAREFA);

                
                if (tarefa == null)
                {
                    throw new KeyNotFoundException($"Tarefa com ID {ID_TAREFA} não encontrada.");
                }

                
                _tarefas.Remove(tarefa);

                
                return _tarefas;
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro ao deletar tarefa com ID {ID_TAREFA}.", ex);
            }
        }

        
        public List<TarefaDTO> AtualizarTarefa(int ID_TAREFA, TarefaDTO request)
        {
            try
            {
                
                if (request == null || string.IsNullOrEmpty(request.DS_TAREFA))
                {
                    throw new ArgumentException("A descrição da tarefa é obrigatória.");
                }

                
                var tarefa = _tarefas.FirstOrDefault(x => x.ID_TAREFA == ID_TAREFA);
                if (tarefa == null)
                {
                    throw new KeyNotFoundException($"Tarefa com ID {ID_TAREFA} não encontrada.");
                }

                
                tarefa.DS_TAREFA = request.DS_TAREFA;

               
                return _tarefas;
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro ao atualizar tarefa com ID {ID_TAREFA}.", ex);
            }
        }

        
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