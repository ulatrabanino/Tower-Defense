using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class King : MonoBehaviour
{
    public float maxHP;
    private float HP;

    public GameObject restart;
    // Start is called before the first frame update
    void Start()
    {
        HP = maxHP;
        restart.gameObject.SetActive(false);
    }


    private void OnTriggerEnter(Collider collision)
    {
        Debug.Log("ow");
        if (collision.tag == "Enemy")
        {
            OnHit(1);
        }
    }
    public void OnHit(float damage)
    {
        HP -= damage;
        if(HP <= 0)
        {
            restart.gameObject.SetActive(true);
            Destroy(this.gameObject,1);
        }
    }
}
