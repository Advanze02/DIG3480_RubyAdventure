using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//Alec Jerard Prestoza
public class StaminaBar : MonoBehaviour
{
    public Text staminaText;

    public float maxStamina = 100f;
    public float currentStamina;
    public float staminaDepletionRate = 10f;
    public float staminaRegenRate = 10f;
     public float normalSpeed = 5f; // Adjust the normal speed as needed
    public float slowedSpeed = 2.5f; // Adjust the slowed speed as needed

    void Start()
    {
        currentStamina = maxStamina;
        UpdateStamina();
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D))
        {
            if (currentStamina > 0)
            {
                currentStamina -= staminaDepletionRate * Time.deltaTime;
                currentStamina = Mathf.Clamp(currentStamina, 0f, maxStamina);
                UpdateStamina();
                MovePlayer(normalSpeed);
            }
            else
            {
                // Player has no stamina, slow down movement
                MovePlayer(slowedSpeed);
            }
        }
        else
        {
            // If the player is not moving, regenerate stamina
            currentStamina += staminaRegenRate * Time.deltaTime;
            currentStamina = Mathf.Clamp(currentStamina, 0f, maxStamina);
            UpdateStamina();
        }
    }

    void MovePlayer(float speed)
    {
        // Implement your player movement logic here, adjusting speed as needed
        float horizontalMovement = Input.GetAxis("Horizontal");
        float verticalMovement = Input.GetAxis("Vertical");

        Vector2 movement = new Vector2(horizontalMovement, verticalMovement) * speed * Time.deltaTime;
        transform.Translate(movement);
    }

    void UpdateStamina()
    {
        staminaText.text = "Stamina: " + currentStamina.ToString();
    }
}
