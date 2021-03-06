using CsvHelper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;

namespace MovieAPI.App.Controllers
{
	[Route("api")]
	[ApiController]
	public class MoviesController : ControllerBase
	{
		string currentDirectory = Directory.GetCurrentDirectory();

		[HttpGet]
		public List<Metadata> Get()
		{
			var metadataLines = Path.Combine(currentDirectory, "CsvFiles/metadata.csv");
			var data = CSVReader<Metadata>.Read(metadataLines);
			return data;
		}

		[HttpPost]
		[Route("metadata")]
		public IActionResult PostMetadata([FromBody]Metadata file)
		{
			var filePath = Path.Combine(currentDirectory, "CsvFiles/metadata.csv");
			var data = file.ToString();
			System.IO.File.AppendAllText(filePath, data);
			return Ok();
		}

		[HttpGet]
		[Route("metadata/{movieId:int}")]
		public IActionResult GetByMovieId(int movieId)
		{
			var filePath = Path.Combine(currentDirectory, "CsvFiles/metadata.csv");
			var data = CSVReader<Metadata>.Read(filePath);
			var results = data.Where(w => w.MovieId == movieId).ToList();

			if (results.Count <= 0)
				return NotFound();

			return Ok(results);
		}

		[HttpGet]
		[Route("movies/stats")]
		public IActionResult GetStats()
		{
			var filePath = Path.Combine(currentDirectory, "CsvFiles/stats.csv");
			var data = CSVReader<Stats>.Read(filePath);
			data = data.OrderByDescending(d => d.watchDurationMs).ToList();
			return Ok(data);
		}
	}
}
