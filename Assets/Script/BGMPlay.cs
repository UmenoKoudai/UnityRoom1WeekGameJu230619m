using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BGMPlay : MonoBehaviour
{
    void Start()
    {
        AudioManager.Instance.PlayBGM(AudioManager.BgmSoundData.BGM.Title);
    }
}
