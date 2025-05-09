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

public class INS_WEB_dataFeedContext : DbContext
{
    public INS_WEB_dataFeedContext() : base(GetConnectionString("INS_WEB_DATA"))
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

public class Inspection_dataFeedContext : DbContext
{
    public Inspection_dataFeedContext() : base(GetConnectionString("Inspection_DATA"))
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

public class IMAT_dataFeedContext : DbContext
{
    public IMAT_dataFeedContext() : base(GetConnectionString("IMAT_DATA"))
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

public class MATWEB_dataFeedContext : DbContext
{
    public MATWEB_dataFeedContext() : base(GetConnectionString("MATWEB_DATA"))
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