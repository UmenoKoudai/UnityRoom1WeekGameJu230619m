using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using static AudioManager.BgmSoundData;
using static AudioManager;

public class Enemy : MonoBehaviour
{
    [SerializeField, Tooltip("次に登場するエネミーの画像")] Sprite[] _enemyImages;
    [SerializeField, Tooltip("エネミー撃破のエフェクト")] GameObject _effect;
    [SerializeField] Slider _enemyHpBar;
    [SerializeField] int[] _enemyHp;
    [SerializeField] EnemyType _type = EnemyType.Normal;
    GameManager _gameManager;
    public int _nowEnemy;
    int _nowHp;
    int i;
    void Start()
    {
        _gameManager = FindObjectOfType<GameManager>();
        _gameManager.Next += NextStage;
        GetComponent<SpriteRenderer>().sprite = _enemyImages[_nowEnemy];
        _nowHp = _enemyHp[_nowEnemy];
        _enemyHpBar.maxValue = _nowHp;
        if (_type == EnemyType.Normal)
        {
            AudioManager.Instance.PlayBGM(BGM.Slime);
        }
        if (_type == EnemyType.Boss)
        {
            AudioManager.Instance.PlayBGM(BGM.Boss);
        }
    }

    void Update()
    {
        _enemyHpBar.DOValue(_nowHp, 1f);
    }

    public void NextStage()
    {
        _nowEnemy++;
        StartCoroutine(Cinematic());
    }

    public void Damage(int damage)
    {
        _nowHp -= damage;
        Instantiate(_effect, transform.position, transform.rotation);
        AudioManager.Instance.PlaySE(SeSoundData.SE.Hit);
        if (_nowHp <= 0)
        {
            if (_type == EnemyType.Normal)
            {
                if (_nowEnemy == _enemyImages.Length - 1)
                {
                    _gameManager.NextStageCallback(GameManager.GameState.BossStage);
                }
                else
                {
                    _gameManager.NextStageCallback(GameManager.GameState.Next);
                }
            }
            if(_type == EnemyType.Boss)
            {
                _gameManager.NextStageCallback(GameManager.GameState.Result);
            }
        }
    }
    IEnumerator Cinematic()
    { 
        GetComponent<Animator>().Play("Die");
        yield return new WaitForSeconds(1.5f);
        _nowHp = _enemyHp[_nowEnemy];
        _enemyHpBar.maxValue = _nowHp;
        GetComponent<SpriteRenderer>().color = Color.white;
        GetComponent<SpriteRenderer>().sprite = _enemyImages[_nowEnemy];
        AudioManager.Instance.PlayBGM(BGM.Golem);
    }
    enum EnemyType
    {
        Normal,
        Boss,
    }
}
