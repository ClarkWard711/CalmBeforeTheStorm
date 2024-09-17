using UnityEngine;

public class MusicManager : MonoBehaviour
{
    // 静态实例，用于确保只存在一个 MusicManager
    private static MusicManager instance;

    // 音乐播放器
    public AudioSource audioSource;

    // 背景音乐音频剪辑
    public AudioClip backgroundMusic;

    // Awake 函数在场景加载时调用
    void Awake()
    {
        // 如果当前没有实例，则设置为当前实例，并保持持续存在
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);  // 确保音乐在场景切换时持续播放
        }
        // 如果已经有实例存在，则销毁新创建的对象，防止重复播放
        else
        {
            Destroy(gameObject);  // 防止多个实例导致音乐重叠
        }
    }

    // 在游戏开始时调用
    void Start()
    {
        PlayMusic();  // 播放背景音乐
    }

    // 播放背景音乐
    public void PlayMusic()
    {
        // 确保有背景音乐片段存在
        if (backgroundMusic != null)
        {
            audioSource.clip = backgroundMusic;  // 设置音频剪辑
            audioSource.loop = true;  // 设置为循环播放
            audioSource.Play();  // 开始播放
        }
    }
}

