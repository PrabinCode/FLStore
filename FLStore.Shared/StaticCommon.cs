using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FLStore.Shared
{
    public class StaticCommon:Common
    {
        public string StaticId { get; set; }
        public string StaticType { get; set; }
        public string StaticValue { get; set; }
        public string Description { get; set; }
        public string Status { get; set; }
    }
}
