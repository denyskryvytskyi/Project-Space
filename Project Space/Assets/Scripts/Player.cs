using System.Collections;
using System.Collections.Generic;
using UnityEngine;

enum playerStates { }


/* Класс описывает обьект "Игрок"
 * Содержит следующие поля:
 * 1. Здоровье
 * 2. Щит
 * 3. Различные состояния: движение, диалог, открыт инвентарь, сражение / Нужно подумать как правильно реализовать все состояния, пока решил перечеслением.
 * 4. Заряд оружия
 * 5. Уровень состояния оружия
 */
 // Думаю можно сделать синглтон
public class Player : MonoBehaviour
{
    [SerializeField]
    private string s_Name; // имя игрока, пока не сделал возможность изменять

    [SerializeField]
    [Range(0, 100)]
    private float health; // уровень здоровья, максимум - 3 полоски по 100 раз

    [SerializeField]
    [Range(0, 100)]
    private float shield; // уровень щита, если упал до 0, то полоска здоровья

    // Getter for a health
    public float Health
    {
        get
        {
            return health;
        }
    }
}
