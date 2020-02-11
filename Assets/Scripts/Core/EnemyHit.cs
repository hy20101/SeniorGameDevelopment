using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHit : MonoBehaviour
{
    public int damageToGive;
    public float damageDelay = 1f;
    private bool canTakeDamage = true;

    /*private void OnTriggerEnter(Collider other)
    {
        if (canTakeDamage = true && other.tag == "Player")
        {
            other.gameObject.GetComponent<HealthSystem>().getDamage(damageToGive);

            StartCoroutine(damageTimer());
        }
    }*/

    private void OnTriggerStay(Collider other)
    {
        if (canTakeDamage && other.tag == "Player")
        {
            other.gameObject.GetComponent<HealthSystem>().getDamage(10);

            StartCoroutine(damageTimer());
        }
    }

    private IEnumerator damageTimer()
    {
        canTakeDamage = false;
        yield return new WaitForSeconds(damageDelay);
        canTakeDamage = true;
    }
}
