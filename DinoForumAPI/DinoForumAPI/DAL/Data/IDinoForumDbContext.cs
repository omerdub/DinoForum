using DinoForumAPI.Entities.Models;

namespace DinoForumAPI.DAL.Data
{
    public interface IDinoForumDbContext 
    {
        Task<DataBaseStructure> GetData();
        Task SaveData(DataBaseStructure data);
    }
}
