using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Schema
{
    public class UploadVideoSchema
    {
        public string VideoID { get; set; }
        public string VideoName { get; set; }
        public string VideoPath { get; set; }
        public string ImagePath { get; set; }
        public string Description { get; set; }
        public string Type { get; set; }
        public DateTime LastUpdated { get; set; }
        public string Flag { get; set; }
        public int langid { get; set; }

        public string VideoName_LL { get; set; }
        public string VideoPath_LL { get; set; }
        public string ImagePath_LL { get; set; }
        public string Description_LL { get; set; }

        public Guid CreatedBy { get; set; }
        public string IPAddress { get; set; }
        public string Keyword { get; set; }
    }
}
