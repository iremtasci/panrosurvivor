using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunDonumu : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
		transform.RotateAround(new Vector3(250,0,250), Vector3.right, 1f * Time.deltaTime);
    }
}
