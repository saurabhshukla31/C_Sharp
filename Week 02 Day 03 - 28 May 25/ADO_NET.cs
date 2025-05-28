using EmployeeManagement.Models;
using System.Data;
using System.Data.SqlClient;

// Static class because connection string needs to be common everywhere and should not be changed
public static class ConnectionStringProvider
{
    public static string ConnectionString { get; } = 
        "User ID=sa;password=examlyMssql@123;server=localhost;Database=appdb;trusted_connection=false;Persist Security Info=False;Encrypt=False";
}

public class Program
{
    // Used by all the functions => accessible to all the class methods
    public static string conn = ConnectionStringProvider.ConnectionString;

    public static void AddEmployee(Employees employees)
    {
        // At this point, connect to database and save the record
        using (SqlConnection con = new SqlConnection(conn)) 
        {
            // If we write anything inside 'using' block, it is persistent till the execution of the function completes.
            // As soon as the closing braces of the function are encountered, whatever is passed inside using block is removed from memory.

            SqlCommand cmd = new SqlCommand("select * from Employees", con);
            SqlDataAdapter adapt = new SqlDataAdapter(cmd);
            SqlCommandBuilder build = new SqlCommandBuilder(adapt);
            DataSet ds = new DataSet(); // Dataset is a collection of tables
            adapt.Fill(ds, "Employees"); // Dataset gets disconnected and into our local space
            // Now we have to save a new record
            DataTable dt = new DataTable();
            dt = ds.Tables["Employees"]; // Now dt is pointing to 1 table in ds (here, the Employees table)

            DataRow dr = dt.NewRow(); // Reference for an empty record
            dr["EmployeeName"] = employees.EmployeeName;
            dr["EmployeeAge"] = employees.EmployeeAge;
            dr["EmployeeLastDateJob"] = employees.EmployeeLastDateJob;
            dt.Rows.Add(dr);

            // Disconnected (local) to connected (main database). Now new record is added in database.
            adapt.Update(dt);
            Console.WriteLine("Employee added Successfully.");
        }
    }

    public static void ListEmployees()
    {
        using (SqlConnection con = new SqlConnection(conn)) 
        {
            // If we write anything inside 'using' block, it is persistent till the execution of the function completes.
            // As soon as the closing braces of the function are encountered, whatever is passed inside using block is removed from memory.

            SqlCommand cmd = new SqlCommand("select * from Employees", con);
            SqlDataAdapter adapt = new SqlDataAdapter(cmd);
            SqlCommandBuilder build = new SqlCommandBuilder(adapt);
            DataSet ds = new DataSet(); // Dataset is a collection of tables
            adapt.Fill(ds, "Employees"); // Dataset gets disconnected and Employees table is available in DataSet

            DataTable dt = new DataTable();
            dt = ds.Tables["Employees"]; // Now dt is pointing to 1 table in ds (here, the Employees table)
        }
    }

    public static void DeleteEmployee(int eid)
    {
        using (SqlConnection con = new SqlConnection(conn)) 
        {
            // If we write anything inside 'using' block, it is persistent till the execution of the function completes.
            // As soon as the closing braces of the function are encountered, whatever is passed inside using block is removed from memory.

            SqlCommand cmd = new SqlCommand("select * from Employees", con);
            SqlDataAdapter adapt = new SqlDataAdapter(cmd);
            SqlCommandBuilder build = new SqlCommandBuilder(adapt);
            DataSet ds = new DataSet(); // Dataset is a collection of tables
            adapt.Fill(ds, "Employees"); // Dataset gets disconnected and Employees table is available in DataSet

            DataTable dt = new DataTable();
            dt = ds.Tables["Employees"]; // Now dt is pointing to 1 table in ds (here, the Employees table)

            DataRow[] dr = dt.Select($"EmployeeID={eid}"); // 'Select()' function returns a DataRow Type
            dr[0].Delete(); // At this point record is deleted from dataset (disconnected, local machine)

            // Now deletion is reflected on database
            adapt.Update(dt);
            Console.WriteLine("Record Deleted Successfully.");
        }
    }

    public static void Main(String[] args)
    {
        Console.WriteLine("Menu LTI:");
        Console.WriteLine("1. Add Employee:");
        Console.WriteLine("2. List Employee:");
        Console.WriteLine("3. Delete Employee:");
        Console.WriteLine("Exit");
        Console.WriteLine("Enter your choice");

        int choice = int.Parse(Console.ReadLine());

        switch (choice)
        {
            case 1:
                Console.WriteLine("Enter Details for the new Employee:");
                string name = Console.ReadLine();
                int age = int.Parse(Console.ReadLine());
                string lastDate = Console.ReadLine();

                // At this point, we have to create an object of the Employees class
                Employees e = new Employees();
                e.EmployeeName = name;
                e.EmployeeAge = age;
                e.EmployeeLastDateJob = lastDate;

                // Now, employee data is available in e, i.e., our record is ready. So now we pass it to AddEmployee method.
                // We are calling static function from static method main => we can call directly
                AddEmployee(e);
                break;

            case 2:
                ListEmployees();
                break;

            case 3:
                int id = int.Parse(Console.ReadLine());
                DeleteEmployee(id);
                break;

            case 4:
                break;
        }
    }
}
