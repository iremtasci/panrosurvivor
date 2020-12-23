using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class Avlanma : MonoBehaviour
{
	private int hayvanCan = 1;
	public GameObject Yemek;
	private GameObject oyuncu;
    // Start is called before the first frame update
    void Start()
    {
		oyuncu = GameObject.Find ("FPSController");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
	private void OnCollisionEnter (Collision c){

		if (c.collider.gameObject.tag.Equals("mermi")){
			hayvanCan--;
			Debug.Log("Çarpışma");
			if(hayvanCan == 0){
				//zombieOluyor = true;
				//oKontrol.PuanArttir(zombi_puan);
				Instantiate(Yemek,transform.position, Quaternion.identity);
				//GetComponentInChildren<Animation>().Play("Zombie_Death_01");
				Destroy(this.gameObject,0.250f);
			}

		}

	}
}
