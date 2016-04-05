using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace maryu
{
    class Fisica
    {
        public float gravy = 5;

        public void gravidad (Personagem x)
        {
            x.y = x.y + gravy;


        }

        public bool jump(Personagem x, bool jumpyn)
        {
            float heightjump = 50;
            x.y = x.y - 5;


            if (x.y <= heightjump)
            {
                x.y += 50;
                jumpyn = false;

            }
            return jumpyn;


        }
    }
}
