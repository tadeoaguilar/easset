var builder = DistributedApplication.CreateBuilder(args);

//dotnet user-secrets set Parameters:sql-password Tam1234567
var sqlPassword = builder.AddParameter("sql-password", secret: true);
var sql = builder.AddSqlServer("eAssetSQL", password: sqlPassword)
    .WithHttpEndpoint(port: 4500, targetPort: 1433)    
    .WithExternalHttpEndpoints();
    
var sqldb = sql.AddDatabase("sqldb");


builder.Build().Run();
