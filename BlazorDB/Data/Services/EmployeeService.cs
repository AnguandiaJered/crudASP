using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlazorDB.Data.Interfaces;
using Dapper;
using System.Data;
using Microsoft.Data.SqlClient;

namespace BlazorDB.Data.Services
{
   
    public class EmployeeService : IEmployeeService
    {
        public readonly SqlConnectionConfiguration _config;
        public EmployeeService(SqlConnectionConfiguration conf)
        {
            _config = conf;
        }
        public async Task<bool> CreateEmployee(Employee employee)
        {
            var parameters = new DynamicParameters();
            parameters.Add("name", employee.Name, DbType.String);
            parameters.Add("departement", employee.Departement, DbType.String);
            parameters.Add("designation", employee.Designation, DbType.String);
            parameters.Add("company", employee.Company, DbType.String);
            parameters.Add("cityId", employee.CityId, DbType.Int32);
            using(var con=new SqlConnection(_config.Value))
            {
                if (con.State == ConnectionState.Closed) con.Open();
                try
                {
                    await con.ExecuteAsync("add_employee", parameters, commandType: CommandType.StoredProcedure);
                }catch(Exception ex)
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

        public async Task<bool> DeleteEmployee(int id)
        {
            var parameters = new DynamicParameters();      
            parameters.Add("id",id, DbType.Int32);
            using (var con = new SqlConnection(_config.Value))
            {
                if (con.State == ConnectionState.Closed) con.Open();
                try
                {
                    await con.ExecuteAsync("delete_employee", parameters, commandType: CommandType.StoredProcedure);
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

        public async Task<IEnumerable<EmployeeModel>> GetEmployees()
        {
            IEnumerable<EmployeeModel> employees;
            using (var con = new SqlConnection(_config.Value))
            {
                if (con.State == ConnectionState.Closed) con.Open();
                try
                {
                    employees = await con.QueryAsync<EmployeeModel>("getAllEmployee", commandType: CommandType.StoredProcedure);
                }catch(Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    if (con.State == ConnectionState.Open) con.Close();
                }
            }
            return employees;
        }

        public async Task<EmployeeModel> SingleEmployee(int id)
        {
            var parameters = new DynamicParameters();
            parameters.Add("id", id, DbType.Int32);
            EmployeeModel employee = new EmployeeModel();
            using (var con = new SqlConnection(_config.Value))
            {
                if (con.State == ConnectionState.Closed) con.Open();
                try
                {
                    employee = await con.QueryFirstOrDefaultAsync<EmployeeModel>("getByIdEmployee",parameters ,commandType: CommandType.StoredProcedure);
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
            return employee;
        }

        public async Task<bool> UpdateEmployee(int id, Employee employee)
        {
            var parameters = new DynamicParameters();
            parameters.Add("id", employee.Id, DbType.Int32);
            parameters.Add("name", employee.Name, DbType.String);
            parameters.Add("departement", employee.Departement, DbType.String);
            parameters.Add("designation", employee.Designation, DbType.String);
            parameters.Add("company", employee.Company, DbType.String);
            parameters.Add("cityId", employee.CityId, DbType.Int32);
            using (var con = new SqlConnection(_config.Value))
            {
                if (con.State == ConnectionState.Closed) con.Open();
                try
                {
                    await con.ExecuteAsync("update_employee", parameters, commandType: CommandType.StoredProcedure);
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
