using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace LINQ
{
    public class FeatureCollection
    {
        public string type { get; set; }
        public IList <Features> features { get; set; }
    }
}
