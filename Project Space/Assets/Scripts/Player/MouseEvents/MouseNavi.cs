using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseNavi : MonoBehaviour
{
    public static bool isDone { get; private set; }  // два использования: 1. путь построен. 2. точка пройдена
    //
    public Transform dotPrefab; // префаб для визуализации точки
    public float step = 1f; // расстояние от точки до точки
    [SerializeField]
    private Transform player; // координаты игрока
    //
    private Vector2 targetPosition; // целевая точка
    private List<Transform> path = new List<Transform>(); // массив точек - путь
    private int index = -1;
    private Vector2 position; // текущая позиция новой точки пути
    //
    [SerializeField]
    private CheckClicks clickChecker;
    //
    ShipMovement shipMovementManager;
    //
    UIManager uiManager;

    private void Awake()
    {
        shipMovementManager = FindObjectOfType<ShipMovement>();
        uiManager = UIManager.GetInstance();
    }

    // добавление префаба точки на сцену
    void AddDot(Vector2 curPos)
    {
        Transform t = Instantiate(dotPrefab) as Transform;
        t.position = curPos;
        path.Add(t);
    }

    // основная функция, создание маршрута
    void DoAction() 
    {
        float dist = step;
        
        do
        {
            dist = Vector3.Distance(position, targetPosition);
            AddDot(position);
            position = position + (targetPosition - position) * step / dist;
        }while(dist >= step);
    }

    void Update()
    {
        if (!uiManager.isWindowOpened)
        {
            if (shipMovementManager.canMove)
            {
                if (Input.GetMouseButtonUp(0) && !clickChecker.IsHud())
                {
                    // если путь уже установлен, то удаляем и создаем новый
                    if (isDone)
                    {
                        ClearPath();
                    }

                    // задаем путь
                    targetPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                    position = player.position;
                    DoAction();
                    isDone = true;
                }
            }

            if (shipMovementManager.isMoving)
            {
                UpdatePath();
            }
        }
        
    }

    // Удаляем точки пути
    void ClearPath()
    {
        index = -1;
        for (int i = 0; i < path.Count; i++)
        {
            Destroy(path[i].gameObject);
        }
        path.Clear();
        isDone = false;
    }

    // обновление массива точек пути (если корабль двигается, необходимо удалять пройденные точки)
    void UpdatePath()
    {
        if (!isDone) return; // если нет пути - проверять и чистить не нужно

        // Механизм следующий: берем индекс первой точки и сравниваем расстояние от нее до позиии игрока, если меньше 0.1 - удаляем, увеличиваем индекс
        // Далее сравниваем расстояние до след точки
        // Если путь перестроен, массив обновлен, и индекс сбрасывается соответственно до -1, чтобы начинать с первой точки (сброс в методе Clear Path)
        if (index == -1)
            index = 0;

        if(index < path.Count && index >= 0)
        {
            float dist = Vector3.Distance(path[index].position, player.position);
            //Debug.Log("dots count :" + path.Count + "; dist: " + dist + "; index:" + index);
            if (dist <= 0.1f)
            {
                //Debug.Log("Точка удалена");
                Destroy(path[index].gameObject);
                path.RemoveAt(index);
            }
        }
       
    }
}
