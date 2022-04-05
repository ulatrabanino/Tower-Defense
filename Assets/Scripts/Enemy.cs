using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.Events;

public class Enemy : MonoBehaviour
{
    public Pathway path;
    private Waypoint[] enemyPath;

    public int drops;
    public Image hpBar;
    public float maxHP;
    private float HP;
    public float speed = 3f;

    private int index = 0;
    private Vector3 nextPoint;
    private bool stop = false;

    public UnityEvent death;

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
        hpBar.GetComponent<RectTransform>().sizeDelta = new Vector2(50 * (HP / maxHP), 10);
        if (HP <= 0)
        {
            death.Invoke();
            death.RemoveAllListeners();
            GameManager.manager.addCoins(drops);
            Destroy(this.gameObject);
        }
    }
}
