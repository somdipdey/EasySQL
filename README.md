# EasySQL
Use this class library to execute your MS SQL queries in your C# programs easily without hassle. 

# Background

Do you find yourself writing a handful of codes to execute a single or number of SQL statement(s) in your C# program using System.Data.SqlClient?
Do your code somewhat looks like this as follows:

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
                catch
                {
                    conn.Close();
                    throw new SqlException();
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


And don't even mention that what headache this code can cause to you in case you mess up or forget a single line of code from the above.

But do not worry, there is an easy solution. 

# Enters The EasySQL Class
Use EasySQL class library to execute any (or list of) SQL statement(s) without hassle.

Let me show you how you can write the aforementioned code using EasySQL Class as follows:

        EasySQL thisSQL = new EasySQL(SQLConnectionString);
        thisSQL.Execute(Query);

That's it. Nothing else. You don't have to worry about opening or closing database connections or worry about other small stuffs, so that you can devote more in developing your solution effectively rather than fighting to execute database queries.

# Methods In EasySQL Class
#### Name:	  Returns:	 Description

IsConnected():	 bool:	 Returns true or false whether connection to database is successful or not

GetConnectionString():	 String:	 Returns the connection string which is set/used

GetTimeout():	 Int:	Returns the connection time out

Execute(String):	Int:	Executes the query and returns the number of rows affected

Execute(String, out DataSet):	Int:	Executes the query to fetch the data in dataset and returns the number of rows affected

Execute(String, out DataTable):	        Int:	Executes the query to fetch the data in datatable and returns the number of rows affected

Execute(String, Dictionary<String, String>):	Int:	Executes the query with parameters and returns the number of rows affected

Execute(String, Dictionary<String, String>, out DataSet):	Int:	Executes the query with parameters to fetch the data in dataset and returns the number of rows affected

Execute(String, Dictionary<String, String>, out DataTable):	        Int:	Executes the query with parameters to fetch the data in datatable and returns the number of rows affected


ExecuteProcedure(String):	Int:	Excutes the stored procedure and returns the number of rows affected

ExecuteProcedure(String, out DataSet):	        Int:	Excutes the stored procedure to fetch data in dataset and returns the number of rows affected

ExecuteProcedure(String, out DataTable):	Int:	Excutes the stored procedure to fetch data in datatable and returns the number of rows affected

Execute(String, SqlCredential):	        Int:	Excutes the query using SqlCredential for elevated security and returns the number of rows affected

Execute(String, SqlCredential, out DataSet):	        Int:	Executes the query using SqlCredential for elevated security to fetch the data in dataset and returns the number of rows affected

Execute(String, SqlCredential, out DataTable):	        Int:	Executes the query using SqlCredential for elevated security to fetch the data in datatable and returns the number of rows affected

Execute(String, Dictionary<String, String>, SqlCredential):	        Int:	Excutes the query with parameters using SqlCredential for elevated security and returns the number of rows affected

Execute(String, Dictionary<String, String>, SqlCredential, out DataSet):	        Int:	Executes the query with parameters using SqlCredential for elevated security to fetch the data in dataset and returns the number of rows affected

Execute(String, Dictionary<String, String>, SqlCredential, out DataTable):	        Int:	Executes the query with parameters using SqlCredential for elevated security to fetch the data in datatable and returns the number of rows affected


ExecuteProcedure(String, SqlCredential):	Int:	Executes the stored procedure using SqlCredential for elevated security and returns the number of rows affected

ExecuteProcedure(String, SqlCredential, out DataSet):   	Int:	Executes the stored procedure using SqlCredential for elevated security to fetch data in dataset and returns the number of rows affected

ExecuteProcedure(String, SqlCredential, out DataTable): 	Int:	Executes the stored procedure using SqlCredential for elevated security to fetch data in datatable and returns the number of rows affected


# Some Examples
Let's insert a new record of city in our CITIES table as follows:

        private void InsertCityRecord(string connectionString)
        {
          string query = "Insert Into [CITIES] (CityName, Country) VALUES('Kolkata', 'India')";

          EasySQL thisSQL = new EasySQL(connectionString);
          thisSQL.Execute(query);
        }

Or we can fetch user credentials from a form and use that to query our database as follows:

        private void runUserQuery()
        {
          // Fetch User input
          System.Windows.Controls.TextBox txtUserId = new System.Windows.Controls.TextBox();
          System.Windows.Controls.PasswordBox txtPwd = new System.Windows.Controls.PasswordBox();

          // Read config for connection string
          Configuration config = Configuration.WebConfigurationManager.OpenWebConfiguration(Null);
          ConnectionStringSettings connString = config.ConnectionStrings.ConnectionString[“MyConnString”];

          // Create sql credential
          SecureString pwd = txtPwd.SecurePassword;
          pwd.MakeReadOnly();
          SqlCredential cred = new SqlCredential(txtUserId.Text, pwd);

          // Execute using EasySQL
          EasySQL thisSQL = new EasySQL(connString);
          thisSQL.ExecuteProcedure(storedProcedureName, cred);
        }

Or we can also execute a list of queries as follows:

        private void runListOfQueries(List<string> queries, string connectionString)
        {
          // Initiate EasySQL
          EasySQL thisSQL = new EasySQL(connectionString);

          // Iterate over list of queries and execute one by one
          foreach(string query in queries)
          {
            thisSQL.Execute(query);
          }
        }

# Extras

The source code of the EasySQL Class library is available to download from TechNet Gallery and GitHub.

This article is also available from TechNet Wiki here: https://social.technet.microsoft.com/wiki/contents/articles/48290.using-easysql-class-to-execute-ms-sql-and-stored-procedures-easily-in-c.aspx
