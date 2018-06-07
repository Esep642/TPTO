using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine.Extensions
{
    public static class MyNumberExtensions
    {
        public static float Abs(this float self)
        {
            return Math.Abs(self);
        }

        public static float Rounded(this float self)
        {
            return (float)Math.Round(self);
        }

        public static int RoundedToInt(this float self)
        {
            return (int)Math.Round(self);
        }

        public static int FloorToInt(this double self)
        {
            return (int)Math.Floor(self);
        }

        public static int FloorToInt(this float self)
        {
            return (int)Math.Floor(self);
        }

        public static bool IsCloseTo(this float self, float num)
        {
            if (self == num) return true;
            return (self - num).Abs() / self.Abs().Max(num.Abs()) < 0.0001f;
        }

        public static bool IsBetween(this float self, float min, float max)
        {
            return self >= min && self <= max;
        }

        public static bool IsBetween(this int self, int min, int max)
        {
            return self >= min && self <= max;
        }

        public static float Max(this float self, float num)
        {
            return self > num ? self : num;
        }

        public static int Max(this int self, int num)
        {
            return self > num ? self : num;
        }

        public static float Min(this float self, float num)
        {
            return self < num ? self : num;
        }

        public static int Min(this int self, int num)
        {
            return self < num ? self : num;
        }

        public static float MinMax(this float self, float min, float max)
        {
            return self.Min(min).Max(max);
        }

        public static int MinMax(this int self, int min, int max)
        {
            return self.Min(min).Max(max);
        }

    }
}
