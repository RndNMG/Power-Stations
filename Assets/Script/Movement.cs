using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public VariableJoystick joyStick;
    public AudioSource audioSource;
    private float speed = 15f;

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x >= -30 && transform.position.x <= 30 || transform.position.z >= -40 && transform.position.z <= 40)
        {
            float vel = joyStick.Vertical;
            float hor = joyStick.Horizontal;
            var movement = new Vector3(hor, 0, vel) * speed * Time.deltaTime;
            transform.Translate(movement, Space.Self);
            if (joyStick.isWalking)
            {
                if (!audioSource.isPlaying)
                    audioSource.Play();
            }
            else
                audioSource.Stop();
        }
        if (transform.position.x > 30)
        {
            transform.position = new Vector3(30, 0, transform.position.z);
        }
        if(transform.position.z > 40)
        {
            transform.position = new Vector3(transform.position.x, 0, 40);
        }
        if (transform.position.x < -30)
        {
            transform.position = new Vector3(-30, 0, transform.position.z);
        }
        if(transform.position.z < -40)
        {
            transform.position = new Vector3(transform.position.x, 0, -40);
        }
    }
}
