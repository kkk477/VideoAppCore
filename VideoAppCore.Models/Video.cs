﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VideoAppCore.Models
{
	public class Video
	{
		/// <summary>
		/// 일련번호
		/// </summary>
		public int Id { get; set; }

		/// <summary>
		/// 등록일
		/// </summary>
		public DateTimeOffset Created { get; set; }
		
		/// <summary>
		/// 동영상 제목
		/// </summary>
		public string Title { get; set; }

		/// <summary>
		/// 동영상 제공 URL
		/// </summary>
		public string Url { get; set; }

		/// <summary>
		/// 동영상 작성자
		/// </summary>
		public string Name { get; set; }

		/// <summary>
		/// 회사
		/// </summary>
		public string Company { get; set; }
	}
}
