using Dapper;
using Microsoft.Data.SqlClient;
using System.Data;

namespace VideoAppCore.Models
{
    /// <summary>
    /// [4][2] 리포지터리 클래스(비동기) : Dapper를 사용하여 CRUD 구현
    /// </summary>
    public class VideoRepositoryDapperAsync : IVideoRepositoryAsync
    {
        private readonly SqlConnection db;

        public VideoRepositoryDapperAsync(string connectionString)
        {
            db = new SqlConnection(connectionString);
        }

        public async Task<Video> AddVideoAsync(Video model)
        {
            const string query =
                "INSERT INTO Videos(Title, Url, Name, Company, CreatedBy) Values(@Title, @Url, @Name, @Company, @CreatedBy);" +
                "SELECT Cast(SCOPE_IDENTITY() AS Int);";

            int id = await db.ExecuteScalarAsync<int>(query, model);

            model.Id = id;

            return model;
        }

        public async Task DeleteVideoByIdAsync(int id)
        {
            const string query = "DELETE FROM Videos WHERE Id = @Id";

            await db.ExecuteAsync(query, new { id }, commandType: CommandType.Text);
        }

        public async Task<List<Video>> GetAllVideosAsync()
        {
            const string query = "SELECT * FROM Videos";

            var videos = await db.QueryAsync<Video>(query);

            return videos.ToList();
        }

        public async Task<Video> GetVideoByIdAsync(int id)
        {
            const string query = "SELECT * FROM Videos WHERE Id = @Id";

            var video = await db.QueryFirstOrDefaultAsync<Video>(query, new { id }, commandType: CommandType.Text);

            return video;
        }

        public async Task<Video> UpdateVideoAsync(Video model)
        {
            const string query = "UPDATE Videos SET Title = @Title, Url = @Url, Name = @Name, Company = @Company, ModifiedBy = @ModifiedBy WHERE Id = @Id";
            await db.ExecuteAsync(query, model);

            return model;
        }
    }
}
