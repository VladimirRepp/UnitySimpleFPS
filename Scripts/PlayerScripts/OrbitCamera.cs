using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrbitCamera : MonoBehaviour
{
    //Цель наблюдения
    [SerializeField]
    private Transform _target;

    //Скорость вращения
    public float _rotSpeed;
    private float _rotY;
    private Vector3 _offset;

    private void Start()
    {
        //Запомним начальное смещение относительно камеры и цели
        _rotY = transform.eulerAngles.y;
        _offset = _target.position - transform.position;
    }


}
