namespace VideoAppCore.Models
{
    /// <summary>
    /// [3] 인터페이스 : Videos 테이블에 대한 CRUD API 명세서 작성.비동기방식
    /// </summary>
    public interface IVideoRepositoryAsync
    {
        Task<Video> AddVideoAsync(Video model);
        Task<List<Video>> GetAllVideosAsync();
        Task<Video> GetVideoByIdAsync(int id);
        Task<Video> UpdateVideoAsync(Video model);
        Task DeleteVideoByIdAsync(int id);
    }
}
