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
                    (cellX + offsetX) * cellSize + RandomGenerator.RandomValue(cellX + offsetX, cellZ + offsetZ) * cellSize,
                    (cellZ + offsetZ) * cellSize + RandomGenerator.RandomValue(cellX + offsetX, cellZ + offsetZ + 1000) * cellSize // offset seed for variation
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
}
