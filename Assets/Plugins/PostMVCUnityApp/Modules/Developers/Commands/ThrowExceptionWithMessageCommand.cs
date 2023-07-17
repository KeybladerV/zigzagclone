using System;
using Build1.PostMVC.Core.MVCS.Commands;

namespace Build1.PostMVC.Unity.App.Modules.Developers.Commands
{
    public sealed class ThrowExceptionWithMessageCommand : Command<string>
    {
        public override void Execute(string message)
        {
            throw new Exception(message);
        }
    }
}