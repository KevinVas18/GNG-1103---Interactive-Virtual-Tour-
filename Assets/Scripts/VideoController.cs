using UnityEngine;
using UnityEngine.Video;

public class ControlledVideo : MonoBehaviour
{
    public VideoPlayer videoPlayer;
    public AudioSource audioSource;

    void Start()
    {
        videoPlayer.Stop();
        audioSource.Stop();
    }

    public void PlayVideo()
    {
        audioSource.Play();
        videoPlayer.Play();
    }

    public void PauseVideo()
    {
        videoPlayer.Pause();
        audioSource.Pause();
    }

    public void StopVideo()
    {
        videoPlayer.Stop();
        audioSource.Stop();
    }
}
