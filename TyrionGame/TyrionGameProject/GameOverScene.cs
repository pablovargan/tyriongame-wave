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
    public class GameOverScene : Scene
    {
        private int score;

        public GameOverScene(int score) { this.score = score; }

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
            TextBlock scoreEnd = new TextBlock("scoreEndTextBlock")
            {
                Text = "Score\n" + this.score.ToString(),
                VerticalAlignment = WaveEngine.Framework.UI.VerticalAlignment.Top,
                HorizontalAlignment = WaveEngine.Framework.UI.HorizontalAlignment.Center,
                DrawOrder = 3f,
            };

            EntityManager.Add(scoreEnd);

            Button button = new Button()
                {
                    Text = "Restart?",
                    IsBorder = false,
                    Width = 700,
                    Height = 500,
                    HorizontalAlignment = WaveEngine.Framework.UI.HorizontalAlignment.Right,
                    VerticalAlignment = WaveEngine.Framework.UI.VerticalAlignment.Center,
                    //BackgroundImage = "Content/button.wpk",
                    //PressedBackgroundImage = "Content/buttonPressed.wpk",
                    Margin = new WaveEngine.Framework.UI.Thickness(100, 400, 0, 0)
                };
            button.Click += (s, o) =>
            {
                WaveServices.ScreenContextManager.To(new ScreenContext(new MyScene()), new SpinningSquaresTransition(TimeSpan.FromSeconds(2.0f)));
            };
            EntityManager.Add(button);
        }
    }
}
