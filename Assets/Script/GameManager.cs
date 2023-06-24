using DG.Tweening;
using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [Header("�L�����̓���")]
    [SerializeField, Tooltip("�v���C���[�̃I�u�W�F�N�g")] Player _player;
    [SerializeField, Tooltip("�G�l�~�[�̃I�u�W�F�N�g")] Enemy _enemy;
    [SerializeField, Tooltip("�t�F�[�h�̃I�u�W�F�N�g")] Image _fade;
    [Header("�^�C�}�[����UI")]
    [SerializeField, Tooltip("���̉���N���A���Ă��邩�̃e�L�X�g")] Text _nowStageText;
    [SerializeField, Tooltip("�J�E���g�_�E���̃C���[�W")] Image _countDownImage;
    [SerializeField, Tooltip("�J�E���g�_�E���̃e�L�X�g")]Text _countDownText;
    [SerializeField, Tooltip("��������")] float _timeLimit;
    [SerializeField, Tooltip("���̃Q�[����")]GameState _state = GameState.Ready;
    [SerializeField, Tooltip("���̃Q�[����")] Text _questionText;
    [SerializeField] int _maxStage;
    KanjiData _questionData;
    SceneChanger _sceneChanger;
    event Action _nextStage;
    int _nowStage = 1;
    float _nowTime;

    public Action Next { get => _nextStage; set => _nextStage = value; }
    public GameState State { get => _state; set => _state = value; }

    void Start()
    {
        _fade.DOFade(0, 0.5f).OnComplete(() => { _state = GameState.Game;_fade.gameObject.SetActive(false); });
        _nowTime = _timeLimit;
        _questionData = FindObjectOfType<KanjiData>();
        _sceneChanger = FindObjectOfType<SceneChanger>();
    }

    void Update()
    {
        if (_state != GameState.Result)
        {
            _nowStageText.text = $"{_nowStage}/{_maxStage}";
            _countDownText.text = $"{_nowTime.ToString("F0")}";
            if (_state == GameState.Game)
            {
                _questionText.text = _questionData.NowKanji;
                _nowStageText.text = $"{_nowStage + 1}/{_maxStage}";
                _countDownImage.fillAmount -= Time.deltaTime / _timeLimit;
                _nowTime -= Time.deltaTime;
                if (_nowTime < 0)
                {
                    _state = GameState.Result;
                    _sceneChanger.ScneChange("Result");
                }
            }
        }
    }

    public void NextStageCallback(GameState state)
    {
        _nowTime = _timeLimit;
        _countDownImage.fillAmount = 1;
        _nowStage++;
        _questionData.KanjiYomiganaOnLoad();
        if (state == GameState.Damage)
        {
            _enemy.Damage(_player.Attack);
        }
        if (state == GameState.Next)
        {
            _state = GameState.Ready;
            _nextStage();
            StartCoroutine(NextStage());
        }
        if (state == GameState.BossStage)
        {
            _sceneChanger.ScneChange("Boss");
        }
        if(state == GameState.Result)
        {
            _state = GameState.Result;
            _sceneChanger.ScneChange("Result");
        }
    }

    IEnumerator NextStage()
    {
        _fade.gameObject.SetActive(true);
        yield return new WaitForSeconds(0.5f);
        _fade.DOFade(1, 1f);
        yield return new WaitForSeconds(1f);
        _fade.DOFade(0, 0.5f).OnComplete(() => _fade.gameObject.SetActive(false));
        yield return new WaitForSeconds(0.4f);
    }
    public enum GameState
    {
        Ready,
        Game,
        Result,
        Damage,
        Next,
        BossStage,
    }
}
