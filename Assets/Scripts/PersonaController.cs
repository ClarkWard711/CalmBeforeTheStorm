using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PersonaController : MonoBehaviour
{
    public static PersonaController Instance;
    public Text description;
    public Sprite[] PersonaSprites;
    public List<int> personaAmountList;
    public List<GameObject> PersonaList;
    private void Awake()
    {
        if (Instance == null) 
        {
            Instance = this;
        }
        personaAmountList.Clear();

        for (int i = 0; i < 5; i++)
        {
            personaAmountList.Add(50);
        }

        for (int i = 0; i < 5; i++)
        {
            //Debug.Log(i);
            PersonaList[i].GetComponent<Persona>().id = i;
            PersonaList[i].GetComponent<Persona>().blank.sprite = PersonaSprites[PersonaList[i].GetComponent<Persona>().id];
            PersonaList[i].GetComponent<Persona>().back.sprite = PersonaSprites[PersonaList[i].GetComponent<Persona>().id];
            PersonaList[i].GetComponent<Persona>().blank.fillAmount = personaAmountList[PersonaList[i].GetComponent<Persona>().id] / 100f;
        }
    }

    public void ChangeAmount()
    {
        for (int i = 0; i < 5; i++)
        {
            PersonaList[i].GetComponent<Persona>().blank.fillAmount = Mathf.Max(0f, personaAmountList[PersonaList[i].GetComponent<Persona>().id] / 100f);
            //Debug.Log(personaAmountList[PersonaList[i].GetComponent<Persona>().id] / 100f);
        }
    }

    public void ChangeAvatar()
    {
        for (int i = 0; i < 5; i++)
        {
            PersonaList[i].GetComponent<Persona>().back.sprite = PersonaSprites[PersonaList[i].GetComponent<Persona>().id];
            PersonaList[i].GetComponent<Persona>().blank.sprite = PersonaSprites[PersonaList[i].GetComponent<Persona>().id];
        }
    }
}
