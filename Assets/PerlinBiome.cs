using UnityEngine;

public enum Biome
{
    plain,
    desert,
    forest
}

static public class PerlinBiome
{
    static public void setFrequency(float plain, float desert, float forest)
    {
        plainFrequency = plain;
        desertFrequency = desert;
        forestFrequency = forest;
    }

    static public Biome getBiome(float x, float z)
    {
        float noise = Mathf.PerlinNoise(x * biomeScale, z * biomeScale);
        float totalWeight = plainFrequency + desertFrequency + forestFrequency;

        float plainLimit = plainFrequency / totalWeight;
        float desertLimit = desertFrequency / totalWeight + plainLimit;

        if (noise < plainLimit) return Biome.plain;
        else if (noise < desertLimit) return Biome.desert;
        else return Biome.forest;
    }

    static public Color GetBiomeColor(Biome biome)
    {
        return biome switch
        {
            Biome.desert => Color.red,
            Biome.plain => Color.green,
            Biome.forest => Color.blue,
            _ => Color.gray
        };
    }

    static private float plainFrequency;
    static private float desertFrequency;
    static private float forestFrequency;

    static private float biomeScale = 0.01f;
}
