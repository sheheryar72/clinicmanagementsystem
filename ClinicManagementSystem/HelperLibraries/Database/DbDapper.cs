using Dapper;
using System.Data;
using System.Data.SqlClient;
using System.Transactions;

namespace ClinicManagementSystem.HelperLibraries.Database
{
    public class DbDapper : IDbDapper
    {
        private readonly string _connectionString;
        //private readonly ILogger _logger;

        public DbDapper(IConfiguration connectionString)
        {
            _connectionString = connectionString["ConnectionString:SheheryarLocalHost"];
            //_logger = logger;
        }

        public int Execute(string sql, DynamicParameters parameters = null)
        {
            int result = default(int);
            using (var connection = new SqlConnection(_connectionString))
            {
                try
                {
                    connection.StatisticsEnabled = true;
                    connection.Open();
                    result = connection.Execute(sql, parameters);
                }
                catch(Exception orignalException)
                {
                    throw orignalException;
                }
                var stats = connection.RetrieveStatistics();
            }
            return result;
        }

        public T ExecuteScalar<T>(string sql, DynamicParameters parameters = null)
        {
            T result = default(T);
            using (var connection = new SqlConnection(_connectionString))
            {
                try
                {
                    connection.StatisticsEnabled = true;
                    connection.Open();
                    result = connection.QueryFirst(sql , parameters);
                }
                catch (Exception orignalException)
                {
                    throw orignalException;
                }
            }
            return result;
        }

        public List<T> ExecuteSP<T>(string sql, DynamicParameters parameters = null, string connectionString = null)
        {
            List<T> records;

            using (var connection = new SqlConnection(_connectionString))
            {
                connection.StatisticsEnabled = true;
                connection.Open();

                try
                {
                    records = connection.Query<T>(sql, parameters, commandType: CommandType.StoredProcedure).ToList();
                }
                catch (Exception originalException)
                {
                    throw originalException;
                }
                finally
                {
                    var stats = connection.RetrieveStatistics();
                }
            }

            return records;
        }

        public void ExecuteSp(string sql, DynamicParameters parameters = null)
        {
            using (var transaction = new TransactionScope())
            {
                using (var connection = new SqlConnection(_connectionString))
                {
                    connection.StatisticsEnabled = true;
                    connection.Open();

                    try
                    {
                        connection.Query(sql, parameters, commandType: CommandType.StoredProcedure);
                        transaction.Complete();
                    }
                    catch (Exception originalException)
                    {
                        throw originalException;
                    }

                    var stats = connection.RetrieveStatistics();
                }
            }
        }

        public List<dynamic> ExecuteSP(string sql, DynamicParameters parameters = null)
        {
            List<dynamic> records;

            using (var transaction = new TransactionScope())
            {
                using (var connection = new SqlConnection(_connectionString))
                {
                    connection.StatisticsEnabled = true;
                    connection.Open();

                    try
                    {
                        records = connection.Query(sql, parameters, commandType: CommandType.StoredProcedure).ToList();
                        transaction.Complete();
                    }
                    catch (Exception originalException)
                    {
                        throw originalException;
                    }

                    var stats = connection.RetrieveStatistics();
                }
            }

            return records;
        }

        public List<T> Query<T>(string sql, DynamicParameters parameters = null)
        {
            List<T> records = default(List<T>);

            using (var connection = new SqlConnection(_connectionString))
            {
                connection.StatisticsEnabled = true;
                connection.Open();

                try
                {
                    records = connection.Query<T>(sql, parameters).ToList();
                }
                catch (Exception originalException)
                {
                    throw originalException;
                }

                var stats = connection.RetrieveStatistics();
            }

            return records;
        }

        public T QueryFirstOrDefault<T>(string sql, DynamicParameters parameters = null)
        {
            T record = default(T);

            using (var connection = new SqlConnection(_connectionString))
            {
                connection.StatisticsEnabled = true;
                connection.Open();

                try
                {
                    record = connection.QueryFirstOrDefault<T>(sql, parameters);
                }
                catch (Exception originalException)
                {
                    throw originalException;
                }

                var stats = connection.RetrieveStatistics();
            }

            return record;
        }

        public Tuple<List<TU>, List<TV>> QueryMultiple<TU, TV>(string sql, DynamicParameters parameters = null)
        {
            Tuple<List<TU>, List<TV>> tuple;

            using (var connection = new SqlConnection(_connectionString))
            {
                connection.StatisticsEnabled = true;
                connection.Open();

                try
                {
                    using (var gridReader = connection.QueryMultiple(sql, parameters, commandType: CommandType.StoredProcedure))
                    {
                        tuple = Tuple.Create(gridReader.Read<TU>().ToList(), gridReader.Read<TV>().ToList());
                    }
                }
                catch (Exception originalException)
                {
                    throw originalException;
                }

                var stats = connection.RetrieveStatistics();
            }

            return tuple;
        }

    }
}
