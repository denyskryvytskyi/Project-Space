using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueWindowTrigger : MonoBehaviour
{
    [SerializeField]
    private GameObject dialogueWinPrefab; // Макет окна диалога

    //public void StartDialogueWindow()
    //{
    //    Transform dialogueWin = Instantiate(dialogueWinPrefab);
    //    FindObjectOfType<DialogManager>().dialogueWin = dialogueWin;
    //}

    private void OnTriggerEnter2D(Collider2D other)
    {
        dialogueWinPrefab.SetActive(true);
        FindObjectOfType<ShipMovement>()._canMove = false; // игрок не может двигаться

        //if(other.gameObject.tag == "Player") // Если с планетой(станицей, другое космическое тело) взаимодействует игрок, то показываем окно диалога
        //{
        //    Debug.Log("Игрок прибыл.");
        //    FindObjectOfType<ShipMovement>()._canMove = false; // игрок не может двигаться
        //    StartDialogueWindow();
        //}

    }
}
