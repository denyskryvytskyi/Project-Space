using UnityEngine;
using System.Collections;

public class UIManager
{
    public bool isWindowOpened = false; // октрыто ли какое-либо игровое окно (для блокировки корабля)

    public static UIManager Internal { get; set; }

    public static UIManager GetInstance()
    {
        if (Internal == null)
        {
            Internal = new UIManager();
        }

        return Internal;
    }

    public void blockPlayerMovement(bool blockMove)
    {
        isWindowOpened = blockMove;
    }
}
