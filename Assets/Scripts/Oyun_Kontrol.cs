using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Oyun_Kontrol : MonoBehaviour
{

	public GameObject zombi1;
	public GameObject hayvan;
	private float zamanSayaci;
	private float olusumSureci= 10f;
	public Text puanText;
	private int puan;
	private float zamanSayaci2;
	private float olusumSureci2= 30f;
    // Start is called before the first frame update
    void Start()
    {
		zamanSayaci = olusumSureci;
    }

    // Update is called once per frame
    void Update()
    {
		zamanSayaci -= Time.deltaTime;
		if(zamanSayaci<0){
			Vector3 pos = new Vector3(Random.Range(145f,360f),24.3f,Random.Range(191f,360f));
			Instantiate (zombi1, pos, Quaternion.identity);
			zamanSayaci = olusumSureci;
		}
		zamanSayaci2 -= Time.deltaTime;
		if(zamanSayaci2<0){
			Vector3 pos = new Vector3(Random.Range(145f,360f),24.3f,Random.Range(191f,360f));
			Instantiate (hayvan, pos, Quaternion.identity);
			zamanSayaci2 = olusumSureci2;
		}

    }

	public void PuanArttir(int p){
		puan += p;
		puanText.text = ""+ puan;
	}

	public void OyunBitti(){
		PlayerPrefs.SetInt("puan",puan);
		SceneManager.LoadScene("OyunBitti");
	}
}
