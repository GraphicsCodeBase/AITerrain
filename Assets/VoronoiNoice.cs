using UnityEngine;

static public class VoronoiNoice
{
    public static float GenerateVoronoi(float x, float z, float cellSize)
    {
        int cellX = Mathf.FloorToInt(x / cellSize);
        int cellZ = Mathf.FloorToInt(z / cellSize);

        float minDist = float.MaxValue;

        // Check neighboring cells to find the closest feature point
        for (int offsetX = -1; offsetX <= 1; offsetX++)
        {
            for (int offsetZ = -1; offsetZ <= 1; offsetZ++)
            {
                // Feature point position in this cell, pseudo-randomized
                Vector2 featurePoint = new Vector2(
                    (cellX + offsetX) * cellSize + RandomValue(cellX + offsetX, cellZ + offsetZ) * cellSize,
                    (cellZ + offsetZ) * cellSize + RandomValue(cellX + offsetX, cellZ + offsetZ + 1000) * cellSize // offset seed for variation
                );

                // Distance from (x,z) to this feature point
                float dist = Vector2.Distance(new Vector2(x, z), featurePoint);

                if (dist < minDist)
                {
                    minDist = dist;
                }
            }
        }

        // Normalize the distance to 0..1 range (depends on cellSize)
        return minDist / cellSize;
    }

    // Helper pseudo-random function based on cell coordinates
    private static float RandomValue(int x, int z)
    {
        int n = x * 73856093 ^ z * 19349663; // some large primes
        n = (n << 13) ^ n;
        return (1.0f - ((n * (n * n * 15731 + 789221) + 1376312589) & 0x7fffffff) / 1073741824.0f);
    }
}
