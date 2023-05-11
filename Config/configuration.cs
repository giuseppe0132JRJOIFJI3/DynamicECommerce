using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConfigurationFileJson
{

    internal class Configurations
    {
        public List<Pages> Pages { get; set; }

    }
    public class Pages
    {
        public string Name { get; set; }
        public List<Fields> Fields { get; set; }
    }
    public class Fields
    {
        public string Name;
        public bool IsVisible { get; set; }
        public string Text { get; set; }
    }

}


