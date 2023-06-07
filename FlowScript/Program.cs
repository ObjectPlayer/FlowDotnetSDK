using ScriptTesting;

namespace FlowSdkTesting
{
    class Program
    {
        static async Task Main(string[] args)
        {
            FlowScriptTesting flowScriptTesting = new FlowScriptTesting();

            await flowScriptTesting.testIntType();
        }
    }
}
