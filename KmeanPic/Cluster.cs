using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KmeanPic
{
    class Cluster
    {
        private Vector vectorOC;
        private List<Picture> picturesListOC;

        public Cluster(Vector vectorOC, List<Picture> picturesListOC1)
        {
            VectorOC = vectorOC;
            PicturesListOC = picturesListOC1;
        }
        public Cluster(Vector vectorOC)
        {
            VectorOC = vectorOC;
            PicturesListOC = new List<Picture>();
        }

        internal Vector VectorOC { get => vectorOC; set => vectorOC = value; }
        internal List<Picture> PicturesListOC { get => picturesListOC; set => picturesListOC = value; }
    }
}
