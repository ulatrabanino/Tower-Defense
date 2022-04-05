using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    public List<Enemy> alive;
    public Enemy target;
    public float damage;
    public Transform twr;
    private LineRenderer lazer;

    // Start is called before the first frame update
    void Start()
    {
        lazer = GetComponent<LineRenderer>();
        lazer.SetPosition(0, this.transform.position);
    }

    // Update is called once per frame
    void Update()
    {
        if (target)
        {
            lazer.SetPosition(1, target.transform.position);
            target.onHit(damage * Time.deltaTime);
        }else if(lazer.GetPosition(1) != this.transform.position)
        {
            lazer.SetPosition(1, this.transform.position);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Enemy>() != null)
        {
            Enemy newEnemy = other.GetComponent<Enemy>();
            alive.Add(newEnemy);
            newEnemy.death.AddListener(delegate { BookKeeping(newEnemy); });
            if(target == null)
            {
                target = newEnemy;
            }
        }
    }

    void OnTriggerExit(Collider other)
    {
        if(other.GetComponent<Enemy>() != null)
        {
            Enemy oldEnemy = other.GetComponent<Enemy>();
            BookKeeping(oldEnemy);
        }
    }

    void BookKeeping(Enemy enemy)
    {
        alive.Remove(enemy);
        target = (alive.Count > 0) ? alive[0] : null;
    }
}
