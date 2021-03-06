using System;
/// <summary>
///Delegate
/// </summary>

public class AttributeTargetsDelegate
{
    public static int Main()
    {
        AttributeTargetsDelegate AttributeTargetsDelegate = new AttributeTargetsDelegate();

        TestLibrary.TestFramework.BeginTestCase("AttributeTargetsDelegate");
        if (AttributeTargetsDelegate.RunTests())
        {
            TestLibrary.TestFramework.EndTestCase();
            TestLibrary.TestFramework.LogInformation("PASS");
            return 100;
        }
        else
        {
            TestLibrary.TestFramework.EndTestCase();
            TestLibrary.TestFramework.LogInformation("FAIL");
            return 0;
        }
    }
    public bool RunTests()
    {
        bool retVal = true;
       TestLibrary.TestFramework.LogInformation("[Positive]");
        retVal = PosTest1() && retVal;
      
        return retVal;
    }
    // Returns true if the expected result is right
    // Returns false if the expected result is wrong

    public bool PosTest1()
    {
        bool retVal = true;
        TestLibrary.TestFramework.BeginScenario("PosTest1: Verify the AttributeTargets.Delegate value is 0x1000. ");
        try
        {
            int expectValue = 0x1000;
            if ((int)AttributeTargets.Delegate != expectValue)
            {
                TestLibrary.TestFramework.LogError("001.1", " AttributeTargets.Delegate should return 0x1000.");
                retVal = false;
            }
           
        }
        catch (Exception e)
        {
            TestLibrary.TestFramework.LogError("001.0", "Unexpected exception: " + e);
            retVal = false;
        }
       
        return retVal;
    }
   
}

