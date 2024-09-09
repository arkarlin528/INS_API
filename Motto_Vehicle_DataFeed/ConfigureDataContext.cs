using System;
using System.Configuration;
using System.Data.Entity;

public class dataFeedContext : DbContext
{
    public dataFeedContext() : base(GetConnectionString("ATS_DATA"))
    {
    }

    private static string GetConnectionString(string name)
    {
        var connectionString = ConfigurationManager.ConnectionStrings[name]?.ConnectionString;

        if (string.IsNullOrEmpty(connectionString))
        {
            throw new InvalidOperationException($"Connection string '{name}' not found in configuration file.");
        }

        return connectionString;
    }

    // DbSet properties and other DbContext configurations...
}

public class MAMS_dataFeedContext : DbContext
{
    public MAMS_dataFeedContext() : base(GetConnectionString("MAMS_DATA"))
    {
    }

    private static string GetConnectionString(string name)
    {
        var connectionString = ConfigurationManager.ConnectionStrings[name]?.ConnectionString;

        if (string.IsNullOrEmpty(connectionString))
        {
            throw new InvalidOperationException($"Connection string '{name}' not found in configuration file.");
        }

        return connectionString;
    }

}