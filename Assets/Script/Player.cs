using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using static GameManager;

public class Player : MonoBehaviour
{
    [SerializeField, Tooltip("敵を倒した後にプレイヤーが出ていくポジション")] Transform _endPosition;
    [SerializeField, Tooltip("プレイヤーが入ってくる演出のポジション")] Transform _startPosition;
    [SerializeField] int _playerAttack;
    Vector3 _basePosition;
    GameManager _gameManager;

    public int Attack => _playerAttack;
    private void Start()
    {
        _gameManager = FindObjectOfType<GameManager>();
        _gameManager.Next += NextStage;
        _basePosition = transform.position;
    }

    public void NextStage()
    {
        StartCoroutine(Cinematic());
    }

    IEnumerator Cinematic()
    {
        yield return new WaitForSeconds(0.5f);
        transform.DOMoveX(_endPosition.position.x, 1f);
        AudioManager.Instance.PlaySE(AudioManager.SeSoundData.SE.Move);
        yield return new WaitForSeconds(1f);
        transform.position = _startPosition.position;
        yield return new WaitForSeconds(0.4f);
        transform.DOMoveX(_basePosition.x, 1f).OnComplete(() => _gameManager.State = GameState.Game);
    }
}
