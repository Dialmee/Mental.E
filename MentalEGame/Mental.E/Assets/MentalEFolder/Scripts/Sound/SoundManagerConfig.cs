using System.Collections.Generic;
using FMOD.Studio;
using UnityEngine;

[CreateAssetMenu(
    fileName = "SoundManagerConfig",
    menuName = "Scriptable Objects/SoundManagerConfig"
)]
public class SoundManagerConfig : ScriptableObject
{
    [SerializeField]
    public string musicVcaName = "vca:/Music";

    [SerializeField]
    public string sfxVcaName = "vca:/Sfx";

    [SerializeField]
    public string uiVcaName = "vca:/Ui";

    public float fVolumeMusic = 0f;
    public float fVolumeSfx = 0f;
    public float fVolumeUi = 0f;

    [SerializeField]
    public string sfxUiNewLevelPath = "path";

    [SerializeField]
    public string sfxUiPointerPath = "path";

    [SerializeField]
    public string sfxUiClickPath = "path";

    [SerializeField]
    public string sfxUiUpgradeButtonPath = "path";

    [SerializeField]
    public string sfxExplosionPath = "path";

    [SerializeField]
    public string sfxLazerGunPath = "path";

    [SerializeField]
    public string sfxLazerHitPath = "path";

    [SerializeField]
    public string sfxStoneHitPath = "path";

    [SerializeField]
    public string sfxMovementPath = "path";


    public FMOD.Studio.EventInstance musicLoopInstance;
    public List<EventInstance> activeLoopedSounds = new List<EventInstance>();
    public FMOD.Studio.VCA music_VCA;
    public FMOD.Studio.VCA sfx_VCA;
    public FMOD.Studio.VCA ui_VCA;
}
