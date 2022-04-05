using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseDestroy : MonoBehaviour
{
    public GameObject tower;
    public GameObject plane;
    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("click");
            RaycastHit click;
            Ray mouse = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(mouse, out click))
            {
                BoxCollider boxCollider = click.collider as BoxCollider;
                if (boxCollider.tag == "Enemy")
                {
                    boxCollider.gameObject.GetComponent<Enemy>().onHit(1);
                    Debug.Log("Ouch!");
                }
                if(boxCollider.tag == "EmptyLot" && GameManager.manager.coinAmount >= 10)
                {
                    GameManager.manager.addCoins(-10);
                    boxCollider.transform.gameObject.SetActive(false);
                    Instantiate(tower, boxCollider.transform.position, Quaternion.identity, plane.transform);
                }
            }
        }
    }
}
