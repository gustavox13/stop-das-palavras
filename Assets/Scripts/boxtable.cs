using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boxtable : MonoBehaviour
{
    public float CurrentWordsOnTable = 0;  //num de palavras na tabela

    private GameObject currentWordsCat;

    private int currentpoints;

    [SerializeField]
    private GameObject controller;

    [SerializeField]
    private GameObject timer;

    [SerializeField]
    private GameObject stophand;

    public void AddWord()
    {
        if (CurrentWordsOnTable < 4)//4 eh o numero maximo ao preencher a tabela com 5 palavras
        {
            CurrentWordsOnTable += 1;
        }
        else //---------------------------------------------- TABELA PREENCHIDA ------------------  
        {
            timer.GetComponent<Timer>().tableComplete = true;
            StopTable();
        }

    }

    public void StopTable()
    {
        stophand.SetActive(true);

        this.gameObject.GetComponent<BoxCollider2D>().enabled = false; //desativa o colider da tabela

        currentWordsCat = GameObject.FindGameObjectWithTag("categoria"); //procura qual categoria esta ativa na tela no momento

        currentWordsCat.GetComponent<wordsCat>().VerifyPoints(); //verifica os pontos da tabela

        currentpoints = currentWordsCat.GetComponent<wordsCat>().CatPoints; //pega os pontos da categoria ativa

        StartCoroutine(CountToDisableChallenge()); // pausa antes de iniciar o prox round
    }

    IEnumerator CountToDisableChallenge()
    {
        yield return new WaitForSeconds(1.5f);

        stophand.SetActive(false);

        yield return new WaitForSeconds(2.5f);

        controller.GetComponent<GameControler>().ManagePoints(currentpoints);//joga os pontos pro game controller somar os pontos

        currentWordsCat.SetActive(false);
    }



    public void ResetCount()
    {
        //currentWordsCat = null;
        CurrentWordsOnTable = 0;
        this.gameObject.GetComponent<BoxCollider2D>().enabled = true;
    }
}
