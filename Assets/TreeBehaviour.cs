using UnityEngine;

public class TreeBehaviour : MonoBehaviour
{
    private float speed;

    private void OnEnable()
    {
        speed = GameManager.Instance.globalSpeed;
    }
    // Update is called once per frame
    void Update()
    {
        if (GameManager.Instance.speedChanged)
        {
            speed = GameManager.Instance.globalSpeed;
        }
        transform.position += Vector3.down * speed * Time.deltaTime;

        if(transform.position.y < -8)
        {
            ObjectPool.Instance.ReturnTreeToPool(gameObject);
        }
    }
}
