using System;
using UnityEngine;

public static class RandomGenerator
{
    static private System.Random baseRng;

    // Combine x, z and seed into a deterministic value
    static public float RandomValue(int x, int z, int? seed = null)
    {
        baseRng = seed.HasValue ? new System.Random(seed.Value) : new System.Random();
        int combinedSeed = x * 73856093 ^ z * 19349663 ^ baseRng.Next();
        System.Random localRng = new System.Random(combinedSeed);
        return (float)localRng.NextDouble();
    }
}
