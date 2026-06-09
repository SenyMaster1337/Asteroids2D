using UnityEngine;

namespace Code.Core.Tools
{
    public static class Vector3Extensions
    {
        public static float SqrMagnitudeTo(this Vector2 from, Vector2 to)
        {
            return Vector2.SqrMagnitude(to - from);
        }
    }
}