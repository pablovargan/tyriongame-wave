using System;
using WaveEngine.Common.Math;
using WaveEngine.Common.Graphics;
using WaveEngine.Components.Gestures;
using WaveEngine.Components.Graphics2D;
using WaveEngine.Components.UI;
using WaveEngine.Framework;
using WaveEngine.Framework.Graphics;
using WaveEngine.Framework.Physics2D;
using WaveEngine.Framework.Services;
using WaveEngine.Components.Transitions;
using WaveEngine.Framework.Managers;


namespace TyrionGameProject
{
    class GameOverScene : Scene
    {
        protected override void CreateScene()
        {
            RenderManager.BackgroundColor = Color.Black;
            /*Entity title = new Entity("Title")
                   .AddComponent(new Sprite("Content/TitlePong.wpk"))
                   .AddComponent(new SpriteRenderer(DefaultLayers.Alpha))
                   .AddComponent(new Transform2D()
                   {
                       Y = WaveServices.Platform.ScreenHeight / 2,
                       X = WaveServices.Platform.ScreenWidth / 2
                   });

            EntityManager.Add(title);*/

            Button button = new Button()
                {
                    Text = "Restart?",
                    IsBorder = false,
                    Width = 600,
                    Height = 200,
                    //BackgroundImage = "Content/button.wpk",
                    //PressedBackgroundImage = "Content/buttonPressed.wpk",
                    Margin = new WaveEngine.Framework.UI.Thickness(76, 800, 0, 0)
                };
            button.Click += (s, o) =>
            {
                WaveServices.ScreenContextManager.To(new ScreenContext(new MyScene()), new SpinningSquaresTransition(TimeSpan.FromSeconds(2.0f)));
            };
            EntityManager.Add(button);
        }
    }
}
