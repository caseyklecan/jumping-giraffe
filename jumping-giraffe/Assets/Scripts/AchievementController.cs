using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AchievementController : MonoBehaviour {

	private bool pinkUnlocked;
	private bool blueUnlocked;

	void Awake() { 
		int valid = 0;
		if (PlayerPrefs.HasKey ("PinkUnlocked")) {
			valid = PlayerPrefs.GetInt ("PinkUnlocked");
		} else { 
			PlayerPrefs.SetInt ("PinkUnlocked", 0);
		}
		if (valid == 0) {
			pinkUnlocked = false;
		} else { 
			pinkUnlocked = true;
		}

		valid = 0;
		if (PlayerPrefs.HasKey("BlueUnlocked"))
		{
			valid = PlayerPrefs.GetInt("BlueUnlocked");
		} else { 
			PlayerPrefs.SetInt ("BlueUnlocked", 0);
		}
		if (valid == 0) { 
			blueUnlocked = false;
		} else { 
			blueUnlocked = true;
		}
	}

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public bool PinkIsUnlocked() { 
		return pinkUnlocked;
	}

	public bool BlueIsUnlocked() { 
		return blueUnlocked;
	} 

	public void SetPinkUnlocked() { 
		if (pinkUnlocked)
			return;
		PlayerPrefs.SetInt ("PinkUnlocked", 1);
	}

	public void SetBlueUnlocked() { 
		if (blueUnlocked)
			return;
		PlayerPrefs.SetInt ("BlueUnlocked", 1);
	}

	public void OnChooseRegular() { 
		// set multiplier to 1, set sprite to regular, free death to false
		GiraffeController.SetRegular ();
		SceneManager.LoadScene ("MainScene");
	}

	public void OnChoosePink() { 
		// set multiplier to 2, sprite to pink, free death to false
		GiraffeController.SetPink ();
		SceneManager.LoadScene ("MainScene");
	}

	public void OnChooseBlue() { 
		// set multiplier to 1, sprite to blue, free death to true
		GiraffeController.SetBlue ();
		SceneManager.LoadScene ("MainScene");
	}
}
