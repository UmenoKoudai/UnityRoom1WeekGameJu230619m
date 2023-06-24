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
            _scoreText.text = $"正解数：{Result.Instance.CurrentScore.ToString("D2")}";
            _scoreBackText.text = $"正解数：{Result.Instance.CurrentScore.ToString("D2")}";
        }
        Result.Instance.CurrentScore = 0;
    }
}
