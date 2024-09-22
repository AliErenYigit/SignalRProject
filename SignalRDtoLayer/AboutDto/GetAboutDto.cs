using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalRDtoLayer.AboutDto
{
    public class GetAboutDto
    {
        public int AboutID { get; set; }
        public string ImageURl { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
    }
}
