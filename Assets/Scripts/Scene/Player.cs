using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public Text Nametext;
    public List<Charater> CharaterList = new List<Charater>();
    public CharacterType characterType;
    public Animator animator;

    private void Start()
    {
        Nametext.text = PlayerPrefs.GetString("T");
        characterType = (CharacterType)PlayerPrefs.GetInt("C");
        animator.runtimeAnimatorController = CharaterList[(int)characterType].AnimatorController;
    }

    
    
}
