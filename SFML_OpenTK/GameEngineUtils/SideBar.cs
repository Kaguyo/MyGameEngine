using SFML.Graphics;
using SFML.System;

namespace GameEngine.SFML_OpenTK.GameEngineUtils
{
    internal class SideBar
    {
        private static readonly Color SidebarColor = new Color(169, 169, 169); // Cor cinza

        internal static RectangleShape GenerateSideBar(RenderWindow window)
        {
            RectangleShape sidebar = new RectangleShape(new Vector2f(window.Size.X / 5, window.Size.Y))
            {
                FillColor = SidebarColor
            };

            return sidebar;
        }
    }
}
