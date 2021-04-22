using Microsoft.Xna.Framework;
using SadConsole;
using SadConsole.Controls;
using System;

namespace Multirogue.Client.AsciiClient.UI
{
    public class UIManager : ContainerConsole
    {
        public ScrollingConsole MapConsole;
        public Window MapWindow;

        public MessageLogWindow MessageLog;
        public SadConsole.Themes.Colors CustomColors;

        public UIManager()
        {
            // must be set to true
            // or will not call each child's Draw method
            IsVisible = true;
            IsFocused = true;

            // The UIManager becomes the only
            // screen that SadConsole processes
            Parent = SadConsole.Global.CurrentScreen;
        }

        // Initializes all windows and consoles
        public void Init()
        {

            SetupCustomColors();
            CreateConsoles();
            CreateMapWindow(GameLoop.GameWidth / 2, GameLoop.GameHeight / 2, "Game Map");

            MessageLog = new MessageLogWindow(GameLoop.GameWidth / 2, GameLoop.GameHeight / 2, "Message Log");
            Children.Add(MessageLog);
            MessageLog.Show();
            MessageLog.Position = new Point(0, GameLoop.GameHeight / 2);
        }

        // Creates all child consoles to be managed
        public void CreateConsoles()
        {
            MapConsole = new SadConsole.ScrollingConsole(
                GameLoop.World.CurrentMap.Width,
                GameLoop.World.CurrentMap.Height,
                Global.FontDefault,
                new Rectangle(0, 0, GameLoop.GameWidth, GameLoop.GameHeight),
                GameLoop.World.CurrentMap.Tiles);
        }

        // Creates a window that encloses a map console
        // of a specified height and width
        // and displays a centered window title
        // make sure it is added as a child of the UIManager
        // so it is updated and drawn
        public void CreateMapWindow(int width, int height, string title)
        {
            MapWindow = new Window(width, height);
            MapWindow.CanDrag = false;

            //make console short enough to show the window title
            //and borders, and position it away from borders
            int mapConsoleWidth = width - 2;
            int mapConsoleHeight = height - 2;

            // Resize the Map Console's ViewPort to fit inside of the window's borders snugly
            MapConsole.ViewPort = new Rectangle(0, 0, mapConsoleWidth, mapConsoleHeight);

            //reposition the MapConsole so it doesnt overlap with the left/top window edges
            MapConsole.Position = new Point(1, 1);

            //close window button
            Button closeButton = new Button(3, 1);
            closeButton.Position = new Point(0, 0);
            closeButton.Text = "[X]";

            //Add the close button to the Window's list of UI elements
            MapWindow.Add(closeButton);

            // Centre the title text at the top of the window
            MapWindow.Title = title.Align(HorizontalAlignment.Center, mapConsoleWidth);

            //add the map viewer to the window
            MapWindow.Children.Add(MapConsole);

            // The MapWindow becomes a child console of the UIManager
            Children.Add(MapWindow);

            // Without this, the window will never be visible on screen
            MapWindow.Show();

        }

        // Build a new coloured theme based on SC's default theme
        // and then set it as the program's default theme.
        private void SetupCustomColors()
        {
            // Create a set of default colours that we will modify
            CustomColors = SadConsole.Themes.Colors.CreateDefault();

            // Pick a couple of background colours that we will apply to all consoles.
            Color backgroundColor = Color.Black;

            // Set background colour for controls consoles and their controls
            CustomColors.ControlHostBack = backgroundColor;
            CustomColors.ControlBack = backgroundColor;

            // Generate background colours for dark and light themes based on
            // the default background colour.
            CustomColors.ControlBackLight = (backgroundColor * 1.3f).FillAlpha();
            CustomColors.ControlBackDark = (backgroundColor * 0.7f).FillAlpha();

            // Set a color for currently selected controls. This should always
            // be different from the background colour.
            CustomColors.ControlBackSelected = CustomColors.GrayDark;

            // Rebuild all objects' themes with the custom colours we picked above.
            CustomColors.RebuildAppearances();

            // Now set all of these colours as default for SC's default theme.
            SadConsole.Themes.Library.Default.Colors = CustomColors;
        }

        // centers the viewport camera on an Actor
        public void CenterOnActor(Actor actor)
        {
            MapConsole.CenterViewPortOnPoint(actor.Position);
        }

        public override void Update(TimeSpan timeElapsed)
        {
            CheckKeyboard();
            base.Update(timeElapsed);
        }

        // Scans the SadConsole's Global KeyboardState and triggers behaviour
        // based on the button pressed.
        private void CheckKeyboard()
        {
            // As an example, we'll use the F5 key to make the game full screen
            if (SadConsole.Global.KeyboardState.IsKeyReleased(Microsoft.Xna.Framework.Input.Keys.F5))
            {
                SadConsole.Settings.ToggleFullScreen();
            }

            // Keyboard movement for Player character: Up arrow
            // Decrement player's Y coordinate by 1
            if (SadConsole.Global.KeyboardState.IsKeyPressed(Microsoft.Xna.Framework.Input.Keys.Up))
            {
            }

            // Keyboard movement for Player character: Down arrow
            // Increment player's Y coordinate by 1
            if (SadConsole.Global.KeyboardState.IsKeyPressed(Microsoft.Xna.Framework.Input.Keys.Down))
            {
            }

            // Keyboard movement for Player character: Left arrow
            // Decrement player's X coordinate by 1
            if (SadConsole.Global.KeyboardState.IsKeyPressed(Microsoft.Xna.Framework.Input.Keys.Left))
            {
            }

            // Keyboard movement for Player character: Right arrow
            // Increment player's X coordinate by 1
            if (SadConsole.Global.KeyboardState.IsKeyPressed(Microsoft.Xna.Framework.Input.Keys.Right))
            {
            }
        }
    }
}