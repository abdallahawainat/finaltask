using System;
using System.Collections.Generic;
using System.Text;

namespace learn.core.Data
{
    public class message_api
    {
        public int id { get; set; }
        public int fromuserid { get; set; }
        public int touserid { get; set; }
        public string message { get; set; }
        public DateTime messagedate { get; set; }
    }
}
