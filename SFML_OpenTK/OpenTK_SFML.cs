using SFML.Graphics;
using OpenTK;
using OpenTK.Graphics;
using SFML.Window;
using SFML.Graphics;
using SFML.System;
using System.Text;
using static SFML.Window.Mouse;

namespace GameEngine.SFML_OpenTK
{
    internal class SFML_OpenTK
    {
        private static List<Drawable> gameObjects = new();

        private static void CreateGameObject(string objectType)
        {
            if (objectType == "Cube")
            {
                RectangleShape cube = new RectangleShape(new Vector2f(50, 50))
                {
                    FillColor = Color.Green,
                    Position = new Vector2f(100, 100)
                };
                gameObjects.Add(cube);
            }
            else if (objectType == "Triangle")
            {
                ConvexShape triangle = new ConvexShape(3);
                triangle.SetPoint(0, new Vector2f(100, 100));
                triangle.SetPoint(1, new Vector2f(150, 50));
                triangle.SetPoint(2, new Vector2f(200, 100));
                triangle.FillColor = Color.Red;
                gameObjects.Add(triangle);
            }
        }

        internal static void EngineInterface()
        {
            RenderWindow window = new RenderWindow(new VideoMode(800, 600), "SFML + OpenTK Integration");
            window.SetFramerateLimit(60);

            Text logText = new()
            {
                CharacterSize = 16,
                FillColor = Color.White,
                Position = new Vector2f(10, 10),
                Font = new Font(@"C:\Windows\Fonts\arial.ttf")
            };
            StringBuilder logBuilder = new();
            Console.SetOut(new StringWriter(logBuilder));
            
            RectangleShape sideBar = GameEngineUtils.SideBar.GenerateSideBar(window);
            float realSideBar = sideBar.Size.X;
            byte logOutputCount = 0;
            bool sideBarLog = false;
            
            while (window.IsOpen)
            {
                if (Keyboard.IsKeyPressed(Keyboard.Key.Escape))
                {
                    window.Close();
                }
                if (Mouse.IsButtonPressed(Mouse.Button.Left))
                {
                    Vector2i mousePos = Mouse.GetPosition(window);
                    realSideBar = window.Size.X / 5;
                    if (mousePos.X < realSideBar) // Se o clique for dentro da aba
                    {
                        //if (button1.GetGlobalBounds().Contains(mousePos.X, mousePos.Y))
                        //{
                        //    // Botão "Adicionar Cubo"
                        //    CreateGameObject("Cube");
                        //}
                        //else if (button2.GetGlobalBounds().Contains(mousePos.X, mousePos.Y))
                        //{
                        //    // Botão "Adicionar Triângulo"
                        //    CreateGameObject("Triangle");
                        //}
                        Console.WriteLine("You have pressed inside sideBar");
                        logOutputCount = 0;
                        sideBarLog = true;
                    }
                }
                foreach (var gameObject in gameObjects)
                {
                    window.Draw(gameObject);
                }
                
                window.DispatchEvents();
                window.Clear(Color.Black);
                logText.DisplayedString = logBuilder.ToString();
                window.Draw(sideBar);
                if (logOutputCount >= 15)
                {
                    logBuilder.Clear();
                    logOutputCount = 0;
                }
                else
                {
                    if (sideBarLog) window.Draw(logText);
                    sideBarLog = false;
                    logOutputCount++;
                }
                window.Display();
            }
        }
    }
}
