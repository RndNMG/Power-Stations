﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pulsing : MonoBehaviour
{

    private bool coroutineAllowed;
    private VariableJoystick joystick;
    // Start is called before the first frame update
    void Start()
    {
        coroutineAllowed = true;
        joystick = VariableJoystick.instance;
    }

    private void OnMouseOver()
    {
        if (coroutineAllowed)
        {
            joystick = VariableJoystick.instance;
            if (joystick != null)
                if (!joystick.isWalking)
                    StartCoroutine("StartPulsing");
        }
    }
    private IEnumerator StartPulsing()
    {
        coroutineAllowed = false;
        for (float i = 0f; i < 1f; i += 0.1f)
        {
            transform.localScale = new Vector3(
                Mathf.Lerp(transform.localScale.x, transform.localScale.x + 0.025f, Mathf.SmoothStep(0f, 1f, i)), 
                Mathf.Lerp(transform.localScale.y, transform.localScale.y + 0.025f, Mathf.SmoothStep(0f, 1f, i)), 
                Mathf.Lerp(transform.localScale.z, transform.localScale.z + 0.025f, Mathf.SmoothStep(0f, 1f, i)));
            yield return new WaitForSeconds(0.02f);
        }
        for (float i = 0f; i < 1f; i += 0.1f)
        {
            transform.localScale = new Vector3(
                Mathf.Lerp(transform.localScale.x, transform.localScale.x - 0.025f, Mathf.SmoothStep(0f, 1f, i)),
                Mathf.Lerp(transform.localScale.y, transform.localScale.y - 0.025f, Mathf.SmoothStep(0f, 1f, i)),
                Mathf.Lerp(transform.localScale.z, transform.localScale.z - 0.025f, Mathf.SmoothStep(0f, 1f, i)));
            yield return new WaitForSeconds(0.02f);
        }
        coroutineAllowed = true;
    }
}
