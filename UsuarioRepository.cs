using System;
using System.Collections.Generic;
using MySqlConnector;
 
namespace AT02_RafaelOlivato_UC04.Models
{
    public class UsuarioRepository
    {
        private const string DadosConexao ="Database=Turismo;Data Source=localhost; User Id=root;";
 
        public void TestarConexao(){
 
            MySqlConnection Conexao = new MySqlConnection(DadosConexao);
 
            Conexao.Open();
            Console.WriteLine("Banco de dados funcionando");
 
            Conexao.Close();
 
        }

        public Usuario BuscarPorId(int id){

            MySqlConnection Conexao = new MySqlConnection(DadosConexao);
            
            Conexao.Open();

            Usuario UsuarioEncontrado = new Usuario();

            String Query ="SELECT * FROM Usuario WHERE ID=@id";

            MySqlCommand Comando = new MySqlCommand(Query, Conexao);

            Comando.Parameters.AddWithValue("@Id", id);

            //recuperar os registros comando
            MySqlDataReader Reader = Comando.ExecuteReader();

            if (Reader.Read()){

                UsuarioEncontrado.Id =Reader.GetInt32("id");

                if(!Reader.IsDBNull(Reader.GetOrdinal("Nome"))){
               UsuarioEncontrado.Nome=Reader.GetString("Nome");
                }
                if(!Reader.IsDBNull(Reader.GetOrdinal("Login"))){
                UsuarioEncontrado.Login=Reader.GetString("Login");
                }
                if(!Reader.IsDBNull(Reader.GetOrdinal("Senha"))){
                UsuarioEncontrado.Senha=Reader.GetString("Senha");
                }
                
                UsuarioEncontrado.DataNascimento= Reader.GetDateTime("DataNascimento");
            }


            Conexao.Close();

            return UsuarioEncontrado;
        }

        public void remover(Usuario user){

            MySqlConnection Conexao = new MySqlConnection(DadosConexao);
            Conexao.Open();

            String Query = "DELETE FROM Usuario WHERE Id=@Id";
            MySqlCommand Comando = new MySqlCommand(Query, Conexao);

            Comando.Parameters.AddWithValue("@Id", user.Id);

            Comando.ExecuteNonQuery();

            Conexao.Close();
        }

        public void inserir(Usuario novouser){

            MySqlConnection Conexao = new MySqlConnection(DadosConexao);
            Conexao.Open();

            String Query = "INSERT INTO Usuario (Nome,Login,Senha,DataNascimento) VALUES (@Nome,@login,@Senha,@DataNascimento)";
           
            MySqlCommand Comando = new MySqlCommand(Query, Conexao);

            
            Comando.Parameters.AddWithValue("@Nome", novouser.Nome);
            Comando.Parameters.AddWithValue("@Login", novouser.Login);
            Comando.Parameters.AddWithValue("@Senha", novouser.Senha);
            Comando.Parameters.AddWithValue("@DataNascimento", novouser.DataNascimento);

            Comando.ExecuteNonQuery();

            Conexao.Close();
        }

        public void atualizar(Usuario user){

            MySqlConnection Conexao = new MySqlConnection(DadosConexao);
            Conexao.Open();

            String Query = "UPDATE Usuario SET Nome=@Nome,Login=@login,Senha=@Senha,DataNascimento=@DataNascimento WHERE Id=@Id";
           
            MySqlCommand Comando = new MySqlCommand(Query, Conexao);

            Comando.Parameters.AddWithValue("@Id", user.Id);
            Comando.Parameters.AddWithValue("@Nome", user.Nome);
            Comando.Parameters.AddWithValue("@Login", user.Login);
            Comando.Parameters.AddWithValue("@Senha", user.Senha);
            Comando.Parameters.AddWithValue("@DataNascimento", user.DataNascimento);

            Comando.ExecuteNonQuery();

            Conexao.Close();
        }
 
        public List<Usuario> Listar(){
 
            MySqlConnection Conexao = new MySqlConnection(DadosConexao);
 
            Conexao.Open();
           
            List<Usuario> ListaDeUsuarios = new List<Usuario>();
 
            String Query = "SELECT * FROM Usuario";
            MySqlCommand Comando = new MySqlCommand(Query,Conexao);
 
            MySqlDataReader Reader = Comando.ExecuteReader();
 
            while(Reader.Read()){
 
                Usuario UsuarioEncontrado = new Usuario();
 
                UsuarioEncontrado.Id =Reader.GetInt32("Id");

                if (!Reader.IsDBNull(Reader.GetOrdinal("Nome"))){
                UsuarioEncontrado.Nome =Reader.GetString("Nome");
                }
                 if (!Reader.IsDBNull(Reader.GetOrdinal("Login"))){
                UsuarioEncontrado.Login =Reader.GetString("Login");
                 }
                 if (!Reader.IsDBNull(Reader.GetOrdinal("Senha"))){
                UsuarioEncontrado.Senha = Reader.GetString("Senha");
                 }
                UsuarioEncontrado.DataNascimento =Reader.GetDateTime("DataNascimento");

                ListaDeUsuarios.Add(UsuarioEncontrado);
 
            }
           
            Conexao.Close();
 
            return ListaDeUsuarios;
        }
    }
}
