
using System;
using System.Configuration;
using System.Xml;
using NUnit.Framework.Internal;
using UnityEditor;
using UnityEditor.TestTools.TestRunner.Api;
using UnityEngine;

[InitializeOnLoad]
public class RunAllTests
{
    private static readonly TestRunnerApi TestRunnerApi;

    static RunAllTests()
    {
        TestRunnerApi = ScriptableObject.CreateInstance<TestRunnerApi>();
        TestRunnerApi.RegisterCallbacks(new MyCallbacks());
    }
    

    public static void RunPlayModeTests()
    {
        RunTests(TestMode.PlayMode);
    }
    
    public static void RunEditModeTests()
    {
        RunTests(TestMode.EditMode);
    }
    
    
    private static void RunTests(TestMode testMode)
    {
        var filter = new Filter()
        { 
            testMode = testMode
        };

       
        TestRunnerApi.RetrieveTestList(testMode, (testRoot) =>
        {
            Debug.Log($"Tree contains {testRoot.TestCaseCount} tests.");
        });
        TestRunnerApi.Execute(new ExecutionSettings(filter));
    }

}

class MyCallbacks : ICallbacks
{
    
    public void RunStarted(ITestAdaptor testsToRun)
    {
       //Debug.Log($"{testsToRun.Name} + {testsToRun.Method}");
    }

    public void RunFinished(ITestResultAdaptor result)
    {
        //Debug.Log($"{result.Name} + {result.ResultState}");
    }

    public void TestStarted(ITestAdaptor test)
    {
     //  Debug.Log($"{test.Name} + {test.Method}");
    }

    public void TestFinished(ITestResultAdaptor result)
    {
        
        //Debug.Log($"{result.Name} + {result.ResultState}");
        
        if (!result.HasChildren)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load("Assets/StreamingAssets/TestResults.xml");
            XmlElement newTest = doc.CreateElement(result.Name);
            newTest.InnerText = result.ResultState;
            if (doc.DocumentElement != null) 
                doc.DocumentElement.AppendChild(newTest);
            doc.Save("Assets/StreamingAssets/TestResults.xml");
            Debug.Log($"{result.Name} + {result.ResultState}");
        }

    }
}

