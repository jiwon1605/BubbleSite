using UnityEngine;

public class BubbleRepel : MonoBehaviour
{
    public float repelRadius = 2f;    // ���콺 ��ó �ݰ�
    public float repelForce = 5f;     // ƨ�ܳ����� ��

    Camera mainCam;
    Rigidbody rb;

    void Start()
    {
        mainCam = Camera.main;
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        Vector3 mousePos = Input.mousePosition;
        mousePos.z = Mathf.Abs(mainCam.transform.position.z - transform.position.z); // z �Ÿ� ����
        Vector3 worldMouse = mainCam.ScreenToWorldPoint(mousePos);

        float dist = Vector3.Distance(worldMouse, transform.position);

        if (dist < repelRadius)
        {
            Vector3 dir = (transform.position - worldMouse).normalized;
            rb.AddForce(dir * repelForce, ForceMode.Impulse);
        }
    }
}
