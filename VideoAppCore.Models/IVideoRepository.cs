using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VideoAppCore.Models
{
	/// <summary>
	/// [3] 인터페이스 : Videos 테이블에 대한 CRUD API 명세서 작성
	/// </summary>
	public interface IVideoRepository
	{
		Video AddVideo(Video model);
		List<Video> GetAllVideos();
		Video GetVideoById(int id);
		Video UpdateVideo(Video model);
		void DeleteVideoById(int id);

	}
}
