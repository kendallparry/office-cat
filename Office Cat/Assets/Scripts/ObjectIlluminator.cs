using UnityEngine;
using System.Collections;

public class ObjectIlluminator : MonoBehaviour
{
    public GameObject glow;
    private Rigidbody2D rb;
    private bool hasGlowed = false;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        glow.SetActive(false);
    }

    void Update()
    {
        Collider2D hit = Physics2D.OverlapCircle(transform.position, 2f, ~0);

        if (hit!=null)
        {
            if(hit.CompareTag("player")){
                if (!hasGlowed){
                    StartCoroutine(lightUp());
                    hasGlowed = true; 
                }
            }

            else{
                glow.SetActive(false);
                hasGlowed = false;
            }
            
        }
    }
    
    private IEnumerator lightUp(){
        for (int i=0; i<2; i++){
            glow.SetActive(true);
            yield return new WaitForSeconds(0.15f);
            glow.SetActive(false);
            yield return new WaitForSeconds(0.15f);
        }
        glow.SetActive(true);
    }

}

