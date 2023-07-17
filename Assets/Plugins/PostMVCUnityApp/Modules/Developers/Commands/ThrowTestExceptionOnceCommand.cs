using System;
using Build1.PostMVC.Core.MVCS.Commands;

namespace Build1.PostMVC.Unity.App.Modules.Developers.Commands
{
    public sealed class ThrowTestExceptionOnceCommand : Command
    {
        private static bool _thrown;
        
        public override void Execute()
        {
            if (_thrown)
                return;

            _thrown = true;
            throw new Exception("Test exception");
        }
    }
}