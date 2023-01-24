using DinoForumAPI.Entities.Models;
using DinoForumAPI.Entities.Settings;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;

namespace DinoForumAPI.DAL.Data
{
    public class DinoForumDbContext : IDinoForumDbContext
    {
        private readonly JsonFileSettings _settings;

        public DinoForumDbContext(IOptions<JsonFileSettings> settings)
        {
            _settings = settings.Value;
        }

        public async Task<DataBaseStructure> GetData()
        {
            string dbRaw = await File.ReadAllTextAsync(_settings.FilePath);
            var db = JsonConvert.DeserializeObject<DataBaseStructure>(dbRaw);
            return db;
        }

        public async Task SaveData(DataBaseStructure data)
        {
            string json = JsonConvert.SerializeObject(data);
            await File.WriteAllTextAsync(_settings.FilePath, json);
        }
    }
}
