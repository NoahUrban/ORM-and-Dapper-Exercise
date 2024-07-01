using System;
using System.Data;
using System.IO;
using MySql.Data.MySqlClient;
using Microsoft.Extensions.Configuration;
using System.Data.Common;
using Dapper;
using ORM_Dapper;

namespace ORM_Dapper
{
	public interface IDepartmentRepository
	{
		IEnumerable<Department> GetAllDepartments();
	}
}

