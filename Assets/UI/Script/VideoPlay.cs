using UnityEngine;
using UnityEngine.Video;

public class NewBehaviourScript : MonoBehaviour
{
    public VideoPlayer videoPlayer;
    public RenderTexture renderTexture;

    void Start()
    {
        // ”станавливаем RenderTexture как текстуру дл€ VideoPlayer
        videoPlayer.targetTexture = renderTexture;

        // ”станавливаем видео на посто€нное зацикливание
        videoPlayer.isLooping = true;

        // ѕровер€ем, запущено ли воспроизведение, и запускаем, если нет
        if (!videoPlayer.isPlaying)
        {
            videoPlayer.Play();
        }
    }
}
