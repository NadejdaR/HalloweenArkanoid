using UnityEngine;
using UnityEngine.Audio;

public class SettingMenuScript : MonoBehaviour
{
  public AudioMixer AudioMixer;

  public void SetVolume(float volume)
  {
    AudioMixer.SetFloat("volume", volume);
  }

  public void SetFullscreen(bool isFullscreen)
  {
    Screen.fullScreen = isFullscreen;
  }
}