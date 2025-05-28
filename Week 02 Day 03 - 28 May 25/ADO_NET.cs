using empManagement.Models;
using System;
using System.Data;
using System.Data.SqlClient;

public static class ConnectionStringProvider
{
    public static string ConnectionString { get; } =
        "User ID=sa;password=examlyMssql@123; server=localhost;Database=appdb;trusted_connection=false;Persist Security Info=False;Encrypt=False";
}

public class Program
{
    static string myConnection = ConnectionStringProvider.ConnectionString;

    public static void AddEmployees(Employees employees)
    {
        using (SqlConnection sqlCon = new SqlConnection(myConnection))
        {
            SqlCommand sqlCmd = new SqlCommand("SELECT * FROM Employees", sqlCon);
            SqlDataAdapter sqlAdapt = new SqlDataAdapter(sqlCmd);
            SqlCommandBuilder sqlBuild = new SqlCommandBuilder(sqlAdapt);
            DataSet ds = new DataSet();
            sqlAdapt.Fill(ds, "Employees");

            DataTable dt = ds.Tables["Employees"];
            DataRow dr = dt.NewRow();
            dr["EmployeeName"] = employees.EmployeeName;
            dr["EmployeeAge"] = employees.EmployeeAge;
            dr["EmployeeLastDateJob"] = employees.EmployeeLastDateJob;
            dt.Rows.Add(dr);
            sqlAdapt.Update(dt);
        }
    }

    public static void ListEmployees()
    {
        using (SqlConnection sqlCon = new SqlConnection(myConnection))
        {
            SqlCommand sqlCmd = new SqlCommand("SELECT * FROM Employees", sqlCon);
            SqlDataAdapter sqlAdapt = new SqlDataAdapter(sqlCmd);
            SqlCommandBuilder sqlBuild = new SqlCommandBuilder(sqlAdapt);
            DataSet ds = new DataSet();
            sqlAdapt.Fill(ds, "Employees");

            foreach (DataRow dr in ds.Tables["Employees"].Rows)
            {
                Console.WriteLine($"Employee ID: {dr["EmployeeId"]}\tEmployee Name: {dr["EmployeeName"]}\tEmployee Age: {dr["EmployeeAge"]}\tLast Date at Job: {dr["EmployeeLastDateJob"]}");
            }
        }
    }

    public static void DeleteEmployees(int employeeId)
    {
        using (SqlConnection sqlCon = new SqlConnection(myConnection))
        {
            SqlCommand sqlCmd = new SqlCommand("SELECT * FROM Employees", sqlCon);
            SqlDataAdapter sqlAdapt = new SqlDataAdapter(sqlCmd);
            SqlCommandBuilder sqlBuild = new SqlCommandBuilder(sqlAdapt);
            DataSet ds = new DataSet();
            sqlAdapt.Fill(ds, "Employees");

            DataTable dt = ds.Tables["Employees"];
            DataRow[] rows = dt.Select($"EmployeeId = {employeeId}");

            if (rows.Length > 0)
            {
                dt.Rows.Remove(rows[0]);
                sqlAdapt.Update(dt);
                Console.WriteLine("Employee deleted successfully.");
            }
            else
            {
                Console.WriteLine("Employee not found.");
            }
        }
    }

    public static void Main(string[] args)
    {
        while (true)
        {
            Console.WriteLine("\n--- Employee Management Menu ---");
            Console.WriteLine("1. Add Employee");
            Console.WriteLine("2. List Employees");
            Console.WriteLine("3. Delete Employee");
            Console.WriteLine("4. Exit");
            Console.Write("Enter your choice (1-4): ");
            int choice = int.Parse(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    Console.Write("Enter Employee Name: ");
                    string name = Console.ReadLine();
                    Console.Write("Enter Employee Age: ");
                    int age = int.Parse(Console.ReadLine());
                    Console.Write("Enter Last Date at Job (yyyy-MM-dd): ");
                    string lastDate = Console.ReadLine();

                    Employees emp = new Employees
                    {
                        EmployeeName = name,
                        EmployeeAge = age,
                        EmployeeLastDateJob = lastDate
                    };

                    AddEmployees(emp);
                    Console.WriteLine("Employee added successfully.");
                    break;

                case 2:
                    ListEmployees();
                    break;

                case 3:
                    Console.Write("Enter Employee ID to delete: ");
                    int id = int.Parse(Console.ReadLine());
                    DeleteEmployees(id);
                    break;

                case 4:
                    Console.WriteLine("Exiting...");
                    return;

                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;
            }
        }
    }
}
