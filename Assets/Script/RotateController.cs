using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//[RequireComponent(typeof(MeshRenderer))]
public class RotateController : MonoBehaviour
{
    public GameObject GuildPanel;

    #region ROTATE
    private float _sensitivity = .2f;
    private Vector3 _mouseReference;
    private Vector3 _mouseOffset;
    private Vector3 _rotation = Vector3.zero;
    private bool _isRotating;

    #endregion
    void Update()
    {
        if (_isRotating)
        {
            print("Enter The IF ");
            // offset
            _mouseOffset = (Input.mousePosition - _mouseReference);

            // apply rotation
            _rotation.y = -(_mouseOffset.x + _mouseOffset.y) * _sensitivity;

            // rotate
            gameObject.transform.Rotate(_rotation);

            // store new mouse position
            _mouseReference = Input.mousePosition;

            if (GuildPanel != null)
                GuildPanel.SetActive(false);
        }
    }

    void OnMouseDown()
    {
        // rotating flag
        _isRotating = true;
        Debug.Log("Clicked");

        // store mouse position
        _mouseReference = Input.mousePosition;
    }

    void OnMouseUp()
    {
        // rotating flag
        _isRotating = false;
    }
}
