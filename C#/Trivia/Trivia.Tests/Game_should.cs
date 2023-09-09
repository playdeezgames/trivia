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
    [Fact]
    public void add_three_players()
    {
        const string playerName1 = "yermom";
        const string playerName2 = "nacho mama";
        const string playerName3 = "another";
        var log = new List<string>();
        var subject = new Game(log.Add);

        subject.Add(playerName1);
        subject.Add(playerName2);
        subject.Add(playerName3);

        log.Count.ShouldBe(6);
        log[0].ShouldContain($"{playerName1} was added");
        log[1].ShouldContain("They are player number 1");
        log[2].ShouldContain($"{playerName2} was added");
        log[3].ShouldContain("They are player number 2");
        log[4].ShouldContain($"{playerName3} was added");
        log[5].ShouldContain("They are player number 3");
        subject.IsPlayable().ShouldBeTrue();
        subject.HowManyPlayers().ShouldBe(3);
    }
    [Theory]
    [InlineData(1,"Science")]
    [InlineData(2,"Sports")]
    [InlineData(3,"Rock")]
    [InlineData(4,"Pop")]
    [InlineData(5,"Science")]
    public void roll_for_current_player(int dieRoll,string expectedCategory)
    {
        const string playerName1 = "yermom";
        const string playerName2 = "nacho mama";
        const string playerName3 = "another";
        var log = new List<string>();
        var subject = new Game(log.Add);
        subject.Add(playerName1);
        subject.Add(playerName2);
        subject.Add(playerName3);
        log.Clear();

        subject.Roll(dieRoll);

        log.Count().ShouldBe(5);
        log[0].ShouldContain($"{playerName1} is the current player");
        log[1].ShouldContain($"They have rolled a {dieRoll}");
        log[2].ShouldContain($"{playerName1}'s new location is {dieRoll}");
        log[3].ShouldContain($"The category is {expectedCategory}");
        log[4].ShouldContain($"{expectedCategory} Question 0");
   }
}