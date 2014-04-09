#region Using Statements
using System;
using WaveEngine.Common;
using WaveEngine.Common.Graphics;
using WaveEngine.Common.Math;
using WaveEngine.Components.Graphics2D;
using WaveEngine.Components.Graphics3D;
using WaveEngine.Components.UI;
using WaveEngine.Framework;
using WaveEngine.Framework.Graphics;
using WaveEngine.Framework.Physics2D;
using WaveEngine.Framework.Services;
#endregion

namespace TyrionGameProject
{
    public class MyScene : Scene
    {
        protected override void CreateScene()
        {
            RenderManager.BackgroundColor = Color.CornflowerBlue;
            RenderManager.DebugLines = true;
            Entity tyrion = new Entity()
                .AddComponent(new Transform2D()
                {
                    Origin = new Vector2(0.5f,1f),
                    X = WaveServices.Platform.ScreenWidth/2,
                    Y = WaveServices.Platform.ScreenHeight,
                })
                .AddComponent(new RectangleCollider())
                .AddComponent(new KickBehavior())
                .AddComponent(new Sprite("Content/tyrion.wpk"))
                .AddComponent(new SpriteRenderer(DefaultLayers.Opaque));
            EntityManager.Add(tyrion);

            Entity touchPanel = new Entity("TouchPanel")
                .AddComponent(new TouchesRenderer("Content/touch.wpk"));


            // Score
            TextBlock texblock = new TextBlock("ScoreTextBlock") 
            { 
                Text = "Score: 0", 
                VerticalAlignment = WaveEngine.Framework.UI.VerticalAlignment.Top,
                HorizontalAlignment = WaveEngine.Framework.UI.HorizontalAlignment.Right 
            };
            /*
            TextBlock attempt = new TextBlock("AttemptTextBlock")
            {
                Tex
            }
            */
            EntityManager.Add(texblock);

            EntityManager.Add(touchPanel);
            

        }

        public void KickReceived(float score)
        {

        }
    }
}
