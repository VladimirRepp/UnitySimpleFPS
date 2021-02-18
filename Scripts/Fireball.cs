using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireball : MonoBehaviour
{
    public float speed = 10f;//скорость движения 
    public int damage = 1;//наносимый урон

    private void Update()
    {
        //У огненного шара постоянное движение вперед
        transform.Translate(0,0,speed*Time.deltaTime);
    }

    //Когда с тригером столкнется другой объект, вызывется этот метод
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.name);

        PlayerCharacter player = other.GetComponent<PlayerCharacter>();
        if(player != null)
        {
            player.Hurt(damage);
        }

        Destroy(this.gameObject);
    }

}
