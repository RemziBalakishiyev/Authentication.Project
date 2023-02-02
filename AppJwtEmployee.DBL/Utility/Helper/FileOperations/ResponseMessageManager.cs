using Microsoft.AspNetCore.Hosting;
using System.Reflection;
using System.Text.Json;

namespace AppJwtEmployee.DBL.Utility.Helper.FileOperations
{
    public static class ResponseMessageManager
    {

        private const string JsonFilePath = "..\\AppJwtEmployee.DBL\\root\\responsemessages.json";

        private static Dictionary<string, string> messages;
        public static string GetResponseMessageByMessageCode(string messageCode)
        {
            if (!String.IsNullOrEmpty(messageCode))
            {
                LoadMessages();
            }

            if (!messageCode.Contains(messageCode))
            {
                throw new KeyNotFoundException($"There is no message by message code={messageCode}");
            }

            return messages[messageCode];
        }


        public static void LoadMessages()
        {

            messages = new Dictionary<string, string>();
            using var json = File.OpenRead(JsonFilePath);

            JsonDocumentOptions options = new JsonDocumentOptions
            {
                AllowTrailingCommas = true,
                CommentHandling = JsonCommentHandling.Skip
            };

            var nm = json.Name;
            var ps = json.Position;
            var cw = json.CanWrite;
            using JsonDocument jsonDocument = JsonDocument.Parse(json, options);

            JsonElement root = jsonDocument.RootElement;
            var properties = root.GetProperty("Messages").EnumerateObject();
            while (properties.MoveNext())
            {
                var prop = properties.Current;
                messages.Add(prop.Name, prop.Value.ToString());
            }
        }
    }
}
