using UnityEngine;

// Движение корабля 
public class ShipMovement : MonoBehaviour
{
    [SerializeField]
    public float speed; //  скорость корабля

    [SerializeField]
    public bool isMoving = false; // состояние корабля: false - стоит, true - двигается

    [SerializeField]
    public bool canMove = true; // может двигаться или нет

    private Vector3 target; // Точка-цель движения
    //
    [SerializeField]
    private CheckClicks clickChecker;
    //
    UIManager uiManager;

    private void Awake()
    {
        uiManager = UIManager.GetInstance();
    }

    void Update()
    {
        if (canMove && !uiManager.isWindowOpened)
        {
            if (Input.GetMouseButtonDown(0) && !clickChecker.IsHud())
            {
                target = Camera.main.ScreenToWorldPoint(Input.mousePosition); // координаты нажатия ЛКМ пересчитываем в координаты мира.
                target.z = transform.position.z;
                if (!isMoving)
                {
                    isMoving = true;
                }
            }
            if (transform.position == target) // если корабль игрока достиг цели
            {
                isMoving = false; // то он не двигается
            }
            if (isMoving) // если корабль двигается, то вращаем его к цели (нос корабля указывает на таргет)
            {
                RotateObject();
                transform.position = Vector3.MoveTowards(transform.position, target, speed * Time.deltaTime);
            }
        }
    }

    // вращение корабля игрока к точке назначения
    void RotateObject()
    {
        Vector3 diff = target - transform.position;
        diff.Normalize();

        float angleRotZ = Mathf.Atan2(diff.y, diff.x) * Mathf.Rad2Deg; // угол поворота
        transform.rotation = Quaternion.Euler(0f, 0f, angleRotZ - 90);
    }
}
