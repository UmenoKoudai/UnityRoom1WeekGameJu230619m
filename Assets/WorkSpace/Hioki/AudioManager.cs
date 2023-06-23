using UnityEngine;
using static GameManager;


//�V���O���g��
public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;

    [Header("AudioSource")]
    [Tooltip("BGM���Đ�����AudioSource")]
    [SerializeField] AudioSource _audioBgm;
    [Tooltip("SE���Đ�����AudioSource")]
    [SerializeField] AudioSource _audioSe;

    [Space]

    [Header("AudioClip")]
    [Tooltip("BGM")]
    [SerializeField] BgmSoundData[] _bgmSoundDatas;
    [Tooltip("SE")]
    [SerializeField] SeSoundData[] _seSoundDatas;

    [SerializeField]
    float _masterVolume = 1;
    [SerializeField]
    float _bgmMasterVolume = 1;
    [SerializeField]
    float _seMasterVolume = 1;

    #region�@�V���O���g��
    public static AudioManager Instance
    {
        get
        {
            if (!instance)
            {
                SetupInstance();
            }

            return instance;
        }
    }

    void Awake()
    {
        if (!instance)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
            return;
        }

        DontDestroyOnLoad(gameObject);
    }

    static void SetupInstance()
    {
        instance = FindObjectOfType<AudioManager>();

        if (!instance)
        {
            GameObject go = new GameObject();
            instance = go.AddComponent<AudioManager>();
            go.name = instance.GetType().Name;
            DontDestroyOnLoad(go);
        }
    }
    #endregion

    /// <summary>
    /// BGM���Đ�����悤�ɂ���
    /// </summary>
    /// <param name="bgm">�Đ�������BGM��enum</param>
    public void PlayBGM(BgmSoundData.BGM bgm)
    {
        BgmSoundData data = new BgmSoundData();

        for (int i = 0; i < _bgmSoundDatas.Length; i++)
        {
            if (bgm == _bgmSoundDatas[i].Bgm)
            {
                data = _bgmSoundDatas[i];
            }
        }

        _audioBgm.clip = data.AudioClip;

        //���ʂ̒���
        _audioBgm.volume = data.Volume * _bgmMasterVolume * _masterVolume;
        _audioBgm.Play();
    }

    /// <summary>
    /// SE���Đ�����悤�ɂ���
    /// </summary>
    /// <param name="se">�Đ�������SE��enum</param>
    public void PlaySE(SeSoundData.SE se)
    {
        SeSoundData data = new SeSoundData();

        for (int i = 0; i < _seSoundDatas.Length; i++)
        {
            if (se == _seSoundDatas[i].Se)
            {
                data = _seSoundDatas[i];
                Debug.Log(data.Se);
                break;
            }
        }

        //���ʂ̒���
        _audioSe.volume = data.Volume * _seMasterVolume * _masterVolume;
        _audioSe.PlayOneShot(data.AudioClip);
    }


    //BGM
    /*
     �ʏ��BGM
    �{�X��BGM
     */
    [System.Serializable]
    public class BgmSoundData
    {
        public enum BGM
        {
            Title,
            Slime,
            Golem,
            Boss,
        }

        public BGM Bgm;
        public AudioClip AudioClip;
        [Range(0f, 1f)]
        public float Volume = 1f;
    }


    //SE
    /*
     �N���b�N��
    �ړ�
    �Ō���
     */
    [System.Serializable]
    public class SeSoundData
    {
        public enum SE
        {
            Click,
            Move,
            Hit,
        }

        public SE Se;
        public AudioClip AudioClip;
        [Range(0, 1)]
        public float Volume = 1f;
    }
}
