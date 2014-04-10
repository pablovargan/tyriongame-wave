using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using WaveEngine.Common.Math;
using WaveEngine.Components.UI;
using WaveEngine.Framework;
using WaveEngine.Framework.Graphics;
using WaveEngine.Framework.Physics2D;
using WaveEngine.Framework.Services;

namespace TyrionGameProject
{
    public class KickBehavior : Behavior
    {
        [RequiredComponent]
        private RectangleCollider collider;

        private bool first;
        private bool kickReceived;
        // First position pressed
        private Vector2 pressedPosition;
        // Last position collisioned 
        private Vector2 collisionPosition;
 
        // Time, velocity and score
        private TimeSpan timer; 
        private double velocity; 
        private int score;

        private MyScene myScene;

        public KickBehavior()
        {
            this.first = true;
            this.kickReceived = false;
            this.timer = TimeSpan.Zero;
            this.score = 0;  
        }

        protected override void ResolveDependencies()
        {
            base.ResolveDependencies();
            this.myScene = (MyScene)this.Owner.Scene;
        }

        protected override void Update(TimeSpan gameTime)
        {
            if (WaveServices.Input.TouchPanelState.Count > 0)
            {
                if (this.first)
                {
                    // Save the first position
                    this.pressedPosition = WaveServices.Input.TouchPanelState[0].Position; 
                    this.first = false;
                }
                else
                {
                    this.timer += gameTime; 
                }

                var touchPosition = WaveServices.Input.TouchPanelState[0].Position;
                if(this.collider.Contain(touchPosition) && !this.kickReceived)
                {
                    // Save the last position
                    this.collisionPosition = WaveServices.Input.TouchPanelState[0].Position;
                    double distance = Math.Sqrt(Math.Pow((collisionPosition.X - pressedPosition.X), 2) + 
                            Math.Pow((collisionPosition.Y - pressedPosition.Y), 2));
                    this.velocity = distance / this.timer.Milliseconds;
                    this.score += Convert.ToInt32(this.velocity*100.0);
                    this.kickReceived = true;
                    Debug.WriteLine("DENTRO");
                    Debug.WriteLine("Distancia " + distance.ToString());
                    Debug.WriteLine("velocidad " + velocity.ToString());
                    Debug.WriteLine("Puntos " + score.ToString());
                    var text = EntityManager.Find<TextBlock>("ScoreTextBlock");
                    text.Text = score.ToString();
                    // TODO: Insert into this method score properties
                    //this.myScene.KickReceived()
                }       


            }
            else
            {
                if (!this.first)
                {
                    this.timer = TimeSpan.Zero;
                    this.first = true;
                    this.kickReceived = false;
                }
            }
        }
    }
}
