using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HingeCycle : MonoBehaviour
{
    #region Variables
    bool mouseDown; // Ekrana basıldığında çalıştırılacak algoritmanın anahtarı.
    bool rightControl = true; // Kancamızın ne zaman sağa sola gitmesi gerektiğni belirten anahtarlar.
    bool leftControl = false; // ***    ****        ***     **      ***     ***     ***     ***
    public static bool borderControl = true; // Kancanın sahne sınırlarında olacaklar ve geri dönüş algoritmasının anahtarı.
    float _loopControl = 0; // Kanca çağırılıp geri döndükten sonra ne tarafa doğru gitmesi gerektiğini gösterir.
    float _hookControl = 0; // Kancanın gidiş ve geliş kontrolünü sağlar.
    public static float _hookSpeed = 0.2f;

    [SerializeField] GameObject Hook;
    #endregion


    void Update()
    {


        if (rightControl ==true) 
        {
            transform.Rotate(0, 0, 0.5f);
            if (transform.rotation.z > 0.38f)
            {
                rightControl = false;
                leftControl = true;
                _loopControl++;
            }
        }
        if (leftControl ==true)    
        {
            transform.Rotate(0, 0, -0.5f);
            if (transform.rotation.z < -0.38f)
            {
                leftControl = false;
                rightControl = true;
                _loopControl++;
            }
        }




        if (Input.GetMouseButtonDown(0))
        {
            mouseDown = true;
        }




        if (mouseDown == true)
        {
            leftControl = false;
            rightControl = false;


            if (borderControl == true)  // Kanca yerindeyse fırlatılabilir mi?
            {
                Hook.transform.Translate(0, -_hookSpeed, 0);
            }

            if (borderControl == false) // Kanca sahne sınırına çarptı mı?
            {
                if (Hook.transform.position.y < - 1)
                {
                    Hook.transform.Translate(0, _hookSpeed, 0);
                }
                if (Hook.transform.position.y > -1)   
                {
                    mouseDown = false;      // Kancayı fırlatılabilir duruma getir.
                    borderControl = true;   // ** **        *****       ***     **

                    if (HookTrigger.child == true)
                    {
                        HookTrigger.childObject.SetActive(false);
                        HookTrigger.child = false;
                    }
                    

                    _hookSpeed = 0.2f;

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
}
