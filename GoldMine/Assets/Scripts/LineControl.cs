using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineControl : MonoBehaviour
{
    LineRenderer line;
    [SerializeField] Transform object1, object2;
    void Start() // Menteşe ile kanca arasındaki bağ.
    {
        line = GetComponent<LineRenderer>();

        line.SetPosition(0, object1.position);
        
    }
    void Update() // Kanca yeri değişken olduğu için gitmesi gereken yeri her zaman güncel tut.
    {
        line.SetPosition(1, object2.position);
    }
}
