using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDestroyer : MonoBehaviour
{
   

    void OnBecameInvisible()
    {
        GameObject.Destroy(this.gameObject);

    }
}
