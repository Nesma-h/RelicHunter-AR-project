using UnityEngine;

public class InputManager : MonoBehaviour
{
    void Update()
    {
        // بيشتغل مع اللمس على الموبايل أو ضغطة الماوس في الـ Editor
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                // بنحاول نلاقي سكريبت الـ RelicInteraction على الحاجة اللي خبطنا فيها
                RelicInteraction relic = hit.collider.GetComponent<RelicInteraction>();

                if (relic != null)
                {
                    relic.OnTapped(); // السطر ده لازم يكون اسمه OnTapped زي اللي في الملف فوق
                }
            }
        }
    }
}