using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [Header("キャラの動きに")]
    [SerializeField, Tooltip("プレイヤーのオブジェクト")] GameObject _player;
    [SerializeField, Tooltip("エネミーのオブジェクト")] GameObject _enemy;
    [SerializeField, Tooltip("フェードのオブジェクト")] Image _fade;
    [SerializeField, Tooltip("次に登場するエネミーの画像")] Sprite[] _enemyImages;
    [SerializeField, Tooltip("敵を倒した後にプレイヤーが出ていくポジション")] Transform _endPosition;
    [SerializeField, Tooltip("プレイヤーが入ってくる演出のポジション")] Transform _startPosition;
    [SerializeField, Tooltip("エネミー撃破のエフェクト")] GameObject _effect;
    [Header("タイマー等のUI")]
    [SerializeField, Tooltip("今の何回クリアしているかのテキスト")] Text _nowStageText;
    [SerializeField, Tooltip("カウントダウンのイメージ")] Image _countDownImage;
    [SerializeField, Tooltip("カウントダウンのテキスト")]Text _countDownText;
    [SerializeField, Tooltip("制限時間")] float _timeLimit;
    [SerializeField, Tooltip("今のゲーム状況")]GameState _state = GameState.Ready;
    Vector3 _basePosition;
    int _maxStage;
    int _nowStage;
    float _nowTime;

    void Start()
    {
        _basePosition = _player.transform.position;
        _enemy.GetComponent<SpriteRenderer>().sprite = _enemyImages[_nowStage];
        _fade.DOFade(0, 0.5f).OnComplete(() =>  _state = GameState.Game);
        _maxStage = _enemyImages.Length;
        _nowTime = _timeLimit;
    }

    void Update()
    {
        _nowStageText.text = $"{_nowStage + 1}/{_maxStage}";
        _countDownText.text = $"{_nowTime.ToString("F0")}";
        if (_state == GameState.Game)
        {
            _nowStageText.text = $"{_nowStage + 1}/{_maxStage}";
            _countDownImage.fillAmount -= Time.deltaTime / _timeLimit;
            _nowTime -= Time.deltaTime;
            if (Input.GetButtonDown("Fire1"))
            {
                _nowTime = _timeLimit;
                _countDownImage.fillAmount = 1;
                if (_nowStage + 1 == _maxStage)
                {
                    SceneManager.LoadScene("BossStage");
                }
                else
                {
                    Instantiate(_effect, _enemy.transform.position, transform.rotation);
                    _state = GameState.Ready;
                    _nowStage++;
                    NextStageCallback();
                }
            }
        }
    }

    public void NextStageCallback()
    {
        StartCoroutine(NextStage());
    }

    IEnumerator NextStage()
    {
        _enemy.GetComponent<Animator>().Play("Die");
        yield return new WaitForSeconds(0.5f);
        _player.transform.DOMoveX(_endPosition.position.x, 1f);
        _fade.DOFade(1, 1f);
        yield return new WaitForSeconds(1f);
        _enemy.GetComponent<SpriteRenderer>().color = Color.white;
        _player.transform.position = _startPosition.position;
        _enemy.GetComponent<SpriteRenderer>().sprite = _enemyImages[_nowStage];
        _fade.DOFade(0, 0.5f);
        yield return new WaitForSeconds(0.4f);
        _player.transform.DOMoveX(_basePosition.x, 1f).OnComplete(() => _state = GameState.Game);
    }
    public enum GameState
    {
        Ready,
        Game,
        GameOver,
    }
}
