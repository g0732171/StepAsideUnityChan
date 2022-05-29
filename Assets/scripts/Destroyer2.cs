using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroyer2 : MonoBehaviour
{


    private GameObject maincam;
    // Start is called before the first frame update
    void Start()
    {

        this.maincam = GameObject.Find("Main Camera");
    }

    // Update is called once per frame
    void Update()
    {
        if (this.transform.position.z < maincam.transform.position.z)
        {           
            GameObject.Destroy(this.gameObject);
        }

    }
}
