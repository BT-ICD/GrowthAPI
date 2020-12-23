using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Growth.Models
{
    /// <summary>
    /// To edit details of existing topic
    /// </summary>
    public class TopicDTOEdit:TopicDTOAdd
    {
        public int TopicId { get; set; }

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }

    }
}
