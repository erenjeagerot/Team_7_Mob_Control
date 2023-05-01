using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyParticle : MonoBehaviour
{
    void Start()
    {
        Destroy(gameObject, 1f);    //aslýnda destroy etmek yerine disabled yaparsak daha az ram yer
    }
}
