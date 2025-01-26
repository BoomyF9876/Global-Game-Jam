using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAngleMove : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        if (angle > 90 || angle < -90) {
            GetComponent<SpriteRenderer>().flipY = true;
        }
       transform.Rotate(Vector3.forward * angle);
    }

    public float angle = 0.0f;
    public float yCameraTriggerOffset = 0.0f;
    public float speed = 2;

    bool isTriggered = false;

    // Update is called once per frame
    void Update()
    {
        if (!isTriggered) {
            if (transform.position.y > Camera.main.transform.position.y + yCameraTriggerOffset)
                isTriggered = true;
        }
        if (isTriggered) {
            transform.position = transform.position + Time.deltaTime * speed * new Vector3(Mathf.Cos(angle / 180 * Mathf.PI), Mathf.Sin(angle / 180 * Mathf.PI), 0);
        }
    }
}
