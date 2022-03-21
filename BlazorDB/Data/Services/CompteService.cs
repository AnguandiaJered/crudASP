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
    public class CompteService : ICompteService
    {
        private readonly SqlConnectionConfiguration _config;
        public CompteService(SqlConnectionConfiguration configuration)
        {
            _config = configuration;
        }
        public async Task<bool> CreateCompte(Compte compte)
        {
            var parameters = new DynamicParameters();
            parameters.Add("numcompte", compte.NumCompte, DbType.String);
            parameters.Add("typecompte", compte.TypeCompte, DbType.String);
            parameters.Add("datecreate", compte.DateCreate, DbType.DateTime);
            parameters.Add("solde", compte.Solde, DbType.Decimal);
            parameters.Add("refclient", compte.RefClient, DbType.Int32);
            parameters.Add("author", compte.Author, DbType.String);
            using (var con = new SqlConnection(_config.Value))
            {
                if (con.State == ConnectionState.Closed) con.Open();
                try
                {
                    await con.ExecuteAsync("savecompte", parameters, commandType: CommandType.StoredProcedure);
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

        public async Task<bool> DeleteComte(int id)
        {
            var parameters = new DynamicParameters();
            parameters.Add("id", id, DbType.Int32);
            using (var con = new SqlConnection(_config.Value))
            {
                if (con.State == ConnectionState.Closed) con.Open();
                try
                {
                    await con.ExecuteAsync("deletecompte", parameters, commandType: CommandType.StoredProcedure);
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

        public async Task<IEnumerable<CompteModel>> GetCompte()
        {
            IEnumerable<CompteModel> compte;
            using (var con = new SqlConnection(_config.Value))
            {
                if (con.State == ConnectionState.Closed) con.Open();
                try
                {
                    compte = await con.QueryAsync<CompteModel>("getAllCompte", commandType: CommandType.StoredProcedure);
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
            return compte;
        }

        public async Task<CompteModel> SingleCompte(int id)
        {
            var parameters = new DynamicParameters();
            parameters.Add("id", id, DbType.Int32);
            CompteModel compte = new CompteModel();
            using (var con = new SqlConnection(_config.Value))
            {
                if (con.State == ConnectionState.Closed) con.Open();
                try
                {
                    compte = await con.QueryFirstOrDefaultAsync<CompteModel>("getByIdCompte", parameters, commandType: CommandType.StoredProcedure);
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
            return compte;
        }

        public async Task<bool> UpdateCompte(int id, Compte compte)
        {
            var parameters = new DynamicParameters();
            parameters.Add("id", compte.Id, DbType.Int32);
            parameters.Add("numcompte", compte.NumCompte, DbType.String);
            parameters.Add("typecompte", compte.TypeCompte, DbType.String);
            parameters.Add("datecreate", compte.DateCreate, DbType.DateTime);
            parameters.Add("solde", compte.Solde, DbType.Decimal);
            parameters.Add("refclient", compte.RefClient, DbType.Int32);
            parameters.Add("author", compte.Author, DbType.String);
            using (var con = new SqlConnection(_config.Value))
            {
                if (con.State == ConnectionState.Closed) con.Open();
                try
                {
                    await con.ExecuteAsync("updatecompte", parameters, commandType: CommandType.StoredProcedure);
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
    }
}
