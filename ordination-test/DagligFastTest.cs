namespace ordination_test;

using shared.Model;

[TestClass]
public class DagligFastTest
{
    [TestMethod]
    public void TestDoegnDosis()
    {
        var lm = new Laegemiddel("Test",1,1,1,"stk");
        var df = new DagligFast(DateTime.Now, DateTime.Now, lm, 2,1,1,0);

        Assert.AreEqual(4, df.doegnDosis());
    }
    
    [TestMethod]
    public void TestSamletDosis()
    {
        var lm = new Laegemiddel("Test",1,1,1,"stk");
        var df = new DagligFast(new DateTime(2024,1,1), new DateTime(2024,1,3), lm, 2,1,1,0);

        Assert.AreEqual(12, df.samletDosis()); // 4 * 3 dage
    }
    
    [TestMethod]
    public void TestDagligFastZero()
    {
        var lm = new Laegemiddel("Test",1,1,1,"stk");
        var df = new DagligFast(DateTime.Now, DateTime.Now, lm, 0,0,0,0);

        Assert.AreEqual(0, df.doegnDosis());
    }
}

