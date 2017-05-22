using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public abstract class IGrapher : MonoBehaviour
{
    [Range(10, 100)]
    public int resolution = 100;
    private int _resolution = 100;

    protected ParticleSystem.Particle[] points;

    public void Update()
    {
        if (resolution != _resolution || points == null)
        {
            _resolution = resolution;
            CreatePoints();
        }
        for (int i = 0; i < points.Length; i++)
        {
            Vector3 p = points[i].position;
            p.y = Function(p, Time.timeSinceLevelLoad);

            Color c = points[i].GetCurrentColor(GetComponent<ParticleSystem>());
            c.g = p.y;

            points[i].position = p;
            points[i].startColor = c;
        }
        GetComponent<ParticleSystem>().SetParticles(points, points.Length);
    }

    protected void CreatePoints()
    {
        points = new ParticleSystem.Particle[resolution * resolution];

        int i = 0;
        for (int x = 0; x < resolution; x++)
        {
            for (int z = 0; z < resolution; z++)
            {
                float increment = 1f / (resolution - 1);
                Vector3 p = new Vector3(x * increment, 0f, z * increment);
                points[i].position = p;
                points[i].startColor = new Color(p.x, 0f, p.y);
                points[i++].startSize = 0.1f;
            }
        }
    }

    /// <summary>
    /// The function to be graphed
    /// </summary>
    /// <param name="x">X value</param>
    /// <param name="z">Z value</param>
    /// <returns>Y value</returns>
    protected abstract float Function(Vector3 p, float t = 0);
}

