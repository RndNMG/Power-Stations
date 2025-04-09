using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Hotspot : MonoBehaviour
{
    public UnityEvent onClick = new UnityEvent();

    private GameObject clickableHotspot;
    private VariableJoystick joystick;
    private bool alardyPlayed = false;
    // Start is called before the first frame update
    void Start()
    {
        joystick = VariableJoystick.instance;
        clickableHotspot = this.gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            joystick = VariableJoystick.instance;
            Vector3 mousePosFar = new Vector3(Input.mousePosition.x, Input.mousePosition.y, Camera.main.farClipPlane);
            Vector3 mousePosNear = new Vector3(Input.mousePosition.x, Input.mousePosition.y, Camera.main.nearClipPlane);

            Vector3 mousePosF = Camera.main.ScreenToWorldPoint(mousePosFar);
            Vector3 mousePosN = Camera.main.ScreenToWorldPoint(mousePosNear);

            Debug.DrawRay(mousePosN, mousePosF - mousePosN, Color.red);

            RaycastHit hit;

            if (Physics.Raycast(mousePosN, mousePosF - mousePosN, out hit))
            {
                if(hit.collider.gameObject == gameObject)
                {
                    if (joystick != null)
                        if (!joystick.isWalking)
                            if (!alardyPlayed)
                            {
                                onClick.Invoke();
                                alardyPlayed = true;
                            }

                }
            }
        }
    }
    public void ChagePlay()
    {
        alardyPlayed = false;
    }
}
