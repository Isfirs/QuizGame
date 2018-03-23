using UnityEngine;

namespace QuizGame {

    /// <summary>
    /// This is a template object that can be created via editor functionality.
    /// </summary>
    public class Question : ScriptableObject {

        public string QuestionText = "Question text";

        public CategoryEnum Category = CategoryEnum.ENGLISH;

        public LevelEnum Level = LevelEnum.EASY;

        public string AnswerA;

        public string AnswerB;

        public string AnswerC;

        public string AnswerD;

        [TextArea]
        public string trivia;

        [Range(1, 4)]
        public int CorrectAnswerIndex;

    }

    public enum CategoryEnum {

        ENGLISH, HISTORY, SCIENCE

    }

    public enum LevelEnum {

        EASY,
        MEDIUM,
        HARD

    }

}
