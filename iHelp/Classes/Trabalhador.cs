using iHelp.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iHelp.Classes
{
    public class trabalhador
    {
        // ATRIBUTOS
        // PROPRIEDADES
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Email{ get; set; }
        public string Senha { get; set; }
        public int Cep { get; set; }
        public int Cpf { get; set; }
        public int Celular { get; set; }
        public int Telefone { get; set; }

        // METODOS CONSTRUTORES
        public trabalhador() { }

        public trabalhador(int id, string nome, string email, string senha, int cep, int cpf, int celular, int telefone)
        {
            Id = id;
            Nome = nome;
            Email = email;
            Senha = senha;
            Cep = cep;
            Cpf = cpf;
            Celular = celular;
            Telefone = telefone;
        }
        public trabalhador( string nome, string email, string senha, int cep, int cpf, int celular, int telefone)
        {
           
            Nome = nome;
            Email = email;
            Senha = senha;
            Cep = cep;
            Cpf = cpf;
            Celular = celular;
            Telefone = telefone;
        }
        // METODOS FUNCIONALIDADES
        public void Inserir()
        {
            // CONECTAR AO BANCO
            var cmd = Banco.Abrir();
            // INSERÇÃO DE VALORES A TABELA
            cmd.CommandText = $"insert trabalhador values (" +
                $"0, '{Nome}', '{Email}', '{Senha}', '{Cep}', '{Cpf}', '{Celular}','{Telefone}');";
            cmd.ExecuteNonQuery();
            // ATRIBUIR id a PROPRIEDADE Id
            cmd.CommandText = "select @@identity";
            Id = Convert.ToInt32(cmd.ExecuteScalar());

        }

        public List<trabalhador> Listar() // LISTAR TODOS OS TRABALHADORES
        {
            List<trabalhador> lista = new List<trabalhador>();
            // conectar ao banco
            var cmd = Banco.Abrir();
            cmd.CommandText = "select * from trabalhador";
            var dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                lista.Add(new trabalhador(
                    dr.GetInt32(0),
                    dr.GetString(1),
                    dr.GetString(2),
                    dr.GetString(3),
                    dr.GetInt32(4),
                    dr.GetInt32(5),
                    dr.GetInt32(6),
                    dr.GetInt32(7)
                ));
            }
            return lista;
        }
        public void BuscarPorId(int id) // BUSCAR TODOS OS TRABALHADORES
        {
            // CONEXÃO COM O BANCO
            var cmd = Banco.Abrir();
            // BUSCAR REGISTROS NA TABELA  
            cmd.CommandText = "select * from trabalhador where id = " + id;
            var dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                Id = dr.GetInt32(0);
                Nome = dr.GetString(1);
                Email = dr.GetString(2);
                Senha = dr.GetString(3);
                Cep = dr.GetInt32(4);
                Cpf = dr.GetInt32(5);
                Celular = dr.GetInt32(6);
                Telefone = dr.GetInt32(7);


            }
        }
        public bool Alterar(int id)
        {
            bool alterado = false;
            // CONEXÃO COM O BANCO
            var cmd = Banco.Abrir();
            // ATRIBUIR VALOR AS PROPRIEDADES
            cmd.CommandText = $"update trabalhador set   nome = '{Nome}', email = '{Email}', senha = '{Senha}', cep = '{Cep}', cpf = '{Cpf}', Celular = '{Celular}',Telefone = '{Telefone}',where id = {id};";
            // registra a alteração
            try
            {
                cmd.ExecuteNonQuery();
                alterado = true;
            }
            catch (Exception)
            {
                throw;
            }
            // INDICA A VALIDAÇÃO SE FOI FEITA OU NÃO
            return alterado;
        }
    }
}