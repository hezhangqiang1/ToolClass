using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioTest : MonoBehaviour {

	
	void Start () {
        AudioManager.GetInstance().PlayAudioSourceBGByName("FightBG");
        AudioManager.GetInstance().SetAudioVolumns(1, 1);
	}
	
	
	void Update () {
        if (Input.GetKeyDown(KeyCode.A))
        {
            AudioManager.GetInstance().PlayGameSoundByName("ButtonClick");
        }
	}
}
