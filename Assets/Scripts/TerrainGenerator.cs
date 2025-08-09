using System;
using System.Globalization;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class TerrainGenerator : MonoBehaviour
{
    public LineRenderer lr;

    public string filename;

    [Range(1, 1000)]
    public float terrainPointsScaleFactor = 100.0f;
    public Vector3[] terrainPoints;

    

    public float[] map;
    [Range(0, 100)]
    public float frequency = 10.0f;
    public int width = 1000;
    public int height = 100;
    public int y_offset = 0;
    public bool hasBeenDrawn = false;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (filename != null && filename.Length > 0)
        {
            terrainPoints = ReadCSV(filename);
            lr.positionCount = terrainPoints.Length;
            lr.SetPositions(terrainPoints);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    private Vector3[] ReadCSV(string filename)
    {
        List<Vector3> list = new();

        foreach (string line in File.ReadAllLines(filename))
        {
            if (string.IsNullOrWhiteSpace(line) || string.IsNullOrEmpty(line))
                continue;

            string[] values = line.Split(',');
            Vector3 data = new(
                float.Parse(values[0], CultureInfo.InvariantCulture),
                float.Parse(values[2], CultureInfo.InvariantCulture),
                float.Parse(values[1], CultureInfo.InvariantCulture));
            // Debug.Log("X: " + data.x);
            // Debug.Log("Y: " + data.y);
            // Debug.Log("Z: " + data.z);
            // Debug.Log("V: " + data);
            list.Add(data  * terrainPointsScaleFactor);
        }

        Debug.Log("List size: " + list.Capacity);

        return list.ToArray();
    }

    float[] PopulateMap(int length)
    {
        float[] map = new float[length];
        for (int x = 0; x < length; x++)
        {
            map[x] = Mathf.PerlinNoise(x / frequency, y_offset) * height;
        }
        return map;
    }

    void OnDrawGizmos()
    {
        // if (!hasBeenDrawn)
        // {
        //     map = new float[width];
        //     map = PopulateMap(width);
        //     hasBeenDrawn = true;
        // }

        // if (hasBeenDrawn)
        // {
        //     Vector3 start = new Vector3(0, 0, 0);
        //     for (int x = 0; x < map.Length; x++)
        //     {
        //         Gizmos.DrawLine(start, new Vector3(x, map[x] * 10, 0));
        //         start = new Vector3(x, map[x] * 10, 0);
        //     }
        // }
    }
}

