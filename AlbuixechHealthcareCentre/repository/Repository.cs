using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Web;

namespace AlbuixechHealthcareCentre.repository
{
    public class Repository<T> where T : class
    {

        private string connectionString = "Data Source=|DataDirectory|/BDD.db;Version=3;";


        public IEnumerable<T> GetAll(string query, Action<SQLiteCommand> parameterSetter, Func<SQLiteDataReader, T> mapFunction)
        {
            var list = new List<T>();
            using (var con = new SQLiteConnection(connectionString))
            {
                var cmd = new SQLiteCommand(query, con);
                parameterSetter?.Invoke(cmd);
                con.Open();
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        list.Add(mapFunction(reader));
                    }
                }
            }
            return list;
        }

        public void ExecuteCommand(string query, Action<SQLiteCommand> parameterSetter)
        {

            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                SQLiteCommand command = new SQLiteCommand(query, connection);

                connection.Open();

                parameterSetter(command);

                command.ExecuteNonQuery();

            }
        }

        public int ExecuteScalar(string query, Action<SQLiteCommand> parameterSetter)
        {
            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                SQLiteCommand command = new SQLiteCommand(query, connection);
                connection.Open();
                parameterSetter?.Invoke(command);

                // Convertir el resultado a int, o lanzar una excepción si no es posible
                object result = command.ExecuteScalar();
                if (result != null && int.TryParse(result.ToString(), out int scalarValue))
                {
                    return scalarValue;
                }
                throw new InvalidOperationException("ExecuteScalar did not return a valid integer value.");
            }
        }

        public int ExecuteTransaction(Func<SQLiteCommand, int> transactionalOperation)
        {
            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                connection.Open();
                using (var transaction = connection.BeginTransaction())
                {
                    SQLiteCommand command = connection.CreateCommand();
                    command.Transaction = transaction;

                    try
                    {
                        // Ejecutar la operación
                        int result = transactionalOperation(command);

                        // Confirmar la transacción
                        transaction.Commit();
                        return result;
                    }
                    catch
                    {
                        // Revertir si hay algún error
                        transaction.Rollback();
                        throw;
                    }
                }
            }
        }
    }


}