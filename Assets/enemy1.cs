using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy1 : MonoBehaviour
{
    public float enemySpeedFactor = 1.0f;
    public int enemyDirection = 1;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float positionX = transform.position.x;
        float timeDeltaTime = Time.deltaTime;

        positionX += enemySpeedFactor * timeDeltaTime * enemyDirection;

        transform.position = new Vector3(positionX, transform.position.y, 0);
    }
}
