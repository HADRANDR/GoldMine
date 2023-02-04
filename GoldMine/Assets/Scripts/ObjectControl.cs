using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class ObjectControl : MonoBehaviour
{

    #region Functions
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (HookTrigger.child == false && !collision.CompareTag("Hook"))   // Kanca ile maden tutmadıysam ve Madenlere çarpan şey Kanca değilse.
        {
            var collider = collision.gameObject.GetComponents<BoxCollider2D>()[1]; // Madenlerin içerisindeki 2. Box Collider componentine ulaş
            collider.enabled = true; // Componenti aktifleştir.

            int _shakeControl = 1; // Madenlerin Trigger tarafından yakalanması için her madeni sadece 1 kez hareket ettiriyorum.
            for (int i = 0; i < _shakeControl; i++)
            {
                collision.gameObject.transform.DOShakePosition(0.01f);
            }


            Invoke(nameof(DestroyMine), 2f); // 2. box colliderı  aktifleşen maden objelerinin SetActive = false yapıyorum. 
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Hook") && !this.gameObject.CompareTag("TNT"))   // Madenlere çarpan şey Hook ise ve Madenlere çarpan şey TNT değilse 
        {
            BoxCollider2D boxCollider2D = this.gameObject.GetComponent<BoxCollider2D>();
            boxCollider2D.isTrigger = true; // Kancaya yakalanan madenlerin başka madenlerle çarpışmaması, birleşmemesi için Trigger'i aktifleştiriyorum.
        }
    }
    void DestroyMine() // TNT yoluyla zincirleme reaksiyona uğrayan maden objelerini sahneden kaldır.
    {
        this.gameObject.SetActive(false);
    }

    #endregion

}
