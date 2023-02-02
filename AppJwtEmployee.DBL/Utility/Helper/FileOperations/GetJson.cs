using System.Text.Json.Nodes;

namespace AppJwtEmployee.DBL.Utility.Helper.FileOperations;

public class GetJson
{
    public static string ConnectionString { get; set; }
    static GetJson()
    {

        using var stream = File.OpenRead("..\\AppJwtEmployee.DBL\\appsettings.json");

        var node = JsonNode.Parse(stream);

        ConnectionString = node["ConnectionStrings"]["defaultConnection"].ToString();
    }

}
