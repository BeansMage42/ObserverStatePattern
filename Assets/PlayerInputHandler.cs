using System;
using UnityEngine;
using UnityEngine.InputSystem;
public class PlayerInputHandler : MonoBehaviour
{
    public Action<Vector2> playerMoved;
   public void PlayerMove(InputAction.CallbackContext context)
    {

        playerMoved?.Invoke(context.ReadValue<Vector2>());

    }
}
