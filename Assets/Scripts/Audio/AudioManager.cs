
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UIElements;

public class AudioManager : MonoBehaviour
{

    /*=========================Description==================*/
    /*The purpose of the sound manager script is to play all sounds. It helps us by keeping the sound effects
     in one spot. Each player has its own sound Manager Currently, the Sound Manager uses two main Audio Mixer 
    groups, one for the local player, and the other for the remote player. 
    Each These has a sub group for sound effects and music. By default the remote
    player group is muted, so we don't hear duplicate sounds. */

    /*=========Adding Sounds===========*/
    /*  1) Create an empty game object as a child of the prefab
        2) Name the Object after the sound effect or music
        3) Add an Field For the AudioSource, then drag and drop the child in
        4) In the awake method tell which mixer the sound has to go to
        5) Add a play Method in the Play_Functions Regions

    Notes: Adding a an empty game object to the sound manager is not necessary, but it makes it easier to understand
           The play_functions region also contains things for stoping sound effects like running/walking*/





    AudioMixerGroup sfx;
    AudioMixerGroup music;
    AudioMixerGroup master;
    public AudioSource SceneTheme; // default music supposed to playing in a scene


    //volume variable names
    [SerializeField]
    float defaultVolumeValue = 0.6f;
    private const string musicVol = "MusicVol";
    private const string sfxVol = "SFXVol";
    private const string masterVol = "MasterVol";


    [SerializeField]
    AudioSource testAttack;
    AudioSource testBGM;

    private void Awake()
    {
        // when a player is loaded through the game manager it will determine
        // where audio for that player is routed by default, all remote players are muted
        // this can be expanded upon later on to utilize unity's 3d audio for player player sfx
        // when two players are close to eachother. However, there will need to be More Audio Mixer groups
        AudioMixer mix = Resources.Load("Mixer") as AudioMixer;
       

        //will allways return an array so we have to access the 0th element

        sfx = mix.FindMatchingGroups("Master/SFX")[0];
        music = mix.FindMatchingGroups("Master/Music")[0];
        master = mix.FindMatchingGroups("Master")[0];
        DontDestroyOnLoad(this);

    }
    #region UI_INTERACTIONS
    public void setSFXVol(float value)
    {

        sfx.audioMixer.SetFloat(sfxVol, Mathf.Log10(value) * 20);
    }

    public void setMusicVol(float value)
    {

        music.audioMixer.SetFloat(musicVol, Mathf.Log10(value) * 20);
    }

    public float getSFXVol()
    {

        sfx.audioMixer.GetFloat(sfxVol, out float val);
        val = Mathf.Pow(10, val / 20);
        if (val <= 0 || val > 1)
        {
            return defaultVolumeValue;
        }
        return val;
    }

    public float getMusicVol()
    {
        sfx.audioMixer.GetFloat(musicVol, out float val);
        val = Mathf.Pow(10, val / 20);
        if (val <= 0 || val > 1)
        {
            return defaultVolumeValue;
        }
        return val;
    }



    public void setMasterVol(float value)
    {

        master.audioMixer.SetFloat(masterVol, Mathf.Log10(value) * 20);
    }

    public float getMasterVol()
    {

        master.audioMixer.GetFloat(masterVol, out float val);
        val = Mathf.Pow(10, val / 20);
        if (val <= 0 || val > 1)
        {
            return defaultVolumeValue;
        }
        return val;
    }
# endregion
    #region PLAY_FUNCTIONS

    public void playTestAttack()
    {
        if (testAttack.isPlaying)
        {
            return;
        }
        testAttack.loop = false;
        testAttack.Play();
    }


    public void playTestAttackLooped()
    {
        if (testAttack.isPlaying)
        {
            return;
        }
        testAttack.loop = true;
        testAttack.Play();
    }

    public void stopPlayingTestAttackLoop()
    {
        testAttack.loop = false;
        testAttack.Stop();
    }

    #endregion


}
