using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayShooter : MonoBehaviour
{
    //Объект камеры
    private Camera _camera;
    private void Start()
    {
        //Получаем данные о камере
        _camera = GetComponent<Camera>();

        //Скроем указатель мыши в Game окошке (чтоб его обратно активировать нажми - esp)
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void Update()
    {
        //Проверяем, когда нажимаем на "выстрел"
        if (Input.GetMouseButtonDown(0))
        {
            //Запоминаем центр экрана
            Vector3 screenСenter = new Vector3(Screen.width/2, Screen.height/2, 0);
            
            //Пускаем луч из центра экрана относительно камеры
            Ray ray = _camera.ScreenPointToRay(screenСenter);
            RaycastHit hit;//улавливаем попадание в эту переменную

            //Если попали в какой то объект
            if(Physics.Raycast(ray, out hit))//пускаем луч ray результат столкновения считываем в hit
            {
                //Распознование попаданий в цель
                GameObject hitObject = hit.transform.gameObject;//получаем объект, в который попали
                ReactiveTarget target = hitObject.GetComponent<ReactiveTarget>();//получаем компонет этого объекта

                //Проверим, попадание в мишень
                if (target != null)
                {
                    target.ReactToHit();
                }
                else
                {
                    //Запускаем сопрограмму
                    StartCoroutine(SphereInicatorCoroutine(hit.point));
                    //Рисуем отладочную линию, чтобы проследить траекторию луча
                    Debug.DrawLine(this.transform.position, hit.point, Color.green, 6);
                }
            }
        }
    }

    private void OnGUI()
    {
        //Добавление визуального индикатора в центре экрана
        int size = 12;
        float posX = _camera.pixelWidth / 2 - size / 4;
        float posY = _camera.pixelHeight / 2 - size / 2;
        GUI.Label(new Rect(posX, posY, size, size), "*");
    }

    //Сопрограмма, которая создает сферу в месте попадания
    private IEnumerator SphereInicatorCoroutine(Vector3 pos)
    {
       //Создаем игровой объект сферу
        GameObject sphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        sphere.transform.position = pos;//указываем позицию сферы

        //yield - ключевое слово для сопрограммы, которое указывает ей, что пора остановиться
        yield return new WaitForSeconds(6);//время ожидания
        //После ожидания вернется в эту часть сопрограммы
        Destroy(sphere);//удалим сферу
    }
}
