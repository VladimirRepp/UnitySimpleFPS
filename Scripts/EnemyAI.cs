using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Базовый искуственный интелект
public class EnemyAI : MonoBehaviour
{
    //Параметры сценария
    public float speed = 5.0f;
    public float obstacleRande = 5.0f;
    public bool _alive = true;

    //Снаряды
    [SerializeField]
    private GameObject[] _fireballsPrefab;
    private GameObject _fireball;

    private void Start()
    {
        _alive = true;
    }

    private void Update()
    {
        if (_alive)
        {
            //Непрерывное движение вперед
            transform.Translate(0, 0, speed * Time.deltaTime);

            //Луч из объекта вперед
            Ray ray = new Ray(transform.position, transform.forward);
            RaycastHit hit;//объект удара

            //Пускаем луч и проверяем 
            if (Physics.Raycast(ray, out hit))
            {
                //Получаем объект удара
                GameObject hitObject = hit.transform.gameObject;
                //Если объект удара игрок
                if (hitObject.GetComponent<CharacterController>())
                {
                    //Если огненого шара нет
                    if (_fireball == null)
                    {
                        int randFireball = Random.Range(1, _fireballsPrefab.Length);
                        _fireball = Instantiate(_fireballsPrefab[randFireball]) as GameObject;
                        _fireball.transform.position = transform.TransformPoint(Vector3.forward * 1.5f);//напривим огненый шар перед врагом
                        _fireball.transform.rotation = transform.rotation;//в том же направлении
                    }
                }
                //Проверяем дистанцию до объекта впереди
                else if (hit.distance < obstacleRande)
                {
                    //Пора действовать
                    float angleRotation = Random.Range(-100, 100);//выбираем угол поворота
                    transform.Rotate(0, angleRotation, 0);//поворачиваемся
                }
            }
        }        
    }

    public void SetAlive(bool alive)
    {
        _alive = alive;
    }
}
