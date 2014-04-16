using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SFML.Window;
using SFML.Graphics;


    class Game
    {
        static RenderWindow win;

        public static void Main()
        {
            // Erzeuge ein neues Fenster
            win = new RenderWindow(new VideoMode(800, 600), "Mein erstes Fenster");
            win.Closed += win_Closed;

            Player p = new Player("std", new Vector2f(300, 200));

            while (win.IsOpen())
            {
                win.Clear();
                p.updatePlayer();
                p.drawPlayer(win);
                

                win.DispatchEvents();
                win.Display();
            }

        }

        static void win_Closed(object sender, EventArgs e)
        {
            // Fenster Schließen
            (sender as Window).Close();
        }
        
    }

