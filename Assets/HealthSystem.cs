using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class HealthSystem : MonoBehaviour
{
    [FormerlySerializedAs("health")]
    public float maxHealth;
    float currentHealth;

    public GameObject healthBarPrefab;

    public GameObject deathEffectPrefab;

    HealthBar myHealthBar;
    
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        //Create health panel ON the canvas
        GameObject healthBarObject = Instantiate(healthBarPrefab, References.canvas.transform);
        myHealthBar = healthBarObject.GetComponent<HealthBar>();
    }
    
    public void TakeDamage(float damageAmount)
    {
        currentHealth -= damageAmount;
        if (currentHealth <= 0)
        {
            if (deathEffectPrefab != null)
            {
                Instantiate(deathEffectPrefab, transform.position + Vector3.down*0.5f,transform.rotation);
            }
            Destroy(gameObject);
        }
    }

    private void OnDestroy()
    {
        if (myHealthBar != null)
            Destroy(myHealthBar.gameObject);    
    }

    // Update is called once per frame
    void Update()
    {
        //Make our healthbar reflect our health
        myHealthBar.ShowHealthFraction(currentHealth/maxHealth);
        //Make our healthbar follow us
        myHealthBar.transform.position = Camera.main.WorldToScreenPoint(transform.position + Vector3.up*2);
        
    }
}
