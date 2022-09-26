using Dapper;

namespace ClinicManagementSystem.HelperLibraries.Database
{
    public interface IDbDapper
    {
        T QueryFirstOrDefault<T>(string sql, DynamicParameters parameters = null);
        List<T> Query<T>(string sql, DynamicParameters parameters = null);
        int Execute(string sql, DynamicParameters parameters = null);
        T ExecuteScalar<T>(string sql, DynamicParameters parameters = null);
        List<T> ExecuteSP<T>(string sql, DynamicParameters parameters = null, string connectionString = null);

        void ExecuteSp(string sql, DynamicParameters parameters = null);
        List<dynamic> ExecuteSP(string sql, DynamicParameters parameters = null);
        Tuple<List<TU>, List<TV>> QueryMultiple<TU, TV>(string sql, DynamicParameters parameters = null);

        /*Tuple<List<TU>, List<TV>, List<TW>> QueryMultiple<TU, TV, TW>(string sql, DynamicParameters parameters = null);

        Tuple<List<TU>, List<TV>, List<TW>, List<TX>> QueryMultiple<TU, TV, TW, TX>(string sql, DynamicParameters parameters = null);

        Tuple<List<TU>, List<TV>, List<TW>, List<TX>, List<TY>> QueryMultiple<TU, TV, TW, TX, TY>(string sql,
            DynamicParameters parameters = null);

        Tuple<List<TU>, List<TV>, List<TW>, List<TX>, List<TY>, List<TZ>>
            QueryMultiple<TU, TV, TW, TX, TY, TZ>(string sql, DynamicParameters parameters = null);

        Tuple<List<TT>, List<TU>, List<TV>, List<TW>, List<TX>, List<TY>, List<TZ>>
            QueryMultiple<TT, TU, TV, TW, TX, TY, TZ>(string sql, DynamicParameters parameters = null);

        Tuple<List<TS>, List<TT>, List<TU>, List<TV>, List<TW>, List<TX>, List<TY>, Tuple<List<TZ>>>
            QueryMultiple<TS, TT, TU, TV, TW, TX, TY, TZ>(string sql, DynamicParameters parameters = null);

        Tuple<Tuple<List<TP>, List<TQ>, List<TR>, List<TS>, List<TT>, List<TU>, List<TV>>,
            Tuple<List<TW>, List<TX>, List<TY>, List<TZ>>> QueryMultiple<TP, TQ, TR, TS, TT, TU, TV, TW, TX, TY, TZ>(string sql,
            DynamicParameters parameters = null);

        void BatchInsert(List<dynamic> data, string tableName, Table table);
        int UpdateChanges(List<dynamic> data, string tableName, Table table, bool insertDone = false);

        Task<T> ExecuteScalarAsync<T>(string sql, DynamicParameters parameters = null);
        Task<List<T>> ExecuteSPAsync<T>(string sql, DynamicParameters parameters = null, string connectionString = null);
        Task<Tuple<List<TU>, List<TV>>> QueryMultipleAsync<TU, TV>(string sql, DynamicParameters parameters = null);*/
    }
}
