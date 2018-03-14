using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

namespace QuizGame {

    public class MenuController : MonoBehaviour {

        public Text UsernameInput;

        private void Start() {
            Debug.Log("Start");

            if (GameController.Instance.PlayerData != null) {
                Debug.Log("Filling text");

                UsernameInput.text = GameController.Instance.PlayerData.Name;
            }
        }

        /// <summary>
        /// Start button callback
        /// </summary>
        public void onStartButton() {
            Debug.Log("onStartButton()");

            Debug.Log("Username: " + UsernameInput.text);

            // Check if username is entered
            if (UsernameInput.text.Length > 0) {
                GameController.Instance.InitPlayer(UsernameInput.text);

                SceneManager.LoadScene("Game");
            } 
        }

    }

}
