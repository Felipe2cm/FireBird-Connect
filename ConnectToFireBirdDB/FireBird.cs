using FirebirdSql.Data.FirebirdClient;
using System;
using System.Data;

namespace ConnectToFireBirdDB
{
    public class FireBird
    {        
        private readonly FbConnection Fbcon;

        public FireBird(string connectionString)
        {
            Fbcon = new(connectionString);
        }        

        public DataTable DataTableRetornar(string sql)
        {            
            DataTable dataTable = new();

            try
            {
                Fbcon.Open();

                FbCommand fbCmd = new(sql, Fbcon);

                FbDataAdapter fbDa = new(fbCmd);

                fbDa.Fill(dataTable);
            }
            catch (FbException fbex)
            {
                Console.WriteLine("Erro ao acessar o FireBird " + fbex.Message, "Erro");
            }
            finally
            {
                Fbcon.Close();
            }

            return dataTable;
        }
    }
}
