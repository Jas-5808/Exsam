using UnityEngine;
using UnityEngine.Video;

public class NewBehaviourScript : MonoBehaviour
{
    public VideoPlayer videoPlayer;
    public RenderTexture renderTexture;

    void Start()
    {
        // ������������� RenderTexture ��� �������� ��� VideoPlayer
        videoPlayer.targetTexture = renderTexture;

        // ������������� ����� �� ���������� ������������
        videoPlayer.isLooping = true;

        // ���������, �������� �� ���������������, � ���������, ���� ���
        if (!videoPlayer.isPlaying)
        {
            videoPlayer.Play();
        }
    }
}
