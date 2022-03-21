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
    public class DepotService : IDepotService
    {
        private readonly SqlConnectionConfiguration _config;
        public DepotService(SqlConnectionConfiguration configuration)
        {
            _config = configuration;
        }
        public async Task<bool> CreateDepot(Depot depot)
        {
            var parameters = new DynamicParameters();
            parameters.Add("refclient", depot.RefClient, DbType.Int32);
            parameters.Add("refcompte", depot.RefCompte, DbType.Int32);
            parameters.Add("montant", depot.Montant, DbType.Decimal);
            parameters.Add("devise", depot.Devise, DbType.String);
            parameters.Add("datedepot", depot.DateDepot, DbType.DateTime);
            parameters.Add("author", depot.Author, DbType.String);
            using (var con = new SqlConnection(_config.Value))
            {
                if (con.State == ConnectionState.Closed) con.Open();
                try
                {
                    await con.ExecuteAsync("savedepot", parameters, commandType: CommandType.StoredProcedure);
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

        public async Task<bool> DeleteDepot(int id)
        {
            var parameters = new DynamicParameters();
            parameters.Add("id", id, DbType.Int32);
            using (var con = new SqlConnection(_config.Value))
            {
                if (con.State == ConnectionState.Closed) con.Open();
                try
                {
                    await con.ExecuteAsync("deletedepot", parameters, commandType: CommandType.StoredProcedure);
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

        public async Task<IEnumerable<DepotModel>> GetDepot()
        {
            IEnumerable<DepotModel> depot;
            using (var con = new SqlConnection(_config.Value))
            {
                if (con.State == ConnectionState.Closed) con.Open();
                try
                {
                    depot = await con.QueryAsync<DepotModel>("getAlldepot", commandType: CommandType.StoredProcedure);
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
            return depot;
        }

        public async Task<DepotModel> SingleDepot(int id)
        {
            var parameters = new DynamicParameters();
            parameters.Add("id", id, DbType.Int32);
            DepotModel depot = new DepotModel();
            using (var con = new SqlConnection(_config.Value))
            {
                if (con.State == ConnectionState.Closed) con.Open();
                try
                {
                    depot = await con.QueryFirstOrDefaultAsync<DepotModel>("getByIdDepot", parameters, commandType: CommandType.StoredProcedure);
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
            return depot;
        }

        public async Task<bool> UpdateDepot(int id, Depot depot)
        {
            var parameters = new DynamicParameters();
            parameters.Add("id", depot.Id, DbType.Int32);
            parameters.Add("refclient", depot.RefClient, DbType.Int32);
            parameters.Add("refcompte", depot.RefCompte, DbType.Int32);
            parameters.Add("montant", depot.Montant, DbType.Decimal);
            parameters.Add("devise", depot.Devise, DbType.String);
            parameters.Add("datedepot", depot.DateDepot, DbType.DateTime);
            parameters.Add("author", depot.Author, DbType.String);
            using (var con = new SqlConnection(_config.Value))
            {
                if (con.State == ConnectionState.Closed) con.Open();
                try
                {
                    await con.ExecuteAsync("updatedepot", parameters, commandType: CommandType.StoredProcedure);
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
