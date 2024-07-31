using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace GD2.Services
{
    public static class SessionExtensions
    {
        private static readonly JsonSerializerSettings _settings = new JsonSerializerSettings()
        {
            //Bỏ qua các vòng lặp tham chiếu để tránh lỗi khi tuần tự hóa các đối tượng có mối quan hệ tham chiếu vòng
            ReferenceLoopHandling = ReferenceLoopHandling.Ignore,            
            //Chuyển đổi các tên thuộc tính sang dạng camelCase khi tuần tự hóa.
            ContractResolver = new CamelCasePropertyNamesContractResolver()
        };

        //mở rộng ISession để lưu trữ một đối tượng dưới dạng chuỗi JSON
        public static void SetObjectAsJson(this ISession session, string key, object value)
        {
            var json = JsonConvert.SerializeObject(value, _settings);
            session.SetString(key, json);
        }

        //mở rộng ISession để truy xuất một đối tượng từ chuỗi JSON đã lưu trữ trong session:
        public static T GetObjectFromJson<T>(this ISession session, string key)
        {
            var json = session.GetString(key);
            return json == null ? default : JsonConvert.DeserializeObject<T>(json, _settings);
        }
    }
}
