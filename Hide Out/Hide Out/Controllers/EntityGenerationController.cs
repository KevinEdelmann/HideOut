﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework;


namespace HideOut.Controllers
{
    class EntityGenerationController
    {
        KeyboardState oldState;
        bool isListening;
        public ItemController itemController { get; set; }
        public NPCController npcController { get; set; }
        public ObstacleController obstacleController { get; set; }

        public EntityGenerationController()
        {
            oldState = Keyboard.GetState();
            isListening = false;
        }

        public EntityGenerationController(ItemController ic, NPCController nc, ObstacleController oc) : this()
        {
            itemController = ic;
            npcController = nc;
            obstacleController = oc;
        }

        public void Update(GameTime gameTime)
        {
            KeyboardState newState = Keyboard.GetState();

            if (newState.IsKeyDown(Keys.M) && !oldState.IsKeyDown(Keys.M))
            {
                isListening = !isListening;
            }
            if (isListening)
            {
                MouseState mouseState = Mouse.GetState();
                if (newState.IsKeyDown(Keys.P) && !oldState.IsKeyDown(Keys.P))
                {
                    npcController.CreateNPC(Entities.NPCType.Police, new Vector2(mouseState.X + HideOutGame.SCREEN_OFFSET_X, mouseState.Y + HideOutGame.SCREEN_OFFSET_Y));
                    isListening = false;
                }
                else if (newState.IsKeyDown(Keys.A) && !oldState.IsKeyDown(Keys.A))
                {
                    itemController.CreateItem(Entities.ItemType.Apple, new Vector2(mouseState.X + HideOutGame.SCREEN_OFFSET_X, mouseState.Y + HideOutGame.SCREEN_OFFSET_Y));
                    isListening = false;
                }
                else if (newState.IsKeyDown(Keys.C) && !oldState.IsKeyDown(Keys.C))
                {
                    itemController.CreateItem(Entities.ItemType.CandyBar, new Vector2(mouseState.X + HideOutGame.SCREEN_OFFSET_X, mouseState.Y + HideOutGame.SCREEN_OFFSET_Y));
                    isListening = false;
                }
                else if (newState.IsKeyDown(Keys.O) && !oldState.IsKeyDown(Keys.O))
                {
                    itemController.CreateItem(Entities.ItemType.Coin, new Vector2(mouseState.X + HideOutGame.SCREEN_OFFSET_X, mouseState.Y + HideOutGame.SCREEN_OFFSET_Y));
                    isListening = false;
                }
                else if (newState.IsKeyDown(Keys.W) && !oldState.IsKeyDown(Keys.W))
                {
                    itemController.CreateItem(Entities.ItemType.WaterBottle, new Vector2(mouseState.X + HideOutGame.SCREEN_OFFSET_X, mouseState.Y + HideOutGame.SCREEN_OFFSET_Y));
                    isListening = false;
                }
                else if (newState.IsKeyDown(Keys.B) && !oldState.IsKeyDown(Keys.B))
                {
                    obstacleController.CreateObstacle(Entities.ObstacleType.Bush, new Vector2(mouseState.X + HideOutGame.SCREEN_OFFSET_X, mouseState.Y + HideOutGame.SCREEN_OFFSET_Y));
                    isListening = false;
                }
                else if (newState.IsKeyDown(Keys.T) && !oldState.IsKeyDown(Keys.T))
                {
                    obstacleController.CreateObstacle(Entities.ObstacleType.Tree, new Vector2(mouseState.X + HideOutGame.SCREEN_OFFSET_X, mouseState.Y + HideOutGame.SCREEN_OFFSET_Y));
                    isListening = false;
                }
                else if (newState.IsKeyDown(Keys.F) && !oldState.IsKeyDown(Keys.F))
                {
                    obstacleController.CreateObstacle(Entities.ObstacleType.Fountain, new Vector2(mouseState.X + HideOutGame.SCREEN_OFFSET_X, mouseState.Y + HideOutGame.SCREEN_OFFSET_Y));
                    isListening = false;
                }
                else if (newState.IsKeyDown(Keys.N) && !oldState.IsKeyDown(Keys.N))
                {
                    obstacleController.CreateObstacle(Entities.ObstacleType.Pond, new Vector2(mouseState.X + HideOutGame.SCREEN_OFFSET_X, mouseState.Y + HideOutGame.SCREEN_OFFSET_Y));
                    isListening = false;
                }
            }
        }
    }
}
