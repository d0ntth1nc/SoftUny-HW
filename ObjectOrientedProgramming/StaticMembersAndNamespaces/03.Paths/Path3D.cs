using _01.Point3D;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace _03.Paths
{
    [DataContract]
    public class Path3D
    {
        [DataMember]
        private List<Point3D> path;

        public Path3D()
        {
            this.path = new List<Point3D>();
        }

        public Path3D(params Point3D[] points)
        {
            this.path = new List<Point3D>(points);
        }

        [IgnoreDataMember]
        public Point3D[] Points
        {
            get { return this.path.ToArray(); }
        }

        public void AddPoint(Point3D point)
        {
            if (point == null) throw new ArgumentNullException("Cannot add null point");
            this.path.Add(point);
        }
    }
}
