using BlazorDB.Data.Interfaces;
using Dapper;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorDB.Data.Services
{
    public class CityService : ICityService
    {
        private readonly SqlConnectionConfiguration _configuration;
        public CityService(SqlConnectionConfiguration configuration)
        {
            _configuration = configuration;
        }
        public async Task<bool> CreateCity(City city)
        {
            using (var conn = new SqlConnection(_configuration.Value))
            {
                const string query = @"INSERT INTO dbo.City(Name,State) VALUES (@Name, @State)";
                if (conn.State == ConnectionState.Closed) conn.Open();
                try
                {
                    await conn.ExecuteAsync(query, new { city.Name, city.State }, commandType: CommandType.Text);
                }catch(Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    if (conn.State == ConnectionState.Open) conn.Close();
                }
            }
            return true;
        }

        public async Task<bool> DeleteCity(int id)
        {
            //on utilise SqlConnection avec la chaine de connexion parametre
            using(var conn=new SqlConnection(_configuration.Value))
            {
                //on cree la requette
                const string query = @"DELETE FROM dbo.City WHERE Id=@Id";
                //on test si la connexion est fermee on l'ouvre
                if (conn.State == ConnectionState.Closed) conn.Open();
                //on fait l'operation en tennant compte de la gestion d'erreur
                try
                {
                    await conn.ExecuteAsync(query, new { id }, commandType: CommandType.Text);
                }catch(Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    if (conn.State == ConnectionState.Open) conn.Close();
                }
            }
            return true;
        }

        public async Task<bool> EditCity(int id, City city)
        {
            using (var conn = new SqlConnection(_configuration.Value))
            {
                const string query = @"UPDATE dbo.City SET Name=@Name, State=@State WHERE Id=@Id";
                if (conn.State == ConnectionState.Closed) conn.Open();
                try
                {
                    await conn.ExecuteAsync(query, new { city.Name, city.State, id }, commandType: CommandType.Text);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    if (conn.State == ConnectionState.Open) conn.Close();
                }
            }
            return true;
        }

        public async Task<IEnumerable<City>> GetCities()
        {
            IEnumerable<City> cities;
            using(var conn=new SqlConnection(_configuration.Value))
            {
                const string query = @"SELECT * FROM dbo.City";
                if (conn.State == ConnectionState.Closed) conn.Open();
                try
                {
                    cities = await conn.QueryAsync<City>(query);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    if (conn.State == ConnectionState.Open) conn.Close();
                }
            }

            return cities;
        }

        public async Task<City> SingleCity(int id)
        {
            City city = new City();
            using (var conn = new SqlConnection(_configuration.Value))
            {
                const string query = @"SELECT * FROM dbo.City WHERE Id=@id";
                if (conn.State == ConnectionState.Closed) conn.Open();
                try
                {
                    city = await conn.QueryFirstOrDefaultAsync<City>(query, new { id }, commandType: CommandType.Text);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    if (conn.State == ConnectionState.Open) conn.Close();
                }
            }

            return city;
        }
    }
}
