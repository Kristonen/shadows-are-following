using Raylib_cs;

RunGame();


[STAThread]
void RunGame()
{
    Raylib.InitWindow(1920, 1080, "Shadows are following");

    while (!Raylib.WindowShouldClose()){
        Raylib.BeginDrawing();
        Raylib.DrawCircleV(new(500, 500), 50, Color.Purple);
        Raylib.EndDrawing();
    }
}