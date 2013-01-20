using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace Fired
{
    class Map
    {
        public const int MAP_COLS = 20;
        public const int MAP_ROWS = 15;

        int level;
        Tile[,] tiles;
        Texture2D tileset, playerImage, guardImage, employeeImage, swatImage, sewageImage, bossImage;
        bool levelFinished, loseGame, winGame, openWindow;
        Hero hero;
        List<Employee> employees;
        List<Swat> swat;
        List<SecurityGuard> guard;
        List<Boss> boss;
        List<SewageSucker> sucker;
        Rectangle stairs, window;
        Vector2 windowLocation;

        public Map()
        {
            level = 5;
            tiles = new Tile[MAP_ROWS, MAP_COLS];
            for (int i = 0; i < MAP_ROWS; ++i)
                for (int j = 0; j < MAP_COLS; ++j)
                {
                    tiles[i, j] = new Tile();
                    tiles[i, j].location = new Rectangle(j * Fired.TILE_SIZE, i * Fired.TILE_SIZE, Fired.TILE_SIZE, Fired.TILE_SIZE);
                }
            levelFinished = true;
            openWindow = false;
            loseGame = winGame = false;
            hero = new Hero(0, 0, 3);
            employees = new List<Employee>();
            swat = new List<Swat>();
            guard = new List<SecurityGuard>();
            boss = new List<Boss>();
            sucker = new List<SewageSucker>();
            stairs = new Rectangle();
            window = new Rectangle(2000, 2000, 1, 1);
        }

        public void LoadContent(ContentManager content)
        {
            tileset = content.Load<Texture2D>("tiles");
            playerImage = content.Load<Texture2D>("HeroStrip");
            employeeImage = content.Load<Texture2D>("CorporateWhore");
            guardImage = content.Load<Texture2D>("SecurityGuard");
            swatImage = content.Load<Texture2D>("Swat");
            sewageImage = content.Load<Texture2D>("SewageSucker");
            bossImage = content.Load<Texture2D>("boss");
        }

        public void Update(ContentManager content)
        {
            if (levelFinished)
            {
                levelFinished = false;
                LoadNextLevel(content);
            }

            hero.update(tiles);

            //Update employees / employee player collision
            for (int i = 0; i < employees.Count; ++i)
            {
                employees[i].update(tiles, hero.getPosition());
                if (hero.getHitBox().Intersects(employees[i].getHitBox()))
                {
                    employees.RemoveAt(i);
                    i--;
                }
            }

            //Update guard / collisions
            for (int i = 0; i < guard.Count; ++i)
            {
                guard[i].update(tiles, hero.getPosition());
                if (hero.getHitBox().Intersects(guard[i].getHitBox()))
                {
                    loseGame = true;
                }
            }

            //Update swat / player swat collision
            for (int i = 0; i < swat.Count; ++i)
            {
                swat[i].update(tiles, hero.getPosition());
                if (hero.getHitBox().Intersects(swat[i].getHitBox()))
                {
                    loseGame = true;
                }
            }

            //Update boss
            for (int i = 0; i < boss.Count; ++i)
            {
                boss[i].update(tiles, hero.getPosition());
                if (hero.getHitBox().Intersects(boss[i].getHitBox()))
                {
                    boss.RemoveAt(i);
                    i--;
                    openWindow = true;
                    tiles[(int)windowLocation.Y, (int)windowLocation.X].imageSource = new Rectangle(Fired.SOURCE_SIZE * 8, 0, Fired.SOURCE_SIZE, Fired.SOURCE_SIZE);
                }
            }

            //Check if you can go up a level
            if (employees.Count == 0 && hero.getHitBox().Intersects(stairs))
                levelFinished = true;
                
            //Check player intersect with open window
            if (hero.getHitBox().Intersects(window) && openWindow)
                winGame = true;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            if (levelFinished)
                return;

            for (int i = 0; i < MAP_ROWS; ++i)
                for (int j = 0; j < MAP_COLS; ++j)
                {
                    spriteBatch.Draw(tileset, tiles[i, j].location, tiles[i, j].imageSource, Color.White);
                }

            for (int i = 0; i < employees.Count; ++i)
                employees[i].draw(spriteBatch);

            for (int i = 0; i < guard.Count; ++i)
                guard[i].draw(spriteBatch);

            for (int i = 0; i < swat.Count; ++i)
                swat[i].draw(spriteBatch);

            for (int i = 0; i < boss.Count; ++i)
                boss[i].draw(spriteBatch);

            for (int i = 0; i < sucker.Count; ++i)
                sucker[i].draw(spriteBatch);

            hero.draw(spriteBatch);
        }

        //Change to the next level
        void LoadNextLevel(ContentManager content)
        {
            level++;
            employees.Clear();
            swat.Clear();
            guard.Clear();

            //Make file name and open file
            string fileName = "level" + level.ToString() + ".txt";
            StreamReader sr = new StreamReader(fileName);
            string [] line;

            //Get tiles from file
            for (int i = 0; i < MAP_ROWS; ++i)
            {
                //Read a line in and split each character at the space
                line = sr.ReadLine().Split(' '); 
                for (int j = 0; j < MAP_COLS; ++j)
                {
                    if (line[j] == "W")
                    {
                        tiles[i, j].type = TileType.Collision;
                        tiles[i, j].imageSource = new Rectangle(Fired.SOURCE_SIZE, 0, Fired.SOURCE_SIZE, Fired.SOURCE_SIZE);
                    }
                    else if (line[j] == ".")
                    {
                        tiles[i, j].type = TileType.Empty;
                        tiles[i, j].imageSource = new Rectangle(0, 0, Fired.SOURCE_SIZE, Fired.SOURCE_SIZE);
                    }
                    else if(line[j] == "U")
                    {
                        tiles[i, j].type = TileType.Up;
                        tiles[i, j].imageSource = new Rectangle(Fired.SOURCE_SIZE * 2, 0, Fired.SOURCE_SIZE, Fired.SOURCE_SIZE);
                        stairs = new Rectangle(j * Fired.TILE_SIZE, i * Fired.TILE_SIZE, Fired.TILE_SIZE, Fired.TILE_SIZE);
                    }
                    else if (line[j] == "B")
                    {
                        tiles[i, j].type = TileType.Collision;
                        tiles[i, j].imageSource = new Rectangle(Fired.SOURCE_SIZE * 3, 0, Fired.SOURCE_SIZE, Fired.SOURCE_SIZE);
                    }
                    else if (line[j] == "[")
                    {
                        tiles[i, j].type = TileType.Collision;
                        tiles[i, j].imageSource = new Rectangle(Fired.SOURCE_SIZE * 4, 0, Fired.SOURCE_SIZE, Fired.SOURCE_SIZE);
                    }
                    else if (line[j] == "=")
                    {
                        tiles[i, j].type = TileType.Collision;
                        tiles[i, j].imageSource = new Rectangle(Fired.SOURCE_SIZE * 5, 0, Fired.SOURCE_SIZE, Fired.SOURCE_SIZE);
                    }
                    else if (line[j] == "]")
                    {
                        tiles[i, j].type = TileType.Collision;
                        tiles[i, j].imageSource = new Rectangle(Fired.SOURCE_SIZE * 6, 0, Fired.SOURCE_SIZE, Fired.SOURCE_SIZE);
                    }
                    else if (line[j] == "+")
                    {
                        tiles[i, j].type = TileType.Collision;
                        tiles[i, j].imageSource = new Rectangle(Fired.SOURCE_SIZE * 7, 0, Fired.SOURCE_SIZE, Fired.SOURCE_SIZE);
                        window = new Rectangle(j * Fired.TILE_SIZE, i * Fired.TILE_SIZE, Fired.TILE_SIZE, Fired.TILE_SIZE + 5);
                        windowLocation = new Vector2(i, j);
                    }
                }
            }

            //Add player
            sr.ReadLine();
            line = sr.ReadLine().Split(' ');
            hero = new Hero(int.Parse(line[0]), int.Parse(line[1]), int.Parse(line[2]));
            hero.load(content, playerImage);

            int count;
            //Add employee
            Employee e;
            line = sr.ReadLine().Split(' ');
            count = int.Parse(line[2]);
            for(int i = 0; i < count; ++i)
            {            
                line = sr.ReadLine().Split(' ');
                e = new Employee(int.Parse(line[0]), int.Parse(line[1]), int.Parse(line[2]));
                e.load(content, employeeImage);
                employees.Add(e);
            }
            
            //Add guards
            SecurityGuard s;
            line = sr.ReadLine().Split(' ');
            count = int.Parse(line[2]);
            for (int i = 0; i < count; ++i)
            {
                line = sr.ReadLine().Split(' ');
                s = new SecurityGuard(int.Parse(line[0]), int.Parse(line[1]), int.Parse(line[2]), int.Parse(line[3]), int.Parse(line[4]));
                s.load(content, guardImage);
                guard.Add(s);
            }
            
            //Add swat
            Swat sw;
            line = sr.ReadLine().Split(' ');
            count = int.Parse(line[2]);
            for (int i = 0; i < count; ++i)
            {
                line = sr.ReadLine().Split(' ');
                sw = new Swat(int.Parse(line[0]), int.Parse(line[1]), int.Parse(line[2]));
                sw.load(content, swatImage);
                swat.Add(sw);
            }

            //Add boss
            Boss b;
            line = sr.ReadLine().Split(' ');
            count = int.Parse(line[2]);
            for (int i = 0; i < count; ++i)
            {
                line = sr.ReadLine().Split(' ');
                b = new Boss(int.Parse(line[0]), int.Parse(line[1]), int.Parse(line[2]));
                b.load(content, bossImage);
                boss.Add(b);
            }

            //Add Sucker
            SewageSucker su;
            line = sr.ReadLine().Split(' ');
            count = int.Parse(line[2]);
            for (int i = 0; i < count; ++i)
            {
                line = sr.ReadLine().Split(' ');
                su = new SewageSucker(int.Parse(line[0]), int.Parse(line[1]));
                su.load(content, bossImage);
                sucker.Add(su);
            }

            sr.Close();
        }

        public void Reset()
        {
            level = 0;
            levelFinished = true;
            loseGame = winGame = false;
        }

        public bool CheckGameLose()
        {
            return loseGame;
        }

        public bool CheckGameWin()
        {
            return winGame;
        }
    }
}
