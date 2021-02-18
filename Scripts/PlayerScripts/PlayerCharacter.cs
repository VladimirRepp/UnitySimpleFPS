using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCharacter : MonoBehaviour
{
    //Количество жизни у игрока
    private int _health = 5;

    private void Start()
    {
        //Инициализируем
        _health = 5;
    }

    //Ранение
    public void Hurt(int damage)
    {
        _health -= damage;
        Debug.Log("Player health: " + _health);
    }
}
