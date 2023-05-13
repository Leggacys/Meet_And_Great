using System.Collections;
using NUnit.Framework;
using UnityEditor.TestTools.TestRunner.Api;
using UnityEngine;
using UnityEngine.TestTools;

public class MovementTest
{
   /// <summary>
   /// Play Mode Tests
   /// </summary>
   /// <returns></returns>
    
    [UnityTest]
    public IEnumerator MovementTestWithEnumeratorPasses()
    {
        GameObject player = new GameObject();
        Movement move = player.AddComponent<Movement>();

        move.Move(Constants.EastDirection);

        Assert.AreEqual(new Vector3(1, 0, 0), player.transform.position);
        yield return null;
    }


    [UnityTest]
    public IEnumerator TweenMovementTestWithEnumeratorPasses()
    {
        GameObject player = new GameObject();
        Movement move = player.AddComponent<Movement>();

        move.TweenMovement(Constants.EastDirection);

        yield return new WaitForSeconds(move.movementDuration);

        Assert.AreEqual(new Vector3(1, 0, 0), player.transform.position);
    }

}
