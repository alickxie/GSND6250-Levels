using UnityEngine;

public class MusicPlayer : MonoBehaviour
{
    private AudioSource audioSource;

    void Start()
    {
        // 获取或添加音频源组件
        audioSource = gameObject.GetComponent<AudioSource>() ?? gameObject.AddComponent<AudioSource>();
    }

    // 公开的方法来播放音乐
    public void PlayMusic()
    {
        if (!audioSource.isPlaying)
        {
            audioSource.Play();
        }
    }

    // 公开的方法来停止音乐
    public void StopMusic()
    {
        if (audioSource.isPlaying)
        {
            audioSource.Stop();
        }
    }

    // 公开的方法来切换播放/停止状态
    public void ToggleMusic()
    {
        Debug.Log("ToggleMusic called");
        if (audioSource.isPlaying)
        {
            StopMusic();
        }
        else
        {
            PlayMusic();
        }
    }
}

