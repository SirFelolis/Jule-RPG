using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Game_Test {
    public class Camera2D {

        private Matrix transform;
        public Matrix Transform {
            get { return transform; }
        }

        private Viewport viewport;

        private Vector2 centre;

        public float X {
            get { return centre.X; }
            set { centre.X = value; }
        }

        public float Y {
            get { return centre.Y; }
            set { centre.Y = value; }
        }

        private float zoom = 1;
        public float Zoom {
            get { return zoom; }
            set { zoom = value; 
                if (zoom < 0.1f) zoom = 0.1f; }
        }

        private float rotation = 0;
        public float Rotation {
            get { return rotation; }
            set { rotation = value; }
        }

        public Camera2D(Viewport newViewport) {
            viewport = newViewport;
        }

        public void Update(Vector2 position) {
            centre = new Vector2(position.X, position.Y);
            // - 16 for å gjør at du blir akkurat i midten                v              v
            transform = Matrix.CreateTranslation(new Vector3(-centre.X - 16, -centre.Y - 16, 0)) * Matrix.CreateRotationZ(Rotation) * Matrix.CreateScale(new Vector3(Zoom, Zoom, 0)) * Matrix.CreateTranslation(new Vector3(viewport.Width / 2, viewport.Height / 2, 0));

        }
    }
}
