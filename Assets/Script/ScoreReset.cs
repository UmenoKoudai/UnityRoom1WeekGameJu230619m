using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreReset : MonoBehaviour
{
    [SerializeField] Text _scoreText;
    [SerializeField] Text _scoreBackText;
    int _currentScore;
    private void Start()
    {
        _currentScore = Result.Instance.CurrentScore;
        if (_scoreText)
        {
            _scoreText.text = $"ê≥âêîÅF{Result.Instance.CurrentScore.ToString("D2")}";
            _scoreBackText.text = $"ê≥âêîÅF{Result.Instance.CurrentScore.ToString("D2")}";
        }
        Result.Instance.CurrentScore = 0;
    }
    public void Ranking()
    {
        naichilab.RankingLoader.Instance.SendScoreAndShowRanking(_currentScore);
    }
}
