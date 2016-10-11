using Microsoft.Xna.Framework;
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

        // Sprites
        Texture2D testure;

        // Battle stuff
        Hero warrior;
        Hero anotherWarrior;
        Enemy fish;
        Battle anyBattle;

        // Input
        InputHelper inputHelper = new InputHelper();
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
            anotherWarrior = new Hero("Warrior2", 10, 1);
            fish = new Enemy("Fish", 10, 1, 3);
            List<Creature> heroes = new List<Creature>();
            List<Creature> enemies = new List<Creature>();
            heroes.Add(warrior);
            heroes.Add(anotherWarrior);
            enemies.Add(fish);
            anyBattle = new Battle(heroes, enemies);
            //anyBattle.proceed();
            // End battle stuff

            IsMouseVisible = true;
            base.Initialize();
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);
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
            if (Keyboard.GetState().IsKeyDown(Keys.Escape)) Exit();
            while (anyBattle.proceed()) { }
            if (testButton.isClicked(inputHelper)) foreach (turnlog turn in anyBattle.battlelog) System.Console.WriteLine(turn.Print());

            // Pass the Update into the base "Game" class
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            spriteBatch.Begin();
            // Blank lines for readability


            GraphicsDevice.Clear(Color.White);
            testButton.Draw(spriteBatch);


            // Blank lines for readability
            spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
