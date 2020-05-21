using BS_Utils.Utilities;
using IPA;
using System;
using System.Linq;
using UnityEngine;

namespace WideBombs
{
    [Plugin(RuntimeOptions.SingleStartInit)]
    public class Plugin
    {
        private BeatmapObjectManager beatmapObjectManager;

        [Init]
        public void Init(IPA.Logging.Logger logger)
        {
            Logger.log = logger;
        }

        [OnStart]
        public void OnStart()
        {
            BSEvents.gameSceneLoaded += gameSceneLoaded;
        }

        private void gameSceneLoaded()
        {
            beatmapObjectManager = Resources.FindObjectsOfTypeAll<BeatmapObjectManager>().FirstOrDefault();

            beatmapObjectManager.noteWasSpawnedEvent += noteWasSpawnedEvent;
        }

        private void noteWasSpawnedEvent(NoteController note)
        {
            if (note.noteData.noteType == NoteType.Bomb)
            {
                note.noteTransform.localScale = new Vector3(1f, 3f, 1f);
            }
        }

        [OnExit]
        public void OnExit(){}
    }
}
