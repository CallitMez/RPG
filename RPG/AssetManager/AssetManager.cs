using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG
{
    public class AssetManager
    {
        private AssetLoader<Texture2D> textureLoader;
        private AssetLoader<SpriteFont> fontLoader;

        public AssetManager(ContentManager content)
        {
            textureLoader = new AssetLoader<Texture2D>(content);
            fontLoader = new AssetLoader<SpriteFont>(content);
        }

        public Texture2D getTexture(string name)
        {
            return textureLoader[name];
        }

        public SpriteFont getFont(string name)
        {
            return fontLoader[name];
        }

        // TODO check if this is actually possible?
        public T getAsset<T>(string name) where T : class
        {
            object s = textureLoader[name];
            if (s is T)
                return (T) s;

            s = fontLoader[name];
            if (s is T)
                return (T) s;


            // Can't find an asset that works? Well, fuck that D:
            return null;
        }

        private class AssetLoader<T>
        {
            ContentManager content;
            Dictionary<string, T> assetDict;

            public AssetLoader(ContentManager content)
            {
                this.content = content;
                assetDict = new Dictionary<string, T>();
            }

            public T getAsset(string name)
            {
                // Return the loaded asset if it exists
                if (assetDict.ContainsKey(name))
                    return assetDict[name];

                // Try loading it if it hasn't been loaded before
                T asset = content.Load<T>(name);
                assetDict[name] = asset;
                return asset;
            }

            public T this[string name]
            {
                get
                {
                    return getAsset(name);
                }
            }
        }
    }
}
