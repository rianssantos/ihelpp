using iHelp.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComercialSys.Classes
{
    public class categoria
    {
        public int Id { get; set; }
        public string Nome { get; set; }
      
        public categoria() { } // METODO CONSTRUTOR VAZIO

        public categoria(int id, string nome)
        {
            Id = id;
            Nome = nome;
          
        }
        public categoria(string nome)
        {
            Nome = nome;
            
        }
      
        // METODO DE FUNCIONALIDADES
        public void Inserir()
        {
            // CONEXÃO COM O BANCO
            var cmd = Banco.Abrir();
            // INSERIR VALORES NA TABELA CATEGORIA
            cmd.CommandText = "insert categoria values (0, '" + Nome + "'));";
            cmd.ExecuteNonQuery();
            // ATRIBUIÇÃO id a PROPRIEDADE Id
            cmd.CommandText = "select @@identity";
            Id = Convert.ToInt32(cmd.ExecuteScalar());
            // FECHAR A CONEXÃO
        }
        public List<categoria> Listar() // LISTAR A CATEGORIA
        {
            List<categoria> lista = new List<categoria>();
            // ABRIR CONEXÃO COM O BANCO
            var cmd = Banco.Abrir();
            cmd.CommandText = "select * from categoria";
            var dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                lista.Add(new categoria(
                   dr.GetInt32(0),
                   dr.GetString(1)
                ));
            }
            return lista;
        }

        public void BuscarPorId(int id) // LISTAR A TABELA CATEGORIA
        {
            // ABRIR CONEXÃO COM O BANCO
            var cmd = Banco.Abrir();
            // BUSCAR REGISTROS NA TABELA CATEGORIA
            cmd.CommandText = "select * from categoria where id = " + id;
            var dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                Id = dr.GetInt32(0);
                Nome = dr.GetString(1);
            }  
        }
        public bool Alterar(int id)
        {
            bool alterado = false;
            // CONEXÃO COM O BANCO
            var cmd = Banco.Abrir();
            // BUSCAR VALORES NA TABELA A SER ALTERADO
            cmd.CommandText = "update categoria " +
                "set nome = '" + Nome + "'," +
         
                "where id = " + id;
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
            // INDICA A VALIDAÇÃO (SE FOI ALTERADO OU NÃO)
            
            return alterado;
        }
    }
}