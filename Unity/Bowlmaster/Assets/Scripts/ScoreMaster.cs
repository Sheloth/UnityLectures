using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ScoreMaster {

    public static List<int> ScoreCumulative(List<int> rolls) {
        List<int> cumulativeScores = new List<int>();
        int runningTotal = 0;

        foreach(int frameScore in ScoreFrames(rolls)) {
            runningTotal += frameScore;
            cumulativeScores.Add(runningTotal);
        }

        return cumulativeScores;
    }

	public static List<int> ScoreFrames (List<int> rolls) {
        List<int> frames = new List<int>();

        for (int i = 1; i < rolls.Count; i += 2) {
            // Prevents 11 frame
            if (frames.Count == 10) {
                break;
            }

            // Normal open frame
            if (rolls[i - 1] + rolls[i] < 10) {
                frames.Add(rolls[i - 1] + rolls[i]);
            }

            // Ensure at least 1 look-ahead
            if (rolls.Count - i > 1) {
                // Strike
                if (rolls[i - 1] == 10) {
                    i--;
                    frames.Add(10 + rolls[i + 1] + rolls[i + 2]);
                }
                else  if(rolls[i - 1] + rolls[i] == 10) {
                    frames.Add(10 + rolls[i + 1]);
                }
            }
        }

        return frames;
    }


}
