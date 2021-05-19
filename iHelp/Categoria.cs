using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iHelp
{ 
    public class Categoria
    {
        public int id { get; set; }
        public string nome { get; set; }
        public string ativo { get; set; }
    }

    public Categoria() { } // método construtor

    public Categoria(int id, string nome, string ativo)
    {
        id = id;
        nome = nome;
        ativo = ativo;        
    }

    public Categoria( string nome, string ativo)
    {
        
        nome = nome;
        ativo = ativo;
    }

    public void Inserir()
    {
        // conectar ao banco
        var cmd = Banco.Abrir();
        // inserir valores na tabela 
        cmd.CommandText = "insert categoria  values (0, '" + nome + "','" + ativo + "', '" + default + "');";
        cmd.ExecuteNonQuery();
        // atribuir id a Propriedade Id
        cmd.CommandText = "select @@identity";
        Id = Convert.ToInt32(cmd.ExecuteScalar());
        // fecha a concexao
    }

    public List<ativo> Listar() // lista todos os produtos
    {
        List<ativo> lista = new List<ativo>();
        // conectar ao banco
        var cmd = Banco.Abrir();
        cmd.CommandText = "select * from categoria";
        var dr = cmd.ExecuteReader();
        while (dr.Read())
        {
            lista.Add(new categoria(
            dr.GetInt32(0),
            dr.GetString(1),
            dr.GetString(2)

            ));
        }
        // atribuir registros à lista
        // fecha a concexao
        // entregar lista pra quem chamou
        return lista;
    }

    public bool Alterar(int id)
    {
        bool alterado = false;
        // conectar ao banco
        var cmd = Banco.Abrir();
        // buscar o registro na tabela  a ser alterado 
        // atribuir os valores às propriedades
        cmd.CommandText = "update categoria " +
            "set nome = '" + nome + "'," +
            "ativo = '" + ativo + "'," +
            "where id = " + id;
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
        // indica a validação (alterado com sucesso ou não)
        // fecha a concexao
        return alterado;
    }
}

