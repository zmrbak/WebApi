namespace WebApi23.Configurations
{
    public class SqlConfigurationSource : IConfigurationSource
    {
        public string SqlConnection { set; get; }
        public string Query { set; get; }

        public SqlConfigurationSource(string sqlConnection, string query)
        {
            this.SqlConnection = sqlConnection;
            this.Query = query;
        }

        public IConfigurationProvider Build(IConfigurationBuilder builder)
        {
            return new SqlConfigurationProvider(this);
        }
    }
}
