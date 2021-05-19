using iHelp.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iHelp.Classes
{
    public class servicos
    {
        public int Id { get; set; }
        public string Nome { get; set; }

        public string Descricao { get; set; }
        public double Valor { get; set; }
        public string Status { get; set; }
        public string Comentarios { get; set; }
        public servicos() { } // método construtor

        public servicos(int id, string nome, string descricao, double valor, string status, string comentarios)
        {
            Id = id;
            Nome = nome;
            Descricao = descricao;
            Valor = valor;
            Status = status;
            Comentarios = comentarios;
        }

        public servicos( string nome, string descricao, double valor, string status, string comentarios)
        {

          
            Nome = nome;
            Descricao = descricao;
            Valor = valor;
            Status = status;
            Comentarios = comentarios;
        }

        // METODOS FUNCIONALIDADES

        public void Inserir() // INSERIR SERVIÇOS
        {
            
            // CONEXÃO COM O BANCO
            var cmd = Banco.Abrir();
            // INSERÇÃO DE VALORES NA TABELAS
            cmd.CommandText = "insert servicos values (0, '" + Nome + "','" + Descricao + "', '" + Valor + "','" + Status + "','" + Comentarios + "'  )";
            cmd.ExecuteNonQuery();
            // atribuir id a Propriedade Id
            cmd.CommandText = "select @@identity";
            Id = Convert.ToInt32(cmd.ExecuteScalar());
            // FECHAR A CONEXÃO
        }

        public List<servicos> Listar() // LISTAR TODOS OS SERVIÇOS
        {
            List<servicos> lista = new List<servicos>();
            // CONEXÃO COM O BANCO
            var cmd = Banco.Abrir();
            cmd.CommandText = "select * from usuarios";
            var dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                lista.Add(new servicos(
                 dr.GetInt32(0),
                 dr.GetString(1),
                 dr.GetString(2),
                 dr.GetDouble(3),
                 dr.GetString(4),
                 dr.GetString(5)
          
                ));
            }   
                return lista;
        }

        public void BuscarPorId(int id) // BUSCAR TODOS OS SERVIÇOS
        {
            // CONEXÃO COM O BANCO
            var cmd = Banco.Abrir();
            // BUSCAR SERVICOS NA TABELA
            cmd.CommandText = "select * from servicos where id = " + id;
            var dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                Id = dr.GetInt32(0);
                Nome = dr.GetString(1);
                Descricao= dr.GetString(2);
                Valor = dr.GetDouble(3);
                Status = dr.GetString(4);
                Comentarios = dr.GetString(5);
            }
        }

        public bool Alterar(int id)
        {
            bool alterado = false;
            // CONECTAR COM O BANCO
            var cmd = Banco.Abrir();

            // INSERÇÃO DE SERVIÇOS A TABELA
            cmd.CommandText = $"update servicos set " +
                $"nome = '{Nome}', " +
                $"descricao = '{Descricao}', " +
                $"valor = '{Valor}', " +
                $"status = '{Status}' " +
                $"status = '{Comentarios}' " +
                $"where id = {id}";


            // REGISTRAR A ALTERAÇÃO
            try
            {
                cmd.ExecuteNonQuery();
                alterado = true;
            }
            catch (Exception)
            {
                throw;
            }
            // indica a validação (alterado com sucesso ou não)
            // fecha a concexao
            return alterado;
        }

    }
}
