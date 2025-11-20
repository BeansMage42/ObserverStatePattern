using NUnit.Framework;
using UnityEngine;
using System.Collections.Generic;

public class CommandInvoker : MonoBehaviour
{
    public List<BaseCommand> executedCommands = new List<BaseCommand> ();

    public static CommandInvoker Instance;

    private void Awake()
    {
        if (Instance != null)
        {
            if (Instance != this)
            {
                Destroy(gameObject);
            }
        }
        else
        {
            Instance = this;
        }
    }


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void ExectuteCommand(BaseCommand command)
    {
        command.Exectute();
        executedCommands.Add(command);
    }
}
