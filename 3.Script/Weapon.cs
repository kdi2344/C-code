using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] private GameObject Player_bullet;
    [SerializeField] private float Attack_Rate = 0.1f;

    public void TryAttack()
    {
        Instantiate(Player_bullet, transform.position, Quaternion.identity);
    }
    private IEnumerator TryAttack_co()
    {
        while (true)
        {
            Instantiate(Player_bullet, transform.position, Quaternion.identity);
            yield return new WaitForSeconds(Attack_Rate);
        }

    }

    public void startFire()
    {
        StartCoroutine("TryAttack_co");
    }
    public void stopFire()
    {
        StopCoroutine("TryAttack_co");
    }
}
