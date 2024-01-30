using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public enum CharacterType
{
    Character_1,
    Character_2,
    Character_3,
    Character_4

}

[System.Serializable]

public class Charater
{
    public CharacterType CharacterType;
    public Sprite CharacterSprite;
    public RuntimeAnimatorController AnimatorController;
}

public class NextScene : MonoBehaviour
{
    public List<Charater> CharaterList = new List<Charater>();

    //public Animator PlayerAnimator;
    //public Text PlayerName;

    [SerializeField] private Image characterSprite;
    [SerializeField] private InputField inputField;
    [SerializeField] private GameObject information;
    [SerializeField] private GameObject selectCharacter;

    private CharacterType characterType;


    public void OnClickCharater()
    {
        information.SetActive(false);
        selectCharacter.SetActive(true);
    }

    public void OnClickSelectCharacter(int index)
    {
        characterType = (CharacterType)index;
        Charater character = CharaterList.Find(item => item.CharacterType == characterType);

        characterSprite.sprite = character.CharacterSprite;
        //characterSprite.SetNativeSize();

        selectCharacter.SetActive(false);
        information.SetActive(true);
    }

    /*public void SetChracter(CharacterType characterType, string name)
    {
        var character = CharaterList.Find(item => item.CharacterType == characterType);

        //PlayerAnimator.runtimeAnimatorController = character.AnimatorController;
        //PlayerName.text = name;
    }*/

    public void OnClickJoin()
    {
        if (2 >= inputField.text.Length || inputField.text.Length >= 10)
        {
            return;
        }

        //SetChracter(characterType, inputField.text);
        string inputText = inputField.text;


        PlayerPrefs.SetString("T",inputText);
        PlayerPrefs.SetInt("C",(int)characterType);
        

        SceneManager.LoadScene("StartingLevel");

    }
}
