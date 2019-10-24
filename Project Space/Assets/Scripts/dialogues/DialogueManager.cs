using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    public Text nameText;
    public Text dialogueText;

    //public Animator animator;

    [SerializeField]
    private GameObject dialogueWinPrefab; // Макет окна диалога

    //public Transform dialogueWin; // Макет окна диалога

    public Queue<string> sentences;

    void SetSentencesMemory()
    {
        if (sentences != null)
        {
            sentences.Clear();
            Debug.Log("Фразы перезаписаны");
        }
        else
        {
            sentences = new Queue<string>();
            Debug.Log("Выделено место для фраз");
        }
    }

    public void StartDialogue(Dialogue dialogue)
    {
        //// присваиваем все необходимое из созданного на лету DialogueCanvas: name, dialogue, animator
        //nameText = dialogueWin.Find("DialogueBox").transform.Find("NameText").GetComponent<Text>();
        //dialogueText = dialogueWin.Find("DialogueBox").transform.Find("DialogueText").GetComponent<Text>();
        //animator = dialogueWin.Find("DialogueBox").gameObject.GetComponent<Animator>();
        //animator.SetBool("IsOpen", true);

        nameText.text = dialogue.name;
        SetSentencesMemory();



        foreach (string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);
            Debug.Log("Фраза добавлена.");
        }

        
        DisplayNextSentence();
    }

    public void DisplayNextSentence()
    {
        Debug.Log("Следующая фраза.");
        Debug.Log("Кол-во фраз: " + sentences.Count);
        if(sentences.Count == 0)
        {
            EndDialogue();
            return;
        }

        string sentence = sentences.Dequeue();
        dialogueText.text = sentence;
        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence));
    }

    IEnumerator TypeSentence(string sentence)
    {
        dialogueText.text = "";
        foreach(char letter in sentence.ToCharArray())
        {
            dialogueText.text += letter;
            yield return null;
        }
    }
    void EndDialogue()
    {
        Debug.Log("Конец диалога.");
        //animator.SetBool("IsOpen", false);
        //dialogueWinPrefab.SetActive(false);
        //FindObjectOfType<ShipMovement>()._canMove = true; // Игрок снова может двигаться
    }
}
