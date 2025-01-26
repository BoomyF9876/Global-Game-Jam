using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundAudioTrigger : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    bool hasBeenTriggered = false;

    // Update is called once per frame
    void Update()
    {
        if (!hasBeenTriggered) {
            float spriteTop = GetComponent<SpriteRenderer>().bounds.max.y;
            float cameraBottom = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, 1)).y;
            if (spriteTop > cameraBottom)
            {
                GetComponent<AudioSource>().Play();
                hasBeenTriggered = true;

            }
        }
        

    }
}
