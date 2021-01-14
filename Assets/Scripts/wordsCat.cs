using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wordsCat : MonoBehaviour
{
    [SerializeField]
    private GameObject[] words = new GameObject[10];

    public int CatPoints;

    private void Start()
    {
        StartCoroutine(DisableAnim());
    }


    IEnumerator DisableAnim()
    {
        yield return new WaitForSeconds(1.2f);
        this.gameObject.GetComponent<Animator>().enabled = false;
    }

    public void VerifyPoints()
    {
        for (int i = 0; i < words.Length; i++)
        {
            if(words[i].GetComponent<DragAndDrop>().onTable == true) //ESSAS PALAVRAS ESTAO NA TABELA
            {
                words[i].GetComponent<individualWords>().EnableFlag();

                CatPoints += words[i].GetComponent<individualWords>().ImCorrect;
            }
        }
        
    }

}
