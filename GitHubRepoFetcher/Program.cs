using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace GitHubRepoFetcher
{
    class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine("Program started...");

            string githubUsername = "111vamsi"; // Replace with the GitHub username
            string githubApiUrl = $"https://api.github.com/users/{githubUsername}/repos";

            using (HttpClient client = new HttpClient())
            {
                Console.WriteLine("HttpClient initialized.");

                // GitHub API requires a user-agent header
                client.DefaultRequestHeaders.Add("User-Agent", "C# App");

                try
                {
                    Console.WriteLine("Sending request to GitHub API...");
                    HttpResponseMessage response = await client.GetAsync(githubApiUrl);
                    Console.WriteLine($"Response status code: {response.StatusCode}");

                    if (response.IsSuccessStatusCode)
                    {
                        string responseBody = await response.Content.ReadAsStringAsync();
                        Console.WriteLine("Repositories:");
                        Console.WriteLine(responseBody);
                    }
                    else
                    {
                        Console.WriteLine($"Error: {response.StatusCode} - {response.ReasonPhrase}");
                    }
                }
                catch (HttpRequestException e)
                {
                    Console.WriteLine($"Request error: {e.Message}");
                }
            }

            Console.WriteLine("Program finished. Press Enter to exit...");
            Console.ReadLine();
        }
    }
}
