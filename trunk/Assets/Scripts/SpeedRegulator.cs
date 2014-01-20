using UnityEngine;
using System.Collections;

public class SpeedRegulator : MonoBehaviour
{

    public float velocity {get; private set;}
    public float initialVelocity;
    public float deceleration;

    private bool boosted = false;
    private float boostAmount = 25;
    private float slowAmount = -10;
    private float boostDuration = 3;
    private float maxSpeed = 50f;
    private float currentBoostDuration;
    private bool farting;

    private GameObject fartAnim;

	void Start () {
        velocity = initialVelocity;
        fartAnim = GameObject.FindGameObjectWithTag("FartAnim");
	}
	
	void Update ()
    {
        if (velocity <= 2) {
            Application.LoadLevel("GameOver");
        }

	    // Speed goes down over time
        if (!boosted && !farting)
        {
            velocity = velocity > 0 ? velocity - velocity * 0.1f * Time.deltaTime : 0;
        }
        else if (boosted)
        {
            currentBoostDuration -= Time.deltaTime;
            if(currentBoostDuration < 0)
            {
                boosted = false;
            }
        }

        if(farting)
        {
            velocity += 15 * Time.deltaTime;
        }

        velocity = Mathf.Clamp (velocity, 0f, maxSpeed);

        fartAnim.SetActive (farting);


	}

    public void AdjustSpeed(GameObject collider)
    {
        string objectName = collider.name;
        float amount = 0;

        switch (objectName)
        {
        case "RainbowBooster":
        case "RainbowBooster(Clone)":
            amount = boostAmount;
            Boost();
            break;
        case "SlowCloud":
        case "SlowCloud(Clone)":
            amount = slowAmount;
            break;
        default:
            break;
        }
        velocity = (velocity + amount < 0) ? 0 : velocity + amount;
    }

    private void Boost()
    {
        if(!boosted)
        {
            boosted = true;
        }
        currentBoostDuration = boostDuration;
    }

    public void SetFarting(bool status)
    {
        farting = status;
    }

    public bool GetFarting()
    {
        return farting;
    }
}
