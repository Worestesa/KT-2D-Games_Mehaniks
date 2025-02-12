using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TeleportButten : MonoBehaviour
{
    [SerializeField] private int nomberScene;
    
    public void Transition()
    {
        SceneManager.LoadScene(nomberScene);
    }
}
