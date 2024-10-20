using System;

class LineDrawer
{
    static void Main(string[] args)
    {
        // Размеры массива
        int width = 20;
        int height = 20;
        int[,] grid = new int[height, width];

        // Начальная точка
        int startX = 0;
        int startY = 0;

        // Угол (в градусах)
        double angle = 90;

        // Длина линии
        int lineLength = 15;

        // Рисуем линию
        DrawLine(grid, startX, startY, angle, lineLength);

        // Вывод массива
        PrintGrid(grid);
    }

    static void DrawLine(int[,] grid, int startX, int startY, double angle, int length)
    {
        // Преобразуем угол в радианы
        double radians = angle * Math.PI / 180;

        // Вычисляем направление движения
        double deltaX = Math.Cos(radians);
        double deltaY = Math.Sin(radians);

        // Проходим по каждой точке линии
        for (int i = 0; i < length; i++)
        {
            // Определяем текущие координаты
            int x = startX + (int)(i * deltaX);
            int y = startY + (int)(i * deltaY);

            // Проверяем, что координаты находятся в пределах массива
            if (x >= 0 && x < grid.GetLength(1) && y >= 0 && y < grid.GetLength(0))
            {
                // Устанавливаем значение 1 для текущей точки
                grid[y, x] = 1;
            }
        }
    }

    static void PrintGrid(int[,] grid)
    {
        for (int y = 0; y < grid.GetLength(0); y++)
        {
            for (int x = 0; x < grid.GetLength(1); x++)
            {
                Console.Write(grid[y, x] + " ");
            }
            Console.WriteLine();
        }
    }
}
