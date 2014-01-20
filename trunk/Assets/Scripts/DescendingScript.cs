using UnityEngine;
using System.Collections;

public class DescendingScript : MonoBehaviour {

    private SpeedRegulator speedRegulator;
    private ComboRegulator comboRegulator;
    private GeneralRegulator generalRegulator;
    private float baseMoveSpeed = 0.6f;
    private float endingY = -7f;


    private bool entry = false;

	void Start ()
    {
        speedRegulator = GameObject.Find ("SpeedRegulator").GetComponent<SpeedRegulator>();
        generalRegulator = GameObject.Find ("GeneralRegulator").GetComponent<GeneralRegulator>();
//        comboRegulator = GameObject.Find ("ComboRegulator").GetComponent<ComboRegulator> ();
	}
	
	void Update ()
    {
        transform.Translate (Vector3.down * Time.deltaTime * baseMoveSpeed * speedRegulator.velocity);
        if(transform.position.y < endingY)
        {
            Destroy (this.gameObject);
        }
	}

    public void setMoveSpeed(float baseMoveSpd)
    {
        baseMoveSpeed = baseMoveSpd;
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if(!entry)
        {
            entry = true;
            if(collider.gameObject.name == "Duck")
            {
                //speedRegulator.AdjustSpeed(this.gameObject);
                generalRegulator.NotifyCollision(this.gameObject);
            }
        }
    }

    void OnTriggerExit2D(Collider2D collider)
    {
        entry = false;
    }
}
