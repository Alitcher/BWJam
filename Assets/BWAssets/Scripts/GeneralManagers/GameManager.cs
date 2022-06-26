using BWAssets.Utils;
using System.Collections.Generic;
using UnityEngine;

namespace BWAssets.Game
{
    public class GameManager : GenericSingleton<GameManager>
    {
        [SerializeField] private DevDebugPanel devPanel;
        [SerializeField] private CameraManager camManagerRef;

        public BWConfig ConfigRef;
        public List<GameObject> RegisteredSeeds;
        public LayerShaker shakerRef;
        public GameProgress CurrentProgress;

        // Start is called before the first frame update
        void Start()
        {
            CurrentProgress = GameProgress.JustStarted;
            camManagerRef.CheckCurrentProgress(CurrentProgress);
        }

        // Update is called once per frame
        void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                if (CurrentProgress < GameProgress.Max)
                    CurrentProgress++;
                camManagerRef.CheckCurrentProgress(CurrentProgress);
            }
        }
    }
}

