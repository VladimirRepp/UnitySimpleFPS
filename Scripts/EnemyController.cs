using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [Header("Название заголовка")]
    [Tooltip("Для чего нужна переменная")]
    [SerializeField]
    private GameObject[] _enemyPrefab;//массив объектов шаблонов
    private GameObject _enemy;

    private void Update()
    {
        //Создаем нового врага, если врагов нет
        //Так можно регулировать количество врагов на сцене
        if(_enemy == null)
        {
            int randEnemy = Random.Range(1, _enemyPrefab.Length);//случайно выбираем врага
            _enemy = Instantiate(_enemyPrefab[randEnemy]) as GameObject;//создаем клона как игровой объект
            _enemy.transform.position = new Vector3(0, 3, 0);//задаем позицию появления
           
            float angle = Random.Range(0, 360);
            _enemy.transform.Rotate(0, angle, 0);//поворачиваем
        }
    }
}
