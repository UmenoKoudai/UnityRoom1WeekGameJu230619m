using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>�����̕����Ɠ��͂������������������肷��X�N���v�g</summary>
public class AnswerJudge : MonoBehaviour
{
    //[SerializeField] private string _kanjiData = "�}�[�W������ς��Ă�";

    [Tooltip("���̖��̓���")] private string _answer = default;

    private void Start()
    {
        //�ŏ��̖��̓��������Ă���
        _answer = "";
    }

    /// <summary>�������ǂ������肷��B���͂��m�肵���Ƃ��ɌĂ΂��</summary>
    public void Judgement(string input)
    {

        if(input == _answer)
        {
            Debug.Log("�����Ă��");
        }
        else
        {
            Debug.Log("��������");
        }

    }

}
