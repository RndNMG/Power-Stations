using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Guild : MonoBehaviour
{
    public GameObject touchGuild;

    private bool hold = true;
    private bool lastHold = false;

    public void SetfristTimeTrue()
    {
        if (hold == true && lastHold == false)
        {
            // do your jump logic
            touchGuild.SetActive(true);
            lastHold = hold;
        }
        else if (lastHold == true && hold == false)
        {
            lastHold = hold;
        }

    }
}
