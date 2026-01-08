using FMOD.Studio;
using FMODUnity;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SoundManager : MonoBehaviour
{
    [SerializeField] private string sGameSceneName = "MentalEGame";
    public float fPausedVolume = 0f;
    public float fPlayingVolume = 1f;
    public SoundManagerConfig soundManagerConfig;
    private void Start()
    {
        if(!soundManagerConfig.music_VCA.isValid())
        {
            soundManagerConfig.music_VCA = FMODUnity.RuntimeManager.GetVCA(soundManagerConfig.musicVcaName);
        }
        if(!soundManagerConfig.sfx_VCA.isValid())
        {
            soundManagerConfig.sfx_VCA = FMODUnity.RuntimeManager.GetVCA(soundManagerConfig.sfxVcaName);
        }
        if(!soundManagerConfig.ui_VCA.isValid())
        {
            soundManagerConfig.ui_VCA = FMODUnity.RuntimeManager.GetVCA(soundManagerConfig.uiVcaName);
        }
        fPlayingVolume = soundManagerConfig.fVolumeMusic;
        fPausedVolume = fPlayingVolume*0.4f;
    }
    public void ChangeVolume(VolumeType volumeType, float volume)
    {
        switch (volumeType)
        {
            case VolumeType.None:
                return;
            case VolumeType.Music:
                VolumeChanging(soundManagerConfig.music_VCA, volume);
                soundManagerConfig.fVolumeMusic = volume;
                break;
            case VolumeType.Sfx:
                VolumeChanging(soundManagerConfig.sfx_VCA, volume);
                soundManagerConfig.fVolumeSfx = volume;
                break;
            case VolumeType.Ui:
                VolumeChanging(soundManagerConfig.ui_VCA, volume);
                soundManagerConfig.fVolumeUi = volume;
                break;
        }
    }
    public void PausedVolume(bool toPause)
    {
        if(SceneManager.GetActiveScene().name == sGameSceneName)
        {
            if (toPause)
            {
                fPausedVolume = fPlayingVolume * 0.4f;
                VolumeChanging(soundManagerConfig.music_VCA, fPausedVolume);
            }
            else
            {
                VolumeChanging(soundManagerConfig.music_VCA, fPlayingVolume);
            }
        }
    }

    public void PreResetVolume(VolumeType volumeType)
    {
        switch (volumeType)
        {
            case VolumeType.None:
                return;
            case VolumeType.Music:
                VolumeGet(soundManagerConfig.music_VCA, volumeType);
                break;
            case VolumeType.Sfx:
                VolumeGet(soundManagerConfig.sfx_VCA, volumeType);
                break;
            case VolumeType.Ui:
                VolumeGet(soundManagerConfig.ui_VCA, volumeType);
                break;
        }
    }

    private void VolumeChanging(FMOD.Studio.VCA VCA, float volume)
    {
        if (VCA.isValid())
        {
            VCA.setVolume(volume);
        }
        else
        {
            Debug.LogWarning("VCA is not Validl");
        }
    }

    private void VolumeGet(FMOD.Studio.VCA VCA, VolumeType volumeType)
    {
        if (VCA.isValid())
        {
            VCA.getVolume(out float volume);

            switch (volumeType)
            {
                case VolumeType.None:
                    return;
                case VolumeType.Music:
                    soundManagerConfig.fVolumeMusic = volume;
                    break;
                case VolumeType.Sfx:
                    soundManagerConfig.fVolumeSfx = volume;
                    break;
                case VolumeType.Ui:
                    soundManagerConfig.fVolumeUi = volume;
                    break;
            }
        }
        else
        {
            Debug.LogWarning("VCA is not Validl");
        }
    }

    public void PlayOneShot(string path, Vector3 vect)
    {
        if(vect==Vector3.zero)
        {
            RuntimeManager.PlayOneShot(path);
        }
        else
        {
            FMODUnity.RuntimeManager.PlayOneShot(path, vect);
        }
    }

    public void PlayMusic(FMODUnity.EventReference eventReference)
    {
        if (soundManagerConfig.musicLoopInstance.isValid())
        {
            soundManagerConfig.musicLoopInstance.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
            soundManagerConfig.musicLoopInstance.release();
        }
        soundManagerConfig.musicLoopInstance = RuntimeManager.CreateInstance(eventReference);
        soundManagerConfig.musicLoopInstance.start();
    }

    public void SetMusic(string type)
    {
        RuntimeManager.StudioSystem.setParameterByNameWithLabel("Gamestate", type);
    }
}
