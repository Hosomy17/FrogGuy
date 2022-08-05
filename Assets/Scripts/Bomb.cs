using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Invoke("SelfDestroy", 3f);
    }

    // Update is called once per frame

    void SelfDestroy()
    {
        Destroy(gameObject);
    }
}
