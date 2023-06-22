using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
public class KanjiData : MonoBehaviour
{
    [Header("確認用")]
    /// <summary>今問題に出されている漢字</summary>
    [SerializeField] string _kanji;
    /// <summary>今問題に出されている漢字の答えとなる読み仮名</summary>
    [SerializeField] string _yomigana;
    /// <summary>漢字読み仮名のCSV形式のテーブル</summary>
    [SerializeField, Header("漢字読み仮名のCSVTextAseet")] TextAsset[] _kanjiAnswerTable;
    /// <summary>漢字と正解となる読み仮名が入っているList</summary>
    List<KanjiYomiganaData> _kanjiYomiganaData = new List<KanjiYomiganaData>();
    /// <summary>今問題対象になっているListのIndex</summary>
    int _index = 0;

    /// <summary>今問題に出されている漢字</summary>
    public string NowKanji => _kanji;
    /// <summary>答えとなる読み仮名</summary>
    public string NowAnswer => _yomigana;
    void Awake()
    {
        //テーブルをListに保存
        AnswerDataLoad();
        //最初に漢字と読み仮名を更新
        KanjiYomiganaOnLoad();
    }

    /// <summary>現在の問題となる漢字と正解の読み仮名の変数の値を更新するメソッド</summary>
    public void KanjiYomiganaOnLoad()
    {
        if(_index == _kanjiYomiganaData.Count)
        {
            Debug.Log("問題となる漢字がないです");
        }
        else
        {
            _kanji = _kanjiYomiganaData[_index].Kanji;
            _yomigana = _kanjiYomiganaData[_index].Yomigana;
            _index++;
        }
    }

    /// <summary>CSVテーブルの中のデータをすべてListに入れる</summary>
    void AnswerDataLoad()
    {
        for (int i = 0; i < _kanjiAnswerTable.Length; i++)
        {
            System.IO.StringReader sr = new System.IO.StringReader(_kanjiAnswerTable[i].text);

            while(true)
            {
                string line = sr.ReadLine();
                //lineがnullまたは""だった場合
                if (string.IsNullOrEmpty(line))
                {
                    break;
                }

                string[] data = line.Split(',');
                _kanjiYomiganaData.Add(new KanjiYomiganaData(data[0], data[1]));
            }
        }
    }
}

public struct KanjiYomiganaData
{
    /// <summary>問題となる漢字</summary>
    public string Kanji;
    /// <summary>問題となる漢字の正解の読み仮名</summary>
    public string Yomigana;

    /// <summary>問題の漢字と正解となる読み仮名を格納する</summary>
    /// <param name="kanji">問題としてだす漢字</param>
    /// <param name="yomigana">正解となる読み仮名</param>
    public KanjiYomiganaData(string kanji, string yomigana)
    {
        this.Kanji = kanji;
        this.Yomigana = yomigana;
    }
}
