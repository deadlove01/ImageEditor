using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoArtist.Model
{
    public class Transform
    {
        public Vector3 Position { get; set; }
        public Vector3 Rotation { get; set; }
        public Vector3 Scale { get; set; }
        public Vector3 Size { get; set; }

        public Transform()
        {
            Position = new Vector3();
            Rotation = new Vector3();
            Scale = Vector3.One;
            Size = new Vector3();
        }

        public Transform(Vector3 pos, Vector3 rot, Vector3 scale, Vector3 size)
        {
            this.Position = pos;
            this.Rotation = rot;
            this.Scale = scale;
            this.Size = size;
        }
    }
}
