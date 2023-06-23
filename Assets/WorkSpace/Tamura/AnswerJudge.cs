using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>正解の文字と入力した文字が同じか判定するスクリプト</summary>
public class AnswerJudge : MonoBehaviour
{
    //[SerializeField] private string _kanjiData = "マージしたら変えてね";

    [Tooltip("今の問題の答え")] private string _answer = default;

    private void Start()
    {
        //最初の問題の答え持ってくる
        _answer = "";
    }

    /// <summary>正解かどうか判定する。入力が確定したときに呼ばれる</summary>
    public void Judgement(string input)
    {

        if(input == _answer)
        {
            Debug.Log("あってるよ");
        }
        else
        {
            Debug.Log("ちがうよ");
        }

    }

}
