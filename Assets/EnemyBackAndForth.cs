using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBackAndForth : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public float zigDistance = 2.0f;
    public float speed = 2.0f;
    public float initialDelay = 0;
    public float waitAfterZig = 0.5f;
    public float verticalSpeed = 1.0f;


    float distanceMoved = 0;
    float totalWait = 0;
    enum Phase {
        DELAY, RIGHT, WAIT_RIGHT, LEFT, WAIT_LEFT
    }
    Phase phase = Phase.DELAY;
    bool verticalMoveTriggered = false;

    // Update is called once per frame
    void Update()
    {
        handleVerticalMovement();
        switch (phase)
        {
            case Phase.DELAY:
            {
                totalWait += Time.deltaTime;
                if (totalWait > initialDelay) {
                    distanceMoved = 0;
                    GetComponent<SpriteRenderer>().flipX = false;
                    phase = Phase.RIGHT;
                }
                break;
            }
            case Phase.RIGHT:
            {
                float moveAmount = speed * Time.deltaTime;
                if (moveAmount > zigDistance - distanceMoved)
                {
                    moveAmount = zigDistance - distanceMoved;
                    totalWait = 0;
                    phase = Phase.WAIT_RIGHT;
                }
                distanceMoved += moveAmount;
                transform.Translate(moveAmount, 0, 0);
                break;
            }
            case Phase.WAIT_RIGHT:
            {
                totalWait += Time.deltaTime;
                if (totalWait > waitAfterZig) {
                    distanceMoved = 0;
                    GetComponent<SpriteRenderer>().flipX = true;
                    phase = Phase.LEFT;
                }
                break;
            }
            case Phase.LEFT:
            {
                float moveAmount = speed * Time.deltaTime;
                if (moveAmount > zigDistance - distanceMoved)
                {
                    moveAmount = zigDistance - distanceMoved;
                    totalWait = 0;
                    phase = Phase.WAIT_LEFT;
                }
                distanceMoved += moveAmount;
                transform.Translate(-moveAmount, 0, 0);
                break;
            }
            case Phase.WAIT_LEFT:
            {
                totalWait += Time.deltaTime;
                if (totalWait > waitAfterZig) {
                    distanceMoved = 0;
                    GetComponent<SpriteRenderer>().flipX = false;
                    phase = Phase.RIGHT;
                }
                break;
            }
        }
    }

    void handleVerticalMovement()
    {
        if (!verticalMoveTriggered) {
            float spriteTop = GetComponent<SpriteRenderer>().bounds.max.y;
            float cameraBottom = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, 1)).y;
            if (spriteTop > cameraBottom)
                verticalMoveTriggered = true;
        }
        
        // Scroll it up when it is visible
        if (verticalMoveTriggered && transform.position.y < 5000f) {
            transform.position = transform.position + verticalSpeed * Time.deltaTime * new Vector3(0.0f, 1.0f, 0.0f);
        }

    }
}
