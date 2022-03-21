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
    public class RetraitService : IRetraitService
    {
        private readonly SqlConnectionConfiguration _config;
        public RetraitService(SqlConnectionConfiguration configuration)
        {
            _config = configuration;
        }
        public async Task<bool> CreateRetrait(Retrait retrait)
        {
            var parameters = new DynamicParameters();
            parameters.Add("refclient", retrait.RefClient, DbType.Int32);
            parameters.Add("refcompte", retrait.RefCompte, DbType.Int32);
            parameters.Add("montant", retrait.Montant, DbType.Decimal);
            parameters.Add("devise", retrait.Devise, DbType.String);
            parameters.Add("dateretrait", retrait.DateRetrait, DbType.DateTime);
            parameters.Add("author", retrait.Author, DbType.String);
            using (var con = new SqlConnection(_config.Value))
            {
                if (con.State == ConnectionState.Closed) con.Open();
                try
                {
                    await con.ExecuteAsync("saveretrait", parameters, commandType: CommandType.StoredProcedure);
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

        public async Task<bool> DeleteRetrait(int id)
        {
            var parameters = new DynamicParameters();
            parameters.Add("id", id, DbType.Int32);
            using (var con = new SqlConnection(_config.Value))
            {
                if (con.State == ConnectionState.Closed) con.Open();
                try
                {
                    await con.ExecuteAsync("deleteretrait", parameters, commandType: CommandType.StoredProcedure);
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

        public async Task<IEnumerable<RetraitModel>> GetRetrait()
        {
            IEnumerable<RetraitModel> retrait;
            using (var con = new SqlConnection(_config.Value))
            {
                if (con.State == ConnectionState.Closed) con.Open();
                try
                {
                    retrait = await con.QueryAsync<RetraitModel>("getAllretrait", commandType: CommandType.StoredProcedure);
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
            return retrait;
        }

        public async Task<RetraitModel> SingleRetrait(int id)
        {
            var parameters = new DynamicParameters();
            parameters.Add("id", id, DbType.Int32);
            RetraitModel retrait = new RetraitModel();
            using (var con = new SqlConnection(_config.Value))
            {
                if (con.State == ConnectionState.Closed) con.Open();
                try
                {
                    retrait = await con.QueryFirstOrDefaultAsync<RetraitModel>("getByIdDepot", parameters, commandType: CommandType.StoredProcedure);
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
            return retrait;
        }

        public async Task<bool> UpdateRetrait(int id, Retrait retrait)
        {
            var parameters = new DynamicParameters();
            parameters.Add("id", retrait.Id, DbType.Int32);
            parameters.Add("refclient", retrait.RefClient, DbType.Int32);
            parameters.Add("refcompte", retrait.RefCompte, DbType.Int32);
            parameters.Add("montant", retrait.Montant, DbType.Decimal);
            parameters.Add("devise", retrait.Devise, DbType.String);
            parameters.Add("dateretrait", retrait.DateRetrait, DbType.DateTime);
            parameters.Add("author", retrait.Author, DbType.String);
            using (var con = new SqlConnection(_config.Value))
            {
                if (con.State == ConnectionState.Closed) con.Open();
                try
                {
                    await con.ExecuteAsync("updateretrait", parameters, commandType: CommandType.StoredProcedure);
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
