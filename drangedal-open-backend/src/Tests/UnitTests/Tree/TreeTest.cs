
using Common.Models.Tournament;
using Common.Models.Tournament.Tree;
namespace Tests.UnitTests.Tree;

public class TreeTest
{
    [Fact]
    public void GenerateTreeFour()
    {
        TournamentTree tree = new();
        tree.GenerateTournamentTree(Get4Players());

        Assert.Equal("1",tree.Winner.LeftNode.LeftNode.Player.User.Username);
        Assert.Equal("2",tree.Winner.LeftNode.RightNode.Player.User.Username);
        Assert.Equal("3",tree.Winner.RightNode.LeftNode.Player.User.Username);
        Assert.Equal("4",tree.Winner.RightNode.RightNode.Player.User.Username);
    }
    
    [Fact]
    public void GenerateTreeTwo()
    {
        TournamentTree tree = new();
        tree.GenerateTournamentTree(Get2Players());

        Assert.Equal("1",tree.Winner.LeftNode.Player.User.Username);
        Assert.Equal("2",tree.Winner.RightNode.Player.User.Username);
    }
    
    [Fact]
    public void GenerateTreeFive()
    {
        TournamentTree tree = new();
        tree.GenerateTournamentTree(Get5Players());

        Assert.Equal("1",tree.Winner.LeftNode.LeftNode.LeftNode.Player.User.Username);
        Assert.Equal("2",tree.Winner.LeftNode.LeftNode.RightNode.Player.User.Username);
        Assert.Equal("3",tree.Winner.LeftNode.RightNode.LeftNode.Player.User.Username);
        Assert.Equal("4",tree.Winner.LeftNode.RightNode.RightNode.Player.User.Username);
        Assert.Equal("5",tree.Winner.RightNode.LeftNode.LeftNode.Player.User.Username);
        Assert.Null(tree.Winner.RightNode.LeftNode.RightNode.Player);
    }

    private List<Player> Get4Players()
    {
        return new()
        {
            new() {User = new() {Username = "1"}},
            new(){User = new(){Username = "2"}},
            new(){User = new(){Username = "3"}},
            new(){User = new(){Username = "4"}}
        };
    }
    
    private List<Player> Get2Players()
    {
        return new()
        {
            new() {User = new() {Username = "1"}},
            new(){User = new(){Username = "2"}}
        };
    }
    
    private List<Player> Get5Players()
    {
        return new()
        {
            new() {User = new() {Username = "1"}},
            new(){User = new(){Username = "2"}},
            new(){User = new(){Username = "3"}},
            new(){User = new(){Username = "4"}},
            new(){User = new(){Username = "5"}}
        };
    }
}