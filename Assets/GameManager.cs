using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public float globalSpeed = 0f;
    public float acceleration = 0.5f;
    public float maxSpeed = 50f;
    public TextMeshProUGUI speedText;
    public bool speedChanged = false;
    public static GameManager Instance;
    private void Awake()
    {
        if (Instance != null)
        {
            if(Instance != this)
            {
                Instance = this;
            }
        }
        else
        {
            Instance = this;

        }
    }




    private void Update()
    {
        if (globalSpeed < maxSpeed)
        {
            globalSpeed +=  acceleration * Time.deltaTime * Time.deltaTime;
            speedText.text = "Speed " + (int)(globalSpeed * 10f) + " MPH";
            speedChanged = true;
        }
        else if (speedChanged )
        {
            speedChanged = false;
        }
    }

    public void OnEnemyCollide(float speedChange)
    {
        globalSpeed -= speedChange;
        if(globalSpeed < 0) globalSpeed = 0;
        Debug.Log(globalSpeed);
        speedChanged = true;
    }

}
