#region Using Statements
using System;
using WaveEngine.Common;
using WaveEngine.Common.Graphics;
using WaveEngine.Common.Input;
using WaveEngine.Framework;
using WaveEngine.Framework.Services;
#endregion

namespace TyrionGameProject
{
    public class Game : WaveEngine.Framework.Game
    {
        public override void Initialize(IApplication application)
        {
            base.Initialize(application);

            application.Adapter.DefaultOrientation = DisplayOrientation.Portrait;
            application.Adapter.SupportedOrientations = DisplayOrientation.Portrait;

            WaveServices.ViewportManager.Activate(768, 1024, ViewportManager.StretchMode.Uniform);

            ScreenContext screenContext = new ScreenContext(new MenuScene());
            WaveServices.ScreenContextManager.To(screenContext);
        }

        // OnActivated methods
        //override 
    }
}
