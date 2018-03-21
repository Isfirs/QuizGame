using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace QuizGame {


    /// <summary>
    /// This is the game controller. It will handle question selection, point counting, timings, etc.
    /// </summary>
    public class GameController : MonoBehaviour {

        // Some variables

        // Singleton
        #region Singleton
        private static GameController _instance;
        public static GameController Instance {
            get {
                return _instance;
            }

            private set {
                if (_instance != null) {
                    throw new System.Exception("GameController instance already exists");
                }

                _instance = value;
            }
        }
        #endregion

        private PlayerData _PlayerData;
        public PlayerData PlayerData {
            get {
                return _PlayerData;
            }

            private set {
                if (_PlayerData != null) {
                    throw new System.Exception("GameController instance already set");
                }

                _PlayerData = value;
            }
        }

        /// <summary>
        /// Will be called upon creation.
        /// </summary>
        private void Awake() {
            GameController.Instance = this;

            // Make singleton live forever
            DontDestroyOnLoad(gameObject);
        }

        public void InitPlayer(string name) {
            // Create a new player data container
            PlayerData = new PlayerData(name);
        }

        public void AddPoints(int points) {
            PlayerData.AddPoints(points);
        }

    }

}
