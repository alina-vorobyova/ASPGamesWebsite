using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GamesSearchAsp.Models
{

    public class ScreenshotsApiResponse
    {
        public int count { get; set; }
        public object next { get; set; }
        public object previous { get; set; }
        public ScreenshotsResult[] results { get; set; }
    }

    public class ScreenshotsResult
    {
        public int id { get; set; }
        public string image { get; set; }
        public int width { get; set; }
        public int height { get; set; }
        public bool is_deleted { get; set; }
    }

}
