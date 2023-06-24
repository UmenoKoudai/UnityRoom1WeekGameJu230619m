using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>正解の文字と入力した文字が同じか判定するスクリプト</summary>
public class AnswerJudge : MonoBehaviour
{
    /// <summary>正解かどうか判定する。入力が確定したときに呼ばれる</summary>
    public void Judgement(string input)
    {
        string answer = FindObjectOfType<KanjiData>().NowAnswer;
        Debug.Log($"今の答え = {answer}");

        if(input == answer)
        {
            Debug.Log("あってるよ");
            FindObjectOfType<GameManager>().NextStageCallback(GameManager.GameState.Damage);
        }
        else
        {
            Debug.Log("ちがうよ");
        }

    }

}
