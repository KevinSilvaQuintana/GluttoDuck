using UnityEngine;
using System.Collections;

public class TestCollider2D : MonoBehaviour {

    private TextMesh collisionText;
    private TextMesh triggerText;
    private TextMesh playerPositionText;

    private Transform player;

    private TextMesh[] components;

    void Start()
    {
        player = GameObject.Find("Zelda").GetComponent<Transform>();

        components = this.gameObject.GetComponentsInChildren<TextMesh>();
//        collisionText = this.gameObject.GetComponent<TextMesh>();
//        triggerText = this.gameObject.GetComponent<TextMesh>();
        Debug.Log ("TextMeshes found: " + components.Length);

        collisionText = components[0];
        triggerText = components[1];
        playerPositionText = components[2];

        collisionText.text = "";
        triggerText.text = "";

        if (collisionText != null)
        {
            Debug.Log ("CollisionText found");
        }
        else
        {
            Debug.Log ("CollisionText not found");
        }
    }

    void Update()
    {
        if(playerPositionText != null)
        {
            playerPositionText.text = "Player X: " + player.position.x + "\nPlayer Y: " + player.position.y;
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log ("CollisionEnter2D");
    }

    void OnCollisionStay2D(Collision2D collision)
    {
        Debug.Log ("CollisionStay2D");
        if (collisionText != null)
        {
            collisionText.text = "CollisionStay";
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        Debug.Log ("CollisionExit2D");
        if (collisionText != null)
        {
            collisionText.text = "";
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log ("TriggerEnter2D");
        if (triggerText != null)
        {
            triggerText.text = "OnTriggerEnter2D";
        }
    }

    void OnTriggerStay2D(Collider2D collision)
    {
        Debug.Log ("TriggerStay2D");
        if (triggerText != null)
        {
            triggerText.text = "OnTriggerStay2D";
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        Debug.Log ("TriggerExit2D");
        if (triggerText != null)
        {
            triggerText.text = "OnTriggerExit2D";
        }
    }
}
