using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
    public enum RorationAxes
    {
        XandY,
        X,
        Y
    }
    public RorationAxes _axes = RorationAxes.XandY;
    public float _rotationSpeedHor = 5.0f;
    public float _rotationSpeedVer = 5.0f;

    public float maxVert = 45.0f;
    public float minVert = -45.0f;

    private float _rotationX = 0;

    private bool isMoving;
    private Animator _animator;

    private void Start()
    {
        Rigidbody body = GetComponent<Rigidbody>();
        if (body != null)
            body.freezeRotation = true;

        _animator = GetComponent<Animator>();
    }

    private void Update()
    {
        //Проверим ось движения
        if(_axes == RorationAxes.XandY)
        {
            _rotationX -= Input.GetAxis("Mouse Y") * _rotationSpeedVer;
            _rotationX = Mathf.Clamp(_rotationX, minVert, maxVert);

            float delta = Input.GetAxis("Mouse X") * _rotationSpeedHor;
            float _rotationY = transform.localEulerAngles.y + delta;

            transform.localEulerAngles = new Vector3(_rotationX, _rotationY, 0);
        }
        else if(_axes == RorationAxes.X)
        {
            transform.Rotate(0, Input.GetAxis("Mouse X") * _rotationSpeedHor, 0);
        }
        else if(_axes == RorationAxes.Y)
        {
            _rotationX -= Input.GetAxis("Mouse Y") * _rotationSpeedVer;
            _rotationX = Mathf.Clamp(_rotationX, minVert, maxVert);

            float _rotationY = transform.localEulerAngles.y;

            transform.localEulerAngles = new Vector3(_rotationX, _rotationY, 0);

            if(_animator != null)
            {
                if (!isMoving)
                {
                    if (_rotationX > 0)
                    {
                        _animator.SetFloat("Turn", 1);
                    }
                    else if (_rotationX < 0)
                    {
                        _animator.SetFloat("Turn", -1);
                    }
                    else
                    {
                        _animator.SetFloat("Turn", 0);
                    }
                }
            }
        }
    }

    public void SetIsMovimg(bool new_state)
    {
        isMoving = new_state;
    }
}
