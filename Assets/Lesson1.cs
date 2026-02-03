using UnityEngine;

public class Lesson1 : MonoBehaviour
{
    void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            print("пробел");
        }

        if (Input.GetMouseButton(0))
        {
            print("ЛКМ");
        }

        float h = Input.GetAxis("Horizontal");
    }  
}
