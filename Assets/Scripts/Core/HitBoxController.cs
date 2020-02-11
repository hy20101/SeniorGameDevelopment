using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitBoxController : MonoBehaviour
{
    public Unit ownerUnit;
    public Collider Col_hitbox;
    private MeleeAttack _meleeAttack;

    void Awake()
    {
        if(ownerUnit == null)
        {
            ownerUnit = GetComponentInParent<Unit>();
            if(ownerUnit!= null)
            {
                _meleeAttack = ownerUnit.meleeAttack;
            }
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        if(Col_hitbox == null)
        {
            Col_hitbox = GetComponent<Collider>();
        }
    }

    private void OnTriggerStay(Collider other)
    {
        //Debug.Log("Stayyy " + other.gameObject.name);
        //.tag == "Damagable" || other.tag == "Enemy" || other.tag == "Player"
        if (other != null)
        {
            //Debug.Log(other.tag);
            if (other.GetComponent<Unit>() != null && _meleeAttack != null)
            {
                Unit newUnit = other.GetComponent<Unit>();
                int id = newUnit.id;    
                if (id != -1)
                {
                    if (!_meleeAttack.inRangeDict.ContainsKey(id))
                    {
                        Debug.Log("check in range");
                        _meleeAttack.inRangeDict.Add(id, newUnit);
                        // TODO: ถ้ามี key  อยู่แล้ว add ไม่ได้  หาวิธีใส่่ทับลงไป
                        _meleeAttack.inRangeUnitCount++;
                        Debug.Log("Add Unit to inRangeDict, total = " + _meleeAttack.inRangeUnitCount);
                    }
                    //Unit u = new Unit();
                    //u.Attacked();
                }
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Damagable" || other.tag == "Enemy" || other.tag == "Player")
        {
            //Debug.Log(other.tag);
            if (other.GetComponent<Unit>() != null)
            {
                Unit newUnit = other.GetComponent<Unit>();
                int id = newUnit.id;
                if (id != -1)
                {
                    _meleeAttack.inRangeDict.Remove(id);
                    _meleeAttack.inRangeUnitCount--;
                    Debug.Log("Remove Unit to inRangeDict, total = " + _meleeAttack.inRangeUnitCount);
                }

            }
        }
    }
}
