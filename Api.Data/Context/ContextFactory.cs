using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Api.Data.Context
{
    class ContextFactory : IDesignTimeDbContextFactory<SqlContext>
    {
        public SqlContext CreateDbContext(string[] args)
        {
            var conn = "Server=localhost,11433;Database=dbApi;Uid=sa;Pwd=DockerSql2017!";
            var optionsBuilder = new DbContextOptionsBuilder<SqlContext>();
            optionsBuilder.UseSqlServer(conn);
            return new SqlContext(optionsBuilder.Options);
        }
    }
}
