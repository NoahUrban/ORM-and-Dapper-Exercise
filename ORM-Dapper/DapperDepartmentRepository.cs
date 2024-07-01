using System;
using System.Data;
using System.IO;
using MySql.Data.MySqlClient;
using Microsoft.Extensions.Configuration;
using System.Data.Common;
using Dapper;
using ORM_Dapper;

public class DapperDepartmentRepository : IDepartmentRepository
{
    private readonly IDbConnection _connection;

    public DapperDepartmentRepository(IDbConnection connection)
    {
        _connection = connection;
    }

    public IEnumerable<Department> GetAllDepartments()
    {
        return _connection.Query<Department>("SELECT * FROM Departments;").ToList();
    }

    public void InsertDepartment(string newDepartmentName)
    {
        _connection.Execute("INSERT INTO departments (Name) VALUES (@departmentname);",
         new { departmentName = newDepartmentName });
    }
}

