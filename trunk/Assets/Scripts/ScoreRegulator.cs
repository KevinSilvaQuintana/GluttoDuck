using UnityEngine;
using System.Collections;

public class ScoreRegulator : MonoBehaviour
{


    public int score = 0;
    private int amount;
    private bool displayAmount;
    private ComboRegulator cRegulator;
    private TextMesh text;
    private SpeedRegulator regulator;
    private float amountTimeExpiration =1f;
    private float currentTime = 0f;

    void Awake () {
        DontDestroyOnLoad (this); 
    }

    // Use this for initialization
    void Start ()
    {
        text = this.gameObject.GetComponent<TextMesh> ();
        cRegulator = GameObject.Find ("ComboRegulator").GetComponent<ComboRegulator> ();
    }

    void Update ()
    {

        if (currentTime < amountTimeExpiration && displayAmount) {
            if (amount >= 0) {
                text.text = "Score: " + score + " (+" + amount + ")";
            } else {
                text.text = "Score: " + score + " (" + amount + ")";
            }

        } else {
            currentTime =0;
            text.text = "Score: " + score;
            displayAmount = false;
        }
        currentTime += Time.deltaTime;
    }

    public void AdjustScore (GameObject obj)
    {
        displayAmount = true;
        amount = 0;

        switch (obj.name) {
        case "RainbowBooster":
        case "RainbowBooster(Clone)":
            amount = 500;
            break;
        case "SlowCloud":
        case "SlowCloud(Clone)":
            if (score >= 100)
                amount = -100;
            break;
        case "CandyA":
        case "CandyA(Clone)":
            amount = 100;
            break;
        case "CandyB":
        case "CandyB(Clone)":
            amount = 150;
            break;
        case "CandyC":
        case "CandyC(Clone)":
            amount = 200;
            break;
        case "Donut":
        case "Donut(Clone)":
            amount = 300;
            break;
        case "Lollipop":
        case "Lollipop(Clone)":
            amount = 500;
            break;    
        default:
            break;
        }
        amount = amount * cRegulator.multiplier;
        score += amount;
    }
}
