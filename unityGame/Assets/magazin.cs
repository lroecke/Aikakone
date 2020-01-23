using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Threading;
using TMPro;

public class magazin : MonoBehaviour
{
    public TextMeshProUGUI textMesh; //UI Text Object
    public TextMeshProUGUI textMeshMags; //UI Text Object
    public bool magEmpty = false;


    private float ammoCapacity;
    private float magCapacity;
    private float ammoLeft;
    private float magLeft;

    private float reloadTime;

    void Start()
    {
        ammoCapacity = GameObject.Find("spieler").GetComponent<crosshair>().ammoCapacity;
        magCapacity = GameObject.Find("spieler").GetComponent<crosshair>().magCapacity;

        reloadTime = GameObject.Find("spieler").GetComponent<crosshair>().reloadTime;

         magLeft = magCapacity;
         ammoLeft = ammoCapacity;
         updateAmmoCount();
    }
    void Update()
    {
    }

    public void removeBulletFromMag(int amount)
    {
        if (ammoLeft == 0)
            magEmpty = true;

        ammoLeft = ammoLeft - 1;
            updateAmmoCount();

        if (ammoLeft == 0)
            magEmpty = true;
    }

    public void reload()
    {
        StartCoroutine("reloadEnum");
    }
    IEnumerator reloadEnum()
    {
        yield return new WaitForSeconds(reloadTime);
        if (magLeft > 0)
        {
            ammoLeft = ammoCapacity;
            magLeft--;
            updateAmmoCount();
            magEmpty = false;
        }
        StopCoroutine("reloadEnum");
    }

    public void updateAmmoCount()
    {
        textMeshMags.text = "/"+magLeft;
        textMesh.text = ammoLeft + "/" + ammoCapacity;
        if (ammoLeft < 10)
        {
            textMesh.transform.position = new Vector3(62.5f,31f,0f)*1.5f;
        }
        else
        {
            textMesh.transform.position = new Vector3(55f, 31f, 0f) * 1.5f;
        }
    }
}
