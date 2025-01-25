using System.Text.Json;
using System.Text.Json.Serialization;

namespace SessionHelpers
{
    // public static class SessionHelper
    // {
    //     public static void SetJsonObject(this ISession session, string key, object value)
    //     {
    //         session.SetString(key,JsonSerializer.Serialize(value));
    //     }

    //     public static T GetObjectFromSession<T>(this ISession session,string key)
    //     {
    //        var value=session.GetString(key);
    //     //    if(value==null)
    //     //    {
    //     //         return  default(T);
    //     //     }
    //     //    else
    //     //    {
    //     //     return JsonSerializer.Deserialize<T>(value);
    //     //    }
    //         return value == null ? default(T) : JsonSerializer.Deserialize<T>(value);
    //     }
    // }

    public static class SessionHelper
    {
        public static void SetJsonObject(ISession session, string key, object value)
        {
            session.SetString(key, JsonSerializer.Serialize(value));
        }

        public static T GetObjectFromSession<T>(ISession session, string key)
        {
            var value = session.GetString(key);
            return value == null ? default : JsonSerializer.Deserialize<T>(value);
        }
    }
}