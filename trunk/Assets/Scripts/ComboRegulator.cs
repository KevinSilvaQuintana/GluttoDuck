using UnityEngine;
using System.Collections;

public class ComboRegulator : MonoBehaviour
{

    public int combo;
    public int multiplier;

    private TextMesh textMesh;

    // Use this for initialization
    void Start ()
    {
        combo = 0;
        multiplier = 1;
        textMesh = this.gameObject.GetComponent<TextMesh> ();
    }
    
    // Update is called once per frame
    void Update ()
    {
        textMesh.text = "Combo: " + combo + " (x" + multiplier + ")"; 
    
    }

    public void increaseCombo (GameObject obj)
    {
        if (obj.name == "SlowCloud" || obj.name == "SlowCloud(Clone)") {
            resetCombo ();
        } else {
            combo++;
            if (combo >= 5) {
                multiplier = 2;
                if (combo >= 10) {
                    multiplier = 3;
                    if (combo >= 20) {
                        multiplier = 4;
                        if (combo >= 40) {
                            multiplier = 5;
                        }
                    }
                }
            }//end combo ifs
        }
    }

    public void resetCombo(){
        combo=0;
        multiplier = 1;
    }


}
