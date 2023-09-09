namespace Trivia.Tests;

public class Game_should
{
    [Fact]
    public void initially_be_unplayable()
    {
        var subject = new Game();

        var actual = subject.IsPlayable();

        actual.ShouldBeFalse();
    }
    [Fact]
    public void add_a_player()
    {
        const string playerName = "yermom";
        var log = new List<string>();
        var subject = new Game(log.Add);

        subject.Add(playerName);

        log.Count.ShouldBe(2);
        log[0].ShouldContain($"{playerName} was added");
        log[1].ShouldContain("They are player number 1");
        subject.IsPlayable().ShouldBeFalse();
        subject.HowManyPlayers().ShouldBe(1);
    }
    [Fact]
    public void add_two_players()
    {
        const string playerName1 = "yermom";
        const string playerName2 = "nacho mama";
        var log = new List<string>();
        var subject = new Game(log.Add);

        subject.Add(playerName1);
        subject.Add(playerName2);

        log.Count.ShouldBe(4);
        log[0].ShouldContain($"{playerName1} was added");
        log[1].ShouldContain("They are player number 1");
        log[2].ShouldContain($"{playerName2} was added");
        log[3].ShouldContain("They are player number 2");
        subject.IsPlayable().ShouldBeTrue();
        subject.HowManyPlayers().ShouldBe(2);
    }
}