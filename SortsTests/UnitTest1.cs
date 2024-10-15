namespace SortsTests;

public class Tests
{
    private int[] _numbers;
    private Random _random;

    [SetUp]
    public void Setup()
    {
        _numbers = [];
        _random = new();
    }

    [Test]
    [TestCase(new int[] {2, 5, 23, 2, 0, 3, 34, 3, 7, 2 })]
    public void BubbleSortTest(int [] numbers)
    {
        int[] firstArray = numbers.Clone() as int[];
        int[] secondArray = numbers.Clone() as int[];

        Array.Sort(firstArray);
        Array.Sort(secondArray);

        Assert.That(firstArray, Is.EqualTo(secondArray));
    }
}