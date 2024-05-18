using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class BSPNode
{
    private BSPNode parent;
    private BSPNode sibling;
    private BSPNode[] children;
    private int level;
    private bool connected;

    private Subset subset;
    private Subset room;

    public BSPNode(int assignlevel)
    {
        parent = null;
        sibling = null;
        children = new BSPNode[2]; // Each node can have at most two children
        subset = null;
        this.level = assignlevel;
        connected = false;
        room = null;
    }

    public void SetParent(BSPNode parentNode)
    {
        parent = parentNode;
    }

    public BSPNode GetParent()
    {
        return parent;
    }

    public void SetSibling(BSPNode siblingNode)
    {
        sibling = siblingNode;
    }

    public BSPNode GetSibling()
    {
        return sibling;
    }

    public void SetChildren(BSPNode[] childNodes)
    {
        children = childNodes;
    }

    public BSPNode[] GetChildren()
    {
        return children;
    }

    public void SetSubset(Subset subset)
    {
        this.subset = subset;
    }

    public Subset GetSubset()
    {
        return this.subset;
    }

    public int GetLevel()
    {
        return this.level;
    }

    public void SetConnected()
    {
        this.connected = true;
    }
    public bool GetConnected()
    {
        return connected;
    }

    public void SetRoom(Subset subset)
    {
        this.room = subset;
    }

    public Subset GetRoom()
    {
        return this.room;
    }

    public void SetRoomFromChildren()
    {
        // Ensure there are children nodes
        if (children != null && children.Length > 0)
        {
            // Get all tiles from all children
            var allTiles = children.SelectMany(child => child.GetRoom().GetTiles());

            // Set the room for the parent node
            room = new Subset(allTiles);
        }
    }

}

public class Subset
{
    private List<(int x, int y)> coordinates;
    public Subset(IEnumerable<(int x, int y)> coordinates)
    {
        this.coordinates = coordinates.ToList();
    }

    public Subset((int x1, int y1) topLeft, (int x2, int y2) bottomRight)
    {
        coordinates = new List<(int, int)>();
        //Console.WriteLine($"Creating subset from ({topLeft.x1}, {topLeft.y1}) to ({bottomRight.x2}, {bottomRight.y2})");


        for (int x = topLeft.x1; x <= bottomRight.x2; x++)
        {
            for (int y = topLeft.y1; y >= bottomRight.y2; y--)
            {
                coordinates.Add((x, y));
            }
        }
    }

    public int Length()
    {
        return coordinates.Count;
    }

    public IEnumerable<(int x, int y)> GetTiles()
    {
        return coordinates;
    }

    public void AddCoordinates(IEnumerable<(int x, int y)> newCoordinates)
    {
        coordinates.AddRange(newCoordinates);
    }

    public void AddCoordinates(int startX, int startY, int endX, int endY)
    {
        for (int x = startX; x <= endX; x++)
        {
            for (int y = startY; y <= endY; y++)
            {
                coordinates.Add((x, y));
            }
        }
    }
    public override string ToString()
    {
        StringBuilder sb = new StringBuilder();
        sb.Append("Subset coordinates: ");
        foreach (var coord in coordinates)
        {
            sb.Append($"({coord.x}, {coord.y}) ");
        }
        return sb.ToString();
    }

}

public class BSP_rooms
{
    private Random random = new Random();


    public void run(Subset subset, BSPNode node, int maxAcceptedSize, List<BSPNode> nodeList, char[,] grid)
    {
        partition(subset, node, maxAcceptedSize, nodeList);
        randomRoomPlacement(nodeList, grid);
        // Iterate over each row in reverse order
        for (int row = grid.GetLength(0) - 1; row >= 0; row--) {
            // Iterate over each column in the current row
            for (int col = 0; col < grid.GetLength(1); col++) {
                // Print the value of the current element
                Console.Write(grid[row, col] + " ");
            }
            // Move to the next line after printing all columns in the current row
            Console.WriteLine();
        }
        Console.WriteLine();
        Console.WriteLine();
        BSP_corridors(nodeList, grid);
    }
    
    public void partition(Subset subset, BSPNode node, int maxAcceptedSize, List<BSPNode> nodeList)
    {
        if (subset.Length() <= maxAcceptedSize)
        {
            return;
        }
        int directionOfFirstSplit = random.Next(1, 3);

        if (directionOfFirstSplit == 1)
            split(1, subset, node, nodeList, maxAcceptedSize);
        else if (directionOfFirstSplit == 2)
            split(2, subset, node, nodeList, maxAcceptedSize);
    }
    private void split(int directionOfSplit, Subset subset, BSPNode node, List<BSPNode> nodeList, int maxAcceptedSize)
    {
        BSPNode leftChild = new BSPNode(node.GetLevel()+1);
        BSPNode rightChild = new BSPNode(node.GetLevel()+1);
        int minX = subset.GetTiles().Min(tile => tile.x);
        int maxX = subset.GetTiles().Max(tile => tile.x);
        int minY = subset.GetTiles().Min(tile => tile.y);
        int maxY = subset.GetTiles().Max(tile => tile.y);

        if (directionOfSplit == 1)
        {
            int splitValue = random.Next(minX, maxX);

            
            Subset subset1 = new Subset((subset.GetTiles().Min(tile => tile.x), maxY), (splitValue, minY));
            Subset subset2 = new Subset((splitValue, maxY), (subset.GetTiles().Max(tile => tile.x), minY));

            leftChild.SetSubset(subset1);
            rightChild.SetSubset(subset2);
            leftChild.SetSibling(rightChild);
            rightChild.SetSibling(leftChild);
            leftChild.SetParent(node);
            rightChild.SetParent(node);

            nodeList.Add(leftChild);
            nodeList.Add(rightChild);

            BSPNode[] children= {leftChild, rightChild};
            node.SetChildren(children);         

        
            partition(subset1, leftChild, maxAcceptedSize, nodeList);
            partition(subset2, rightChild, maxAcceptedSize, nodeList);
        }
        if(directionOfSplit == 2)
        {
            int splitValueY = random.Next(minY, maxY);

            // Create subsets based on the random split value
            Subset subset1 = new Subset((subset.GetTiles().Min(tile => tile.x), maxY), (subset.GetTiles().Max(tile => tile.x), splitValueY));
            Subset subset2 = new Subset((subset.GetTiles().Min(tile => tile.x), splitValueY), (subset.GetTiles().Max(tile => tile.x), minY));

            leftChild.SetSubset(subset1);
            rightChild.SetSubset(subset2);
            leftChild.SetSibling(rightChild);
            rightChild.SetSibling(leftChild);
            leftChild.SetParent(node);
            rightChild.SetParent(node);

            nodeList.Add(leftChild);
            nodeList.Add(rightChild);

            BSPNode[] children= {leftChild, rightChild};
            node.SetChildren(children);
            
            partition(subset1, leftChild, maxAcceptedSize, nodeList);
            partition(subset2, rightChild, maxAcceptedSize, nodeList);
        }


    }

    private void randomRoomPlacement(List<BSPNode> nodeList, char[,] grid)
    {
        
        foreach (BSPNode node in nodeList)
        {
            if(node.GetChildren()[0] == null)
            {
                Subset subset = node.GetSubset();
                // Generate random coordinates for the top-left corner of the room
                //Console.WriteLine(subset);
                int minX = subset.GetTiles().Min(tile => tile.x);
                int maxX = subset.GetTiles().Max(tile => tile.x);
                int minY = subset.GetTiles().Min(tile => tile.y);
                int maxY = subset.GetTiles().Max(tile => tile.y);
                //Console.WriteLine("min og max x: " + minX + " " + maxX + " og y: " + minY + " " + maxY);

                int roomTopLeftCornerX = random.Next(minX, maxX);
                int roomTopLeftCornerY = random.Next(minY, maxY);
                //Console.WriteLine("topleft: " + roomTopLeftCornerX +", " + roomTopLeftCornerY);

                // Generate random coordinates for the bottom-right corner of the room
                int roomBottomRightCornerX = random.Next(roomTopLeftCornerX, maxX);
                int roomBottomRightCornerY = random.Next(minY, roomTopLeftCornerY);  

                for(int i = roomTopLeftCornerX; i <= roomBottomRightCornerX; i++)
                {
                    for(int j = roomBottomRightCornerY; j <= roomTopLeftCornerY;j++)
                    {
                        grid[j, i] = (char)('0' + node.GetLevel());
                        //grid[j, i] = 'f';
                    }
                }

                Subset room = new Subset((roomTopLeftCornerX, roomTopLeftCornerY), (roomBottomRightCornerX, roomBottomRightCornerY));
                //Console.WriteLine("Values for SetRoom: " + roomTopLeftCornerX + " " + roomTopLeftCornerY + " " + roomBottomRightCornerX + " " + roomBottomRightCornerY);
                node.SetRoom(room);
                //Console.WriteLine("Node at level: " + node.GetLevel() + " has been set to: " + node.GetRoom());
                
            }
        }
    }

    private void BSP_corridors(List<BSPNode> nodeList, char[,] grid)
    {
        // Group nodes by their level
        var groupedNodes = nodeList.GroupBy(n => n.GetLevel()).OrderByDescending(g => g.Key);
        //Iterate through each group of nodes
        foreach(var group in groupedNodes)
        {
            foreach(var node in group)
            {
                //Console.WriteLine(node.GetLevel());
                if(node.GetSibling() != null && node.GetConnected() == false && node.GetSibling().GetRoom() != null)
                {
                    //Console.WriteLine("Valid node");
                    //Console.WriteLine("fromNode: " + node.GetRoom());
                    //Console.WriteLine("toNode: " + node.GetSibling().GetRoom());

                    connect_rooms(node, node.GetSibling(), grid);
                    node.SetConnected();
                    node.GetSibling().SetConnected();
                    
                    // Set room for the parent node after connecting children
                    if (node.GetParent() != null)
                    {
                        node.GetParent().SetRoomFromChildren();
                    }

                }
            }
            
        }
    }

    private void connect_rooms(BSPNode fromRoom, BSPNode toRoom, char[,] grid)
    {
        int currentX = 0;
        int currentY = 0;
        int smallestXdifference = grid.GetLength(1);
        int smallestYdifference = grid.GetLength(0);
        int startX = 0;
        int startY = 0;
        int endX = 0;
        int endY = 0;

        foreach(var fromTile in fromRoom.GetRoom().GetTiles())
        {
            foreach(var toTile in toRoom.GetRoom().GetTiles())
            {
                if(fromTile.x == toTile.x)
                {
                    currentX = fromTile.x;
                    currentY = fromTile.y;
                    while(currentY != toTile.y)
                    {
                        grid[currentY, currentX] = 'c';
                        if(currentY < toTile.y)
                        {
                            currentY +=1;
                        }
                        else
                        {
                            currentY -=1;
                        }
                        
                        
                    }
                    return;
                }
                if(fromTile.y == toTile.y)
                {
                    currentX = fromTile.x;
                    currentY = fromTile.y;
                    while(currentX != toTile.x)
                    {
                        grid[currentY, currentX] = 'c';
                        if(currentX < toTile.x)
                        {
                            currentX +=1;
                        }
                        else
                        {
                            currentX -=1;
                        }
                    }
                    return;
                }
                if(Math.Abs(fromTile.x - toTile.x) < smallestXdifference)
                {
                    smallestXdifference = Math.Abs(fromTile.x - toTile.x);
                    startX = fromTile.x;
                    startY = fromTile.y;
                    endX = toTile.x;
                    endY = toTile.y;
                }
                if(Math.Abs(fromTile.y - toTile.y) < smallestYdifference)
                {
                    smallestYdifference = Math.Abs(fromTile.y - toTile.y);
                    startX = fromTile.x;
                    startY = fromTile.y;
                    endX = toTile.x;
                    endY = toTile.y;
                }
                
                
            }
            

        }
        if(smallestXdifference < smallestYdifference)
        {
            currentX = startX;
            currentY = startY;
            while(currentX != endX)
            {
                grid[currentY, currentX] = 'c';
                //Console.WriteLine("c in third: (" + currentX + ", " + currentY + ")");
                if(currentX < endX)
                {
                    currentX +=1;
                }
                else
                {
                    currentX -=1;
                }
                
            }
            while(currentY != endY)
            {
                grid[currentY, currentX] = 'c';
                //Console.WriteLine("c in fourth: (" + currentX + ", " + currentY + ")");
                if(currentY < endY)
                {
                    currentY +=1;
                }
                else
                {
                    currentY -=1;
                }
                
            }
            
        }
        else
        {
            currentX = startX;
            currentY = startY;
            //Console.WriteLine("currentPoint: (" + currentX + ", " + currentY + ")");
            //Console.WriteLine("endPoint: (" + endX + ", " + endY + ")");
            while(currentY != endY)
            {
                grid[currentY, currentX] = 'c';
                //Console.WriteLine("c in fifth: (" + currentX + ", " + currentY + ")");
                if(currentY < endY)
                {
                    currentY +=1;
                }
                else
                {
                    currentY -=1;
                }
                
            }
            while(currentX != endX)
            {
                grid[currentY, currentX] = 'c';
                //Console.WriteLine("c in sixth: (" + currentX + ", " + currentY + ")");
                if(currentX < endX)
                {
                    currentX +=1;
                }
                else
                {
                    currentX -=1;
                }
                
            }
        }
    }

    
}