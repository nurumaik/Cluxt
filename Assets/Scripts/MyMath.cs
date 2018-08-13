using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyMath {
    static public float SomewhatNormal(float min, float max, int iters = 5)
    {
        float acc = 0;
        for (int i = 0; i < iters; ++i)
        {
            acc += Random.Range(min, max);
        }
        acc /= iters;
        return acc;
    }
}
