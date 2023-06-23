using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>正解の文字と入力した文字が同じか判定するスクリプト</summary>
public class AnswerJudge : MonoBehaviour
{
    /// <summary>正解かどうか判定する。入力が確定したときに呼ばれる</summary>
    public void Judgement(string input)
    {
        string answer = "今の問題の答えを持ってくる";

        if(input == answer)
        {
            Debug.Log("あってるよ");
        }
        else
        {
            Debug.Log("ちがうよ");
        }

    }

}
