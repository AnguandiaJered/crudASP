using BlazorDB.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using System.Data;
using Microsoft.Data.SqlClient;

namespace BlazorDB.Data.Services
{
    public class ClientService : IClientService
    {
        private readonly SqlConnectionConfiguration _config;
        public ClientService(SqlConnectionConfiguration configuration)
        {
            _config = configuration;
        }

        public async Task<bool> CreateClient(Client client)
        {
            var parameters = new DynamicParameters();
            parameters.Add("noms", client.Noms, DbType.String);
            parameters.Add("sexe", client.Sexe, DbType.String);
            parameters.Add("datenaissance", client.Datenaissance, DbType.DateTime);
            parameters.Add("adresse", client.Adresse, DbType.String);
            parameters.Add("telephone", client.Telephone, DbType.String);
            parameters.Add("ville", client.Ville, DbType.String);
            parameters.Add("nationalite", client.Nationalite, DbType.String);

            using (var con = new SqlConnection(_config.Value))
            {
                if (con.State == ConnectionState.Closed) con.Open();
                try
                {
                    await con.ExecuteAsync("saveclient", parameters, commandType: CommandType.StoredProcedure);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    if (con.State == ConnectionState.Open) con.Close();
                }
            }
            return true;
        }

        public async Task<bool> DeleteClient(int id)
        {
            var parameters = new DynamicParameters();
            parameters.Add("id", id, DbType.Int32);
            using (var con = new SqlConnection(_config.Value))
            {
                if (con.State == ConnectionState.Closed) con.Open();
                try
                {
                    await con.ExecuteAsync("deleteclient", parameters, commandType: CommandType.StoredProcedure);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    if (con.State == ConnectionState.Open) con.Close();
                }
            }
            return true;
        }

        public async Task<bool> EditClient(int id, Client client)
        {
            var parameters = new DynamicParameters();
            parameters.Add("id", client.Id, DbType.Int32);
            parameters.Add("noms", client.Noms, DbType.String);
            parameters.Add("sexe", client.Sexe, DbType.String);
            parameters.Add("datenaissance", client.Datenaissance, DbType.DateTime);
            parameters.Add("adresse", client.Adresse, DbType.String);
            parameters.Add("telephone", client.Telephone, DbType.String);
            parameters.Add("ville", client.Ville, DbType.String);
            parameters.Add("nationalite", client.Nationalite, DbType.String);

            using (var con = new SqlConnection(_config.Value))
            {
                if (con.State == ConnectionState.Closed) con.Open();
                try
                {
                    await con.ExecuteAsync("updateclient", parameters, commandType: CommandType.StoredProcedure);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    if (con.State == ConnectionState.Open) con.Close();
                }
            }
            return true;
        }

        public async Task<IEnumerable<Client>> GetClients()
        {
            IEnumerable<Client> client;
            using (var con = new SqlConnection(_config.Value))
            {
                if (con.State == ConnectionState.Closed) con.Open();
                try
                {
                    client = await con.QueryAsync<Client>("getAllClient", commandType: CommandType.StoredProcedure);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    if (con.State == ConnectionState.Open) con.Close();
                }
            }
            return client;
        }

        public async Task<Client> SingleClient(int id)
        {
            Client client = new Client();
            var parameters = new DynamicParameters();
            parameters.Add("id", id, DbType.Int32);
           
            using (var con = new SqlConnection(_config.Value))
            {
                if (con.State == ConnectionState.Closed) con.Open();
                try
                {
                    client = await con.QueryFirstOrDefaultAsync<Client>("getByIdClient", parameters, commandType: CommandType.StoredProcedure);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    if (con.State == ConnectionState.Open) con.Close();
                }
            }
            return client;
        }
    }
}
