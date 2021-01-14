using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LetterButton : MonoBehaviour
{
    public bool ChallengeComplete = false;

    [SerializeField]
    private GameObject myChallenge;

    [SerializeField]
    private GameObject controller;

    [SerializeField]
    private GameObject timer;

    [SerializeField]
    private AudioSource clickaudio;

    private void OnMouseUpAsButton() // -----------------------------------------------------  AQUI COMECA O TURNO
    {

        clickaudio.Play();

        timer.GetComponent<Timer>().StartTurn = true;

        this.gameObject.GetComponent<SpriteRenderer>().enabled = true; // MOSTRA A LETRA

        ChallengeComplete = true; // DIZ QUE O DESAFIO JA FOI INICIADO

        controller.GetComponent<GameControler>().LockColliders(); //BLOQUEIA OS OUTROS BOTOES

        myChallenge.SetActive(true); //INICIA O DESAFIO
    }

    public void disableMyChalenge()
    {
        myChallenge.SetActive(false);
    }

}
