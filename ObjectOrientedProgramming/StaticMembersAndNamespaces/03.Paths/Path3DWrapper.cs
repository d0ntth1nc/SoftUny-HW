using System.Collections.Generic;
using System.Runtime.Serialization;

namespace _03.Paths
{
    [DataContract]
    public class Path3DWrapper
    {
        [DataMember]
        public List<Path3D> Paths { get; set; }

        public Path3DWrapper()
        {
            this.Paths = new List<Path3D>();
        }
    }
}
