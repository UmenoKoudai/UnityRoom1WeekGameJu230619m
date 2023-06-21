using UnityEngine;
using UnityEngine.UI;

/// <summary> InputFieldに入力された文字をPlayerInputをプロパティに格納するクラス</summary>
public class TextSubmit : MonoBehaviour
{
    [SerializeField, Tooltip("InputFieldの子オブジェクトにあるText")]
    Text _inputText = default;
    [Tooltip("プレイヤーの入力文字")] string _playerInput = "";
    [Tooltip("プレイヤーの入力文字を格納するプロパティ")] public string PlayerInput { get => _playerInput; }

    /// <summary>プレイヤーの入力後にEnterキーで呼ばれるようにInputFieldのインスペクターで割り当てる</summary>
    public void Submit()
    {
        _playerInput = _inputText.text.Trim(); //文字列前後の不要な空白を削除
        Debug.Log(_playerInput);
        /// 文字の判定を行うクラスからPlayerInputプロパティを参照する or
        /// ここで文字の判定を行うクラスのメソッドを呼ぶ
    }

}
