using UnityEngine;

public class GameManager : MonoBehaviour
{
    // Field
    public int WhiteDice;

    // MonoBehavior
    private void Awake()
    {
        Init();
    }

    // My Functions
    private void Init()
    {
        WhiteDice = Random.Range(1, 6);
    }
}
