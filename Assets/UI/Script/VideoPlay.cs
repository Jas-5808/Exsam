using UnityEngine;
using UnityEngine.Video;

public class NewBehaviourScript : MonoBehaviour
{
    public VideoPlayer videoPlayer;
    public RenderTexture renderTexture;
    public VideoClip videoClip1;
    public VideoClip videoClip2;
    private bool isFirstVideoPlayed = false;

    void Start()
    {
        videoPlayer.targetTexture = renderTexture;
        videoPlayer.isLooping = false;
        videoPlayer.loopPointReached += OnVideoFinished;

        PlayFirstVideo();
    }

    void PlayFirstVideo()
    {
        videoPlayer.clip = videoClip1;
        isFirstVideoPlayed = false;
        videoPlayer.Play();
    }

    void PlaySecondVideo()
    {
        videoPlayer.clip = videoClip2;
        videoPlayer.isLooping = true;
        videoPlayer.Play();
    }

    void OnVideoFinished(VideoPlayer vp)
    {
        if (!isFirstVideoPlayed)
        {
            isFirstVideoPlayed = true;
            PlaySecondVideo();
        }
    }
}
