public class randomObjectPlacer
{
    Random random = new Random();
    public void run(char[,] firstLayer, char[,] secondLayer, int numberOfObjectsToPlace, char item)
    {
        int objectsCreated = 0;
        while (objectsCreated < numberOfObjectsToPlace)
        {
            int xCoordinate = random.Next(0, firstLayer.GetLength(0)-1);
            int yCoordinate = random.Next(0,firstLayer.GetLength(1)-1);
            if(firstLayer[yCoordinate,xCoordinate] == 'f' && secondLayer[yCoordinate, xCoordinate] == 'Q')
            {
                secondLayer[yCoordinate, xCoordinate] = item;
                objectsCreated++;
                Console.WriteLine("Placed an object");
            }
        }
    }
}