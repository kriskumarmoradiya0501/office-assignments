using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InternHelper.Models
{
    public class Intern
    {
        public int InternId {get; set;}
        public string InternName {get;set;} = string.Empty;
        public string Gender {get; set;} = string.Empty;
        public int TopicId {get; set;}
        public string TopicName{get; set;} = string.Empty;
        public DateTime DateOfPresentation {get; set;}
        public bool Status {get; set;}
        public string? TopicImage{get; set;}
        public IFormFile? TopicImageFile {get; set;}
    }
}