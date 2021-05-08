using System;

namespace MovieAPI.App
{
	public class Metadata
	{
		public int Id { get; set; }

		public int MovieId { get; set; }

		public string Title { get; set; }

		public string Language { get; set; }

		private DateTime _duration;
		public string Duration 
		{
			get
			{
				return _duration.ToString("HH:mm:ss");
			} 
			set
			{
				DateTime.TryParse(value, out _duration);
			}
		}

		public int ReleaseYear { get; set; }

		public override string ToString()
		{
			return string.Format("{0}, {1}, {2}, {3}, {4}, {5}", Id, MovieId, Title, Language, Duration, ReleaseYear);
		}
	}
}
