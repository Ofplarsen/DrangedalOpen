namespace Common.Models.Tournament.Tree;

public class Node
{
    public Player Player { get; set; }
    public Node LeftNode { get; set; }
    public Node RightNode { get; set; }
}