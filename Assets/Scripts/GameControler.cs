using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameControler : MonoBehaviour
{
    [SerializeField]
    private GameObject[] letters = new GameObject[6];

    private Vector3[] oldPosition = new Vector3[12];

    [SerializeField]
    private GameObject pacoca;

    private Animator pacocaAnim;

    [SerializeField]
    private GameObject tutorial;

    

    [SerializeField]
    private GameObject finalScreen;

    [SerializeField]
    private GameObject table;

    public int totalPoints;

    private int currentTurn;

    private void Awake()
    {
        Shuffleletters();
    }

    private void Start()
    {
        pacocaAnim = pacoca.GetComponent<Animator>();

        LockColliders();

    }

    public void CloseTutoAndStart() //FECHA TUTORIAL E INICIA GAME
    {
        tutorial.SetActive(false);
        StartTurn();
    }

    private void StartTurn() //INICIA TURNO
    {
        UnlockColliders();
    }

    public void ManagePoints(int currentPoints)
    {
     

        if (currentTurn < 5)
        {
            currentTurn++;
            totalPoints += currentPoints;

            Debug.Log("pontos atuais: " + totalPoints);


            //UnlockColliders();
            table.GetComponent<boxtable>().ResetCount();

            StartTurn();

        }
        else
        {
            totalPoints += currentPoints;

            finalScreen.SetActive(true);
        }
    }





    public void LockColliders()
    {
        for (int i = 0; i < letters.Length; i++)
        {
            letters[i].GetComponent<BoxCollider2D>().enabled = false;
        }
    }

    public void UnlockColliders()
    {
        for (int i = 0; i < letters.Length; i++)
        {
            if (letters[i].GetComponent<LetterButton>().ChallengeComplete == false)
            {
                letters[i].GetComponent<BoxCollider2D>().enabled = true;
            }
        }
    }


    private void Shuffleletters()     //EMBARALHAR FRASES
    {

        //SALVA POSICAO ANTIGA
        for (int i = 0; i < letters.Length; i++)
        {
            oldPosition[i] = new Vector3(letters[i].transform.position.x,
                                         letters[i].transform.position.y,
                                         letters[i].transform.position.z);
        }

        //EMBARALHA ARRAY
        for (int i = 0; i < letters.Length; i++)
        {
            GameObject obj = letters[i];
            int randomizeArray = Random.Range(0, i);
            letters[i] = letters[randomizeArray];
            letters[randomizeArray] = obj;
        }


        //ADD NOVAS POSICOES
        for (int i = 0; i < letters.Length; i++)
        {
            letters[i].transform.position = oldPosition[i];
        }


    }




}
