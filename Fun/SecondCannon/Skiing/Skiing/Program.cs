﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace Skiing
{
    class Program
    {
        static void Main(string[] args)
        {
            StreamReader sr = new StreamReader("Test.in");
            String line = sr.ReadLine();
            String[] numbers = line.Split(' ');
            int rows = int.Parse(numbers[0]);
            int cols = int.Parse(numbers[1]);
            int[,] maze = new int[rows, cols];
            for (int i = 0; i < rows; i++)
            {
                line = sr.ReadLine();
                numbers = line.Split(' ');
                for (int j = 0; j < cols; j++)
                {
                    maze[i, j] = int.Parse(numbers[j]);
                }
            }
            int maxResult = 0;
            List<KeyValuePair<int, int>> maxRoad = new List<KeyValuePair<int, int>>();
            for(int i=0; i<rows; i++)
                for (int j = 0; j < rows; j++)
                {
                    List<KeyValuePair<int, int>> road = new List<KeyValuePair<int, int>>();
                    int result = GetMaxRoad(i, j, maze, rows, cols, road);
                    if (result > maxResult)
                    {
                        maxResult = result;
                        maxRoad = road;
                    }
                }

            maxResult += 1;

        }

        static int GetMaxRoad(int ipos, int jpos, int[,] maze, int rows, int cols, List<KeyValuePair<int, int>> road)
        {
            int[] neighbor = new int[4];
            neighbor[0] = (ipos > 0) ? maze[ipos - 1, jpos] : -1;
            neighbor[1] = (jpos > 0) ? maze[ipos, jpos - 1] : -1;
            neighbor[2] = (ipos < rows - 1) ? maze[ipos + 1, jpos] : -1;
            neighbor[3] = (jpos < cols - 1) ? maze[ipos, jpos + 1] : -1;
            int[,] steps = {{-1, 0},{0,-1}, {1,0}, {0,1}};
            int maxResult = 0;
            road.Add(new KeyValuePair<int, int>(ipos, jpos));
            List<KeyValuePair<int, int>> maxRoad = new List<KeyValuePair<int, int>>();
            for (int i = 0; i < 4; i++)
            {
                if (neighbor[i] >= 0 && neighbor[i] < maze[ipos, jpos])
                {
                    List<KeyValuePair<int, int>> curRoad = new List<KeyValuePair<int, int>>();
                    int result = 1 + GetMaxRoad(ipos + steps[i, 0], jpos + steps[i, 1], maze, rows, cols, curRoad);
                    if (result > maxResult)
                    {
                        maxResult = result;
                        maxRoad = curRoad;
                    }
                }
            }
            for (int i = 0; i < maxRoad.Count; i++)
            {
                road.Add(maxRoad[i]);
            }
                return maxResult;
        }
    }
}
