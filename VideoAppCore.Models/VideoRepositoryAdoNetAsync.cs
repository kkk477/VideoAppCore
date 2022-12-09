namespace VideoAppCore.Models
{
    /// <summary>
    /// 리포지토리 클래스(비동기) ADO.NET을 사용하여 CRUD 구현
    /// </summary>
    public class VideoRepositoryAdoNetAsync : IVideoRepositoryAsync
    {
        public Task<Video> AddVideoAsync(Video model)
        {
            throw new NotImplementedException();
        }

        public Task DeleteVideoByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Video>> GetAllVideosAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Video> GetVideoByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Video> UpdateVideoAsync(Video model)
        {
            throw new NotImplementedException();
        }
    }
}
