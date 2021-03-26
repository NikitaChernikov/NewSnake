using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;

[RequireComponent(typeof(Toggle))]
public class MuteToggle : MonoBehaviour
{
    Toggle myToggle;

   // public GameObject sound;

    // Start is called before the first frame update

    //public static MuteToggle instance;

    [System.Obsolete]
    void Start()
    {
        //sound = GameObject.FindGameObjectWithTag("AudioManager");

        /*if (instance == null)
            instance = this;
        else
        {
            Destroy(gameObject);
            return;
        }

        DontDestroyOnLoad(gameObject);*/

        myToggle = GetComponent<Toggle>();


        if (GameObject.FindGameObjectWithTag("AudioManager").active)
        {
            myToggle.isOn = false;
        }
    }

    public void ToggleAudioOnValueChange(bool audioIn)
    {
        if(audioIn)
        {
            GameObject.Find("AudioManager").SetActive(true);
        }
        else
        {
            GameObject.Find("AudioManager").SetActive(false);
        }
    }
}
