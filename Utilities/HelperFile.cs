using FileHelpers;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;

namespace API.Minimal.Utilities
{
    public static class HelperFile
    {
        public static IEnumerable<T> ReadData<T>(string path) where T : class
        {

            var engine = new FileHelperEngine<T>();

            var result = engine.ReadFile(path);
            return result;
        }
        public static IEnumerable<string> ReadCustomFileWithDelimiter(string path, string delimiter, int numberOfDelimiter)
        {
            var line = new List<string>();
            using (var file = new FileStream(path, FileMode.Open, FileAccess.Read))
            {
                using (var reader = new StreamReader(file))
                {
                    while (reader.ReadLine() != null)
                    {
                        string value = reader.ReadLine();
                        if (value != null && value.Contains(delimiter))
                        {
                            if (value.Split(delimiter).Length == numberOfDelimiter)
                            {
                                line.Add(reader.ReadLine());
                            }
                        }
                    }

                }
            }
            return line;
        }
        public static IEnumerable<T> ConvertDataToModelArray<T>(IEnumerable<string> records, string delimiter) where T : class, new()
        {
            var data = new List<T>();
            foreach (var line in records)
            {
                var items = line.Split(delimiter);
                var obj = new T();
                var resultType = typeof(T);
                var toProperties = resultType.GetProperties();

                foreach (var propertyInfo in toProperties.Select((value, index) => new { value, index }))
                {
                    var fromProperty = obj.GetType().GetProperty(propertyInfo.value.Name);
                    if (fromProperty != null)
                        propertyInfo.value.SetValue(obj, items[propertyInfo.index], null);
                }
                data.Add(obj);
            }
            return data;
        }
    }
}
