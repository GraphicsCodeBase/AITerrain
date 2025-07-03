using System.Collections.Generic;
using UnityEngine;

public class PerlinTerrain : MonoBehaviour
{
    [Range(10, 200)] public int width = 100;
    [Range(10, 200)] public int height = 100;
    [Range(1f, 50f)] public float scale = 10f;
    [Range(0.01f, 1f)] public float noiseScale = 0.1f;

    private float   lastScale ;
    private int     lastWidth ;
    private int     lastHeight;
    private float lastNoiseScale;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        GenerateTerrain();
        lastScale = scale;
        lastWidth = width;
        lastHeight = height;
    }

   public void GenerateTerrain()
   {
        Mesh mesh = new Mesh();
        Vector3[] vertices = new Vector3[(width + 1) * (height + 1)];
        int[] triangles = new int[width * height * 6];

        // Generate vertices
        int i = 0;
        for (int z = 0; z <= height; z++)
        {
            for (int x = 0; x <= width; x++)
            {
                float perlin = Mathf.PerlinNoise(x * noiseScale, z * noiseScale);
                float voronoi = VoronoiNoice.GenerateVoronoi(x, z, 10f);
                float y = perlin * voronoi * scale;
                vertices[i++] = new Vector3(x, y, z);
            }
        }

        // Generate triangles
        int vert = 0;
        int tris = 0;
        for (int z = 0; z < height; z++)
        {
            for (int x = 0; x < width; x++)
            {
                triangles[tris + 0] = vert + 0;
                triangles[tris + 1] = vert + width + 1;
                triangles[tris + 2] = vert + 1;
                triangles[tris + 3] = vert + 1;
                triangles[tris + 4] = vert + width + 1;
                triangles[tris + 5] = vert + width + 2;

                vert++;
                tris += 6;
            }
            vert++;
        }

        // Finalize mesh
        mesh.vertices = vertices;
        mesh.triangles = triangles;
        mesh.RecalculateNormals();

        // Assign mesh to MeshFilter
        GetComponent<MeshFilter>().mesh = mesh;
        Debug.Log("Terrain generated with vertices: " + mesh.vertexCount);
    }


    // Update is called once per frame
    void Update()
    {
        if (scale != lastScale || width != lastWidth || height != lastHeight)
        {
            GenerateTerrain();
            lastScale = scale;
            lastWidth = width;
            lastHeight = height;
            lastNoiseScale = noiseScale;
        }
    }

   
}



