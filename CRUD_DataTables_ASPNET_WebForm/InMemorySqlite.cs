using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Web;

namespace CRUD_DataTables_ASPNET_WebForm
{
    public sealed class InMemorySqlite
    {
        private static readonly InMemorySqlite instance = new InMemorySqlite();
        private readonly SQLiteConnection myConn;

        static InMemorySqlite()
        {
        }

        private InMemorySqlite()
        {
            myConn = new SQLiteConnection("Data Source=:memory:");
            
            string createUserTableSql =
                @"CREATE TABLE User(
						Name TEXT NOT NULL,
						Age INT NULL,
						City TEXT NULL,
                        Email TEXT NULL,
						JoinedDate TEXT NULL,
                        ModifiedDate TEXT NULL,
						PRIMARY KEY (Name)
					);";

            ExecuteNonQuery(createUserTableSql);

            ExecuteNonQuery(@"INSERT INTO User VALUES ('San', 30, 'Kuala Lumpur', 'san@test.com', '2021-01-01', '2021-06-30');
                INSERT INTO User VALUES ('Ali', 18, 'Subang', 'ali@test.com', '2021-02-01', '2021-06-30');
                INSERT INTO User VALUES ('Ahmad', 20, 'Kuala Lumpur', 'ahmad@test.com', '2021-03-01', '2021-06-30');
                INSERT INTO User VALUES ('Tan', 29, 'Penang', 'tan@test.com', '2021-04-01', '2021-06-30');
                INSERT INTO User VALUES ('Chia', 40, 'Kuala Lumpur', 'chia@test.com', '2021-05-01', '2021-06-30');
            ");
        }

        public static InMemorySqlite Instance
        {
            get { return instance; }
        }

        private void OpenConnection()
        {
            if (myConn.State == ConnectionState.Closed || myConn.State == ConnectionState.Broken)
            {
                myConn.Open();
            }
        }

        public object ExecuteScalar(string sql, params SQLiteParameter[] parameters)
        {
            OpenConnection();
            SQLiteCommand cmd = new SQLiteCommand(myConn);
            cmd.CommandText = sql;
            cmd.Parameters.AddRange(parameters);
            return cmd.ExecuteScalar();
        }

        public int ExecuteNonQuery(string sql, params SQLiteParameter[] parameters)
        {
            OpenConnection();
            SQLiteCommand cmd = new SQLiteCommand(myConn);
            cmd.CommandText = sql;
            cmd.Parameters.AddRange(parameters);
            return cmd.ExecuteNonQuery();
        }

        public DataTable GetDataTable(string sql, params SQLiteParameter[] parameters)
        {
            OpenConnection();
            SQLiteCommand cmd = new SQLiteCommand(myConn);
            cmd.CommandText = sql;
            cmd.Parameters.AddRange(parameters);
            SQLiteDataAdapter dad = new SQLiteDataAdapter(cmd);
            DataTable table = new DataTable();
            dad.Fill(table);

            return table;
        }
    }
}