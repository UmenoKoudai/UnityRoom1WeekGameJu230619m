using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>�����̕����Ɠ��͂������������������肷��X�N���v�g</summary>
public class AnswerJudge : MonoBehaviour
{
    /// <summary>�������ǂ������肷��B���͂��m�肵���Ƃ��ɌĂ΂��</summary>
    public void Judgement(string input)
    {
        string answer = "���̖��̓����������Ă���";

        if(input == answer)
        {
            Debug.Log("�����Ă��");
        }
        else
        {
            Debug.Log("��������");
        }

    }

}
