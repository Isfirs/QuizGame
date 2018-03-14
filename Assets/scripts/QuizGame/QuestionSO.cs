using UnityEngine;

namespace QuizGame {

    /// <summary>
    /// This is a template object that can be created via editor functionality.
    /// </summary>
    public class QuestionSO : ScriptableObject {

        public string Question = "Question text";

        public string AnswerA;

        public string AnswerB;

        public string AnswerC;

        public string AnswerD;

        [TextArea]
        public string trivia;

        public int CorrectAnswerIndex;

        public int points = 10;

    }

    

}
