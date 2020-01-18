using System.Collections.Generic;

using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class CheckClicks : MonoBehaviour
{
    // Normal raycasts do not work on UI elements, they require a special kind
    [SerializeField]
    GraphicRaycaster raycaster;

    public bool IsHud()
    {
        //Set up the new Pointer Event
        PointerEventData pointerData = new PointerEventData(EventSystem.current);
        List<RaycastResult> results = new List<RaycastResult>();

        //Raycast using the Graphics Raycaster and mouse click position
        pointerData.position = Input.mousePosition;
        this.raycaster.Raycast(pointerData, results);

        if(results.Count > 0)
        {
            return true;
        }

        return false;
    }

    public void ClickBtnExit()
    {
        DiscoveryManager.GetInstance().Close();
    }

    public void ClickDiscovery(Text name)
    {

        DiscoveryManager.GetInstance().OpenDiscovery(name.text);
    }
}