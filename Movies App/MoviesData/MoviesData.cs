using Movies_App.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace Movies_App.MoviesData
{
    public class MoviesData
    {
        //Method for getting the movies in a list of movie
        public static async Task<IEnumerable<Movie>> GetMovies()
        {
            var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri("http://localhost:34925/api/movies/"),
            };
            using (var response = await client.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();
                var body = await response.Content.ReadAsStringAsync();
                var Deser = await Task.Run(() => JsonConvert.DeserializeObject<IEnumerable<Movie>>(body));
                var DeserList = Deser.ToList();
                return DeserList;
            }
        }
        //method of getting a single movie
        public static async Task<Movie> GetMovie(Guid id)
        {
            var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri($"http://localhost:34925/api/movies/{id}"),
            };
            using (var response = await client.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();
                var body = await response.Content.ReadAsStringAsync();
                var Deser = await Task.Run(() => JsonConvert.DeserializeObject<Movie>(body));
                return Deser;
            }
        }
        //method for deleting a movie
        public static async Task DeleteMovie(Guid id)
        {
            var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Delete,
                RequestUri = new Uri($"http://localhost:34925/api/movies/{id}"),
            };
            using (var response = await client.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();
                var body = await response.Content.ReadAsStringAsync();
            }
        }
        //method for adding a movie
        public static async Task AddaMovie(Movie movie)
        {
            string movieParam = movie.ToString();
            var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Post,
                RequestUri = new Uri("http://localhost:34925/api/movies/"),
                Content = new StringContent($"{{\n\t\"Title\":\"{movie.Title}\",\n\t\"Description\":\"{movie.Description}\",\n\t\"Director\":\"{movie.Director}\",\n\t\"Rating\":{movie.Rating},\n\t\"ReleaseDate\":\"{movie.ReleaseDate}\",\n\t\"ImageUrl\":\"{movie.ImageUrl}\"\n}}")
                {
                    Headers =
                    {               
                        ContentType = new MediaTypeHeaderValue("application/json")
                    }
                }
            };
            using (var response = await client.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();
                var body = await response.Content.ReadAsStringAsync();                
            }
        }
    }
}
