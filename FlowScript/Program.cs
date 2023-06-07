// See https://aka.ms/new-console-template for more information
using System;
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
