using Microsoft.EntityFrameworkCore;

namespace VideoAppCore.Models
{
    /// <summary>
    /// [4][3] 리포지터리 클래스(비동기) : EF Core를 사용하여 CRUD 구현
    /// </summary>
    public class VideoRepositoryEfCoreAsync : IVideoRepositoryAsync
    {
        private readonly VideoDbContext _context;
        public VideoRepositoryEfCoreAsync(VideoDbContext context)
        {
            this._context = context;
        }
        public async Task<Video> AddVideoAsync(Video model)
        {
            _context.Videos.Add(model);
            await _context.SaveChangesAsync();
            return model;
        }

        public async Task DeleteVideoByIdAsync(int id)
        {
            var video = await _context.Videos.FindAsync(id);
            if (video != null)
            {
                _context.Videos.Remove(video);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<List<Video>> GetAllVideosAsync()
        {
            return await _context.Videos.ToListAsync();
        }

        public async Task<Video> GetVideoByIdAsync(int id)
        {
            return await _context.Videos.FindAsync(id);
        }

        public async Task<Video> UpdateVideoAsync(Video model)
        {
            _context.Entry(model).State= EntityState.Modified;
            await _context.SaveChangesAsync();
            return model;
        }
    }
}
