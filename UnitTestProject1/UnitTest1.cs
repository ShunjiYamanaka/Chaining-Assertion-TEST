using System;
using ClassLibrary1;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            Assert.AreEqual(3, Class1.Add(1, 2));
            //例外テスト（Chaining Assertion）
            //AssertEx.Throws<InputException>(() => Class1.Add(-1, 2));

            //戻り値もとることができる
            var ex = AssertEx.Throws<InputException>(() => Class1.Add(-1, 2));
            Assert.AreEqual("マイナス値は入力できません。", ex.Message);


            //Chaining Assertionだけで場合
            Class1.Add(1, 2).Is(3);
            ex.Message.Is("マイナス値は入力できません。");
        }

        //例外テスト（InputExceptionが発生すればOK）
        [TestMethod]
        [ExpectedException(typeof(InputException))]
        public void 例外テスト()
        {
            Assert.AreEqual(3, Class1.Add(-1, 2));
        }
    }
}
