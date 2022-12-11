using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VideoAppCore.Models.Tests
{
    [TestClass]
    public class VideoRepositoryTest
    {
        [TestMethod]
        public async Task AddVideoAsyncMethodTest()
        {
            // DbContextOptions 생성
            // DbContextOptionsBuilder를 사용하여 인-메모리 데이터베이스 정보를 DbContext에 전달
            var options = new DbContextOptionsBuilder<VideoDbContext>().UseInMemoryDatabase(databaseName:"AddVideo").Options;

            // 컨텍스트 개체 생성
            using (var context = new VideoDbContext(options))
            {
                // 리포지토리 개체 생성
                var repository = new VideoRepositoryEfCoreAsync(context);
                var video = new Video { Title = "강좌1", Url = "URL", Company = "Hawaso", Name = "박용준", Created = DateTime.Now, CreatedBy = "Ray" };
                await repository.AddVideoAsync(video);
                context.SaveChanges();
            }

            using (var context = new VideoDbContext(options))
            {
                Assert.AreEqual(1, context.Videos.Count());
                Assert.AreEqual("URL", context.Videos.Single().Url);
            }
        }

        [TestMethod]
        public async Task GetAllVideosAsyncMethodTest()
        {
            // DbContextOptions 생성
            // DbContextOptionsBuilder를 사용하여 인-메모리 데이터베이스 정보를 DbContext에 전달
            var options = new DbContextOptionsBuilder<VideoDbContext>().UseInMemoryDatabase(databaseName: "GetAllVideos").Options;

            // 컨텍스트 개체 생성
            using (var context = new VideoDbContext(options))
            {
                context.Videos.Add(new Video { Title = "강좌1", Url = "URL", Company = "Hawaso", Name = "박용준", Created = DateTime.Now, CreatedBy = "Ray" });
                context.Videos.Add(new Video { Title = "강좌2", Url = "URL", Company = "Hawaso", Name = "김태영", Created = DateTime.Now, CreatedBy = "Ray" });
                context.Videos.Add(new Video { Title = "강좌3", Url = "URL", Company = "Hawaso", Name = "한상훈", Created = DateTime.Now, CreatedBy = "Ray" });
                context.SaveChanges();
            }

            using (var context = new VideoDbContext(options))
            {
                var repository = new VideoRepositoryEfCoreAsync(context);
                var videos = await repository.GetAllVideosAsync();
                Assert.AreEqual(3, videos.Count());
                Assert.AreEqual("김태영", videos.Where(v => v.Id == 2).FirstOrDefault()?.Name);
            }
        }

        [TestMethod]
        public async Task GetVideosByIdAsyncMethodTest()
        {
            // DbContextOptions 생성
            // DbContextOptionsBuilder를 사용하여 인-메모리 데이터베이스 정보를 DbContext에 전달
            var options = new DbContextOptionsBuilder<VideoDbContext>().UseInMemoryDatabase(databaseName: "GetVideosById").Options;

            // 컨텍스트 개체 생성
            using (var context = new VideoDbContext(options))
            {
                context.Videos.Add(new Video { Title = "강좌1", Url = "URL", Company = "Hawaso", Name = "박용준", Created = DateTime.Now, CreatedBy = "Ray" });
                context.Videos.Add(new Video { Title = "강좌2", Url = "URL", Company = "Hawaso", Name = "김태영", Created = DateTime.Now, CreatedBy = "Ray" });
                context.Videos.Add(new Video { Title = "강좌3", Url = "URL", Company = "Hawaso", Name = "한상훈", Created = DateTime.Now, CreatedBy = "Ray" });
                context.SaveChanges();
            }

            using (var context = new VideoDbContext(options))
            {
                var repository = new VideoRepositoryEfCoreAsync(context);
                var video = await repository.GetVideoByIdAsync(3);
                Assert.AreEqual("강좌3", video.Title);
                Assert.AreEqual("한상훈", video.Name);
            }
        }

        [TestMethod]
        public async Task UpdateVideoAsyncMethodTest()
        {
            // DbContextOptions 생성
            // DbContextOptionsBuilder를 사용하여 인-메모리 데이터베이스 정보를 DbContext에 전달
            var options = new DbContextOptionsBuilder<VideoDbContext>().UseInMemoryDatabase(databaseName: "UpdateVideo").Options;

            // 컨텍스트 개체 생성
            using (var context = new VideoDbContext(options))
            {
                context.Videos.Add(new Video { Title = "강좌1", Url = "URL", Company = "Hawaso", Name = "박용준", Created = DateTime.Now, CreatedBy = "Ray" });
                context.Videos.Add(new Video { Title = "강좌2", Url = "URL", Company = "Hawaso", Name = "김태영", Created = DateTime.Now, CreatedBy = "Ray" });
                context.Videos.Add(new Video { Title = "강좌3", Url = "URL", Company = "Hawaso", Name = "한상훈", Created = DateTime.Now, CreatedBy = "Ray" });
                context.SaveChanges();
            }

            using (var context = new VideoDbContext(options))
            {
                var repository = new VideoRepositoryEfCoreAsync(context);
                var han = await repository.GetVideoByIdAsync(3);
                han.Title = "넥슨개발자";
                var video = await repository.UpdateVideoAsync(han);
                context.SaveChanges();

                var itist = await repository.GetVideoByIdAsync(3);

                Assert.AreEqual("넥슨개발자", itist.Title);
                Assert.AreEqual("한상훈", itist.Name);
            }
        }

        [TestMethod]
        public async Task DeleteVideoByIdAsyncMethodTest()
        {
            // DbContextOptions 생성
            // DbContextOptionsBuilder를 사용하여 인-메모리 데이터베이스 정보를 DbContext에 전달
            var options = new DbContextOptionsBuilder<VideoDbContext>().UseInMemoryDatabase(databaseName: "DeleteVideoById").Options;

            // 컨텍스트 개체 생성
            using (var context = new VideoDbContext(options))
            {
                context.Videos.Add(new Video { Title = "강좌1", Url = "URL", Company = "Hawaso", Name = "박용준", Created = DateTime.Now, CreatedBy = "Ray" });
                context.Videos.Add(new Video { Title = "강좌2", Url = "URL", Company = "Hawaso", Name = "김태영", Created = DateTime.Now, CreatedBy = "Ray" });
                context.Videos.Add(new Video { Title = "강좌3", Url = "URL", Company = "Hawaso", Name = "한상훈", Created = DateTime.Now, CreatedBy = "Ray" });
                context.SaveChanges();
            }

            using (var context = new VideoDbContext(options))
            {
                var repository = new VideoRepositoryEfCoreAsync(context);
                await repository.DeleteVideoByIdAsync(1);

                var videos = await repository.GetAllVideosAsync();

                Assert.AreEqual(2, videos.Count());
                Assert.IsNull(videos.Where(v =>v.Name == "박용준").SingleOrDefault());
            }
        }
    }
}
