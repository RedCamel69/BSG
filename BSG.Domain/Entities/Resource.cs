using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BSG.Domain.Entities
{
    public enum ResourceType
    {
        Document, Video
    }

    public class Resource
    {
        public int ID { get; set; }
        public ResourceType ResourceType { get; set; }
        public string Name { get; set; }
        public string Path { get; set; }
        public string Description { get; set; }
    }
}
