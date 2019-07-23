using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ws01.pages.classes
{
    public class xusersTs
    {
        public string name { get; set; }
        public string img { get; set; }

        public static implicit operator xusersTs(string v)
        {
            throw new NotImplementedException();
        }
    }
}
