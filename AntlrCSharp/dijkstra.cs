using System.Data;

public class element:IComparable<element>
{
    public int xCoordinate{get; set;}
    public int yCoordinate{get; set;}
    public int distance{get; set;}
    public int CompareTo(element other)
    {
        return distance.CompareTo(other.distance);
    }
}

public class dijkstra
{
    public bool run(char[,] layer, char[,]secondLayer)
    {
        //Get the dimensions of the layer
        int rows = layer.GetLength(0);
        int cols = layer.GetLength(1);
        int[,] distances = new int[rows, cols];

        //Find entrypoint and exitpoint
        int Excoordinate = 0;
        int Eycoordinate = 0;
        int ExitXcoordinate = 0;
        int ExitYcoordinate = 0;
        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                if (secondLayer[i, j] == 'E')
                {
                    Excoordinate = j;
                    Eycoordinate = i;
                }
                if (secondLayer[i, j] == 'X')
                {
                    ExitXcoordinate = j;
                    ExitYcoordinate = i;
                }
            }
        }


        //Set initial distances to a large value, indicating that they are not yet reachable
        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                distances[i, j] = int.MaxValue;
            }
        }

        //Set the distance of the starting point to 0
        distances[Eycoordinate, Excoordinate] = 0;

        //Create queue and enqueue starting tile
        PriorityQueue<element,int> Q = new PriorityQueue<element, int>();
        Q.Enqueue(new element{xCoordinate = Excoordinate, yCoordinate = Eycoordinate, distance = 0}, 0);
        
        int[] neighborXvalues = {-1, 1, 0, 0, -1, -1, 1, 1};
        int[] neighborYvalues = {0, 0, -1, 1, 1, -1, -1, 1};
        while(Q.Count > 0)
        {
            var current = Q.Dequeue();

            int currentX = current.xCoordinate;
            int currentY = current.yCoordinate;
            int currentDist = current.distance;

            //Iterate through each neighbor tile
            for(int i = 0; i < 8; i++)
            {
                int neighborX = currentX - neighborXvalues[i];
                int neighborY = currentY - neighborYvalues[i];

                //Check if neighbor exists in layer
                if (neighborX >= 0 && neighborX < rows && neighborY >= 0 && neighborY < cols && layer[neighborY,neighborX] == 'f')
                {
                    int newDistance = currentDist +1;
                    if(newDistance < distances[neighborY, neighborX])
                    {
                        distances[neighborY, neighborX] = newDistance;
                        Q.Enqueue(new element { xCoordinate = neighborX, yCoordinate = neighborY, distance = newDistance }, newDistance);
                    }
                }
            }
        }
        //TESTING PURPOSES
        //int rows2 = layer.GetLength(0);
        //int cols2 = layer.GetLength(1);

        //for (int i = rows2 - 1; i >= 0; i--)  // Iterate over the rows in reverse order
        //{
        //    for (int j = 0; j < cols2; j++)  // Iterate over the columns in normal order
        //    {
        //        if (distances[i, j] == int.MaxValue)
        //            Console.Write("I ");  // Print 'INF' for unreachable cells
        //        else
        //            Console.Write(distances[i, j] + " ");
        //    }
        //    Console.WriteLine();
        //}
        //If distance to exit point is reachable return true; return false otherwise
        if(distances[ExitYcoordinate, ExitXcoordinate] != int.MaxValue)
        {
            return true;
        }
        return false;
    }
}