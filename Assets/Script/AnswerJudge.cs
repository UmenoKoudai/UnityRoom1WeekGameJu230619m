using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>�����̕����Ɠ��͂������������������肷��X�N���v�g</summary>
public class AnswerJudge : MonoBehaviour
{
    /// <summary>�������ǂ������肷��B���͂��m�肵���Ƃ��ɌĂ΂��</summary>
    public void Judgement(string input)
    {
        string answer = FindObjectOfType<KanjiData>().NowAnswer;
        Debug.Log($"���̓��� = {answer}");

        if(input == answer)
        {
            Debug.Log("�����Ă��");
            FindObjectOfType<GameManager>().NextStageCallback(GameManager.GameState.Damage);
        }
        else
        {
            Debug.Log("��������");
        }

    }

}
