using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOCls
{
    public class DTOInformation
    {
        public int InfomationId { get; set; }
        public DateTime CreateDate { get; set; }
        public string Content { get; set; }
        public string Title { get; set; }
        public int AdminId { get; set; }
        public string AdminName { get; set; }
        public DTOInformation() { }
    }
}
