using UnityEngine;
using UnityEditor;
using NUnit.Framework;

public class ActionMasterTest {

    private const ActionMaster.Action endTurn = ActionMaster.Action.EndTurn;
    private const ActionMaster.Action endGame = ActionMaster.Action.EndGame;
    private const ActionMaster.Action tidy = ActionMaster.Action.Tidy;
    private const ActionMaster.Action reset = ActionMaster.Action.Reset;

    private ActionMaster actionMaster;


    [SetUp]
    public void Setup () {
        actionMaster = new ActionMaster();
    }

    [Test]
    public void T00FailingTest() {
        Assert.AreEqual(1, 1);
    }

    [Test]
    public void T01OneStrikeReturnsEndTurn() {
        
        Assert.AreEqual(endTurn, actionMaster.Bowl(10));
    }

    [Test]
    public void T02Bowl8ReturnsTidy() {
        Assert.AreEqual(tidy, actionMaster.Bowl(8));
    }

    [Test]
    public void T03Bowl2Then8ReturnsEndTurn() {
        Assert.AreEqual(tidy, actionMaster.Bowl(2));
        Assert.AreEqual(endTurn, actionMaster.Bowl(8));
    }

    [Test]
    public void T04StrikeInLastFrameReturnsResets() {
        int[] rolls = new int[18]{ 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 };

        foreach(int roll in rolls) {
            actionMaster.Bowl(roll);
        }

        Assert.AreEqual(reset, actionMaster.Bowl(10));
    }

    [Test]
    public void T05SpareInLastFrameReturnsResets() {
        int[] rolls = new int[18] { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 };

        foreach (int roll in rolls) {
            actionMaster.Bowl(roll);
        }
        Assert.AreEqual(tidy, actionMaster.Bowl(3));
        Assert.AreEqual(reset, actionMaster.Bowl(7));
    }

    [Test]
    public void T06Bowl21ReturnsEndGame() {
        int[] rolls = new int[16] { 8, 2, 7, 3, 3, 4, 10, 2, 8, 10, 10, 8, 0, 10, 8, 2 };

        foreach (int roll in rolls) {
            actionMaster.Bowl(roll);
        }

        Assert.AreEqual(endGame, actionMaster.Bowl(9));
    }

    [Test]
    public void T07GameWithoutBowl21ReturnsEndGame() {
        int[] rolls = new int[19] { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 };

        foreach (int roll in rolls) {
            actionMaster.Bowl(roll);
        }

        Assert.AreEqual(endGame, actionMaster.Bowl(5));
    }

}
