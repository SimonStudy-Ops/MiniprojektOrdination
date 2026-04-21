namespace ordination_test;

using shared.Model;

[TestClass]
public class DagligSkaevTest
{
    [TestMethod]
    public void TestDoegnDosis()
    {
        var lm = new Laegemiddel("Test",1,1,1,"stk");
        var ds = new DagligSkæv(DateTime.Now, DateTime.Now, lm);

        ds.opretDosis(DateTime.Now, 2);
        ds.opretDosis(DateTime.Now, 1);

        Assert.AreEqual(3, ds.doegnDosis());
    }

    [TestMethod]
    public void TestSamletDosis()
    {
        var lm = new Laegemiddel("Test",1,1,1,"stk");
        var ds = new DagligSkæv(new DateTime(2024,1,1), new DateTime(2024,1,3), lm);

        ds.opretDosis(DateTime.Now, 2);
        ds.opretDosis(DateTime.Now, 1);

        // døgndosis = 3, antal dage = 3 → 3 * 3 = 9
        Assert.AreEqual(9, ds.samletDosis());
    }

    [TestMethod]
    public void TestIngenDoser()
    {
        var lm = new Laegemiddel("Test",1,1,1,"stk");
        var ds = new DagligSkæv(DateTime.Now, DateTime.Now, lm);

        Assert.AreEqual(0, ds.doegnDosis());
    }

    [TestMethod]
    public void TestOpretDosis()
    {
        var lm = new Laegemiddel("Test",1,1,1,"stk");
        var ds = new DagligSkæv(DateTime.Now, DateTime.Now, lm);

        ds.opretDosis(DateTime.Now, 5);

        Assert.AreEqual(5, ds.doegnDosis());
    }
}