using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Timer : MonoBehaviour
{
    private Image fillImg;

    [SerializeField]
    private float maxTime;

    public float currentTime = 0;

    public bool StartTurn;

    [SerializeField]
    private GameObject table;

    public bool tableComplete = false;

    private void Start()
    {
        fillImg = this.GetComponent<Image>();
    }


    private void Update()
    {
       

        if (StartTurn)
        {
            if (currentTime < maxTime && tableComplete == false)
            {
                currentTime += Time.deltaTime;

                fillImg.fillAmount = (currentTime / maxTime);

            }
            else//acabou o tempo
            {
                if (tableComplete == false)
                {
                    table.GetComponent<boxtable>().StopTable();
                }

                currentTime = 0;

                fillImg.fillAmount = (currentTime / maxTime);

                tableComplete = false;
                StartTurn = false;
            }
        }

    }





}
