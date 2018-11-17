using MySql.Data.MySqlClient;
using System.Collections.Generic;
using System.Data;

namespace AccountingPlanner.System
{
    public class MySQLGateway
    {
        private string _connectionString;

        public MySqlConnection CreateConnection(string ConnectionString)
        {
            return new MySqlConnection(ConnectionString);
        }

        public MySQLGateway(string connectionString)
        {
            this._connectionString = connectionString;
        }

        public DataTable ExecuteProcedure(string procedure_name, List<KeyValuePair<string, string>> param_list)
        {
            MySqlConnection _conn = CreateConnection(this._connectionString);
            _conn.Open();

            MySqlCommand cmd = new MySqlCommand("", _conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = procedure_name;

            for (int i = 0; i < param_list.Count; i++)
            {
                cmd.Parameters.AddWithValue(param_list[i].Key, param_list[i].Value);
            }

            MySqlDataAdapter _da = new MySqlDataAdapter(cmd);
            DataSet _ds = new DataSet();

            _conn.Close();

            _da.Fill(_ds, "ResponeData");

            return _ds.Tables["ResponeData"];
        }

        public DataSet ExecuteProcedureWithDataSet(string procedure_name, List<KeyValuePair<string, string>> param_list)
        {
            MySqlConnection _conn = CreateConnection(this._connectionString);
            _conn.Open();

            MySqlCommand cmd = new MySqlCommand("", _conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = procedure_name;

            for (int i = 0; i < param_list.Count; i++)
            {
                cmd.Parameters.AddWithValue(param_list[i].Key, param_list[i].Value);
            }

            MySqlDataAdapter _da = new MySqlDataAdapter(cmd);
            DataSet _ds = new DataSet();

            _da.Fill(_ds, "ResponeData");

            _conn.Close();

            return _ds;
        }

        public DataTable ExecuteQuery(string query)
        {
            MySqlConnection _conn = CreateConnection(this._connectionString);
            _conn.Open();

            MySqlCommand cmd = new MySqlCommand(query, _conn);

            MySqlDataAdapter _da = new MySqlDataAdapter(cmd);
            DataSet _ds = new DataSet();

            _da.Fill(_ds, "ResponeData");

            _conn.Close();

            return _ds.Tables["ResponeData"];
        }

    }
}
