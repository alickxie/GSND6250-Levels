using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class VidPlayer : MonoBehaviour
{
    [SerializeField] private string videoFileName;

    // Start is called before the first frame update
    void Start()
    {
        PlayVideo();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void PlayVideo()
    {
        VideoPlayer videoPlayer = GetComponent<VideoPlayer>();

        if (videoPlayer)
        {
            string path = System.IO.Path.Combine(Application.streamingAssetsPath, videoFileName);
            Debug.Log("Loading video from " + path);
            videoPlayer.url = path;
            videoPlayer.Play();
        }
    }
}
