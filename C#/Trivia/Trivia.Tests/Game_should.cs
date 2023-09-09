namespace Trivia.Tests;

public class Game_should
{
    [Fact]
    public void do_something_useful_with_a_meaningful_test_name()
    {
        var subject = new Game();

        var actual = subject.IsPlayable();

        actual.ShouldBeFalse();
    }
}