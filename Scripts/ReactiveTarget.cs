using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReactiveTarget : MonoBehaviour
{
    private EnemyAI _enemyAI;//ссылка на компонент

    private void Start()
    {
        //Получим данные о EnemyAI
        _enemyAI = GetComponent<EnemyAI>();
    }

    //Реакция на попадание
    public void ReactToHit()
    {
        //Если такой компонент есть
        if (_enemyAI != null)
            _enemyAI.SetAlive(false);//вызываем его открытый метод

        //Запускаем сопрограмму для смерти
        StartCoroutine(DieCoroutine(3));
    }

    //Сопрограмма смерти 
    private IEnumerator DieCoroutine(float waitSecond)
    {
        this.transform.Rotate(45, 0, 0);//поворачиваем объект имитируя поподание

        //ждем
        yield return new WaitForSeconds(waitSecond);

        //Уничтожаем объект
        Destroy(this.transform.gameObject);
    }
}
