using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HookTrigger : MonoBehaviour
{
    #region Variables
    public static GameObject mineObject; // Kancadaki madeni statik olarak tutar.
    public static bool child = false; // Kancaya takılı maden olup olmadığını kontrol eder.
    #endregion


    #region Functions
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Border")) // Sahne sınırına çarptığında kancayı geribeslemeye al.
        {
            HingeCycle.borderControl = false; // Kancayı geri çeker.
        }
        if (collision.collider.CompareTag("TNT"))   // TNT objesine çarptığında TNT patlama yarıçapı oluşturmak için 2.BoxCollider i aktifleştir.
        {
            BoxCollider2D boxCollider2D = collision.gameObject.GetComponents<BoxCollider2D>()[1];
            boxCollider2D.enabled = !boxCollider2D.enabled;
            HingeCycle.borderControl = false; // Kancayı geri çeker.
        }
        if (collision.collider.CompareTag("Gold") || collision.collider.CompareTag("Diamond")) // Maden objelerine çarptığında Hook parenti olarak al.
        {
            collision.transform.SetParent(gameObject.transform);
            mineObject = collision.gameObject;
            HingeCycle.borderControl = false;
            mineObject.transform.localPosition = Vector3.zero;

            child = true; // Maden takıldığında kancada maden olduğunu döndür.

            if (collision.collider.CompareTag("Gold")) // tutulan maden türüne göre kanca çekme hızını düzenler.
            {
                HingeCycle._hookSpeed = 0.1f;
            }
            else
            {
                HingeCycle._hookSpeed = 0.15f;
            }
        }
    }
    #endregion

}
