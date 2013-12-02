using Bank;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace TestProject
{
    
    
    /// <summary>
    ///Это класс теста для SavingsAccountTest, в котором должны
    ///находиться все модульные тесты SavingsAccountTest
    ///</summary>
    [TestClass()]
    public class SavingsAccountTest
    {


        private TestContext testContextInstance;

        /// <summary>
        ///Получает или устанавливает контекст теста, в котором предоставляются
        ///сведения о текущем тестовом запуске и обеспечивается его функциональность.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        #region Дополнительные атрибуты теста
        // 
        //При написании тестов можно использовать следующие дополнительные атрибуты:
        //
        //ClassInitialize используется для выполнения кода до запуска первого теста в классе
        //[ClassInitialize()]
        //public static void MyClassInitialize(TestContext testContext)
        //{
        //}
        //
        //ClassCleanup используется для выполнения кода после завершения работы всех тестов в классе
        //[ClassCleanup()]
        //public static void MyClassCleanup()
        //{
        //}
        //
        //TestInitialize используется для выполнения кода перед запуском каждого теста
        //[TestInitialize()]
        //public void MyTestInitialize()
        //{
        //}
        //
        //TestCleanup используется для выполнения кода после завершения каждого теста
        //[TestCleanup()]
        //public void MyTestCleanup()
        //{
        //}
        //
        #endregion


        /// <summary>
        ///Тест для CheckBalance
        ///</summary>
        [TestMethod()]
        public void CheckBalanceTest()
        {
            SavingsAccount target = new SavingsAccount(1,"1",100,36,new DateTime(2013,1,1)); // TODO: инициализация подходящего значения
            DateTime currentDate = new DateTime(2013,3,20); // TODO: инициализация подходящего значения
            double expected = 106.09; // TODO: инициализация подходящего значения
            double actual;
            actual = target.CheckBalance(currentDate);
            Assert.AreEqual(expected, actual);
           // Assert.Inconclusive("Проверьте правильность этого метода теста.");
        }
    }
}
