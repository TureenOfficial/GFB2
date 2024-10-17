using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class IntroFirst : MonoBehaviour
{   
    public float alpha;
    public SpriteRenderer spriterend;

    void Start()
    {
        StartCoroutine(FadeIn());
    }    
    void Update()
    {
        spriterend.color = new Color(1f,1f,1f,alpha); 
    }
    IEnumerator FadeIn() //logo intro ienum
    {   
        yield return new WaitForSeconds(3f);

        while(alpha < 1f)
        {
            yield return new WaitForSeconds(0.05f);
            alpha = Mathf.Min(alpha + 0.05066f, 1);
        }

        yield return new WaitForSeconds(3f);

        while(alpha > 0f)
        {
            yield return new WaitForSeconds(0.05f);
            alpha = Mathf.Max(alpha - 0.05066f, 0);
        }
        
        if(alpha == 0f)
        {
            yield return new WaitForSeconds(3f);
            SceneManager.LoadScene("MainMenu");
        }

    }
}
