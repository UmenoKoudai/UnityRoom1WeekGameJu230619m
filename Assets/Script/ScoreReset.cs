using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreReset : MonoBehaviour
{
    [SerializeField] Text _scoreText;
    [SerializeField] Text _scoreBackText;
    private void Start()
    {
        if (_scoreText)
        {
            _scoreText.text = $"³‰ğ”F{Result.Instance.CurrentScore.ToString("D2")}";
            _scoreBackText.text = $"³‰ğ”F{Result.Instance.CurrentScore.ToString("D2")}";
        }
        Result.Instance.CurrentScore = 0;
    }
}
