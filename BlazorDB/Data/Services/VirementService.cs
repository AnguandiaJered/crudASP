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
    public class VirementService : IVirementService
    {
        private readonly SqlConnectionConfiguration _config;
        public VirementService(SqlConnectionConfiguration configuration)
        {
            _config = configuration;
        }
        public async Task<bool> CreateVirement(Virement virement)
        {
            var parameters = new DynamicParameters();
            parameters.Add("montant", virement.Montant, DbType.Decimal);
            parameters.Add("refcompte", virement.RefCompte, DbType.Int32);
            parameters.Add("compte2", virement.Compte2, DbType.String);
            parameters.Add("datevirement", virement.Datevirement, DbType.DateTime);
            parameters.Add("author", virement.Author, DbType.String);
            using (var con = new SqlConnection(_config.Value))
            {
                if (con.State == ConnectionState.Closed) con.Open();
                try
                {
                    await con.ExecuteAsync("savevirement", parameters, commandType: CommandType.StoredProcedure);
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

        public async Task<bool> DeleteVirement(int id)
        {
            var parameters = new DynamicParameters();
            parameters.Add("id", id, DbType.Int32);
            using (var con = new SqlConnection(_config.Value))
            {
                if (con.State == ConnectionState.Closed) con.Open();
                try
                {
                    await con.ExecuteAsync("deletevirement", parameters, commandType: CommandType.StoredProcedure);
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

        public async Task<IEnumerable<VirementModel>> GetVirement()
        {
            IEnumerable<VirementModel> virement;
            using (var con = new SqlConnection(_config.Value))
            {
                if (con.State == ConnectionState.Closed) con.Open();
                try
                {
                    virement = await con.QueryAsync<VirementModel>("getAllvirement", commandType: CommandType.StoredProcedure);
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
            return virement;
        }

        public async Task<VirementModel> SingleVirement(int id)
        {
            var parameters = new DynamicParameters();
            parameters.Add("id", id, DbType.Int32);
            VirementModel virement = new VirementModel();
            using (var con = new SqlConnection(_config.Value))
            {
                if (con.State == ConnectionState.Closed) con.Open();
                try
                {
                    virement = await con.QueryFirstOrDefaultAsync<VirementModel>("getByIdvirement", parameters, commandType: CommandType.StoredProcedure);
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
            return virement;
        }

        public async Task<bool> UpdateVirement(int id, Virement virement)
        {
            var parameters = new DynamicParameters();
            parameters.Add("id", virement.Id, DbType.Int32);
            parameters.Add("montant", virement.Montant, DbType.Decimal);
            parameters.Add("refcompte", virement.RefCompte, DbType.Int32);
            parameters.Add("compte2", virement.Compte2, DbType.String);
            parameters.Add("datevirement", virement.Datevirement, DbType.DateTime);
            parameters.Add("author", virement.Author, DbType.String);
            using (var con = new SqlConnection(_config.Value))
            {
                if (con.State == ConnectionState.Closed) con.Open();
                try
                {
                    await con.ExecuteAsync("updatevirement", parameters, commandType: CommandType.StoredProcedure);
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
