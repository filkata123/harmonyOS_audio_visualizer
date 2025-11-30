using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MeshFilter), typeof(MeshRenderer))]
public class BubbleMeshGenerator : MonoBehaviour
{
    [Range(16, 512)] public int vertexCount = 128;
    public float radius = 1f;

    Mesh mesh;
    Vector3[] baseVertices;
    Vector3[] vertices;
    int[] triangles;

    public Vector3[] GetVertices() => vertices;
    public void SetVertices(Vector3[] v)
    {
        vertices = v;
        mesh.vertices = v;
        mesh.RecalculateNormals();
        mesh.RecalculateBounds();
    }

    void Awake()
    {
        Generate();
    }

    public void Generate()
    {
        mesh = new Mesh();
        GetComponent<MeshFilter>().mesh = mesh;

        vertices = new Vector3[vertexCount + 1];
        baseVertices = new Vector3[vertexCount + 1];
        triangles = new int[vertexCount * 3];

        // Center vertex
        vertices[0] = Vector3.zero;
        baseVertices[0] = Vector3.zero;

        // Rim vertices
        for (int i = 0; i < vertexCount; i++)
        {
            float angle = (float)i / vertexCount * Mathf.PI * 2f;
            Vector3 pos = new Vector3(Mathf.Cos(angle), Mathf.Sin(angle), 0) * radius;

            vertices[i + 1] = pos;
            baseVertices[i + 1] = pos;

            // Triangles (fan)
            triangles[i * 3] = 0;
            triangles[i * 3 + 1] = i + 1;
            triangles[i * 3 + 2] = (i + 2 > vertexCount) ? 1 : i + 2;
        }

        mesh.vertices = vertices;
        mesh.triangles = triangles;
        mesh.RecalculateNormals();
        mesh.RecalculateBounds();
    }

    public Vector3[] GetBaseVertices()
    {
        return baseVertices;
    }
}
