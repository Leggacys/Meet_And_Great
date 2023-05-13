using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class DirectionsTest
{
    
    /// <summary>
    /// Edit Mode Tests
    /// </summary>
    
    [Test]
    public void NortDirection()
    {
        Assert.AreEqual(new Vector3(0, 1, 0), Constants.NorthDirection);
    }
    
    [Test]
    public void SouthDirection()
    {
        Assert.AreEqual(new Vector3(0, -1, 0),Constants.SouthDirection);
    }
    
    [Test]
    public void EastDirection()
    {
        Assert.AreEqual(new Vector3(1, 0, 0),Constants.EastDirection);
    }
    
    [Test]
    public void WestDirection()
    {
        Assert.AreEqual(new Vector3(-1, 0, 0),Constants.WestDirection);
    }
    
    
}
