using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mimicBehavior : MonoBehaviour
{
   internal bool isAgro;
    GameObject child;
  [SerializeField] private GameObject damageWave;


    private void Start()
    {
        child = transform.GetChild(0).gameObject;
    }

    internal void startAgroAndAttack()
    {

        StartCoroutine(attack(randomGenerationInt(2, 6)));

    }
  
/*    private void FixedUpdate()
    {
        if(isAgro)
        {
            gameObject.transform.parent.gameObject.transform.localScale = new Vector3(gameObject.transform.parent.transform.localScale.x * Time.fixedDeltaTime * 51 , gameObject.transform.parent.transform.localScale.y , 1f);


            

        }
    }
*/

      IEnumerator attack(int time)
    {
        
            yield return new WaitForSeconds(time);
            var damage = Instantiate(damageWave);
            damage.transform.SetParent(child.transform);
            damage.transform.position = gameObject.transform.GetChild(0).transform.position;
            

        
       
    } 
    static int randomGenerationInt(int firtst, int second)
    {
        System.Random rnd = new System.Random();

       return rnd.Next(firtst, second);


    }
    
}
