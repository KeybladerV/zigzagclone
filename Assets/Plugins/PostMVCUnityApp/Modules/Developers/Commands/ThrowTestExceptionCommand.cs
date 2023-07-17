using System;
using Build1.PostMVC.Core.MVCS.Commands;

namespace Build1.PostMVC.Unity.App.Modules.Developers.Commands
{
    public sealed class ThrowTestExceptionCommand : Command
    {
        public override void Execute()
        {
            throw new Exception("Test exception");
        }
    }
}