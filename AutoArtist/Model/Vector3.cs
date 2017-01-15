using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoArtist.Model
{
    public class Vector3
    {
        public float X { get; set; }
        public float Y { get; set; }
        public float Z { get; set; }

        public Vector3()
        {

        }

        public Vector3(float X, float Y, float Z)
        {
            this.X = X;
            this.Y = Y;
            this.Z = Z;
        }


        public static Vector3 One
        {
            get
            {
                return new Vector3(1, 1, 1);
            }
           
        }

        public static Vector3 Zero
        {
            get
            {
                return new Vector3(0, 0, 0);
            }

        }
    }
}
