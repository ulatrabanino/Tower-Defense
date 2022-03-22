using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Pathway path;
    private Waypoint[] enemyPath;

    public int drops;
    public float maxHP;
    private float HP;
    public float speed = 3f;

    private int index = 0;
    private Vector3 nextPoint;
    private bool stop = false;

    // Start is called before the first frame update
    void Start()
    {
        HP = maxHP;
        enemyPath = path.pathway;
        transform.position = enemyPath[index].transform.position;
        Recalculate();
    }

    // Update is called once per frame
    void Update()
    {
        if (!stop)
        {
            if((transform.position - enemyPath[index + 1].transform.position).magnitude < .1f)
            {
                index = index + 1;
                Recalculate();
            }
            Vector3 move = nextPoint * Time.deltaTime * speed;
            transform.Translate(move);
        } 
    }

    void Recalculate()
    {
        if (index < enemyPath.Length - 1)
        {
            nextPoint = (enemyPath[index + 1].transform.position - enemyPath[index].transform.position).normalized;
        }
        else
        {
            stop = true;
        }
    }

    public void onHit(float damage)
    {
        HP -= damage;
        if (HP <= 0)
        {
            GameManager.manager.addCoins(drops);
            Destroy(this.gameObject);
        }
    }
}
