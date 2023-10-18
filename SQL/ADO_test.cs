// Data Source=DESKTOP-KLPOHE4\SQLEXPRESS;Initial Catalog=AdventureWorksDW2022;Integrated Security=True
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
public class AdoNetCSharp
{
    public void Run()
    {
        var connectionStringBuilder = new SqlConnectionStringBuilder();
        connectionStringBuilder["Data Source"] = "DESKTOP-KLPOHE4\\SQLEXPRESS";
        connectionStringBuilder["Initial Catalog"] = "AdventureWorksDW2022";
        connectionStringBuilder["Integrated Security"] = "True";

        var connectionString = connectionStringBuilder.ToString();
        using (var connection = new SqlConnection(connectionString))
        {
            connection.Open();
            using (var command = connection.CreateCommand())
            {
                command.CommandText = "select top 100 * from dbo.DimAccount";

                var reader = command.ExecuteReader();
                while (reader.Read())
                {
                    var accountKey = reader["AccountKey"].ToString();
                    var accountType = reader["AccountType"].ToString();
                    var accountDesc = reader["AccountDescription"].ToString();
                    Console.WriteLine(accountKey + " " + accountType + " " + accountDesc);
                }
            }
        }
    }
}

class Program
{
    public static void Main(string[] args)
    {

        var ado = new AdoNetCSharp();
        ado.Run();

        var connection = new SqlConnection("Data Source=DESKTOP-KLPOHE4\\SQLEXPRESS;Initial Catalog=AdventureWorksDW2022;Integrated Security=True");
        SqlDataAdapter adapter = new SqlDataAdapter("select top 100 * from dbo.DimAccount", connection);
        DataSet dataSet = new DataSet();
        adapter.Fill(dataSet, "DimAccount");
        DataTable dimAccount = dataSet.Tables["DimAccount"];
        dimAccount.AsEnumerable()
            .Where(r => r.Field<string>("AccountType") == "Revenue")
            .ToList()
            .ForEach(r => { 
                Console.WriteLine("{0} {1} {2}", r["AccountKey"].ToString(), r["AccountType"].ToString(), r["AccountDescription"].ToString()); });



        string query = "select top 10 * from dbo.DimAccount";
        adapter = new SqlDataAdapter(query, connection);
        var newTable = new DataTable("DimAccount10");
        adapter.Fill(newTable);
        dataSet.Tables.Add(newTable);
        dataSet.Tables["DimAccount10"].AsEnumerable()
            .Where(r => r.Field<string>("AccountType") == "Assets")
            .ToList()
            .ForEach(r => {
                Console.WriteLine("{0} {1} {2}", r["AccountKey"].ToString(), r["AccountType"].ToString(), r["AccountDescription"].ToString());
            });

        SqlCommand command = new SqlCommand(
        "SET IDENTITY_INSERT dbo.DimAccount ON\n" +
        "INSERT INTO dbo.DimAccount (AccountKey, AccountType, AccountDescription) " +
        "VALUES (@AccKey, @AccType, @AccDesc)", connection);

        // Add the parameters for the InsertCommand.
        command.Parameters.Add("@AccKey", SqlDbType.Int, 4, "AccountKey");
        command.Parameters.Add("@AccType", SqlDbType.NVarChar, 50, "AccountType");
        command.Parameters.Add("@AccDesc", SqlDbType.NVarChar, 50, "AccountDescription");

        adapter.InsertCommand = command;

        var acckey = -3;
        var currentTableRowAdd = dataSet.Tables["DimAccount10"].Rows.Add();
        currentTableRowAdd["AccountKey"] = acckey;
        currentTableRowAdd["AccountType"] = "My Type";
        currentTableRowAdd["AccountDescription"] = "New account added in";

        adapter.Update(dataSet, "DimAccount10");
        adapter.Fill(dataSet);
        
        dataSet.Tables["DimAccount10"].AsEnumerable()
            .Where(r => r.Field<int>("AccountKey") == acckey)
            .ToList()
            .ForEach(r => {
                Console.WriteLine("{0} {1} {2}", r["AccountKey"].ToString(), r["AccountType"].ToString(), r["AccountDescription"].ToString());
            });

    }
}
