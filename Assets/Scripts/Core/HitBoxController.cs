using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitBoxController : MonoBehaviour
{
    public Unit ownerUnit;
    public Collider Col_hitbox;

    EnemyController enemyBehave;

    [SerializeField]
    private MeleeAttack _meleeAttack;

    void Awake()
    {
        
    }

    // Start is called before the first frame update
    void Start()
    {
        // OwnerUnit must reference melee unit in its parameter first then we reference it here
        if (ownerUnit == null)
        {
            ownerUnit = GetComponentInParent<Unit>();
            if (ownerUnit != null)
            {
                _meleeAttack = ownerUnit.meleeAttack;
            }
            else
            {
                Debug.Log("ownerUnit = null");
            }
        }

        if (Col_hitbox == null)
        {
            Col_hitbox = GetComponent<Collider>();
        }
    }

    private void OnTriggerStay(Collider other)
    {
        //Debug.Log("Stayyy " + other.gameObject.name);
        if (other != null && (other.tag == "Player" || other.tag == "Damagable" || other.tag == "Enemy" || other.tag == "OtherPlayer"))
        {
            //Debug.Log("Stayyy - " + other.gameObject.name);
            //Debug.Log(other.tag);

            // TODO: Remove later
            if(other.GetComponent<Unit>() == null)
            {
                Debug.Log("No Unit component in  - " + other.gameObject.name);
            }
            else
            {
                if (_meleeAttack == null)
                {
                    Debug.Log("No reference _meleeAttack");
                }
            }


            if (other.GetComponent<Unit>() != null && _meleeAttack != null)
            {
                //Debug.Log("Try to update dictionary");
                Unit newUnit = other.GetComponent<Unit>();
                //Debug.Log("Known detect unit name = " + newUnit.name + ", id = " + newUnit.id);
                int id = newUnit.id;    
                if (id != -1)
                {
                    //Debug.Log("Id is not -1 so add them to Dictionary ");
                    if (!_meleeAttack.inRangeDict.ContainsKey(id))
                    {
                        //Debug.Log("check in range");
                        _meleeAttack.inRangeDict.Add(id, newUnit);
                        // TODO: ถ้ามี key  อยู่แล้ว add ไม่ได้  หาวิธีใส่่ทับลงไป
                        _meleeAttack.inRangeUnitCount++;
                        //Debug.Log("Add Unit to inRangeDict, total = " + _meleeAttack.inRangeUnitCount);
                    }
                    else
                    {
                        //Debug.Log(newUnit.name + " is already in the dictionary");
                    }
                    //Unit u = new Unit();
                    //u.Attacked();
                }
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other != null && (other.tag == "Player" || other.tag == "Damagable" || other.tag == "Enemy" || other.tag == "OtherPlayer"))
        {
            //Debug.Log("Exited - " + other.gameObject.name);
            if (other.GetComponent<Unit>() != null && _meleeAttack != null)
            {
                Unit newUnit = other.GetComponent<Unit>();
                int id = newUnit.id;
                //Debug.Log("Known exit unit name = " + newUnit.name + ", id = " + newUnit.id);
                if (id != -1)
                {
                    //Debug.Log("Id is not -1 so remove them to Dictionary ");
                    if (_meleeAttack.inRangeDict.ContainsKey(id))
                    {
                        _meleeAttack.inRangeDict.Remove(id);
                        _meleeAttack.inRangeUnitCount--;
                        //Debug.Log("Remove Unit to inRangeDict, total = " + _meleeAttack.inRangeUnitCount);
                    }
                    else
                    {
                        //Debug.Log("No id in the dictionary" + id);
                    }
                }

            }
        }
    }
}
