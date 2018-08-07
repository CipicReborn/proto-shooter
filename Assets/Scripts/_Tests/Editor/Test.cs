using UnityEngine;
using UnityEditor;
using UnityEngine.TestTools;
using NUnit.Framework;
using System.Collections;
using System;

public class Test {

	[Test]
	public void TestSimplePasses() {

        // The environment should be constitued of scrolling layers at different speeds based on the speed of the ship and their distance.
        // The faster with the ship's speed and the slower with the distance to the camera.
        // One of the layers is the game layer which contains the player and the interactive elements
        // In each layer there is elements that can have a speed in the layer's referential.
        // Only the elements of the game layer are interactive.
        // The player can move in the layer in the boundaries of the camera
        // The game area is defined by the visible portion of the game layer
        // The level is a sequence of blocks. At the end of a block, another block is started and/or the player can exit the level.
        // A ship can fire bullets through various guns.
        // The players can move freely in the game area, always looking to the right.
        // The enemies and obstacles enters the interactive zone from the right of the game area.
    }

    [Test]
    public void TestDropInLayer ()
    {
        //IScrollingLayer layer = new GameObject().AddComponent<Layer>();
        //layer.ScrollingSpeed = new Vector2(5, 0);
        //var element = new GameObject();
        //layer.AddAtPosition(element.transform, Vector3.zero);
        //layer.Tick(1);
        //Assert.AreEqual(layer.ScrollingSpeed, layer.GetDistanceScrolled());
    }

    [Test]
    public void TestLayerScroller()
    {
        //var layer = new Layer();
        //var speed = new Vector2(5, 0);
        //var layer = new Layer();
        //var speed = new Vector2(5, 0);
        //scroller.RegisterLayer(layer, speed);
        //scroller.InitialiseLayers();
        //scroller.Tick(1);
        //Assert.AreEqual

    }
}
