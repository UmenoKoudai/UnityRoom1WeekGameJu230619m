using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioTest : MonoBehaviour
{
    [SerializeField] AudioManager _audio;
    void Start()
    {
        _audio.PlayBGM(AudioManager.BgmSoundData.BGM.Normal);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.K))
        {
            _audio.PlaySE(AudioManager.SeSoundData.SE.Click);
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            _audio.PlayBGM(AudioManager.BgmSoundData.BGM.Boss);
        }
        if (Input.GetKeyDown(KeyCode.A)) { _audio.PlayBGM(AudioManager.BgmSoundData.BGM.Normal); }
        if (Input.GetKeyDown(KeyCode.L)) { _audio.PlaySE(AudioManager.SeSoundData.SE.Move); }
        if (Input.GetKeyDown(KeyCode.J)) { _audio.PlaySE(AudioManager.SeSoundData.SE.Hit); }
    }
}
