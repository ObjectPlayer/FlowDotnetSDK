using ScriptTesting;

namespace FlowSdkTesting
{
    class Program
    {
        static async Task Main(string[] args)
        {
            FlowScriptTesting flowScriptTesting = new FlowScriptTesting();

            await flowScriptTesting.testIntType();
            await flowScriptTesting.testUIntType();
            await flowScriptTesting.testInt8Type();
            await flowScriptTesting.testUInt8Type();
            await flowScriptTesting.testInt16Type();
            await flowScriptTesting.testUInt16Type();

        }
    }
}
