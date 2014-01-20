using UnityEngine;
using System.Collections;

public class RainbowCollisionScript : MonoBehaviour {

    private SpeedRegulator regulator;

	void Start () {
        regulator = GameObject.Find ("SpeedRegulator").GetComponent<SpeedRegulator>();
	}
	
    void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.gameObject.name == "Duck")
        {
            regulator.AdjustSpeed(collider.gameObject);
        }
    }
}
