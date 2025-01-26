using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTargetMissile : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
    }

    public float distanceToPlayer = 2.0f;
    public float speed = 2;

    bool isTriggered = false;
    float angle;

    public GameObject player;

    // Update is called once per frame
    void Update()
    {
        if (!isTriggered) {


            if (Vector3.Distance(transform.position, player.transform.position) < distanceToPlayer) {
                isTriggered = true;
                Vector3 posDiff = player.transform.position - transform.position;
                angle = Mathf.Atan2(posDiff.y, posDiff.x) / Mathf.PI * 180;
                if (angle > 90 || angle < -90) {
                    GetComponent<SpriteRenderer>().flipY = true;
                }
                transform.Rotate(Vector3.forward * angle);
            }


        }
        if (isTriggered) {
            transform.position = transform.position + Time.deltaTime * speed * new Vector3(Mathf.Cos(angle / 180 * Mathf.PI), Mathf.Sin(angle / 180 * Mathf.PI), 0);
        }
    }
}
