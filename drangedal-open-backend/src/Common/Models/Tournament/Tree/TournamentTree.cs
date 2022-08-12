namespace Common.Models.Tournament.Tree;

public class TournamentTree
{
    public Tournament Tournament { get; set; }
    public Node Winner { get; set; }

    public void GenerateTournamentTree(List<Player> players)
    {
        var size = GetSize(players.Count);

        List<Node> nodes = new();

        for (int i = 0; i < size; i++) 
        {
            if(players.Count <= i)
                nodes.Add(new());
            else
                nodes.Add(new(){Player = players[i]});
            
        }
        CreateTree(nodes);
    }

    private void CreateTree(List<Node> nodes)
    {
        if (nodes.Count == 1)
        {
            Winner = nodes[0];
            return;
        }
        List<Node> newNodes = new();

        for (int i = 0; i < nodes.Count; i += 2)
        {
            if(i > nodes.Count)
                newNodes.Add(new (){LeftNode = nodes[i]});
            else
                newNodes.Add(new (){LeftNode = nodes[i], RightNode = nodes[i+1]});
        }
        CreateTree(newNodes);
    }

    private int GetSize(int amount)
    {
        var log = (int)Math.Ceiling(Math.Log2(amount));
        return (int)Math.Pow(2, log);
    }

    public List<Match> GetMatches()
    {
        List<Match> matches = new();
        GetMatches(matches, Winner);
        return matches;
    }
    
    private void GetMatches(List<Match> matches, Node node)
    {
        if (node == null)
            return;

        GetMatches(matches, node.LeftNode);
        GetMatches(matches, node.RightNode);
        
    }
    
}