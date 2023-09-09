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
    }
}