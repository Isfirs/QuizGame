using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace QuizGame {

    /// <summary>
    /// Player container
    /// </summary>
    public class PlayerData {

        private string name;
        public string Name {
            get {
                return name;
            }

            private set {
                name = value;
            }
        }

        private int points;
        public int Points {
            get {
                return points;
            }

            private set {
                points = value;
            }
        }

        public PlayerData(string name) {
            this.name = name;
            this.points = 0;
        }

        public void AddPoints(int points) {
            this.points += points;
        }

        public void Reset() {
            this.points = 0;
        }

    }

}
