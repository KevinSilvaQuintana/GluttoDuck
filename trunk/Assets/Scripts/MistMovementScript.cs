using UnityEngine;
using System.Collections;

public class MistMovementScript : MonoBehaviour {

    private SpeedRegulator regulator;
    public float baseMoveSpeed;
    public float startingY;
    public float endingY;


    void Start ()
    {
        // Grab multiplier
        regulator = GameObject.Find ("SpeedRegulator").GetComponent<SpeedRegulator>();
    }

	void Update ()
    {
        transform.Translate (Vector3.down * Time.deltaTime * baseMoveSpeed * regulator.velocity);
        if(transform.position.y <= endingY)
        {
            ResetPosition();
        }
	}

    public void ResetPosition()
    {
        transform.position = new Vector3(0,startingY,1);
    }
}
