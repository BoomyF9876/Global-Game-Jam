using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
// using UnityEngine.UIModule;

public class player1 : MonoBehaviour
{
    public float scrollFactor = 0.1f;
    public float movementSpeedFactor = 1.0f;
    float playerHealth = 1.0f;
    float playerHalfWidth;
    float playerHalfHeight;
    Vector3 screenBoundsLeft;
    Vector3 screenBoundsRight;
    // Start is called before the first frame update
    void Start()
    { 
        playerHalfWidth = GetComponent<SpriteRenderer>().bounds.extents.x;
        playerHalfHeight = GetComponent<SpriteRenderer>().bounds.extents.y;
        
        GameObject.Find("gameover").GetComponent<Renderer>().enabled = false;
        GameObject.Find("restart").GetComponent<Renderer>().enabled = false;
        GameObject.Find("restart").GetComponent<Collider2D>().enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        screenBoundsLeft = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, 1));
        screenBoundsRight = Camera.main.ViewportToWorldPoint(new Vector3(1, 1, 1));

        float timeDeltaTime = Time.deltaTime;
        Camera.main.transform.position = Camera.main.transform.position + new Vector3(0, -scrollFactor * Time.deltaTime, 0);
        float positionX = transform.position.x;
        float positionY = transform.position.y - scrollFactor * timeDeltaTime;

        positionX += Input.GetAxis("Horizontal") * timeDeltaTime * movementSpeedFactor;
        positionY += Input.GetAxis("Vertical") * timeDeltaTime * movementSpeedFactor;

        positionX = Mathf.Clamp(positionX, screenBoundsLeft.x + playerHalfWidth, screenBoundsRight.x - playerHalfWidth);
        positionY = Mathf.Clamp(positionY, screenBoundsLeft.y + playerHalfHeight, screenBoundsRight.y - playerHalfHeight);

        transform.position = new Vector3(positionX, positionY, 0);
    }

    void OnTriggerEnter2D(Collider2D collision) {
        Debug.Log(collision.name);
        playerHealth--;
        GameObject.Find("gameover").GetComponent<Renderer>().enabled = true;
        GameObject.Find("restart").GetComponent<Renderer>().enabled = true;
        GameObject.Find("restart").GetComponent<Collider2D>().enabled = true;
        Time.timeScale = 0;
    }
}
