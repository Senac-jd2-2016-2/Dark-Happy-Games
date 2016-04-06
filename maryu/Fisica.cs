using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace maryu
{
    class Fisica
    {
        public float gravy = 20;

        public void gravidad (Personagem x)
        {
            x.y = x.y + gravy;
        }

        public bool jump(Personagem x, bool jumpyn)
        {
            

            return jumpyn;
        }
    }
}
