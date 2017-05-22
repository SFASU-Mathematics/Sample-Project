using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public class Ripple : IGrapher
{
    protected override float Function(Vector3 p, float t)
    {
        p.x -= 0.5f;
        p.z -= 0.5f;
        float squareRadius = p.x * p.x + p.z * p.z;
        return 0.5f + Mathf.Sin(15f * Mathf.PI * squareRadius - 2f * t) / (2f + 100f * squareRadius);
    }
}