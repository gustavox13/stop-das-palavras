using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class individualWords : MonoBehaviour
{
    public int ImCorrect;

    [SerializeField]
    private GameObject flag;

    public void EnableFlag()
    {
        flag.SetActive(true);
        
    }
}
