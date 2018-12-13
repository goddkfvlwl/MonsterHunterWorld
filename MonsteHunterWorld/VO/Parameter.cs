using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonsteHunterWorld.VO
{
    public class Parameter
    {
        private string getName;
        private string name;
        private string type;

        public Parameter(string getName)
        {
            this.getName = getName;
        }

        public string GetName { get => getName; set => getName = value; }
        public string Name { get => name; set => name = value; }
        public string Type { get => type; set => type = value; }        
    }
}
