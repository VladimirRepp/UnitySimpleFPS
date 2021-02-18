using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPSMovement : MonoBehaviour
{
    //Параметры для работы сценария
    public float _walkingSpeed = 6.0f;
    public float _runningSpeed = 25.0f;
    public float _gravity = -9.8f;

    private CharacterController _characterController;

    [SerializeField]
    private Animator _animator;

    private MouseLook _mouseLook;

    private void Start()
    {
        _characterController = GetComponent<CharacterController>();
        if (_characterController == null)
            Debug.Log("CharacterController is NULL");

        _mouseLook = GetComponent<MouseLook>();
        _animator = GetComponent<Animator>();
    }

    private void Update()
    {
        float deltaX = Input.GetAxis("Horizontal") * _walkingSpeed;
        float deltaZ = Input.GetAxis("Vertical") * _walkingSpeed;

        /* 
         * Было:
          Vector3 movement = new Vector3(deltaX, 0, deltaZ);
          movement = Vector3.ClampMagnitude(movement, _speed);
          movement.y = _gravity;

          movement *= Time.deltaTime;
          movement = transform.TransformDirection(movement);
          _characterController.Move(movement);
          }
        */

        //Стало:
        //Задаем состояния анимации
        if (deltaZ != 0)
        {
            _animator.SetFloat("Forward", deltaZ);//передаем deltaZ - чтобы двигаться вперед и назад, когда нужно 
            _mouseLook.SetIsMovimg(true);

            if (Input.GetKey(KeyCode.LeftShift))
            {
                _animator.SetBool("Run", true);
                _mouseLook.SetIsMovimg(true);
            }
        }
        else
        {
            _animator.SetFloat("Forward", 0);
            _animator.SetBool("Run", false);
            _mouseLook.SetIsMovimg(false);
        }

        if (deltaX > 0)
        {
            _animator.SetFloat("Turn", 1);
        }
        else if(deltaX < 0)
        {
            _animator.SetFloat("Turn", -1);
        }
        else
        {
            _animator.SetFloat("Turn", 0);
        }
    }
}
