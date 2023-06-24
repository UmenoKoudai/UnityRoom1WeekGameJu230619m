using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Result : MonoBehaviour
{
    static Result _instance;
    int _currentScore;

    public int CurrentScore { get => _currentScore; set => _currentScore = value; }
    public static Result Instance
    {
        get
        {
            if(_instance == null)
            {
                _instance = FindObjectOfType<Result>();
            }
            return _instance;
        }
    }

    private void Awake()
    {
        if(FindObjectsOfType<Result>().Length > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }
}
