using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChoiceScript : MonoBehaviour
{
    public Text nameText;
    public GameObject DialogueTextBox;
    private string sentence;

    private void Start()
    {
        nameText.text = "Киллак";
    }

    public void ChoiceOption1()
    {
        sentence = "Вижу ты не очень разговорчивый. А по кораблю вообще непонятно как ты " +
            "смог добраться до нас. Два часа назад мы заметили всплеск энергии возле станции Омрил. " +
            "А потом вдруг из ниоткуда появился ты. Наши ученые долго изучали эту кротовую нору, " +
            "но никто и представить не мог, что она ведет в другой сектор." +
            " Мало того что ты прошел через нее, так еще и выжил. На Омриле до сих пор творится хаос. " +
            " Тебя ждет аудиенция с НИМ. Кстати, как зовут тебя?";

        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence));
    }

    public void ChoiceOption2()
    {
        sentence = "Что?... Неужели... Эмм...Мы раса прирокдитов, входим в конклав Пяти. Ты.. должен был слышать про нас." +
            " Ведь именно ваша раса поспособствовала контакту нашего конклава с конлавом Древних." +
            " Раз ты ничего не знаешь, варианта два: ты потерял память во время прохождения через кротовую нору или совершил временной прыжок еще до контакта наших цивилизаций, что может значить только одно..." +
            " О Великий КРЕГАЛ!!! Так это правда...";

        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence));
    }

    public void ChoiceOption3()
    {
        sentence = "Про товары тут";

        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence));
    }

    public void ChoiceOption4()
    {
        
        sentence = "Ты наверное потратил все свои силы, не буду  доставать тебя расспросами. " +
        "Мы уже выделили комнату для тебя, отдохни - я зайду к тебе позже!";

        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence));
    }

    IEnumerator TypeSentence(string sentence)
    {
        DialogueTextBox.GetComponent<Text>().text = "";
        foreach (char letter in sentence.ToCharArray())
        {
            DialogueTextBox.GetComponent<Text>().text += letter;
            yield return null;
        }
    }

}
