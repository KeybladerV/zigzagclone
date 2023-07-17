using System;
using Build1.PostMVC.Core.MVCS.Commands;

namespace Build1.PostMVC.Unity.App.Modules.Developers.Commands
{
    public sealed class ThrowExceptionCommand : Command<Exception>
    {
        public override void Execute(Exception exception)
        {
            throw exception;
        }
    }
}