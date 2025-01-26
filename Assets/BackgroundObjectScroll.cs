using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundObjectScroll : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public float speed = 1.0f;

    private bool isTriggered = false;

    // Update is called once per frame
    void Update()
    {
        // Trigger when it shows up on screen
        if (!isTriggered) {
            float spriteTop = GetComponent<SpriteRenderer>().bounds.max.y;
            float cameraBottom = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, 1)).y;
            if (spriteTop > cameraBottom)
                isTriggered = true;
        }
        
        // Scroll it up when it is visible
        if (isTriggered && transform.position.y < 5000f) {
            transform.position = transform.position + speed * Time.deltaTime * new Vector3(0.0f, 1.0f, 0.0f);
        }
    }
}
