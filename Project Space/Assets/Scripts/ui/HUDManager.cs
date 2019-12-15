using UnityEngine;
using UnityEngine.UI;

public class HUDManager : MonoBehaviour
{
    [SerializeField]
    private Player player; // объект игрока

    private float health; // уровень здоровья

    [Header("Unity Stuff")]
    public Image healthBar;

    private void Update()
    {
        health = player.Health;

        healthBar.fillAmount = health / 100f;    
    }
}
