using System;
using System.Collections.Generic;
using System.Text;
using MySql.Data.MySqlClient;
using System.Threading.Tasks;
using System.Linq;

namespace VKK
{
    public class MySqlConnector
    {
        MySqlConnection dbVerbindung;
        private string _dbHost = "localhost";
        public string DBHost
        {
            get { return _dbHost; }
            set { _dbHost = value; }
        }

        private string _dbUser = "root";
        public string DBUser
        {
            get { return _dbUser; }
            set { _dbUser = value; }
        }

        private string _dbPassword = "";
        public string DBPassword
        {
            get { return _dbPassword; }
            set { _dbPassword = value; }
        }

        private string _dbName = "";
        public string DBName
        {
            get { return _dbName; }
            set { _dbName = value; }
        }

        private string ConnectionString
        {
            get
            {
                var stringBuilder = new MySqlConnectionStringBuilder();
                stringBuilder.Server = DBHost;
                stringBuilder.UserID = DBUser;
                stringBuilder.Password = DBPassword;
                stringBuilder.Database = DBName;
                stringBuilder.MaximumPoolSize = 120;

                return stringBuilder.ConnectionString;
            }
        }

        public MySqlConnector(string dbname)
        {
            this._dbName = dbname;
        }

        /// <summary>
        /// Öffnet die Verbindung zur Datenbank
        /// </summary>
        /// <returns></returns>
        private MySqlCommand OpenConnection()
        {
            dbVerbindung = new MySqlConnection(this.ConnectionString);
            dbVerbindung.Open();
            MySqlCommand mySqlCommand = new MySqlCommand();
            mySqlCommand.Connection = dbVerbindung;

            return mySqlCommand;
        }

        /// <summary>
        /// Schließt die Verbindung zur Datenbank
        /// </summary>
        public void CloseConnection()
        {
            dbVerbindung.Close();
        }

        /// <summary>
        /// Testet die Verbindung
        /// </summary>
        /// <returns>success message or error message</returns>
        public string TestConnection()
        {
            string msg = "DB-Verbindung erfolgreich!";
            string sql = "show tables; ";

            try
            {
                MySqlCommand sqlCommand = this.OpenConnection();
                sqlCommand.CommandText = sql;
                sqlCommand.ExecuteReader();
                this.CloseConnection();
            }

            catch (Exception ex)
            {
                msg = ex.Message;
            }

            return msg;
        }
        /// <summary>
        /// Führt SQL-Statement aus, gibt letzte eingefügte ID zurück
        /// </summary>
        /// <param name="dml"></param>
        /// <returns>Last Inserted ID</returns>
        public long executeInsert(string dml)
        {
            long retValue = -1;
            MySqlCommand sqlCommand = this.OpenConnection();
            sqlCommand.CommandText = dml;
            sqlCommand.ExecuteNonQuery();
            retValue = sqlCommand.LastInsertedId;
            this.CloseConnection();
            return retValue;
        }

        /// <summary>
        /// Führt SQL-Statement aus
        /// </summary>
        /// <param name="dml"></param>
        /// <returns>ExecuteNonQuery result</returns>
        public int executeNonQuery(string dml)
        {
            int retValue = -1;
            MySqlCommand sqlCommand = this.OpenConnection();
            sqlCommand.CommandText = dml;
            retValue = sqlCommand.ExecuteNonQuery();
            this.CloseConnection();
            return retValue;
        }

        /// <summary>
        /// Führt SQL-Abfrage aus
        /// </summary>
        /// <param name="sql"></param>
        /// <returns>ExecuteReader result</returns>
        public MySqlDataReader ExecuteQuery(string sql)
        {
            MySqlDataReader dataReader = null;
            MySqlCommand sqlCommand = this.OpenConnection();
            sqlCommand.CommandText = sql;
            dataReader = sqlCommand.ExecuteReader();
            return dataReader;
        }
    }
}
