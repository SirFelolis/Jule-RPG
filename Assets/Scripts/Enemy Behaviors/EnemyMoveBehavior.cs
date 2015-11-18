using UnityEngine;
using System.Collections;

public class EnemyMoveBehavior : AbstractEnemyBehavior
{
    private float tileSize = 4;
    private float stride = 1;
    private float step;

    void FixedUpdate()
    {
        step = tileSize * stride;

        var pos = transform.position;

        pos.x += step * -1.0f;

        transform.position = pos;

    }
}
