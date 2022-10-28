using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KmeanPic
{
    class Kmean
    {
        //Cluster Quantity
        static int ClusterQuantity = 3;
        
        //Kmean Algorithm
        public static List<Cluster> kmean(List<Picture> PictureList)
        {
            //Cluster List
            List<Cluster> ClusterList = new List<Cluster>();
            List<Cluster> newClusterList = new List<Cluster>();
            //Choose the root vector for each cluster(1-10 in vector list)
            for (int i = 0; i < ClusterQuantity; i++)
            {
                Cluster clt = new Cluster(PictureList[i].Vector);
                ClusterList.Add(clt);
            }
            //Copy ClusterList to newClusterList
            for (int i = 0; i < ClusterQuantity; i++)
            {
                Cluster clt = new Cluster(PictureList[i].Vector);
                newClusterList.Add(clt);
            }
            while (true)
            {
                foreach (var Picture in PictureList)
                {
                    //Calculate the distance between Image's Vector and Cluster's Vector
                    List<double> AllDistance = new List<double>();
                    foreach (var item in newClusterList)
                    {
                        AllDistance.Add(VectorHandle.Distance(Picture.Vector, item.VectorOC));
                    }
                    //Clustering for Picture
                    foreach (var item in newClusterList)
                    {
                        if (VectorHandle.Distance(Picture.Vector, item.VectorOC) == AllDistance.Min())
                            item.PicturesListOC.Add(Picture);
                    }
                }
                //Recalculate cluster's vector
                foreach (var item in newClusterList)
                {
                    Vector newVector = new Vector();
                    for (int i = 0; i < item.VectorOC.Properties.Count; i++)
                    {
                        double average = 0;
                        foreach (var Picture in item.PicturesListOC)
                        {
                            average += Picture.Vector.Properties[i];
                        }
                        average = average / item.PicturesListOC.Count;
                        newVector.Properties.Add(average);
                    }
                    item.VectorOC = newVector;
                }
                //Check to end of while
                bool checkToEnd = true;
                for (int i = 0; i < ClusterList.Count; i++)
                {
                    if (newClusterList[i] != ClusterList[i])
                    {
                        ClusterList = newClusterList;
                        checkToEnd = false;
                    }
                }
                if (checkToEnd)
                    break;
                //Clear Pictures List of all cluster
                foreach (var item in newClusterList)
                {
                    item.PicturesListOC.Clear();
                }
            }
            return ClusterList;
        }
    }
}
