using AppJwtEmployee.DBL.Utility.Helper.Generators;
using AppJwtEmployee.DBL.Utility.Result.Abstract;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using JsonSerializer = System.Text.Json.JsonSerializer;

namespace AppJwtEmployee.DBL.Extensions;

public static class ApiControllerBaseExtension
{
    public static IActionResult AsObjectResult<TEntity>(
        this IResultFactory<TEntity> result)
        => CreateObjectResult(result.StatusCode, ResultGenerator.Generate(result));



    private static ObjectResult CreateObjectResult(int httpStatusCode, object content)
    {
        var options = new JsonSerializerOptions()
        {
            Encoder = System.Text.Encodings.Web.JavaScriptEncoder.UnsafeRelaxedJsonEscaping,
        };

        var value = JsonSerializer.Serialize(content,options);
        
        var result = new ObjectResult(value);
        //result.ContentTypes.Add("application/json");
        result.StatusCode = httpStatusCode;

        return result;
    }
}
