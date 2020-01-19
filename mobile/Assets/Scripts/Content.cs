using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CreatingJsonFile.Models
{
    public class Content
    {
        public float Lat
        {
            get;
            set;
        }
        public float Lon
        {
            get;
            set;
        }
        public string[] Texts
        {
            get;
            set;
        }
        public string[] PictureLinks
        {
            get;
            set;
        }
        public string[] AudioLinks
        {
            get;
            set;
        }
        public string[] TranscriptTexts
        {
            get;
            set;
        }
    }
}
