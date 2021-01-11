using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueController : MonoBehaviour
{
    [SerializeField]
    private GameObject nextDialogue;
    public void OnClickNextDialogItem()
    {
        gameObject.SetActive(false);
        nextDialogue.SetActive(true);
    }
}
