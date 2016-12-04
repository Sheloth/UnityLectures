using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ActionMaster {

    public enum Action {
        Tidy,
        Reset,
        EndTurn,
        EndGame
    }

    private int[] bowls = new int[21];
    private int bowl = 1;

    public static Action NextAction(List<int> pinFalls) {
        ActionMaster actionMaster = new ActionMaster();
        Action currentAction = new Action();

        foreach(int pinFall in pinFalls) {
            currentAction = actionMaster.Bowl(pinFall);
        }

        return currentAction;
    }

    public Action Bowl (int pins) {
        if(pins < 0 || pins > 10) {
            throw new UnityException("Invalid pins amount");
        }

        bowls[bowl - 1] = pins;

        if(bowl >= 21) {
            return Action.EndGame;
        }

        if (bowl == 19 && pins == 10) {
            bowl += 1;
            return Action.Reset;
        }
        else if(bowl == 20) {
            bowl++;
            if (IsSpareInLastFrame() && pins != 0) {
                return Action.Reset;
            }
            else if(Bowl21Awarded()){
                return Action.Tidy;
            }
            else {
                return Action.EndGame;
            }
        }

        if(pins == 10) {
            bowl += (bowl % 2 == 0 ? 1 : 2);
            return Action.EndTurn;
        }

        if(bowl % 2 != 0) {
            bowl += 1;
            return Action.Tidy;
        }
        else {
            bowl += 1;
            return Action.EndTurn;
        }

        throw new UnityException("Invalid ActionMaster state");
    }

    private bool IsSpareInLastFrame() {
        return (bowls[19 - 1] + bowls[20 - 1]) % 10 == 0;
    }

    private bool Bowl21Awarded() {
        return (bowls[19-1] + bowls[20-1] >= 10);
    }
}
