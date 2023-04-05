using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletControl : MonoBehaviour
{
    [SerializeField] private Stage_Data stageData;
    private float destroyWeight = 2.0f; //삭제 여유공간

    private void LateUpdate()
    {
        if(transform.position.y < stageData.LimitMin.y - destroyWeight || transform.position.y > stageData.LimitMax.y + destroyWeight ||
            transform.position.x < stageData.LimitMin.x - destroyWeight || transform.position.x > stageData.LimitMax.x + destroyWeight)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            Destroy(gameObject);
        }
    }
}
