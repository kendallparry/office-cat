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


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            lightUp();
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            glow.SetActive(false);
        }

    }
    void Update()
    {
        //float distance = Vector3.Distance(player.transform.position, transform.position);

        if (!hasGlowed)
        {
            StartCoroutine(lightUp());
            hasGlowed = true; // Ensure it only happens once
        }
    }
    
    private IEnumerator lightUp(){
        for (int i=0; i<2; i++){
            glow.SetActive(true);
            yield return new WaitForSeconds(0.25f);
            glow.SetActive(false);
            yield return new WaitForSeconds(0.25f);
        }
        glow.SetActive(true);
    }
}

