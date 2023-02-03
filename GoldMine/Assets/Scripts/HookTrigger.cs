using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HookTrigger : MonoBehaviour
{
    BoxCollider2D boxCollider2D;
    public static GameObject parentObject;
    public static GameObject childObject;
    public static bool child = false;
    int _queue = 1;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Border"))
        {
            HingeCycle.borderControl = false; // Sahne sınırına çarptığında kancayı geribeslemeye al.
        }
    }
    private void OnCollisionStay2D(Collision2D collision) 
    {
        /*if (collision.collider.CompareTag("TNT"))   
        {
            BoxCollider2D boxCollider2D = collision.gameObject.GetComponents<BoxCollider2D>()[1];
            boxCollider2D.enabled = !boxCollider2D.enabled;
        }*/
        if (collision.collider.CompareTag("Gold") || collision.collider.CompareTag("Diamond"))
        {
            //boxCollider2D = gameObject.GetComponent<BoxCollider2D>();
            //boxCollider2D.isTrigger = true;
            collision.transform.SetParent(gameObject.transform);
            HingeCycle.borderControl = false;

            parentObject = this.gameObject;

            childObject = parentObject.transform.GetChild(_queue).gameObject;
            boxCollider2D = childObject.GetComponentInChildren<BoxCollider2D>();
            boxCollider2D.isTrigger = true;
            _queue++;
            child = true;
            if (collision.collider.CompareTag("Gold"))
            {
                HingeCycle._hookSpeed = 0.1f;
                GameManager.Instance.PlayerMoney += 100;
            }
            else
            {
                HingeCycle._hookSpeed = 0.15f;
                GameManager.Instance.PlayerMoney += 300;
            }
        }
    }
}
