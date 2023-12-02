namespace Infrastructure.SQL.Utils
{
	public static class SqlExecuter
	{
		public static string GetSql(string fileName)
		{
			var basePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "SQL");
			var filePath = Path.Combine(basePath, fileName+".sql");
			return File.ReadAllText(filePath);
		}
	}
}
