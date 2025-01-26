using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSquashingMovement : MonoBehaviour
{
    void Start()
    { 
        baseScale = transform.localScale;
    }

    Vector3 baseScale = new Vector3(1,1,1);

    void SquashOnMovement()
    {
        float xScale = 0.0f;
        if (Input.GetAxis("Horizontal") != 0)
            xScale = -0.2f;
        float yScale = 0.0f;
        if (Input.GetAxis("Vertical") > 0)
            yScale = -0.2f;
        else if (Input.GetAxis("Vertical") < 0)
            yScale = 0.2f;
        transform.localScale = baseScale + new Vector3(xScale, yScale, 0);
    }

    // Update is called once per frame
    void Update()
    {
        SquashOnMovement();
    }
}
