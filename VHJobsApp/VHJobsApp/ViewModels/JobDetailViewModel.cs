using System.Collections.Generic;
using VHJobsApp.Models;

namespace VHJobsApp.ViewModels
{
    public class JobDetailViewModel : BaseViewModel, IJobDetailViewModel
    {
        public Job Job { get; set; }
        public JobDetailViewModel(Job model)
        {
            Title = model.Title;
            Job = model;
        }

        public string JobTitle => Job.Title;
        public string Country => Job.Country;
        public string City => Job.City;
        public string Description => Job.Description;
        public List<string> Skills => Job.Skills;

        public string Place => $"{Job.City}, {Job.Country}";

        public string SkillsSet => string.Join(", ", Job.Skills.ToArray());
    }
}