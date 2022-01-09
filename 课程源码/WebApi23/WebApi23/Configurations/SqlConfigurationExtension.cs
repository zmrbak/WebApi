namespace WebApi23.Configurations
{
    public static class SqlConfigurationExtension
    {
        public static IConfigurationBuilder AddFromSQL(this IConfigurationBuilder builder, string sqlConnection, string query)
        {
            builder.Add(new SqlConfigurationSource(sqlConnection, query));
            return builder;
        }
    }
}
