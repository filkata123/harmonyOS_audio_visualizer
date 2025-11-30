using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BubbleMeshGenerator))]
public class AudioSoftBody : MonoBehaviour
{
    public AudioSource audioSource;
    public int fftSize = 512;
    public float amplitude = 0.25f;
    public float softness = 10f;
    public int frequencyOffset = 2;

    float[] spectrum;
    BubbleMeshGenerator meshGen;
    Vector3[] workingVertices;
    private Renderer bubbleRenderer;

    void Start()
    {
        meshGen = GetComponent<BubbleMeshGenerator>();
        spectrum = new float[fftSize];
        workingVertices = meshGen.GetVertices();
        bubbleRenderer = GetComponent<Renderer>();
    }

    void Update()
    {
        audioSource.GetSpectrumData(spectrum, 0, FFTWindow.BlackmanHarris);

        Vector3[] baseVerts = meshGen.GetBaseVertices();
        Vector3[] verts = meshGen.GetVertices();

        for (int i = 1; i < verts.Length; i++)
        {
            int fftIndex = Mathf.Clamp((i + frequencyOffset) % spectrum.Length, 0, spectrum.Length - 1);

            float displacement = spectrum[fftIndex] * amplitude * 100f;
            displacement = Mathf.Clamp(displacement, 0f, 0.6f);

            Vector3 target = baseVerts[i] + baseVerts[i].normalized * displacement;

            verts[i] = Vector3.Lerp(verts[i], target, Time.deltaTime * softness);
        }

        meshGen.SetVertices(verts);

    }

}
