using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HingeCycle : MonoBehaviour
{
    #region Variables
    bool mouseDown; // Ekrana basıldığında çalıştırılacak algoritmanın anahtarı.
    bool rightControl = true; // Kancamızın sağa sola gitmesi gerektiğni belirten anahtarlar.
    bool leftControl = false; // ***    ****        ***     **      ***     ***     ***     ***
    public static bool borderControl = true; // Kancanın sahne sınırlarında olacaklar ve geri dönüş algoritmasının anahtarı.
    float _loopControl = 0; // Kanca çağırılıp geri döndükten sonra ne tarafa doğru gitmesi gerektiğini gösterir.
    public static float _hookSpeed = 0.2f; // Kanca hızı.
    [SerializeField] GameObject Hook; // Kanca objesi
    #endregion

    #region Functions
    void Update()
    {

        // Kancanın sağa ve sola ne hızda ve ne kadar ilerleyebileceği
        if (rightControl == true)
        {
            transform.Rotate(0, 0, 0.5f);
            if (transform.rotation.z > 0.38f)
            {
                rightControl = false;
                leftControl = true;
                _loopControl++;
            }
        }
        if (leftControl == true)
        {
            transform.Rotate(0, 0, -0.5f);
            if (transform.rotation.z < -0.38f)
            {
                leftControl = false;
                rightControl = true;
                _loopControl++;
            }
        }



        // Ekrana tıklandığında değişkene atama yap ve gerekli metodu çağır.
        if (Input.GetMouseButtonDown(0))
        {
            mouseDown = true;
        }






        if (mouseDown == true) // tıklandıysa.
        {

            // Kancanın hareketini durdur.
            leftControl = false;
            rightControl = false;


            if (borderControl == true)  // Kanca yerindeyse fırlatılabilir mi?
            {
                Hook.transform.Translate(0, -_hookSpeed, 0); // Kancayı aşağı gönderir.
            }



            if (borderControl == false) // Kanca sahne sınırına çarptı mı?
            {
                if (Hook.transform.position.y < -1) // Kanca sınıra çarptığı için yukarı çekmeye başla
                {
                    Hook.transform.Translate(0, _hookSpeed, 0); // Kancayı yukarı çeker.
                }
                if (Hook.transform.position.y > -1) // Kanca başlangıç noktasına geldiğinde gerçekleştir.
                {
                    mouseDown = false;      // Kanca yerine geldiğinde, Ekrana basıldığında çağırılan metodu durdur.
                    borderControl = true;   // Kancayı kullanılabilir duruma getir.

                    if (HookTrigger.child == true) // Kancada bir maden takılı mı?
                    {
                        HookTrigger.mineObject.SetActive(false); // Kancada takılı bir maden varsa onu sahnede kapat.

                        if (HookTrigger.mineObject.CompareTag("Gold")) // Kapatılan maden Altın mı?
                        {
                            GameManager.Instance.PlayerMoney += 100;
                        }
                        else                                            // Kapatılan maden Elmas mı?
                        {
                            GameManager.Instance.PlayerMoney += 300;
                        }
                        HookTrigger.child = false;  // Kancaya tekrar maden takılabilir duruma getir.
                    }


                    _hookSpeed = 0.2f; // Kanca hızını başlangıç seviyesine getirir.

                    if (_loopControl % 2 == 0) // Kanca fırlatılmadan önce ne yöne doğru ilerliyordu?
                    {
                        leftControl = true; // Kanca geri geldiğinde sola doğru hareket ettir.
                    }

                    else
                    {
                        rightControl = true; // Kanca geri geldiğinde sağa doğru hareket ettir.
                    }
                }
            }
        }

    }


    #endregion

}
