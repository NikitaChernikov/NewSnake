using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonSound : MonoBehaviour
{
    public void OnClick()
    {
        FindObjectOfType<AudioManager>().Play("ButtonClick");
    }
}
