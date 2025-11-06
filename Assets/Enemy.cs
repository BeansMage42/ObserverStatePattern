using System.Collections;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public CarStates currentState;
    [SerializeField] float maxOffset;
    private Vector3 origin;
    [SerializeField] float rotateSpeed;

    private void Start()
    {
        currentState = CarStates.Driving;
        origin = transform.position;
        StartCoroutine(DrivingMotion());
        
    }

    public void SetState(CarStates state)
    {
        Debug.Log("setting state");
        if (currentState != CarStates.Dying)
        {
            if ((currentState & state) == 0)
            {
                StopAllCoroutines();
                switch (state) 
                {
                    case CarStates.Dying:
                        SetDying();
                        break;

                }
            }
        }
    }

    private void SetDying()
    {
        
        currentState = CarStates.Dying;
        
        StartCoroutine(SpinningMotion());

    }
    private IEnumerator DrivingMotion()
    {
        float positionOffset;
        float t = 0;
        while (true) 
        {
            t += Time.deltaTime;
            positionOffset = Mathf.PingPong(t,maxOffset *2) - maxOffset;
            transform.position = origin + new Vector3(positionOffset , 0, 0);
            yield return null;
        }
    }
    private IEnumerator SpinningMotion() 
    {
        GameManager.Instance.OnEnemyCollide(10);
        float timer = 0;
        while (timer < 2)
        {
            timer += Time.deltaTime;
            transform.Rotate(0, 0, rotateSpeed);
            yield return null;
        }
        currentState = CarStates.Dead;
    }

}
