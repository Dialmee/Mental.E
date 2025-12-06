using FMOD.Studio;
using FMODUnity;
using Mono.Cecil;
using UnityEngine;
using UnityEngine.Rendering;
using static UnityEngine.Rendering.VolumeComponent;

public class SoundManager
{
    public SoundManagerConfig soundManagerConfig;

    public void ChangeVolume(VolumeType volumeType, float volume)
    {
        switch (volumeType)
        {
            case VolumeType.None:
                return;
            case VolumeType.Music:
                VolumeChanging(soundManagerConfig.music_VCA, volume);
                break;
            case VolumeType.Sfx:
                VolumeChanging(soundManagerConfig.sfx_VCA, volume);
                break;
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
        }
    }

    private void VolumeChanging(FMOD.Studio.VCA VCA, float volume)
    {
        if (VCA.isValid())
        {
            VCA.setVolume(volume);
        }
    }

    public void PausedGameVolume(bool bIsPaused)
    {
        if (bIsPaused)
        {
            RuntimeManager.StudioSystem.setParameterByName("Pause", 0f);
        }
        else
        {
            RuntimeManager.StudioSystem.setParameterByName("Pause", 100f);
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
            }
        }
    }

    public void PlayOneShot(string path)
    {
        RuntimeManager.PlayOneShot(path);
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
