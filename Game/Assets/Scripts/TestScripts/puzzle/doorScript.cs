using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class doorScript : MonoBehaviour
{
    public GameObject childGO;
    internal bool isStartCor, corIsNow;
    private Rigidbody2D door;
    private Vector2 objPos1, objPoos2, objPos3;
    private GameObject child1, child2, child3;
    private GameObject[] allChilds;
    private Vector2[] allChildPos;
         

    private void Start()
    {
        allChilds = new GameObject[] { child1, child2, child3 };
        for (int i = 0; i < gameObject.transform.childCount; i++)
        { 
            allChilds[i] = gameObject.transform.GetChild(i).gameObject;
        }
        getPositionChild();


        door = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (isStartCor && corIsNow == false)
        {
            StartCoroutine(startTimer());

            isStartCor = false;
        }

        if (gameObject.transform.childCount == 0)
        {
            door.constraints = RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezeRotation;
            door.velocity = new Vector2(0, 16);
        }
    }

    internal IEnumerator startTimer()
    {

        corIsNow = true;

        yield return new WaitForSeconds(5f);

        if(gameObject.transform.childCount > 0)
        {
            spawnObjects();
        }

        corIsNow = false;
       
    }

    void getPositionChild()
    {
        
        allChildPos = new Vector2[] { objPos1, objPoos2, objPos3 };


        for (int i = 0; i <= 2; i++)
        {
            allChildPos[i] = allChilds[i].transform.position;
        }
      
    }

    void spawnObjects()
    {
        for (int i = 0; i <= 2; i++)
        {
            if(allChilds[i] == null)
            {
               var clone = Instantiate(childGO, allChildPos[i], Quaternion.identity);
                clone.transform.SetParent(gameObject.transform);
                clone.transform.localScale = new Vector2(3, 0.4f);
                allChilds[i] = clone;
            }
        }
    }
}
