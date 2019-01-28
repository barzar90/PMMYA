using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Schema
{
    public class Feedback_Schema
    {
        public Int64 Feedback_ID { get; set; }
        public String Name { get; set; }
        public String Mobile { get; set; }
        public String Email_ID { get; set; }
        public String Feedback { get; set; }
        public DateTime CreatedOn { get; set; }
    }
}
