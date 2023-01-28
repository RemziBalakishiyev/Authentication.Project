using System.Text.Json;

namespace AppJwtEmployee.DBL.Utility.Helper.FileOperations
{
    public static class ResponseMessageManager
    {

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
            using var json = File.OpenRead("C:\\Users\\Admin\\source\\repos\\AuthenticationProject\\AppJwtEmployee.DBL\\root\\ResponseMessages.json");

            using JsonDocument jsonDocument = JsonDocument.Parse(json);

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
