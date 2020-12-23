using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OyuncuKontrol : MonoBehaviour
{
	public Transform mermiPos;
	public GameObject mermi;
	public GameObject patlama;
	public Image canImaji;
	private float canDegeri=100f;
	public Image yemekImaji;
	private float yemekDegeri=100f;
	public  Oyun_Kontrol oKontrol;
	public AudioClip atisSesi, olmeSesi, canAlmaSesi, yaralanmaSesi;
	private AudioSource aSource;
	private float zamanSayaci3;
	private float olusumSureci3= 500f;


    // Start is called before the first frame update
    void Start()
    {
		aSource = GetComponent<AudioSource>();
    }

	public void Ates(){
		{
			aSource.PlayOneShot(atisSesi,1f);
			GameObject go = Instantiate(mermi, mermiPos.position, mermiPos.rotation) as GameObject;
			GameObject goPatlama = Instantiate(patlama, mermiPos.position, mermiPos.rotation) as GameObject;
			go.GetComponent<Rigidbody> ().velocity = mermiPos.transform.forward * 10f;
			Destroy (go.gameObject, 2f);
			Destroy (goPatlama.gameObject, 2f);

		}
	}
    // Update is called once per frame
    void Update()
    {
		
		zamanSayaci3 -= Time.deltaTime;
		if(zamanSayaci3<0){
			yemekDegeri-=0.005f;
			float x = yemekDegeri/100f;
			yemekImaji.fillAmount = x;
			yemekImaji.color = Color.Lerp(Color.red, Color.blue, x);
			if(yemekDegeri<=0){
				aSource.PlayOneShot(olmeSesi,1f);
				oKontrol.OyunBitti ();
				zamanSayaci3 = olusumSureci3;
			}
		
		}
    }

	private void OnCollisionEnter (Collision c){

		if (c.collider.gameObject.tag.Equals("zombi")){
			aSource.PlayOneShot(yaralanmaSesi,1f);
			canDegeri-=10f;
			float x = canDegeri/100f;
			canImaji.fillAmount = x;
			canImaji.color = Color.Lerp(Color.red, Color.green, x);
			if(canDegeri<=0){
				aSource.PlayOneShot(olmeSesi,1f);

				oKontrol.OyunBitti ();
			}

		}
	}

	private void OnTriggerEnter(Collider c){//içinden geçilen objeler

		if(c.gameObject.tag.Equals("kalp")){
			aSource.PlayOneShot(canAlmaSesi,1f);
			if(canDegeri<100f);
			canDegeri+=10f;
			float x = canDegeri/100f;
			canImaji.fillAmount = x;
			canImaji.color = Color.Lerp(Color.red, Color.green, x);
			Destroy(c.gameObject);

		}
		else {
			aSource.PlayOneShot(canAlmaSesi,1f);
			if(yemekDegeri<100f);
			yemekDegeri+=2f;
			float x = yemekDegeri/100f;
			yemekImaji.fillAmount = x;
			yemekImaji.color = Color.Lerp(Color.red, Color.blue, x);
			Destroy(c.gameObject);

		}

	}

}
