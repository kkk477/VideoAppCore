using Microsoft.Data.SqlClient;
using System.Data;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;
using System.Security.Policy;

namespace VideoAppCore.Models
{
    /// <summary>
    /// 리포지토리 클래스(비동기) ADO.NET을 사용하여 CRUD 구현
    /// </summary>
    public class VideoRepositoryAdoNetAsync : IVideoRepositoryAsync
    {
        private readonly string _connectionString;
        public VideoRepositoryAdoNetAsync(string connectionString)
        {
            this._connectionString = connectionString;
        }
        public async Task<Video> AddVideoAsync(Video model)
        {
            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                const string query = "INSERT INTO Videos(Title, Url, Name, Company, CreatedBy) Values(@Title, @Url, @Name, @Company, @CreatedBy);" +
                    "SELECT Cast(SCOPE_IDENTITY() AS Int);";
                SqlCommand cmd = new SqlCommand(query, con) { CommandType = CommandType.Text };

                cmd.Parameters.AddWithValue("@Title", model.Title);
                cmd.Parameters.AddWithValue("@Url", model.Url);
                cmd.Parameters.AddWithValue("@Name", model.Name);
                cmd.Parameters.AddWithValue("@Company", model.Company);
                cmd.Parameters.AddWithValue("@CreatedBy", model.CreatedBy);

                con.Open();
                object result = await cmd.ExecuteScalarAsync();
                if (int.TryParse(result.ToString(), out int id))
                {
                    model.Id = id;
                }
                con.Close();
            }

            return model;
        }

        public async Task DeleteVideoByIdAsync(int id)
        {
            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                const string query = "DELETE FROM Videos WHERE Id = @Id";
                SqlCommand cmd = new SqlCommand(query, con) { CommandType = CommandType.Text };

                cmd.Parameters.AddWithValue("@Id", id);

                con.Open();
                await cmd.ExecuteNonQueryAsync();
                con.Close();
            }
        }

        public async Task<List<Video>> GetAllVideosAsync()
        {
            List<Video> videos = new List<Video>();

            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                const string query = "SELECT * FROM Videos";
                SqlCommand cmd = new SqlCommand(query, con) { CommandType = CommandType.Text };

                con.Open();
                SqlDataReader dr = await cmd.ExecuteReaderAsync();
                while (dr.Read())
                {
                    Video video = new Video
                    {
                        Id = dr.GetInt32(0),
                        Title = dr["Title"].ToString(),
                        Url = dr["Url"].ToString(),
                        Name = dr["Name"].ToString(),
                        Company = dr["Company"].ToString(),
                        CreatedBy = dr["CreatedBy"].ToString(),
                        Created = Convert.ToDateTime(dr["Created"])
                    };
                    videos.Add(video);
                }
                con.Close();
            }

            return videos;
        }

        public async Task<Video> GetVideoByIdAsync(int id)
        {
            Video video = new Video();

            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                const string query = "SELECT * FROM Videos WHERE Id = @Id";
                SqlCommand cmd = new SqlCommand(query, con) { CommandType = CommandType.Text };

                cmd.Parameters.AddWithValue("@Id", id);

                con.Open();
                SqlDataReader dr = await cmd.ExecuteReaderAsync();
                if (dr.Read())
                {
                    video.Id = dr.GetInt32(0);
                    video.Title = dr["Title"].ToString();
                    video.Url = dr["Url"].ToString();
                    video.Name = dr["Name"].ToString();
                    video.Company = dr["Company"].ToString();
                    video.CreatedBy = dr["CreatedBy"].ToString();
                    video.Created = Convert.ToDateTime(dr["Created"]);
                }
                con.Close();
            }

            return video;
        }

        public async Task<Video> UpdateVideoAsync(Video model)
        {
            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                const string query = "UPDATE Videos SET Title = @Title, Url = @Url, Name = @Name, Company = @Company, ModifiedBy = @ModifiedBy WHERE Id = @Id";
                SqlCommand cmd = new SqlCommand(query, con) { CommandType = CommandType.Text };

                cmd.Parameters.AddWithValue("@Id", model.Id);
                cmd.Parameters.AddWithValue("@Title", model.Title);
                cmd.Parameters.AddWithValue("@Url", model.Url);
                cmd.Parameters.AddWithValue("@Name", model.Name);
                cmd.Parameters.AddWithValue("@Company", model.Company);
                cmd.Parameters.AddWithValue("@ModifiedBy", model.ModifiedBy);

                con.Open();
                await cmd.ExecuteNonQueryAsync();
                con.Close();
            }

            return model;
        }
    }
}
