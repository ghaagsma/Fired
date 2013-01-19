using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace Fired
{
    abstract class Character : PhysObject
    {
        protected int speed;

        public Character(int initX, int initY, int speed_) :
            base(initX, initY)
        {
            speed = speed_;
        }        
        
        //Calculate the current tile that position x,y intersects
        IntVector currentTile(float x, float y)
        {
            IntVector v = new IntVector(-1, -1);
            while (x > 0)
            {
                x -= Fired.TILE_SIZE;
                v.X += 1;
            }
            while (y > 0)
            {
                y -= Fired.TILE_SIZE;
                v.Y += 1;
            }
            return v;
        }

        public override void mapCollide(Tile[,] tiles)
        {
            //The location a player would end up without collisions
            Vector2 finalLocation = new Vector2(position.X + velocity.X, position.Y + velocity.Y);
            IntVector tile = new IntVector();
            int tileSize = Fired.TILE_SIZE;

            //Check top collisions
            if (velocity.Y > 0)
                while (position.Y < finalLocation.Y)
                {
                    position.Y += 0.1f;
                    tile = currentTile(position.X + Fired.CHAR_SIZE, position.Y + Fired.CHAR_SIZE);
                    if (tiles[tile.Y, tile.X].type == TileType.Collision)
                    {
                        position.Y = tiles[tile.Y, tile.X].location.Y - Fired.CHAR_SIZE;
                        break;
                    }

                    tile = currentTile(position.X, position.Y + Fired.CHAR_SIZE);
                    if (tiles[tile.Y, tile.X].type == TileType.Collision)
                    {
                        position.Y = tiles[tile.Y, tile.X].location.Y - Fired.CHAR_SIZE;
                        break;
                    }
                }
            //Check bottom collisions
            else if (velocity.Y < 0)
                while (position.Y > finalLocation.Y)
                {
                    position.Y -= 0.1f;
                    tile = currentTile(position.X + Fired.CHAR_SIZE, position.Y);
                    if (tiles[tile.Y, tile.X].type == TileType.Collision)
                    {
                        position.Y = tiles[tile.Y, tile.X].location.Y + tileSize + 0.1f;
                        break;
                    }

                    tile = currentTile(position.X, position.Y);
                    if (tiles[tile.Y, tile.X].type == TileType.Collision)
                    {
                        position.Y = tiles[tile.Y, tile.X].location.Y + tileSize + 0.1f;
                        break;
                    }
                }
            else { }

            //Reset the y position so there are no erroneous tile collisions
            //location = finalLocation;

            //Check right collisions
            if (velocity.X > 0)
                while (position.X < finalLocation.X)
                {
                    position.X += 0.1f;
                    tile = currentTile(position.X + Fired.CHAR_SIZE, position.Y + Fired.CHAR_SIZE);
                    if (tiles[tile.Y, tile.X].type == TileType.Collision)
                    {
                        position.X = tiles[tile.Y, tile.X].location.X - Fired.CHAR_SIZE;
                        break;
                    }

                    tile = currentTile(position.X + Fired.CHAR_SIZE, position.Y);
                    if (tiles[tile.Y, tile.X].type == TileType.Collision)
                    {
                        position.X = tiles[tile.Y, tile.X].location.X - Fired.CHAR_SIZE;
                        break;
                    }
                }
            //Check left collisions
            else if (velocity.X < 0)
                while (position.X > finalLocation.X)
                {
                    position.X -= 0.1f;
                    tile = currentTile(position.X, position.Y);
                    if (tiles[tile.Y, tile.X].type == TileType.Collision)
                    {
                        position.X = tiles[tile.Y, tile.X].location.X + tileSize + 0.1f;
                        break;
                    }

                    tile = currentTile(position.X, position.Y + Fired.CHAR_SIZE);
                    if (tiles[tile.Y, tile.X].type == TileType.Collision)
                    {
                        position.X = tiles[tile.Y, tile.X].location.X + tileSize + 0.1f;
                        break;
                    }
                }
            else { }

            //Set locations
            hitBox.X = (int)position.X;
            hitBox.Y = (int)position.Y;
        }
    }
}
