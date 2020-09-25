using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealthDamager : MonoBehaviour
{
    public int damageToGive;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D anObject)
    {
        if(anObject.gameObject.tag == "Enemy")
        {
            anObject.GetComponent<EnemyHealthManager>().EnemyIsDamaged(damageToGive);
        }
    }
}
