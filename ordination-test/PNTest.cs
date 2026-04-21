namespace ordination_test;

using shared.Model;

[TestClass]
public class PNTest
{
    [TestMethod]
    public void TestGivDosisGyldig()
    {
        var lm = new Laegemiddel("Test",1,1,1,"stk");
        var pn = new PN(new DateTime(2024,1,1), new DateTime(2024,1,10), 2, lm);

        bool result = pn.givDosis(new Dato { dato = new DateTime(2024,1,5) });

        Assert.IsTrue(result);
        Assert.AreEqual(1, pn.getAntalGangeGivet());
    }

    [TestMethod]
    public void TestGivDosisUgyldig()
    {
        var lm = new Laegemiddel("Test",1,1,1,"stk");
        var pn = new PN(new DateTime(2024,1,1), new DateTime(2024,1,10), 2, lm);

        bool result = pn.givDosis(new Dato { dato = new DateTime(2023,12,31) });

        Assert.IsFalse(result);
        Assert.AreEqual(0, pn.getAntalGangeGivet());
    }

    [TestMethod]
    public void TestDoegnDosis()
    {
        var lm = new Laegemiddel("Test",1,1,1,"stk");
        var pn = new PN(new DateTime(2024,1,1), new DateTime(2024,1,10), 2, lm);

        pn.givDosis(new Dato { dato = new DateTime(2024,1,1) });
        pn.givDosis(new Dato { dato = new DateTime(2024,1,2) });

        Assert.AreEqual(2, pn.doegnDosis());
    }

    [TestMethod]
    public void TestDoegnDosisIngenDoser()
    {
        var lm = new Laegemiddel("Test",1,1,1,"stk");
        var pn = new PN(new DateTime(2024,1,1), new DateTime(2024,1,10), 2, lm);

        Assert.AreEqual(0, pn.doegnDosis());
    }

    [TestMethod]
    public void TestSamletDosis()
    {
        var lm = new Laegemiddel("Test",1,1,1,"stk");
        var pn = new PN(new DateTime(2024,1,1), new DateTime(2024,1,10), 2, lm);

        pn.givDosis(new Dato { dato = new DateTime(2024,1,1) });
        pn.givDosis(new Dato { dato = new DateTime(2024,1,2) });

        Assert.AreEqual(4, pn.samletDosis());
    }
}