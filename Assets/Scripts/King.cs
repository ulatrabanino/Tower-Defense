using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class King : MonoBehaviour
{
    public float maxHP;
    private float HP;
    // Start is called before the first frame update
    void Start()
    {
        HP = maxHP;
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("ow");
        if (collision.collider.tag == "Enemy")
        {
            OnHit(1);
        }
    }
    public void OnHit(float damage)
    {
        HP -= damage;
        if(HP <= 0)
        {
            Destroy(this.gameObject);
        }
    }
}
