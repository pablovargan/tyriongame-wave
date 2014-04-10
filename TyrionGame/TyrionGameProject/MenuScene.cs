using System;
using WaveEngine.Common.Graphics;
using WaveEngine.Components.Gestures;
using WaveEngine.Components.Graphics2D;
using WaveEngine.Components.UI;
using WaveEngine.Framework;
using WaveEngine.Framework.Graphics;
using WaveEngine.Framework.Physics2D;
using WaveEngine.Framework.Services;

namespace TyrionGameProject
{
    class MenuScene : Scene
    {
        protected override void CreateScene()
        {
            RenderManager.BackgroundColor = Color.Black;
            int offset = 100;

            var title = new Entity("Title")
                        .AddComponent(new Sprite("Content/title.wpk"))
                        .AddComponent(new SpriteRenderer(DefaultLayers.Alpha))
                        .AddComponent(new Transform2D()
                        {
                            Y = WaveServices.Platform.ScreenWidth / 2 - offset,
                            X = WaveServices.Platform.ScreenHeight / 2 - 150
                        });
            EntityManager.Add(title);

            var playButtonEntity = new Entity("Play")
                                .AddComponent(new Transform2D()
                                {
                                    Y = WaveServices.Platform.ScreenHeight / 2,
                                    X = WaveServices.Platform.ScreenWidth / 2,
                                    XScale = 2f,
                                    YScale = 2f
                                })
                                .AddComponent(new TextControl()
                                {
                                    Text = "Play",
                                    Foreground = Color.White,
                                })
                                .AddComponent(new TextControlRenderer())
                                .AddComponent(new RectangleCollider())
                                .AddComponent(new TouchGestures());

            playButtonEntity.FindComponent<TouchGestures>().TouchPressed += new EventHandler<GestureEventArgs>(play_TouchPressed);

            EntityManager.Add(playButtonEntity);
        }

        protected override void Start()
        {
            base.Start();
        }

        private void play_TouchPressed(object sender, GestureEventArgs e)
        {
            WaveServices.ScreenContextManager.To(new ScreenContext(new MyScene()));
        }
    }
}
