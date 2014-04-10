﻿#region Using Statements
using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Storage;
using Microsoft.Xna.Framework.GamerServices;
using HideOut.Entities;
using HideOut.Controllers;
using HideOut.Screens;
using Microsoft.Xna.Framework.Audio;
#endregion

namespace HideOut
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class HideOutGame : Game
    {
        GraphicsDeviceManager graphics;
        public static readonly int SCREEN_WIDTH = 800;
        public static readonly int SCREEN_HEIGHT = 500;
        public static int SCREEN_OFFSET_X = 0;
        public static int SCREEN_OFFSET_Y = 0;

        public Screen currentScreen { get; set; }
        TitleScreen titleScreen;
        LevelScreen levelScreen;
        public static bool LEVEL_INITIALIZED = false;
        public static readonly bool LEVEL_DESIGN_MODE = false;
        public static readonly int LEVEL_DESIGN_SIZE = 3; //1 is 1000x1000, 2 is 1500x1500, 3 is 2000x2000

        SoundEffect backgroundMusic;

        public HideOutGame()
            : base()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            graphics.PreferredBackBufferHeight = SCREEN_HEIGHT;
            graphics.PreferredBackBufferWidth = SCREEN_WIDTH;
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            graphics.ApplyChanges();

            titleScreen = new TitleScreen();
            levelScreen = new LevelScreen();
            if (LEVEL_DESIGN_MODE)
                currentScreen = levelScreen;
            else
                currentScreen = titleScreen; // Choose starting screen;

            titleScreen.Initialize();
            levelScreen.Initialize();

            base.Initialize();



        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            titleScreen.LoadContent(GraphicsDevice, Content);
            levelScreen.LoadContent(GraphicsDevice, Content);
            //  http://www.newgrounds.com/audio/listen/564520
            backgroundMusic = Content.Load<SoundEffect>("ambience.wav");
            backgroundMusic.Play();
            base.LoadContent();
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// all content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /*
        public static FontFile Load(Stream stream)
        {
            XmlSerializer deserializer = new XmlSerializer(typeof(FontFile));
            FontFile file = (FontFile)deserializer.Deserialize(stream);
            return file;
        }
        */

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            switch (currentScreen.Type)
            {
                case "TitleScreen":
                    currentScreen = titleScreen;
                    currentScreen.Type = "TitleScreen";
                    break;
                case "LevelScreen":
                    if (!LEVEL_INITIALIZED)
                    {
                        levelScreen.InitializeLevel();
                        LEVEL_INITIALIZED = true;
                    }
                    currentScreen = levelScreen;
                    currentScreen.Type = "LevelScreen";
                    break;
                case "Exit":
                    Exit();
                    break;
            }

            currentScreen.Update(gameTime);
            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            currentScreen.Draw(GraphicsDevice);
            base.Draw(gameTime);
        }
    }
}
