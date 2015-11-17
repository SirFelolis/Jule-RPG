using UnityEngine;
using System.Collections;

public class PlayerMoveBehavior : AbstractPlayerBehavior
{
    public float speed;

    void FixedUpdate()
    {
        var horizontal = Input.GetAxis("Horizontal");
        var vertical = Input.GetAxis("Vertical");

        if (Mathf.Abs(vertical) > 0.1f)
        {
            if (vertical > 0.2f)
            {
                transform.Translate(0, speed * Time.deltaTime, 0, Space.World);
            }

            if (vertical < -0.2f)
            {
                transform.Translate(0, -speed * Time.deltaTime, 0, Space.World);
            }
        }
        else
        {
            if (horizontal > 0.2f)
            {
                transform.Translate(speed * Time.deltaTime, 0, 0, Space.World);
            }

            if (horizontal < -0.2f)
            {
                transform.Translate(-speed * Time.deltaTime, 0, 0, Space.World);
            }
        }
    }
}
