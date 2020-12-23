using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ZombieHareket : MonoBehaviour
{
	public GameObject kalp;
	private GameObject oyuncu;
	private int zombieCan = 3;
	private float mesafe;
	private int zombi_puan=1;
	private Oyun_Kontrol oKontrol;
	private AudioSource aSource;
	private bool zombieOluyor = false;
	// Start is called before the first frame update
    void Start()
    {
		aSource = GetComponent<AudioSource>();
		oyuncu = GameObject.Find ("FPSController");
		oKontrol = GameObject.Find("_Scripts").GetComponent<Oyun_Kontrol>();
    }

    // Update is called once per frame
    void Update()
    {
		GetComponent<NavMeshAgent>().destination= oyuncu.transform.position;
		mesafe = Vector3.Distance(transform.position,oyuncu.transform.position);
		if(mesafe<10f){
			if(!aSource.isPlaying)
			aSource.Play();
			if(!zombieOluyor)
			GetComponentInChildren<Animation>().Play("Zombie_Attack_01");
		} 
		else {
			if(aSource.isPlaying)
				aSource.Stop();
		}
		
    }
	private void OnCollisionEnter (Collision c){

		if (c.collider.gameObject.tag.Equals("mermi")){
			zombieCan--;
			if(zombieCan == 0){
				zombieOluyor = true;
				oKontrol.PuanArttir(zombi_puan);
				Instantiate(kalp,transform.position, Quaternion.identity);
				GetComponentInChildren<Animation>().Play("Zombie_Death_01");
				Destroy(this.gameObject,1.667f);
			}

		}

	}
}
