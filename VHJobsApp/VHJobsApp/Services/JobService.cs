using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using VHJobsApp.Models;
using System.Linq;

namespace VHJobsApp.Services
{
    public class JobService : IJobService
    {
        private HttpClient _client;
        
        public JobService()
        {
            _client = new HttpClient();
            _client.MaxResponseContentBufferSize = 256000;            
        }

        public async Task<JobsResult> GetJobListAsync(int page = 1)
        {
            List<Job> jobs = await MockJobsAsync(page);

            return new JobsResult
            {
                Total_Pages = 4,
                Total_Results = 12,
                Results = jobs
            };
        }

        private async Task<List<Job>> MockJobsAsync(int page)
        {
            List<Job> jobs = null;
            await Task.Run(() =>
            {
                if (page == 1)
                {
                    jobs = new List<Job>
                    {
                        new Job{ Title = "Java Developer", Description="Java developer with Adobe Experience Manager experience", Country="Luxembourg", City="Luxembourg City", Remote = false, Skills = { "french", "german", "java"} },
                        new Job{ Title = "Front end Software Engineer", Country="Canada", City="Saskatoon", Remote = false, Skills={"css3", "html5", "javascript", "php", "rest apis", "mariadb", "my sql"} } ,
                        new Job{ Title = "Full Stack Developer", Country="Portugal", City="Lisbon", Remote = false, Skills={"css3", "design", "design mobile", "react", "ux"} },
                        new Job{ Title = "Xamarin Developer", Country="US", City="NYC", Remote = true, Skills={"Forms", "Xaml", "MVVM"}}
                    };
                }
                else if(page == 2)
                {
                    jobs = new List<Job>
                    {
                        new Job { Title = "Junior Backend Software Engineer", Description = "Some initial experience either through your first job or through side projects you were actively engaged in,e.g. while studying Comfortable with Python", Country = "Germany", City = "Berlin", Remote = false, Skills = { "docker", "http", "network" } },
                        new Job { Title = "Front end Software Engineer", Country = "Australia", City = "Sidney", Remote = false, Skills = { "es6", "html5", "javascript", "responsive design", "rest apis", "mariadb", "my sql" } } ,
                        new Job { Title = "Backend Software Engineer", Country = "Canada", City = "Winnipeg", Remote = false, Skills = { "css3", "design", "design mobile", "react", "ux" } },
                        new Job { Title = "Xamarin Developer", Country = "US", City = "NYC", Remote = false, Skills = { "css3", "django", "python" } }
                    };
                }
                else 
                {
                    jobs = new List<Job>
                    {
                        new Job { Title = "Blockchain Technologies Developer", Description = "Digital Payments", Country = "Canada", City = "Vancouver", Remote = false, Skills = { "blockchain technologies"} },
                        new Job { Title = "React Developer", Country = "Canada", City = "Vancouver", Remote = false, Skills = { "es6", "html5", "reactJS", "responsive design", "rest apis", "mariadb", "my sql" } } ,
                        new Job { Title = "PHP Laravel Developer", Country = "Canada", City = "Saskatoon", Remote = false, Skills = { "php", "design", "design mobile", "react", "ux" } },
                        new Job { Title = "C# .NET Developer", Country = "Canada", City = "Montreal", Remote = true, Skills = { ".net", "c#", "python" } }
                    };
                }

            });
            return jobs;
        }

        private async Task<TResult> GetHttpRequestAsync<TResult>(Uri uri)
        {
            using (var httpClient = new HttpClient())
            {
                var response = await httpClient.GetAsync(uri);
                var content = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<TResult>(content);
            }
        }
        public async Task<JobsResult> SearchAsync(string searchText, CountryGroup countryGroup, bool? remoteOnly, int page = 1)
        {
            var jobs = await MockJobsAsync(1);
            jobs.AddRange(await MockJobsAsync(2));
            jobs.AddRange(await MockJobsAsync(3));

            List<Job> list = null;
            await Task.Run(() =>
            {
                list = jobs.Where(j =>
                {
                    var matchSearch = j.Title.ToUpper().Contains(searchText.ToUpper()) ||
                    j.Description.ToUpper().Contains(searchText.ToUpper()) ||
                    j.Skills.Where(s => s.Contains(searchText)).Any();

                    var remoteMatch = (remoteOnly == null) || (remoteOnly.Value == false) || (j.Remote == remoteOnly.Value) ;

                    var countryMatch = (countryGroup == null) || (countryGroup.All(c => c.Selected == false)) || (countryGroup.Where(c => c.Selected == true && c.Name.ToUpper().Equals(j.Country.ToUpper())).Any());

                    return matchSearch && remoteMatch && countryMatch;
                })
                .ToList();
            });

            return new JobsResult
            {
                Total_Pages = 2,
                Total_Results = list.Count(),
                Results = list
            };
        }
    }
}
