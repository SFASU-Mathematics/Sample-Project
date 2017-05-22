using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

class Crazy : IGrapher
{
    protected override float Function(Vector3 p, float t = 0)
    {
        return 0.50f +
            0.25f * Mathf.Sin(4f * Mathf.PI * p.x + 4f * t) * Mathf.Sin(2f * Mathf.PI * p.z + t) +
            0.10f * Mathf.Cos(3f * Mathf.PI * p.x + 5f * t) * Mathf.Cos(5f * Mathf.PI * p.z + 3f * t) +
            0.15f * Mathf.Sin(Mathf.PI * p.x + 0.6f * t);
    }
}
