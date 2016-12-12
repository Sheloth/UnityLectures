using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class ScoreDisplay : MonoBehaviour {

    public Text[] rollsTexts;
    public Text[] framesTexts;

    void Start () {
        foreach(Text frame in framesTexts) {
            frame.text = "";
        }

        foreach (Text roll in rollsTexts) {
            roll.text = "";
        }
    }

    static public string FormatRolls(List<int> rolls) {
        string output = "";

        for (int i = 0; i < rolls.Count; i++) {
            int box = output.Length + 1;

            
            if (rolls[i] == 0) { // Zero in frame
                output += "-";
            }
            else if ((box % 2 == 0 || box == 21) && rolls[i - 1] + rolls[i] == 10) { // Spare
                output += "/";
            } 
            else if (box >= 19 && rolls[i] == 10) { // Strike in 10 f
                output += "X";
            }
            else if (rolls[i] == 10) { // Strike in frames 1-9
                output += "X ";
            }
            else {
                output += rolls[i].ToString();
            }
        }

        return output;
    }

    public void FillFrames(List<int> frames) {
        for (int i = 0; i < frames.Count; ++i) {
            framesTexts[i].text = frames[i].ToString();
        }
    }

    public void FillRolls (List<int> rolls) {
        string scoresString = FormatRolls(rolls);
        for(int i = 0; i < scoresString.Length; i++) {
            rollsTexts[i].text = scoresString[i].ToString();
        }
    }
}
