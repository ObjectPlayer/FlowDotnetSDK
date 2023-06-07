using ScriptTesting;

namespace FlowSdkTesting
{
    class Program
    {
        static async Task Main(string[] args)
        {
            FlowScriptTesting flowScriptTesting = new FlowScriptTesting();

            // //Testing Boolean
            // await flowScriptTesting.testBooleanType();

            // //Testing Numbers
            // await flowScriptTesting.testIntType();
            // await flowScriptTesting.testUIntType();
            // await flowScriptTesting.testInt8Type();
            // await flowScriptTesting.testUInt8Type();
            // await flowScriptTesting.testInt16Type();
            // await flowScriptTesting.testUInt16Type();
            // await flowScriptTesting.testInt32Type();
            // await flowScriptTesting.testUInt32Type();
            // await flowScriptTesting.testInt64Type();
            // await flowScriptTesting.testUInt64Type();
            // await flowScriptTesting.testInt128Type();
            // await flowScriptTesting.testUInt128Type();
            // await flowScriptTesting.testInt256Type();
            // await flowScriptTesting.testUInt256Type();
            // await flowScriptTesting.testWord8Type();
            // await flowScriptTesting.testWord16Type();
            // await flowScriptTesting.testWord32Type();
            // await flowScriptTesting.testWord64Type();
            // await flowScriptTesting.testFix64Type();
            // await flowScriptTesting.testUFix64Type();

            // //Testing Address
            // await flowScriptTesting.testAddressType();

            // //Testing String
            // await flowScriptTesting.testStringType();

            // //Testing Array
            // await flowScriptTesting.testArrayType();

            //Testing Dictionary
            await flowScriptTesting.testDictionaryType();

        }
    }
}
