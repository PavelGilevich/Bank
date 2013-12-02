using Bank;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace TestProject
{
    
    
    /// <summary>
    ///Это класс теста для TimedMaturityAccountTest, в котором должны
    ///находиться все модульные тесты TimedMaturityAccountTest
    ///</summary>
    [TestClass()]
    public class TimedMaturityAccountTest
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
            int number = 2; // TODO: инициализация подходящего значения
            string password = string.Empty; // TODO: инициализация подходящего значения
            double balance = 100; // TODO: инициализация подходящего значения
            double rate = 36; // TODO: инициализация подходящего значения
            DateTime openDate = new DateTime(2013,1,1); // TODO: инициализация подходящего значения
            double penalty_rate = 5; // TODO: инициализация подходящего значения
            int period = 1; // TODO: инициализация подходящего значения
            TimedMaturityAccount target = new TimedMaturityAccount(number, password, balance, rate, openDate, penalty_rate, period); // TODO: инициализация подходящего значения
            DateTime currentDate = new DateTime(2013,4,2); // TODO: инициализация подходящего значения
            double expected = 109.2727; // TODO: инициализация подходящего значения
            double actual;
            actual = target.CheckBalance(currentDate);
            Assert.AreEqual(expected, actual);
            //Assert.Inconclusive("Проверьте правильность этого метода теста.");
        }

        [TestMethod()]
        public void WithdrawMoneyTest()
        {
            int number = 2; // TODO: инициализация подходящего значения
            string password = string.Empty; // TODO: инициализация подходящего значения
            double balance = 100; // TODO: инициализация подходящего значения
            double rate = 36; // TODO: инициализация подходящего значения
            DateTime openDate = new DateTime(2013, 1, 1); // TODO: инициализация подходящего значения
            double penalty_rate = 10; // TODO: инициализация подходящего значения
            int period = 2; // TODO: инициализация подходящего значения
            TimedMaturityAccount target = new TimedMaturityAccount(number, password, balance, rate, openDate, penalty_rate, period); // TODO: инициализация подходящего значения
            DateTime currentDate = new DateTime(2013, 2, 10); // TODO: инициализация подходящего значения
            double expected = 45;
            double actual = target.WithdrawMoney(50, currentDate);
            Assert.AreEqual(expected, actual);
        }
    }
}
