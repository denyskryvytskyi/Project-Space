using UnityEngine;
using UnityEngine.UI;

public class HealthBarController : MonoBehaviour
{
    public float healthMax = 3f;

    public Image bar;

    public void DecreaseHealth(float newHealth)
    {
        Debug.Log("Result" + newHealth / healthMax);
        bar.fillAmount = newHealth / healthMax;
    }
}