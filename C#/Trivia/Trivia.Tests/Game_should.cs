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
    public void do_something()
    {
        
    }
}