using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class melee : MonoBehaviour
{
    public GameObject spieler;
    private float lastShot = 0;

    public float meleeRange;
    public float meleeRateMin = 120f;

    void FixedUpdate()
    {
        if (Input.GetMouseButton(0))
        {
            if (spieler.GetComponent<crosshair>().isMelee)
            {
                if ((lastShot - (Time.time * 1000)) <= -(60000 / meleeRateMin))
                { 
                     Collider[] hitInfo = Physics.OverlapSphere(spieler.transform.position + spieler.transform.TransformDirection(new Vector3(0f, 0f, meleeRange)), meleeRange);
                     int i = 0;
                     while (i < hitInfo.Length)
                     {
                         if (hitInfo[i].name != "boden" && hitInfo[i].name != "spieler" && hitInfo[i].name != "bullet(Clone)")
                         {
                             Debug.Log(hitInfo[i].name);
                         }
                         i++;
                     }
                    lastShot = Time.time * 1000;
                }
            }
        }
    }
    
    /*private void OnDrawGizmosSelected()
    {
        Vector3 meleePos = spieler.transform.position + spieler.transform.TransformDirection(new Vector3(0f,0f,meleeRange));

        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(meleePos, meleeRange);
    }*/
}
