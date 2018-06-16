using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine.Utils
{
   public class MathForAngles
    {
        private static Dictionary<int, float> sin = new Dictionary<int, float>(361);
        private static Dictionary<int, float> cos = new Dictionary<int, float>(361);

        public static float Sin(int A)
        {
            if (sin.ContainsKey(A))
            {
                return sin[A];
            }
            sin.Add(A, (float)Math.Sin(A));
            return sin[A];
        }
        public static float Cos(int A)
        {
            if (cos.ContainsKey(A))
            {
                return cos[A];
            }
            cos.Add(A, (float)Math.Cos(A));
            return cos[A];
        }
    }
}
