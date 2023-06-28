using UnityEngine;
using UnityEngine.UI;

/// <summary> InputField�ɓ��͂��ꂽ������PlayerInput���v���p�e�B�Ɋi�[����N���X</summary>
public class TextSubmit : MonoBehaviour
{
    [SerializeField, Tooltip("InputField�̎q�I�u�W�F�N�g�ɂ���Text")]
    Text _inputText = default;
    [Tooltip("�v���C���[�̓��͕���")] string _playerInput = "";
    [Tooltip("�v���C���[�̓��͕������i�[����v���p�e�B")] public string PlayerInput { get => _playerInput; }
    InputField _inputField;

    private void Start()
    {
        _inputField = GetComponent<InputField>();
        _inputField.ActivateInputField();
        _inputField.contentType = InputField.ContentType.Standard;
        _inputField.inputType = InputField.InputType.Standard;
    }
    //public void Update()
    //{
    //    if(Input.GetButtonDown("Submit"))
    //    {
    //        Submit();
    //    }
    //}
    /// <summary>�v���C���[�̓��͌��Enter�L�[�ŌĂ΂��悤��InputField�̃C���X�y�N�^�[�Ŋ��蓖�Ă�</summary>
    public void Submit()
    {
        _playerInput = _inputText.text.Trim(); //������O��̕s�v�ȋ󔒂��폜
        Debug.Log(_playerInput);
        _inputField.text = "";
        _inputField.ActivateInputField();
        FindObjectOfType<AnswerJudge>().Judgement(_playerInput);
        /// �����̔�����s���N���X����PlayerInput�v���p�e�B���Q�Ƃ��� or
        /// �����ŕ����̔�����s���N���X�̃��\�b�h���Ă�
    }

}
