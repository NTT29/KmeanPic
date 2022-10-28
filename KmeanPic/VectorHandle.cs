using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KmeanPic
{
    class VectorHandle
    {
        //Read file 
        public static void input(string fileName, List<Picture> listItem)
        {
            listItem.Clear();
            var strs = File.ReadAllLines(fileName);
            foreach (var str in strs)
            {
                Picture img = new Picture();
                Vector vt = new Vector();
                //Split line 
                var vector = str.Trim().Split(' ', '(', ')');
                img.Id = vector[0];
                //Save feature vector
                for (int i = 1; i < vector.Length - 2; i++)
                {
                    if (vector[i].Contains(".jpg"))
                        img.ImgName = vector[i];
                    else if (Double.TryParse(vector[i], out double v))
                        vt.Properties.Add(v);
                }
                img.Vector = vt;
                //Save Folder Name
                img.FolderName = vector[vector.Length - 1];
                listItem.Add(img);
            }
        }
        //Distance function
        public static double Distance(Vector a, Vector b)
        {
            double sum = 0;
            for (int i = 0; i < a.Properties.Count; i++)
                sum += Math.Pow((a.Properties[i] - b.Properties[i]),2.0);
            return Math.Sqrt(sum);
        }
    }
}
