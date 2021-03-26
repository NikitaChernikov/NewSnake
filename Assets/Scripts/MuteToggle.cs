using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;

[RequireComponent(typeof(Toggle))]
public class MuteToggle : MonoBehaviour
{
    Toggle myToggle;
    public Sound sound;

    // Start is called before the first frame update
    [System.Obsolete]
    void Start()
    {
        
        myToggle = GetComponent<Toggle>();
        if (sound.volume == 0)
        {
            myToggle.isOn = false;
        }
    }

    public void ToggleAudioOnValueChange(bool audioIn)
    {
        if(audioIn)
        {
            sound.volume = 1f;
        }
        else
        {
            sound.volume = 0f;
        }
    }
}
