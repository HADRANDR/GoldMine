using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectControl : MonoBehaviour
{
    [SerializeField]public int _explodeControl;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (collision.CompareTag("Gold") || collision.CompareTag("Diamond"))    
        {
            var collider = collision.gameObject.GetComponents<BoxCollider2D>()[1];
            collider.enabled = true;
        }
        
    }


    //private void OnCollisionEnter2D(Collision2D collision)
    //{
    //    Debug.Log("imdaredt");
    //    if (collision.collider.CompareTag("Gold") || collision.collider.CompareTag("Diamond"))
    //    {
    //        var collider = collision.gameObject.GetComponents<BoxCollider2D>()[1];
    //        collider.enabled = !collider.enabled;
    //        Debug.Log("imdat");
    //    }
    //}


}
