namespace Assignmment1;

[TestClass]
public class UnitTest1
{
    [TestMethod]
    public void TestIsEmpty()
    {
        Set set = new Set();
        Assert.IsTrue(set.isEmpty());
        set.insert(1);
        Assert.IsFalse(set.isEmpty());
        set.remove(1);
        Assert.IsTrue(set.isEmpty());
        for(int i =0; i<1000; i++)
        {
            set.insert(i);
        }
        Assert.IsFalse(set.isEmpty());
        for(int i =0;i<1000; i++)
        {
            set.remove(i);
        }
        Assert.IsTrue(set.isEmpty());
    }

    [TestMethod]
    public void TestInsert()
    {
        Set set = new Set();
        Assert.AreEqual(true, set.isEmpty());
        Assert.ThrowsException<Set.Empty>(() => set.largest());
        set.insert(1);
        Assert.IsFalse(set.isEmpty());
        Assert.AreEqual("[1]", set.print());
        Assert.AreEqual(1, set.largest());
        set.insert(2);
        Assert.IsFalse(set.isEmpty());
        Assert.AreEqual("[1,2]", set.print());
        Assert.AreEqual(2, set.largest());
        set.remove(1);
        Assert.IsFalse(set.isEmpty());
        Assert.AreEqual("[2]", set.print());
        Assert.AreEqual(2, set.largest());
        set.remove(2);
        Assert.IsTrue(set.isEmpty());
        Assert.AreEqual("[]", set.print());
        Assert.ThrowsException<Set.Empty>(() => set.largest());
        set.insert(5);
        Assert.IsFalse(set.isEmpty());
        Assert.AreEqual("[5]", set.print());
        Assert.AreEqual(5, set.largest());
        Assert.ThrowsException<Set.DuplicateException>(() => set.insert(5));
        set.insert(6);
        set.insert(7);
        set.insert(8);
        set.insert(9);
        Assert.ThrowsException<Set.DuplicateException>(() => set.insert(9));
        Assert.ThrowsException<Set.DuplicateException>(() => set.insert(7));
        for( int i =10; i<=1000; i++)
        {
            set.insert(i);
            Assert.AreEqual(i, set.largest()); //????
        }
        Assert.AreEqual(1000, set.largest());
        Assert.ThrowsException<Set.DuplicateException>(() => set.insert(1000));
        Assert.ThrowsException<Set.DuplicateException>(() => set.insert(500));
        Assert.ThrowsException<Set.DuplicateException>(() => set.insert(6));
    }

    [TestMethod]
    public void TestLargest()
    {
        Set set = new Set();
        /*try
        {
            set.largest();
            Assert.Fail("There should be an exception occured");
        }catch(Exception e)
        {
            Assert.IsTrue(e is Set.Empty);
        }*/
        Assert.ThrowsException<Set.Empty>(() => set.largest());
        set.insert(1);
        Assert.AreEqual(1, set.largest());
        Assert.IsFalse(set.isEmpty());
        set.insert(3);
        Assert.AreEqual(3, set.largest());
        Assert.IsFalse(set.isEmpty());
        set.insert(9);
        Assert.AreEqual(9, set.largest());
    }

    [TestMethod]
    public void TestRemove()
    {
        Set set = new Set();
        Assert.ThrowsException<Set.Empty>(() => set.remove(1));
        set.insert(1);
        set.remove(1);
        Assert.IsTrue(set.isEmpty());
        set.insert(1);
        Assert.ThrowsException<Set.IsNotInTheSet>(() => set.remove(3));
        set.insert(2);
        set.insert(3);
        set.insert(4);
        Assert.AreEqual(4, set.largest());
        set.remove(4);
        set.remove(3);
        set.insert(100);
        set.insert(3);
        set.insert(4);
        Assert.AreEqual(100, set.largest());
        for(int i =101; i<1000; i++)
        {
            set.insert(i);
            if(i == 501)
            {
                set.remove(501);
                set.insert(1001);
            }
        }
        Assert.AreEqual(1001, set.largest());
        set.insert(1002);
        Assert.AreEqual(1002, set.largest());
    }

    [TestMethod]
    public void TestContains()
    {
        Set set = new Set();
        Assert.AreEqual(false, set.contains(1));
        set.insert(1);
        Assert.IsTrue(set.contains(1));
        Assert.IsFalse(set.isEmpty());
        set.insert(2);
        Assert.IsFalse(set.contains(3));
        Assert.IsFalse(set.isEmpty());
        set.insert(3);
        set.insert(4);
        set.insert(5);
        Assert.IsTrue(set.contains(5));
        Assert.IsTrue(set.contains(3));
        for(int i =6; i<=1000; i++)
        {
            set.insert(i); 
        }
        Assert.IsTrue(set.contains(1000));
        Assert.IsTrue(set.contains(500));
        Assert.IsTrue(set.contains(1));
        Assert.IsFalse(set.contains(1001));
    }

    [TestMethod]
    public void TestRandom()
    {
        Set set = new Set();
        Assert.ThrowsException<Set.Empty>(() => set.random());
        set.insert(1);
        Assert.AreEqual(1, set.random());
        Assert.IsFalse(set.isEmpty());
        set.insert(2);
        Assert.IsTrue(set.contains(set.random()));
        Assert.IsFalse(set.isEmpty());
        set.insert(3);
        Assert.IsTrue(set.contains(set.random()));
        Assert.IsFalse(set.isEmpty());
        for(int i =4; i<1000; i++)
        {
            set.insert(i);
        }
        Assert.IsTrue(set.contains(set.random()));
    }

    [TestMethod]
    public void TestPrint()
    {
        Set set = new Set();
        Assert.AreEqual("[]", set.print());
        Assert.IsTrue(set.isEmpty());
        set.insert(1);
        Assert.AreEqual("[1]", set.print());
        Assert.IsFalse(set.isEmpty());
        set.insert(2);
        Assert.AreEqual("[1,2]", set.print());
        Assert.IsFalse(set.isEmpty());
        set.insert(3);
        Assert.AreEqual("[1,2,3]", set.print());
        Assert.IsFalse(set.isEmpty());
        set.remove(2);
        Assert.AreEqual("[1,3]", set.print());
    }
}
