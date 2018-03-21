using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

namespace QuizGame {

    public class QuizController : MonoBehaviour {

        [Header("Question elements")]
        public RectTransform QuestionPanel;
        public Text QuestionText;

        public Text ButtonAText;
        public Text ButtonBText;
        public Text ButtonCText;
        public Text ButtonDText;

        [Header("Trivia elements")]
        public RectTransform TriviaPanel;
        public Text TriviaText;

        public RectTransform NextQuestionButton;
        public RectTransform EndGameButton;

        [Header("User elements")]
        public Text UsernameText;
        public Text PointsText;

        public Text TimerText;

        private List<QuestionSO> questions;
        private QuestionSO ActiveQuestion;

        [Range(0, 30)]
        public int QuestionTime = 20;

        private float RemainingTime = 0;

        private GameController GameController;

        /// <summary>
        /// Called once the object was created.
        /// </summary>
        private void Awake() {
            Init();

            // Store the instance locally
            GameController = GameController.Instance;
        }

        /// <summary>
        /// Called when the object was instantiated and is reaching its first frame.
        /// </summary>
        void Start() {
            PickQuestion();
        }

        /// <summary>
        /// Update is called once per frame
        /// </summary>
        void Update() {
            
            // Check if we need the timer
            // Basically, check if there is an active question
            if (ActiveQuestion != null) {
                DecreaseTimer();
            }

        }

        private void DecreaseTimer() {
            RemainingTime -= Time.deltaTime;

            UpdateTimer();

            // Check if time expired
            if (RemainingTime <= 0f) {
                EndQuestion();
            }
        }

        private void UpdateTimer() {
            TimerText.text = ((int) RemainingTime).ToString();
        }

        private void PickQuestion() {
            // Select an integer in the range of available questions
            int pick = Random.Range(0, questions.Count);

            // Pick it from the list
            ActiveQuestion = questions[pick];

            // Remove it so it won't get picked again during this game.
            questions.RemoveAt(pick);

            ShowQuestion();
        }

        // Answer button callbacks

        public void onAnswerA() {
            Evaluate(1);
        }

        public void onAnswerB() {
            Evaluate(2);
        }

        public void onAnswerC() {
            Evaluate(3);
        }

        public void onAnswerD() {
            Evaluate(4);
        }

        // Evaluation

        /// <summary>
        /// Evaluates the answer clicked by its index
        /// </summary>
        /// <param name="clickedIndex"></param>
        private void Evaluate(int clickedIndex) {
            if (ActiveQuestion.CorrectAnswerIndex == clickedIndex) {
                Correct();
            } else {
                False();
            }
        }

        /// <summary>
        /// Called if the clicked answer was correct
        /// </summary>
        private void Correct() {
            NextQuestionButton.gameObject.SetActive(true);
            EndGameButton.gameObject.SetActive(false);

            // Add points to player
            GameController.Instance.AddPoints(ActiveQuestion.points);

            // Update points
            PointsText.text = GameController.PlayerData.Points.ToString();

            ShowTrivia();

            ActiveQuestion = null;
        }

        /// <summary>
        /// Called when the user clicked a wrong answer.
        /// </summary>
        private void False() {
            NextQuestionButton.gameObject.SetActive(false);
            EndGameButton.gameObject.SetActive(true);

            ShowTrivia();

            EndQuestion();
        }

        // General methods

        /// <summary>
        /// Object initalizing logic is located here.
        /// </summary>
        void Init() {
            UsernameText.text = GameController.PlayerData.Name;

            questions = new List<QuestionSO>();

            // Load questions from asset folder
            string[] guids = AssetDatabase.FindAssets("l:question");

            foreach (string guid in guids) {
                string path = AssetDatabase.GUIDToAssetPath(guid);

                QuestionSO q = (QuestionSO) AssetDatabase.LoadAssetAtPath(path, typeof(QuestionSO));

                questions.Add(q);
            }
        }

        /// <summary>
        /// Used to show the trivia of the current question.
        /// </summary>
        private void ShowTrivia() {
            QuestionPanel.gameObject.SetActive(false);

            TriviaText.text = ActiveQuestion.trivia;
            TriviaPanel.gameObject.SetActive(true);
        }

        /// <summary>
        /// Shows
        /// </summary>
        private void EndQuestion() {
            // End the round for this question
            ShowTrivia();

            ActiveQuestion = null;
        }

        /// <summary>
        /// Used by the trivia to navigate to the next question.
        /// </summary>
        public void Next() {
            TriviaPanel.gameObject.SetActive(false);

            if (questions.Count > 0) {
                PickQuestion();
            } else {
                // I have no clue
            }
        }

        /// <summary>
        /// Moves back to the main menu
        /// </summary>
        public void EndGame() {
            SceneManager.LoadScene("_MainMenu");
        }

        /// <summary>
        /// Displays the active question
        /// </summary>
        private void ShowQuestion() {
            QuestionText.text = ActiveQuestion.Question;

            ButtonAText.text = ActiveQuestion.AnswerA;
            ButtonBText.text = ActiveQuestion.AnswerB;
            ButtonCText.text = ActiveQuestion.AnswerC;
            ButtonDText.text = ActiveQuestion.AnswerD;

            QuestionPanel.gameObject.SetActive(true);

            RemainingTime = QuestionTime;
        }

    }

}
