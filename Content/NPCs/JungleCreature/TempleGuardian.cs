using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using TempleUprising.Common.Interfaces;
using Terraria.DataStructures;

namespace TempleUprising.Content.NPCs.JungleCreature
{
    internal class TempleGuardian : CustomNPC
    {
        public override string Texture => throw new System.NotImplementedException();

        public override int Status { get => (int)NPC.ai[0]; set => NPC.ai[0] = value; }
        public override int Behavior { get => (int)NPC.ai[1]; set => NPC.ai[1] = value; }
        public override int ThisTimeValue { get => (int)NPC.ai[2]; set => NPC.ai[2] = value; }

        public override void AI()
        {
            throw new System.NotImplementedException();
        }

        public override void DrawBehind(int index)
        {
            throw new System.NotImplementedException();
        }

        public override void OnKill()
        {
            throw new System.NotImplementedException();
        }

        public override void OnSpawn(IEntitySource source)
        {
            throw new System.NotImplementedException();
        }

        public override bool PreDraw(SpriteBatch spriteBatch, Vector2 screenPos, Color drawColor)
        {
            throw new System.NotImplementedException();
        }

        public override void SetDefaults()
        {
            throw new System.NotImplementedException();
        }

        public override void SetStaticDefaults()
        {
            throw new System.NotImplementedException();
        }
    }
}
