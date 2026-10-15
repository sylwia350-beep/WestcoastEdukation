

using System.Text.Json;

namespace WestcoastEdukation.Services;


public static class JsonService
{
    public static List<T> LoadData<T>(string filePath)
    {
        if (File.Exists(filePath))
        {
            string json = File.ReadAllText(filePath);

            return JsonSerializer.Deserialize<List<T>>(json)
                   ?? new List<T>();
        }

        return new List<T>();
    }

    public static void SaveData<T>(List<T> items, string filePath)
    {
        string json = JsonSerializer.Serialize(items);

        File.WriteAllText(filePath, json);
    }
}
