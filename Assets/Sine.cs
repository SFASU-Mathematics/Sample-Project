using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sine : IGrapher {

    protected override float Function(Vector3 p, float t)
    {
        return 0.5f + 0.5f * Mathf.Sin(2 * Mathf.PI * p.x + t);
    }
}
