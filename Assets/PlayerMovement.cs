using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    private PlayerInputHandler input;
    float moveDir;
    [SerializeField] float playerSpeed;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Awake()
    {
        input = GetComponent<PlayerInputHandler>();
        input.playerMoved += OnPlayerMove;
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        transform.position += new Vector3(moveDir * playerSpeed, 0, 0);
    }

    private void OnPlayerMove(Vector2 dir)
    {
        moveDir = dir.normalized.x;
    }
}
