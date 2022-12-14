using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class MathParabloa : MonoBehaviour
{
    public static Vector3 Parabola(Vector3 start, Vector3 end, float hieght, float t)
    {

        Func<float, float> f = x => -4 * hieght * x * x + 4 * hieght * x;
        var mid = Vector3.Lerp(start, end, t);
        return new Vector3(mid.x, f(t) + Mathf.Lerp(start.y, end.y, t), mid.z);

    }
   /* public static Vector2 Parabola(Vector2 start , Vector2 end ,float hieght ,float t)
    {
        Func<float, float> f = x => -4 * hieght * x * x + 4 * hieght * x;
        var mid = Vector2.Lerp(start, end, t);
        return new Vector2(mid.x, f(t) + Mathf.Lerp(start.y, end.y, t));

    }*/

}
