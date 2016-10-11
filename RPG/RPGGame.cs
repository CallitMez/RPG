﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;

namespace RPG
{
    public class RPGGame : Game
    {




        //TODO create gamestates in which you can see:
        //a list of active battles(same page or different page for additional information)
        //a list of enemies
        //a list of own heroes
        //a list of ended battles (maybe combine with active ones)
        //a list of items





        // Basics
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        screenmanager screens = new screenmanager();
        InputHelper inputHelper = new InputHelper();

        // Sprites
        Texture2D testure;
        SpriteFont font;
        // Battle stuff
        Hero warrior;
        Enemy fish;
        Hero noob;
        Enemy karp;
        Battle anyBattle;
        Battle secondbattle;

        // Input
        Button testButton;

        public RPGGame()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        protected override void Initialize()
        {
            // Battle stuff
            
            warrior = new Hero("Warrior", 10, 1);
            fish = new Enemy("Fish", 10, 1, 0.3);
            List<Creature> heroes = new List<Creature>();
            List<Creature> enemies = new List<Creature>();
            heroes.Add(warrior);
            enemies.Add(fish);
            anyBattle = new Battle(heroes, enemies);
            ongoingbattles.ongoingbattlelist.Add(anyBattle);

            noob = new Hero("Piet", 150, 10,0.009);
            karp = new Enemy("Karp", 100, 10, 0.01);
            List<Creature> noobs = new List<Creature>();
            List<Creature> fishes = new List<Creature>();
            noobs.Add(noob);
            fishes.Add(karp);
            secondbattle = new Battle(noobs,fishes);
            ongoingbattles.ongoingbattlelist.Add(secondbattle);

            //anyBattle.proceed();
            // End battle stuff

            IsMouseVisible = true;
            base.Initialize();
        }

        protected override void LoadContent()
        {
            screens.loadcontent();
            spriteBatch = new SpriteBatch(GraphicsDevice);
            font = Content.Load<SpriteFont>("font");
            FileManager f = new FileManager();
            testure = Content.Load<Texture2D>("testure");
            testButton = new Button(new Rectangle(new Point(50), new Point(16)), testure);
        }

        protected override void UnloadContent()
        {
            // What content is there to be unloaded?
        }

        protected override void Update(GameTime gameTime)
        {
            inputHelper.Update(gameTime);
            // Press escape to exit, will most likely have to be removed
            // at some point because we like to have an onscreen exit button
            screens.update(gameTime);
            if (Keyboard.GetState().IsKeyDown(Keys.Escape)) Exit();
            //while (anyBattle.proceed()) { }
            if (testButton.isClicked(inputHelper))
            {
                anyBattle.writelog();
                anyBattle.proceed();
            }

            // Pass the Update into the base "Game" class
            ongoingbattles.update(gameTime);
            base.Update(gameTime);
        }


        protected override void Draw(GameTime gameTime)
        {
           
            spriteBatch.Begin();
            // Blank lines for readability
            screens.draw(spriteBatch);
            
            
            GraphicsDevice.Clear(Color.White);
            testButton.Draw(spriteBatch);
            ongoingbattles.draw(spriteBatch,font);



            // Blank lines for readability
            spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
