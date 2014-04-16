using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SFML.Graphics;
using SFML.Window;

    class Player
    {
        Sprite head, body, rarm, larm, rleg, lleg;
        bool armsHigh = false;

        public Player(String datapath, Vector2f pos)
        {
            head = new Sprite(new Texture("Content/" + datapath + "/olgarr_head.png"));
            body = new Sprite(new Texture("Content/" + datapath + "/olgarr_body.png"));
            rarm = new Sprite(new Texture("Content/" + datapath + "/olgarr_rarm.png"));
            larm = new Sprite(new Texture("Content/" + datapath + "/olgarr_larm.png"));
            rleg = new Sprite(new Texture("Content/" + datapath + "/olgarr_rleg.png"));
            lleg = new Sprite(new Texture("Content/" + datapath + "/olgarr_lleg.png"));

            rarm.Origin = new Vector2f(rarm.Texture.Size.X, 0);
            larm.Origin = new Vector2f(0, 0);

            head.Position = pos;
            body.Position = new Vector2f(pos.X + head.Texture.Size.X / 2 - body.Texture.Size.X / 2, pos.Y + head.Texture.Size.Y - 20);
            rarm.Position = new Vector2f(body.Position.X - rarm.Texture.Size.X + rarm.Origin.X + 50, body.Position.Y + 10);
            larm.Position = new Vector2f(body.Position.X + body.Texture.Size.X - 50, body.Position.Y + 10);
            rleg.Position = new Vector2f(body.Position.X + 20, body.Position.Y + body.Texture.Size.Y - 10);
            lleg.Position = new Vector2f(body.Position.X + body.Texture.Size.X - lleg.Texture.Size.X - 20, body.Position.Y + body.Texture.Size.Y - 10);

            

        }

        public void updatePlayer()
        {
            if(Keyboard.IsKeyPressed(Keyboard.Key.A))
            {
                movePlayer(-1);
                rotateArms();
            }
            else if (Keyboard.IsKeyPressed(Keyboard.Key.D))
            {
                movePlayer(1);
                rotateArms();
            }
            else if (rarm.Rotation > -10)
            {
                rotateArmsDown();
            }

        }

        public void movePlayer(float dir)
        {
            head.Position += new Vector2f(dir, 0);
            body.Position += new Vector2f(dir, 0);
            rarm.Position += new Vector2f(dir, 0);
            larm.Position += new Vector2f(dir, 0);
            rleg.Position += new Vector2f(dir, 0);
            lleg.Position += new Vector2f(dir, 0);
        }

        public void rotateArms()
        {
            if (!armsHigh && rarm.Rotation < 40)
            {
                rarm.Rotation += 0.2f;
                larm.Rotation -= 0.2f;
            }
            else
            {
                rarm.Rotation -= 0.2f;
                larm.Rotation += 0.2f;
            }

            if (rarm.Rotation >= 40)
            {
                armsHigh = true;
            }

            if (rarm.Rotation <= -10)
            {
                armsHigh = false;
            }         
        }

        public void rotateArmsDown()
        {
            rarm.Rotation -= 0.3f;
            larm.Rotation += 0.3f;

            if (rarm.Rotation <= -10) { armsHigh = false; }
        }

        public void drawPlayer(RenderWindow win)
        {
            
            win.Draw(head);           
            win.Draw(rarm);
            win.Draw(larm);
            win.Draw(rleg);
            win.Draw(lleg);
            win.Draw(body);
        }       


    }
