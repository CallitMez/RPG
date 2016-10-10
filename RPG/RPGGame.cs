using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;

namespace RPG
{
    public class RPGGame : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        Texture2D testure;
        Hero warrior;
        Hero anotherWarrior;
        Enemy fish;
        Battle anyBattle;
        public RPGGame()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        /*I'm trying to make sense of this Initialize stuff but idk what it does
         :/ sorry human beings relying on my expertise*/
        protected override void Initialize()
        {
            warrior = new Hero("Warrior", 10, 1);
            anotherWarrior = new Hero("Warrior2", 10, 1);
            fish = new Enemy("Fish", 10, 1, 3);
            List<Creature> heroes = new List<Creature>();
            List<Creature> enemies = new List<Creature>();
            heroes.Add(warrior);
            heroes.Add(anotherWarrior);
            enemies.Add(fish);
            anyBattle = new Battle(heroes, enemies);
            anyBattle.proceed();
            base.Initialize();
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);
            FileManager f = new FileManager();
            testure = Content.Load<Texture2D>("testure");
        }

        protected override void UnloadContent()
        {
            // What content is there to be unloaded?
        }

        protected override void Update(GameTime gameTime)
        {
            // Press escape to exit, will most likely have to be removed
            // at some point because we like to have an onscreen exit button
            if (Keyboard.GetState().IsKeyDown(Keys.Escape)) Exit();

            // Pass the Update into the base "Game" class
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            spriteBatch.Begin();
            // Blank lines for readability


            GraphicsDevice.Clear(Color.White);
            spriteBatch.Draw(testure, Vector2.Zero, Color.White);


            // Blank lines for readability
            spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
