using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace EasySQL
{
    public class EasySQL
    {
        private string SQLConnectionString { get; set; }
        private int SQLTimeout { get; set; }

        // Constructor
        public EasySQL(string SQLConnectionString, int SQLTimeout = 120)
        {
            this.SQLConnectionString = SQLConnectionString;
            this.SQLTimeout = SQLTimeout;
        }

        // Summary: 
        // Check if connection to database is established
        private bool IsConnected()
        {
            using (SqlConnection conn = new SqlConnection(SQLConnectionString))
            {
                try
                {
                    conn.Open();
                }
                catch
                {
                    return false;
                }
                finally { conn.Close(); }
            }

            return true;
        }

        // Summary:
        // Execute non-query
        public int Execute(string Query)
        {
            if (Query.Trim() == "")
                throw new ArgumentException("Query can not be blank.");

            SqlConnection conn = new SqlConnection(SQLConnectionString);
            SqlCommand comm = null;
            int returnResult;

            try
            {
                comm = conn.CreateCommand();
                comm.CommandType = CommandType.Text;
                comm.CommandText = Query;
                comm.CommandTimeout = SQLTimeout;
                    try
                    {
                        conn.Open();
                        returnResult = comm.ExecuteNonQuery();
                    }
                    catch (SqlException err)
                    {
                        conn.Close();
                        throw new CustomSqlException("SqlException occured: " + err.Message.ToString(), err);
                    }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }
            finally
            {
                conn.Close(); // Always remember to close connection to database or else it would lead to memory leakage
            }

            return returnResult;
        }

        // Summary:
        // Execute query to fetch data in data set
        public int Execute(string Query, out DataSet Data)
        {
            if (Query.Trim() == "")
                throw new ArgumentException("Query can not be blank.");

            Data = new DataSet();

            SqlConnection conn = new SqlConnection(SQLConnectionString);
            SqlCommand comm = null;
            int returnResult;

            try
            {
                comm = conn.CreateCommand();
                comm.CommandType = CommandType.Text;
                comm.CommandText = Query;
                comm.CommandTimeout = SQLTimeout;
                    try
                    {
                        conn.Open();

                        SqlDataAdapter adapter = new SqlDataAdapter(comm);
                        returnResult = adapter.Fill(Data);
                    }
                    catch (SqlException err)
                    {
                        conn.Close();
                        throw new CustomSqlException("SqlException occured: " + err.Message.ToString(), err);
                    }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }
            finally
            {
                conn.Close(); // Always remember to close connection to database or else it would lead to memory leakage
            }

            return returnResult;
        }

        // Summary:
        // Execute query to fetch the data in datatable
        public int Execute(string Query, out DataTable Data)
        {
            if (Query.Trim() == "")
                throw new ArgumentException("Query can not be blank.");

            Data = new DataTable();

            SqlConnection conn = new SqlConnection(SQLConnectionString);
            SqlCommand comm = null;
            int returnResult;

            try
            {
                comm = conn.CreateCommand();
                comm.CommandType = CommandType.Text;
                comm.CommandText = Query;
                comm.CommandTimeout = SQLTimeout;
                    try
                    {
                        conn.Open();

                        SqlDataAdapter adapter = new SqlDataAdapter(comm);
                        returnResult = adapter.Fill(Data);
                    }
                    catch (SqlException err)
                    {
                        conn.Close();
                        throw new CustomSqlException("SqlException occured: " + err.Message.ToString(), err);
                    }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }
            finally
            {
                conn.Close(); // Always remember to close connection to database or else it would lead to memory leakage
            }

            return returnResult;
        }

        // Summary
        // Execute stored procedure
        public int ExecuteProcedure(string ProcedureName)
        {
            if (ProcedureName.Trim() == "")
                throw new ArgumentException("Stored procedure name can not be blank.");

            SqlConnection conn = new SqlConnection(SQLConnectionString);
            SqlCommand comm = null;
            int returnResult;

            try
            {
                comm = conn.CreateCommand();
                comm.CommandType = CommandType.StoredProcedure;
                comm.CommandText = ProcedureName;
                comm.CommandTimeout = SQLTimeout;
                    try
                    {
                        conn.Open();
                        returnResult = comm.ExecuteNonQuery();
                    }
                    catch (SqlException err)
                    {
                        conn.Close();
                        throw new CustomSqlException("SqlException occured: " + err.Message.ToString(), err);
                    }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }
            finally
            {
                conn.Close(); // Always remember to close connection to database or else it would lead to memory leakage
            }

            return returnResult;
        }

        // Summary
        // Execute stored procedure and fetch the data in dataset
        public int ExecuteProcedure(string ProcedureName, out DataSet Data)
        {
            if (ProcedureName.Trim() == "")
                throw new ArgumentException("Stored procedure name can not be blank.");

            Data = new DataSet();

            SqlConnection conn = new SqlConnection(SQLConnectionString);
            SqlCommand comm = null;
            int returnResult;

            try
            {
                comm = conn.CreateCommand();
                comm.CommandType = CommandType.StoredProcedure;
                comm.CommandText = ProcedureName;
                comm.CommandTimeout = SQLTimeout;
                    try
                    {
                        conn.Open();

                        SqlDataAdapter adapter = new SqlDataAdapter(comm);
                        returnResult = adapter.Fill(Data);
                    }
                    catch (SqlException err)
                    {
                        conn.Close();
                        throw new CustomSqlException("SqlException occured: " + err.Message.ToString(), err);
                    }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }
            finally
            {
                conn.Close(); // Always remember to close connection to database or else it would lead to memory leakage
            }

            return returnResult;
        }

        // Summary:
        // Execute stored procedure and fetch the data in dataset
        public void ExecuteProcedure(string ProcedureName, out DataTable Data)
        {
            if (ProcedureName.Trim() == "")
                throw new ArgumentException("Stored procedure name can not be blank.s");

            Data = new DataTable();

            SqlConnection conn = new SqlConnection(SQLConnectionString);
            SqlCommand comm = null;


            try
            {
                comm = conn.CreateCommand();
                comm.CommandType = CommandType.StoredProcedure;
                comm.CommandText = ProcedureName;
                comm.CommandTimeout = SQLTimeout;
                    try
                    {
                        conn.Open();

                        SqlDataAdapter adapter = new SqlDataAdapter(comm);
                        adapter.Fill(Data);
                    }
                    catch (SqlException err)
                    {
                        conn.Close();
                        throw new CustomSqlException("SqlException occured: " + err.Message.ToString(), err);
                    }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }
            finally
            {
                conn.Close(); // Always remember to close connection to database or else it would lead to memory leakage
            }
        }

        // With SQL Credentials -->

        // Summary:
        // Execute query with credentials for extra security
        public int Execute(string Query, SqlCredential Credential)
        {
            if (Query.Trim() == "")
                throw new ArgumentException("Query can not be blank.s");

            SqlConnection conn = new SqlConnection(SQLConnectionString);
            SqlCommand comm = null;
            int returnResult;

            try
            {
                comm = conn.CreateCommand();
                comm.CommandType = CommandType.Text;
                comm.CommandText = Query;
                comm.CommandTimeout = SQLTimeout;
                conn.Credential = Credential;
                    try
                    {
                        conn.Open();
                        returnResult = comm.ExecuteNonQuery();
                    }
                    catch (SqlException err)
                    {
                        conn.Close();
                        throw new CustomSqlException("SqlException occured: " + err.Message.ToString(), err);
                    }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }
            finally
            {
                conn.Close(); // Always remember to close connection to database or else it would lead to memory leakage
            }

            return returnResult;
        }

        // Summary:
        // Execute query with credentials for extra security and fetch the data in dataset
        public int Execute(string Query, SqlCredential Credential, out DataSet Data)
        {
            if (Query.Trim() == "")
                throw new ArgumentException("Query can not be blank.s");

            Data = new DataSet();

            SqlConnection conn = new SqlConnection(SQLConnectionString);
            SqlCommand comm = null;
            int returnResult;

            try
            {
                comm = conn.CreateCommand();
                comm.CommandType = CommandType.Text;
                comm.CommandText = Query;
                comm.CommandTimeout = SQLTimeout;
                conn.Credential = Credential;
                    try
                    {
                        conn.Open();

                        SqlDataAdapter adapter = new SqlDataAdapter(comm);
                        returnResult = adapter.Fill(Data);
                    }
                    catch (SqlException err)
                    {
                        conn.Close();
                        throw new CustomSqlException("SqlException occured: " + err.Message.ToString(), err);
                    }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }
            finally
            {
                conn.Close(); // Always remember to close connection to database or else it would lead to memory leakage
            }

            return returnResult;
        }

        // Summary:
        // Execute query with credentials for extra security and fetch the data in datatable
        public int Execute(string Query, SqlCredential Credential, out DataTable Data)
        {
            if (Query.Trim() == "")
                throw new ArgumentException("Query can not be blank.s");

            Data = new DataTable();

            SqlConnection conn = new SqlConnection(SQLConnectionString);
            SqlCommand comm = null;
            int returnResult;

            try
            {
                comm = conn.CreateCommand();
                comm.CommandType = CommandType.Text;
                comm.CommandText = Query;
                comm.CommandTimeout = SQLTimeout;
                conn.Credential = Credential;
                    try
                    {
                        conn.Open();

                        SqlDataAdapter adapter = new SqlDataAdapter(comm);
                        returnResult = adapter.Fill(Data);
                    }
                    catch (SqlException err)
                    {
                        conn.Close();
                        throw new CustomSqlException("SqlException occured: " + err.Message.ToString(), err);
                    }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }
            finally
            {
                conn.Close(); // Always remember to close connection to database or else it would lead to memory leakage
            }

            return returnResult;
        }

        // Summary:
        // Execute stored procedure with credentials for extra security
        public int ExecuteProcedure(string ProcedureName, SqlCredential Credential)
        {
            if (ProcedureName.Trim() == "")
                throw new ArgumentException("Stored procedure name can not be blank.");

            SqlConnection conn = new SqlConnection(SQLConnectionString);
            SqlCommand comm = null;
            int returnResult;

            try
            {
                comm = conn.CreateCommand();
                comm.CommandType = CommandType.StoredProcedure;
                comm.CommandText = ProcedureName;
                comm.CommandTimeout = SQLTimeout;
                conn.Credential = Credential;
                    try
                    {
                        conn.Open();
                        returnResult = comm.ExecuteNonQuery();
                    }
                    catch (SqlException err)
                    {
                        conn.Close();
                        throw new CustomSqlException("SqlException occured: " + err.Message.ToString(), err);
                    }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }
            finally
            {
                conn.Close(); // Always remember to close connection to database or else it would lead to memory leakage
            }

            return returnResult;
        }

        // Summary:
        // Execute stored procedure with credentials for extra security and fetch the data in dataset
        public int ExecuteProcedure(string ProcedureName, SqlCredential Credential, out DataSet Data)
        {
            if (ProcedureName.Trim() == "")
                throw new ArgumentException("Stored procedure name can not be blank.");

            Data = new DataSet();

            SqlConnection conn = new SqlConnection(SQLConnectionString);
            SqlCommand comm = null;
            int returnResult;

            try
            {
                comm = conn.CreateCommand();
                comm.CommandType = CommandType.StoredProcedure;
                comm.CommandText = ProcedureName;
                comm.CommandTimeout = SQLTimeout;
                conn.Credential = Credential;
                    try
                    {
                        conn.Open();

                        SqlDataAdapter adapter = new SqlDataAdapter(comm);
                        returnResult = adapter.Fill(Data);
                    }
                    catch (SqlException err)
                    {
                        conn.Close();
                        throw new CustomSqlException("SqlException occured: " + err.Message.ToString(), err);
                    }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }
            finally
            {
                conn.Close(); // Always remember to close connection to database or else it would lead to memory leakage
            }

            return returnResult;
        }

        // Summary:
        // Execute stored procedure with credentials for extra security and fetch the data in datatable
        public int ExecuteProcedure(string ProcedureName, SqlCredential Credential, out DataTable Data)
        {
            if (ProcedureName.Trim() == "")
                throw new ArgumentException("Stored procedure name can not be blank.s");

            Data = new DataTable();

            SqlConnection conn = new SqlConnection(SQLConnectionString);
            SqlCommand comm = null;
            int returnResult;

            try
            {
                comm = conn.CreateCommand();
                comm.CommandType = CommandType.StoredProcedure;
                comm.CommandText = ProcedureName;
                comm.CommandTimeout = SQLTimeout;
                conn.Credential = Credential;
                    try
                    {
                        conn.Open();

                        SqlDataAdapter adapter = new SqlDataAdapter(comm);
                        returnResult = adapter.Fill(Data);
                    }
                    catch (SqlException err)
                    {
                        conn.Close();
                        throw new CustomSqlException("SqlException occured: " + err.Message.ToString(), err);
                    }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }
            finally
            {
                conn.Close(); // Always remember to close connection to database or else it would lead to memory leakage
            }

            return returnResult;
        }

        // Summary:
        // Fetch the connection string
        public string GetConnectionString()
        { return SQLConnectionString; }

        // Summary:
        // Fetch the sql timeout property
        public int GetTimeout()
        { return SQLTimeout; }


    }
}
