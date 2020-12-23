using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Growth.Models
{
    /// <summary>
    /// Tp manipulate list of topics
    /// </summary>
    public class TopicDTOList
    {
        public int TopicId { get; set; }
        public int TopicSrNo { get; set; }
        public string Name { get; set; }
        public string Notes { get; set; }

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}
