using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectControl : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log(this.gameObject.tag);        
    }
    private void Update()
    {

    }
}
