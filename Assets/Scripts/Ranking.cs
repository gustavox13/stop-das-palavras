using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Ranking : MonoBehaviour
{
    [SerializeField]
    private GameObject star1;
    [SerializeField]
    private GameObject star2;
    [SerializeField]
    private GameObject star3;
    [SerializeField]
    private GameObject gameControler;

    private int score;

    private void Start()
    {
        score = gameControler.GetComponent<GameControler>().totalPoints;

        StartCoroutine(ShowStars());
    }

    IEnumerator ShowStars()
    {
        if(score >= 30)
        {
            
            star1.SetActive(true);

            yield return new WaitForSeconds(0.4f);

            star2.SetActive(true);

            yield return new WaitForSeconds(0.4f);

            star3.SetActive(true);

        } else if(score < 30  && score >= 10)
        {
            star1.SetActive(true);

            yield return new WaitForSeconds(0.4f);

            star2.SetActive(true);
        }
        else if(score < 10 && score > 1)
        {
            star2.SetActive(true);
        }
        

    }


    public void BackToMenu()
    {
        SceneManager.LoadScene("Menu");
    }

}
