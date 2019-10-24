using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

// Главный класс-контроллер для механики пошаговый бой
// ПЕРЕДЕЛАТЬ: механику движения корабля, повторение в файле ShipMovement
public class GridController : MonoBehaviour
{
    public Transform player;

    [SerializeField]
    public GridLayout grid;

    public Tilemap tilemap;

    [SerializeField]
    private float coefficient; // коеефициент - соотношение размеров ячеек.

    [SerializeField]
    public float _speed; //  скорость корабля

    [SerializeField]
    public bool _move; //  состояние движения

    private Vector3Int cellPosition; // позиция целевой ячейки
    private Vector3 newPosition; // позиция целевой ячейки

    private void Update()
    {
        if (player.position == newPosition)
        {
            _move = false;
        }
        // left click - get info from selected tile
        if (Input.GetMouseButtonUp(0))
        {
            // get mouse click's position in 2d plane
            Vector3 pz = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            pz.z = 0;

            // convert mouse click's position to Grid position
            //GridLayout gridLayout = transform.GetComponent<Grid>();
            cellPosition = grid.WorldToCell(pz);

            Debug.Log("1" + cellPosition);
            // set selectedUnit to clicked location on grid
            setPlayerLocation();
            Debug.Log("3" + cellPosition);
        }
        if (_move)
        {
            Debug.Log("Here!");
            MovePlayer();
        }
        else
        {
            player.rotation = Quaternion.Euler(0f, 0f, 0f);
        }
        
    }

    // передвижение корабля в указанную ячейку
    private void setPlayerLocation()
    {
        Debug.Log("2" + cellPosition);

        // Меняем цвет целевой яечки на зеленый
        // Flag the tile, inidicating that it can change colour.
        // By default it's set to "Lock Colour".
        tilemap.SetTileFlags(cellPosition, TileFlags.None);
        tilemap.SetColor(cellPosition, Color.green);
        _move = true;
    }

    // вращение корабля игрока к точке назначения
    void MovePlayer()
    {
        // Двигаем корабль
        newPosition = new Vector3(cellPosition.x + coefficient, cellPosition.y + coefficient);
        
        Vector3 diff = newPosition - player.position;
        diff.Normalize();

        float angleRotZ = Mathf.Atan2(diff.y, diff.x) * Mathf.Rad2Deg; // угол поворота
        player.rotation = Quaternion.Euler(0f, 0f, angleRotZ - 90);

        player.position = Vector3.MoveTowards(player.position, newPosition, _speed * Time.deltaTime);
    }
}
