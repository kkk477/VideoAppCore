namespace VideoAppCore.Models
{
    /// <summary>
    /// [4][2] 리포지터리 클래스(비동기) : Dapper를 사용하여 CRUD 구현
    /// </summary>
    public class VideoRepositoryAsyncDapper : IVideoRepositoryAsync
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
