using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    AnimatorControlTest animator;

    public GameObject bulletSpawner;
    public GameObject bullet;
    public float speed = 5;
    public float delay = 3;
    
    Transform transform;

    Unit unit;
    bool isDelayAttack = false;
    float delayTimer = 0;

    void Start()
    {
        animator = GetComponent<AnimatorControlTest>();

        transform = GetComponent<Transform>();
        

        unit = GetComponent<Unit>();
    }

    void Update()
    {
        Fire();
    }

    void Fire()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (isDelayAttack == false)
            {
                GetComponent<AudioSource>().Play();
                if (transform.name == "Player_Archer")
                {
                    animator.animator.SetTrigger("AttackBowTrigger");
                }
                else if(transform.name == "Player_Wizard")
                {
                    animator.animator.SetTrigger("AttackMagicTrigger");
                }

                Debug.Log("Fire bullet");
                GameObject tempBulletHandler;
                tempBulletHandler = Instantiate(bullet, bulletSpawner.transform.position, bulletSpawner.transform.rotation) as GameObject;

                tempBulletHandler.transform.Rotate(Vector3.left * 90);

                Rigidbody tempRigid;
                tempRigid = tempBulletHandler.GetComponent<Rigidbody>();

                tempRigid.AddForce(transform.forward * speed);

                isDelayAttack = true;
                delayTimer = unit.attackDelay();
                StartCoroutine("CountDownDelay");

                Destroy(tempBulletHandler, delay);
            }
        }
    }

    public IEnumerator CountDownDelay()
    {

        if (isDelayAttack)
        {
            if (delayTimer <= 0)
            {
                isDelayAttack = false;
            }
            else
            {
                yield return new WaitForSeconds(delayTimer);
                isDelayAttack = false;
                delayTimer = 0;
            }
        }
    }
}
