using System;
using System.ComponentModel.DataAnnotations;

namespace RI.api.Models
{
    public class Video
    {
        public int id { get; set; }
        public string youtubeId { get; set; } = "";
        public string title { get; set; } = "";
        public double likeCount { get; set; }
        public double dislikeCount { get; set; }
        public int views { get; set; }
        public string category { get; set; } = "";
        [DataType(DataType.DateTime)]
        public DateTime submittedOn { get; set; } = DateTime.Now;
        public string submittedBy { get; set; }
        [DataType(DataType.Url)]
        public string submittedUrl { get; set; }
    }
}