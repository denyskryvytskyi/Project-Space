using UnityEngine;

// Движение корабля 
public class ShipMovement : MonoBehaviour
{
    [SerializeField]
    public float _speed; //  скорость корабля

    [SerializeField]
    private bool _move; // состояние корабля: 0 - стоит, 1 - двигается

    [SerializeField]
    public bool _canMove = true; // может двигаться или нет

    private Vector3 _target; // Точка-цель движения

    void Update()
    {
        if(_canMove == true)
        {
            if (Input.GetMouseButtonDown(0))
            {
                _target = Camera.main.ScreenToWorldPoint(Input.mousePosition); // координаты нажатия ЛКМ пересчитываем в координаты мира.
                _target.z = transform.position.z;
                if (_move == false)
                {
                    _move = true;
                }
            }
            if(transform.position == _target) // если корабль игрока достиг цели
            {
                _move = false; // то он не двигается
            }
            if (_move == true) // если корабль двигается, то вращаем его к цели (нос корабля указывает на таргет)
            {
                RotateObject();
                transform.position = Vector3.MoveTowards(transform.position, _target, _speed * Time.deltaTime);
            }
            else // если _move==false
            {
                transform.rotation = Quaternion.Euler(0f, 0f, 0f);
            }
        }
    }

    // вращение корабля игрока к точке назначения
    void RotateObject()
    {
        Vector3 diff = _target - transform.position;
        diff.Normalize();

        float angleRotZ = Mathf.Atan2(diff.y, diff.x) * Mathf.Rad2Deg; // угол поворота
        Debug.Log("angleRotZ: " + angleRotZ);
        transform.rotation = Quaternion.Euler(0f, 0f, angleRotZ - 90);
    }
}
