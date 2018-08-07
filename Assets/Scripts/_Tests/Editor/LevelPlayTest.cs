using UnityEngine;
using UnityEditor;
using UnityEngine.TestTools;
using NUnit.Framework;
using System.Collections;

public class LevelPlayTest {

	[Test]
	public void LevelPlayTestSimplePasses() {
        //var levelPlayer = new LevelPlayer();
        /*
         * Use Case :
         * Je veux pouvoir donner les infos d'un level et faire play.
         * infos : position et nature des element du LD : ennemis, blocks et autres killzones. liste des positions et des "objets" à faire apparaitre.
         * play : levelplayer.Play() (la position est a 0 par défaut).
         * il faut update :
         *  //- le décor
         *  - le ld
         *  - le player
         *
         */



	}

    [Test]
    public void TestPlayerMove()
    {

        /*
         * 
         * The character can :
         * - Move horizontally and vertically in the boundaries of the game area (which will be the screen at first)
         * - Fire at a certain rate with its main weapon dealing a certain amount of damage.
         * - drop a bomb to clean screen
         */

        /*
         * The move is composed of retrieving raw input normalised vector2. Transforming this normalised information into a new position. update the feedback
         */

        /*
         * The fire is composed of retrieving boolean input, triggering or not the bullet, place the new bullet, determine bullet damage capacity, displaying feedback
         */

        /*
         * The death is triggered by damage
         */


        //
    }

    [Test]
    public void TestSavePlayerStartPosition ()
    {
            

    }


    // A UnityTest behaves like a coroutine in PlayMode
    // and allows you to yield null to skip a frame in EditMode
    [UnityTest]
	public IEnumerator LevelPlayTestWithEnumeratorPasses() {
		// Use the Assert class to test conditions.
		// yield to skip a frame
		yield return null;
	}
}
