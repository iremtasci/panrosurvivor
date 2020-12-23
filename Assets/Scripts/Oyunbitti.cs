using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class Oyunbitti : MonoBehaviour
{
	public Text puan;
	// Start is called before the first frame update
   
	void Start()
    {
		Cursor.lockState = CursorLockMode.Confined;
		Cursor.visible = true;
		puan.text = "Puanınız:" +PlayerPrefs.GetInt ("puan");
    }

    // Update is called once per frame
	public void YenidenOyna(){
		SceneManager.LoadScene ("Oyun");

	}

}
