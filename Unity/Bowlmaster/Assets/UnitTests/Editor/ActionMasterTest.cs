using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEditor;
using NUnit.Framework;

public class ActionMasterTest {

    private const ActionMaster.Action endTurn = ActionMaster.Action.EndTurn;
    private const ActionMaster.Action endGame = ActionMaster.Action.EndGame;
    private const ActionMaster.Action tidy = ActionMaster.Action.Tidy;
    private const ActionMaster.Action reset = ActionMaster.Action.Reset;

    private List<int> pinFalls;

    [SetUp]
    public void Setup () {
        pinFalls = new List<int>();
    }

    [Test]
    public void T00PassingTest() {
        Assert.AreEqual(1, 1);
    }

    [Test]
    public void T01OneStrikeReturnsEndTurn() {
        pinFalls.Add(10);
        Assert.AreEqual(endTurn, ActionMaster.NextAction(pinFalls));
    }

    [Test]
    public void T02Bowl8ReturnsTidy() {
        pinFalls.Add(8);
        Assert.AreEqual(tidy, ActionMaster.NextAction(pinFalls));
    }

    [Test]
    public void T03Bowl2Then8ReturnsEndTurn() {
        int[] rolls = { 2, 8 };
        
        Assert.AreEqual(endTurn, ActionMaster.NextAction(rolls.ToList()));
    }

    [Test]
    public void T04StrikeInLastFrameReturnsResets() {
        int[] rolls = new int[]{ 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 10 };

        Assert.AreEqual(reset, ActionMaster.NextAction(rolls.ToList()));
    }
 
    [Test]
    public void T05SpareInLastFrameReturnsResets() {
        int[] rolls = new int[] { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 3, 7 };

        Assert.AreEqual(reset, ActionMaster.NextAction(rolls.ToList()));
    }

    [Test]
    public void T06Bowl21ReturnsEndGame() {
        int[] rolls = new int[] { 8, 2, 7, 3, 3, 4, 10, 2, 8, 10, 10, 8, 0, 10, 8, 2, 9 };

        Assert.AreEqual(endGame, ActionMaster.NextAction(rolls.ToList()));
    }

    [Test]
    public void T07GameWithoutBowl21ReturnsEndGame() {
        int[] rolls = new int[] { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 5 };

        Assert.AreEqual(endGame, ActionMaster.NextAction(rolls.ToList()));
    }

    [Test]
    public void T08StrikeInTheLastFrameThenNotAllPinsReturnsTidy() {
        int[] rolls = new int[] { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 10, 5 };

        Assert.AreEqual(tidy, ActionMaster.NextAction(rolls.ToList()));
    }

    [Test]
    public void T09StrikeInTheLastFrameThenAnyPinReturnsTidy() {
        int[] rolls = new int[] { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 10, 0 };

        Assert.AreEqual(tidy, ActionMaster.NextAction(rolls.ToList()));
    }

    [Test]
    public void T10SpareWith10PinsThenBowlReturnTidy() {
        int[] rolls = new int[] { 0, 10, 2 };
        Assert.AreEqual(tidy, ActionMaster.NextAction(rolls.ToList()));
    }

    [Test]
    public void T11ThreeStrikesInTheEndReturnsEndGame() {
        int[] rolls = new int[] { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 10, 10, 10 };

        Assert.AreEqual(endGame, ActionMaster.NextAction(rolls.ToList()));
    }

    [Test]
    public void T12SpareInTheLastFrameNotAllPinsReturnsEndGame() {
        int[] rolls = new int[] { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 5, 5, 5 };

        Assert.AreEqual(endGame, ActionMaster.NextAction(rolls.ToList()));
    }
}
