using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : GenericSingleton<GameManager>
{
    [SerializeField] private DevDebugPanel devPanel;

    public BWConfig ConfigRef;
    public List<GameObject> RegisteredSeeds;
    public LayerShaker shakerRef;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
